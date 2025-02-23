﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using g3;





/*
 * 
 *  PLANCHECK
 * 
 *  Description:
 *  This program performs a rather extensive set of EBRT plan quailty and safety checks.
 *  
 *  This class library contains ALL of the plan checks used by the plan check script and Tiamat. Each respective program that uses Plancheck deals with getting the information required by these methods in a manner appropriate to how those programs work.
    The methods here constitute the guts and actual majority of the plan check programs. the other programs are just shells used to run in different environments.
 *  PlanCheck has a top-level Execute method which is called by the various programs that use it. Execute is passed top-level variables (like VMS.Plansetup) required for analysis from the calling programs and then parses through
 *  them to create local variables of specific information (like gantry angles) that will be used by the many plan check methods that are called by Execute.
    This organization is used so that time-intensive information gathering from plan information doesn't need to be reapeated
    All of the PlanCheck methods ar done inside Execute, and then instead of returning information to the calling program, Execute generates a standardized PDF report of the PlanCheck results that is saved to the TherpayPhysics drive displayed to the user.
    This allows the same standarized PlanCheck PDF report to be used by the PlanCheck script and Tiamat. 

    Very Important. The programs which utilize PLANCHECK work in a similiar way to the collision check script such that they take all required information from Eclipse and put them into custom classes.
    These classes are then used to pass information to PLANCHECK here, which allows the plancheck method in those programs to run on a separate thread, and allows multithreading here.
    The custom data classes are kept in a separate class library file that is part of PLANCHECK, and were taken directly from collision check.

    This program is expressely written as a plug-in script for use with Varian's Eclipse Treatment Planning System, and requires Varian's API files to run properly.
    This program runs on .NET Framework 4.6.1. 

    Copyright (C) 2022 Zackary Thomas Ricci Morelli
    
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.

    I can be contacted at: zackmorelli@gmail.com


    Release 2.0 - 1/17/2022
 * 
 * 
 * 
 * 
 */


namespace PLANCHECK
{
    public class PLANCHECK
    {
        // For the PLANCHECK SCRIPT
        public static async void PLANCHECKEXECUTE(PLAN plan)
        {
            //MessageBox.Show("TRIG 10");
            bool PCTPNparseExists = false;
            bool HIPPAConsentExists = false;
            bool TreatConsentExists = false;
            bool DocCheckSelection = await MiscPlanCheckUtilities.DocCheckStart();

            if(DocCheckSelection == true)
            {
                //Run DocCheck and PCTPNparse
                DocChecks doccheck = new DocChecks();   //Everything set to false when empty constructor method of DocCheck is called
                PCTPNparse Parse = new PCTPNparse();    //PCTPNparse's default constructor also simply makes an empty object just for initialization puproses
                PCTPNparseExists = false;
                if (plan.CreationDateTime != null)
                {
                    DateTime PlanCreationDate = Convert.ToDateTime(plan.CreationDateTime);
                    try
                    {
                        doccheck = await MiscPlanCheckUtilities.DocCheckLauncher(PlanCreationDate, plan.PatId);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Something went wrong while attempting to run the Docheck module." +
                        "\n\nPlease remember that you need access to Aria's SQL Server database with your MRN in order for Docheck to work." +
                        "\n\nVarian is the system administrator of the SQL Server database, so you must request access from them, not Lahey IT.");
                    }

                    if(doccheck.HIPAApresent == true)
                    {
                        HIPPAConsentExists = true;
                    }

                    if(doccheck.CONSENTpresent == true)
                    {
                        TreatConsentExists = true;
                    }

                    if (doccheck.PCTPNpresent == true)
                    {
                        try
                        {
                            // This object has a ton of properties filled with info from the PCTPN
                            //Parse = await FrontEndUtilities.PCTPNparseLauncher(patientId);
                            Parse = new PCTPNparse(plan.PatId);
                            PCTPNparseExists = true;
                            plan.parse = Parse;
                            //MessageBox.Show("TRIG 5");
                            //MessageBox.Show("plan.parse.Bolus: " + plan.parse.Bolus + "\n\nplan.parse.Site: " + plan.parse.Site);
                        }
                        catch (Exception e)
                        {
                            PCTPNparseExists = false;
                            MessageBox.Show("Something went wrong with PCTPNparse." +
                                "\n\n" + e.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("No PCTPN found!");
                    }
                }
                else
                {
                    MessageBox.Show("Error: The creation date of this plan is null.");
                }
            }


            // Execute various plan check methods, found below, based on calling program
            // i.e. in the future we can discriminate between PLANCHECK_SCRIPT, PLANCHECK_STANDALONE, and Tiamat to build lists of tests as appropriate
            //MessageBox.Show("TRIG 6");

            bool temp = false;
            string str = null;
            string status = null;
            List<PLANCHECKRESULTS> checklist = new List<PLANCHECKRESULTS>();

            //NEED TO ADD SETUP BEAM TO DATA COLLECTION
            //MessageBox.Show("Trig 1");
            try
            {
                if (DocCheckSelection == true)
                {
                    if(HIPPAConsentExists == true)
                    {
                        checklist.Add(new PLANCHECKRESULTS { Name = "HIPPA Consent", status = "PASS", comment = str });
                    }
                    else
                    {
                        checklist.Add(new PLANCHECKRESULTS { Name = "HIPPA Consent", status = "REVIEW", comment = "Could not locate document" });
                    }

                    if(TreatConsentExists == true)
                    {
                        checklist.Add(new PLANCHECKRESULTS { Name = "Treatment Consent", status = "PASS", comment = str });
                    }
                    else
                    {
                        checklist.Add(new PLANCHECKRESULTS { Name = "Treatment Consent", status = "REVIEW", comment = "Could not locate document"});
                    }

                    if (PCTPNparseExists == true)
                    {
                        //MessageBox.Show("plan.parse.Bolus: " + plan.parse.Bolus + "\n\nplan.parse.Site: " + plan.parse.Site);
                        //call all the PCTPN checks
                        //They need to be done here and not in a separate method because they need to be added to the checklist

                        str = DoseCheck(plan);
                        if (str.StartsWith("Prescribed"))
                        {
                            status = "PASS";
                        }
                        else if (str.StartsWith("Warning"))
                        {
                            status = "FAIL";
                        }
                        checklist.Add(new PLANCHECKRESULTS { Name = "Dose Check", status = status, comment = str });

                        str = FractionCheck(plan);
                        if (str.EndsWith("fractions"))
                        {
                            status = "PASS";
                        }
                        else if (str.StartsWith("Warning"))
                        {
                            status = "FAIL";
                        }
                        checklist.Add(new PLANCHECKRESULTS { Name = "Fraction Check", status = status, comment = str });

                        //This is in here not because it requires DocCheck and PCTPNparse, but because it requires the user to have database access
                        str = PatientLinacCheck(plan);
                        if (str == "Pass")
                        {
                            status = "PASS";
                            str = "";
                        }
                        else if (str.StartsWith("No"))
                        {
                            status = "REVIEW";
                        }
                        else if (str.StartsWith("This"))
                        {
                            status = "FAIL";
                        }
                        checklist.Add(new PLANCHECKRESULTS { Name = "Linac Appointment", status = status, comment = str });

                        str = PCTPNBolusCheck(plan);
                        if (str.Equals("The PCTPN does not indicate a bolus for this plan, and no bolus structure is present in Eclipse.") || str.Equals("A bolus structure is present in Eclipse, and the PCTPN indicates a bolus for this plan."))
                        {
                            status = "PASS";
                        }
                        else if (str.Equals("No Bolus structure is present in Eclipse, however the MD selected \"Eval based on plan\" in the PCTPN. Please verify that no bolus is needed."))
                        {
                            status = "REVIEW";
                        }
                        else if (str.Equals("The PCTPN indicates a bolus for this plan, however no bolus structure is present in Eclipse!") || str.Equals("A bolus structure is present in Eclipse, however the PCTPN has no indication of a bolus (not even \"Eval based on plan\")."))
                        {
                            status = "FAIL";
                        }
                        checklist.Add(new PLANCHECKRESULTS { Name = "PCTPN Bolus Check", status = status, comment = str });


                        str = TreatmentPositionCheck(plan);
                        if (str.Contains("NOT"))
                        {
                            status = "FAIL";
                        }
                        else
                        {
                            status = "PASS";
                        }

                        checklist.Add(new PLANCHECKRESULTS { Name = "Treatment Orientation Check", status = status, comment = str });
                    }


                }
               // MessageBox.Show("Trig 2");

                temp = ValidDoseCheck(plan);
                if (temp == true)
                {
                    status = "PASS";
                }
                else if (temp == false)
                {
                    status = "FAIL";
                }
                checklist.Add(new PLANCHECKRESULTS { Name = "Dose Validity", status = status, comment = "" });

                str = ApprovalStatusCheck(plan);
                if (str == "PlanningApproved" || str == "TreatmentApproved" || str == "Completed" || str == "CompletedEarly")
                {
                    status = "PASS";
                }
                else if (str == "Rejected" || str == "UnApproved" || str == "Retired" || str == "UnPlannedTreatment" || str == "Unknown" || str == "Reviewed")
                {
                    status = "FAIL";
                }
                checklist.Add(new PLANCHECKRESULTS { Name = "Approval Status", status = status, comment = str });

                str = BolusAssignedToBeamCheck(plan);
                if (str.StartsWith("All"))
                {
                    status = "PASS";
                }
                else if (str.StartsWith("This"))
                {
                    status = "NA";
                }
                else if (str.StartsWith("There"))
                {
                    status = "FAIL";
                }
                checklist.Add(new PLANCHECKRESULTS { Name = "Bolus assigned to beam", status = status, comment = str });

                str = LateralityCheck(plan, PCTPNparseExists);
                if (str == "Pass")
                {
                    status = "PASS";
                    str = "";
                }
                else if (str.StartsWith("No"))
                {
                    status = "NA";
                }
                else if (str.StartsWith("The") || str.StartsWith("Warning"))
                {
                    status = "FAIL";
                }
                checklist.Add(new PLANCHECKRESULTS { Name = "Laterality Check", status = status, comment = str });

                temp = MachineConstancy(plan);
                if (temp == true)
                {
                    status = "PASS";
                }
                else
                {
                    status = "FAIL";
                }
                checklist.Add(new PLANCHECKRESULTS { Name = "Linac Constancy", status = status, comment = "Checks that all beams are assigned to the same Linac" });

                temp = GantryAnglesAreIntegers(plan);
                if (temp == true)
                {
                    status = "PASS";
                }
                else
                {
                    status = "REVIEW";
                }
                checklist.Add(new PLANCHECKRESULTS { Name = "All beam start angles are integers", status = status, comment = "" });

                temp = IsoConstancy(plan);
                if (temp == true)
                {
                    status = "PASS";
                }
                else
                {
                    status = "FAIL";
                }
                checklist.Add(new PLANCHECKRESULTS { Name = "Isocenter Constancy", status = status, comment = "Checks that all beams have the same Iso" });

                str = TableCoordsExist(plan);
                if (str == "PASS")
                {
                    status = "PASS";
                    str = "";
                }
                else
                {
                    status = "FAIL";
                }
                checklist.Add(new PLANCHECKRESULTS { Name = "Couch Coordinates are valid", status = status, comment = str });

                temp = DoseRateConstancy(plan);
                if (temp == true)
                {
                    status = "PASS";
                }
                else
                {
                    status = "FAIL";
                }
                checklist.Add(new PLANCHECKRESULTS { Name = "Dose Rate Constancy", status = status, comment = "Checks that all beams have the same Dose Rate" });

                // MessageBox.Show("Trig 3");
                temp = CourseIDCheck(plan);
                if (temp == true)
                {
                    status = "PASS";
                }
                else
                {
                    status = "FAIL";
                }
                checklist.Add(new PLANCHECKRESULTS { Name = "Course ID Check", status = status, comment = "Makes sure the Course ID conforms to the naming standard" });

                // MessageBox.Show("Trig 4");

                str = FFFDoseRateChecks(plan);
                if (str == "PASS")
                {
                    status = "PASS";
                    str = "";
                }
                else if (str == "Not Applicable")
                {
                    status = "NA";
                }
                else
                {
                    status = "FAIL";
                }
                checklist.Add(new PLANCHECKRESULTS { Name = "FFF Dose Rate Checks", status = status, comment = str });

                //MessageBox.Show("Trig 5");

                try
                {
                    str = IMRTLeafMotionCalculatorEfficiency(plan);

                    // MessageBox.Show(str);
                    string token;
                    string LMCperdiff;
                    using (StringReader reader = new StringReader(str))
                    {
                        while ((token = reader.ReadLine()) != null)
                        {
                            if (token == "NA")
                            {
                                status = "NA";
                                // make a Not Applicable category in the PDF
                            }
                            else
                            {
                                // MessageBox.Show("token test:  " + token.Substring(token.IndexOf(":") + 1));
                                LMCperdiff = token.Substring(token.IndexOf(":") + 1);
                                //LMCperdiff.TrimEnd('%');
                                //MessageBox.Show("LMCperfdiff: " + LMCperdiff);
                                if (Convert.ToDouble(LMCperdiff) < 2.0 & Convert.ToDouble(LMCperdiff) > -2.0)
                                {
                                    status = "PASS";
                                }
                                else
                                {
                                    status = "FAIL";
                                    break;
                                }
                            }
                        }
                    }

                    if (status == "FAIL")
                    {
                        //str.Replace("*", ": ");
                        str = "One or more beams have a large difference between the expected MU and the MU calculated by the Leaf Motion Calculator. The percent differnce for each beam is listed below. Most likely the leaf motion calculator needs to be rerun.\n" + str;
                    }
                    else if (status == "PASS")
                    {
                        //str.Replace("*", ": ");
                        str = "The percent difference between the expected MU and the MU calculated by the Leaf Motion Calculator for each beam is listed below. All values are within 2%.\n" + str;
                    }
                    else if (status == "NA")
                    {
                        str = "No LMC logs, Not Applicable.";
                    }
                TB:
                    checklist.Add(new PLANCHECKRESULTS { Name = "IMRT Leaf Motion Calculator Efficiency", status = status, comment = str });
                }
                catch (Exception e)
                {
                    MessageBox.Show("Leaf motion calculator problem" + "\n\n" + e.Message + "\n\n" + e.Source + "\n\n" + e.StackTrace + "\n\n" + e.ToString());
                }

                //MessageBox.Show("Trig 6");

                temp = TechniqueConstancy(plan);
                if (temp == true)
                {
                    status = "PASS";
                    str = "";
                }
                else if (temp == false)
                {
                    status = "FAIL";
                    str = "The beams in this plan have different Techniques!";
                }
                checklist.Add(new PLANCHECKRESULTS { Name = "Technique Constancy", status = status, comment = str });

                temp = EnergyConstancy(plan);
                if (temp == true)
                {
                    status = "PASS";
                    str = "";
                }
                else if (temp == false)
                {
                    status = "FAIL";
                    str = "The beams in this plan have different Energy Modes!";
                }
                checklist.Add(new PLANCHECKRESULTS { Name = "Energy Constancy", status = status, comment = str });

                str = AllPatientStructuresInsideBodyContour(plan);
                if (str == "PASS")
                {
                    status = "PASS";
                    str = "";
                }
                else if (str.StartsWith("The"))
                {
                    status = "REVIEW";
                }
                checklist.Add(new PLANCHECKRESULTS { Name = "All patient structures inside body contour", status = status, comment = str });

                // MessageBox.Show("Trig 7");

                str = DoseCalcGridSize(plan);
                //MessageBox.Show("Dose calc grid str: " + str);
                if (str.EndsWith("FAIL"))
                {
                    status = "FAIL";
                    //str = str.Substring(0, 4);
                }
                else if(str.StartsWith("Mismatch") || str.StartsWith("Invalid"))
                {
                    status = "REVIEW";
                }
                else if (str.EndsWith("PASS"))
                {
                    status = "PASS";
                    //str = str.Substring(0, 4);
                }
                checklist.Add(new PLANCHECKRESULTS { Name = "Dose Calculation Grid size", status = status, comment = str });

                str = DoseCalcAlgorithim(plan);
                if (str.StartsWith("This"))
                {
                    status = "FAIL";
                }
                else
                {
                    status = "INF";
                }
                checklist.Add(new PLANCHECKRESULTS { Name = "Dose Calculation Algorithm", status = status, comment = str });

                //MessageBox.Show("Trig 8");

                str = MaxSlicesinTPCT(plan);
                if (str.StartsWith("Invalid"))
                {
                    status = "REVIEW";
                }
                else if (Convert.ToDouble(str) > 399)
                {
                    status = "FAIL";
                    str = "The TPCT is over 399 slices long. Number of Slices: " + str;
                }

                else
                {
                    status = "PASS";
                    str = (str + " slices in TPCT.");
                }

                checklist.Add(new PLANCHECKRESULTS { Name = "Number of slices in TPCT", status = status, comment = str });

                //MessageBox.Show("Trig 9");

                str = MinFieldSizeforEDWBeams(plan);
                if (str.StartsWith("No"))
                {
                    status = "NA";
                }
                else if (str.StartsWith("All") || str.StartsWith("Some"))
                {
                    status = "PASS";
                }
                else if (str.StartsWith("The"))
                {
                    status = "FAIL";
                }
                checklist.Add(new PLANCHECKRESULTS { Name = "Minimum Field Size for EDW Beams", status = status, comment = str });

                //MessageBox.Show("Trig 10");
                str = MinMUEDWBeam(plan);
                if (str.StartsWith("No"))
                {
                    status = "NA";
                }
                else if (str.StartsWith("All") || str.StartsWith("Some"))
                {
                    status = "PASS";
                }
                else if (str.StartsWith("The"))
                {
                    status = "FAIL";
                }
                checklist.Add(new PLANCHECKRESULTS { Name = "Minimum MU for EDW Beams", status = status, comment = str });

                //MessageBox.Show("Trig 11");
                str = MinMUperDegArc(plan);
                status = "INF";
                checklist.Add(new PLANCHECKRESULTS { Name = "Minimum MU per Degree for Arc Beams", status = status, comment = str });

                //MessageBox.Show("Trig 12");
                try
                {
                    str = MinMUforStaticFiF(plan);
                    if (str.StartsWith("No"))
                    {
                        status = "NA";
                    }
                    else if (str.StartsWith("These"))
                    {
                        status = "PASS";
                    }
                    else if (str.StartsWith("At"))
                    {
                        status = "FAIL";
                    }
                    checklist.Add(new PLANCHECKRESULTS { Name = "Minimum MU for Static Beams", status = status, comment = str });
                }
                catch (Exception e)
                {
                    MessageBox.Show("Minimum MU for static beams problem" + "\n\n" + e.Message + "\n\n" + e.Source + "\n\n" + e.StackTrace + "\n\n" + e.ToString());
                }

                //MessageBox.Show("Trig 13");
                str = MinXandYJawSettingsacrossallbeams(plan);
                status = "INF";
                checklist.Add(new PLANCHECKRESULTS { Name = "Minimum Field Sizes", status = status, comment = str });

                //str = StructureCheck(plan);
                //if (str == "PASS")
                //{
                //    status = "PASS";
                //    str = "";
                //}
                //else if (str.StartsWith("The"))
                //{
                //    status = "FAIL";
                //}
                //checklist.Add(new PLANCHECKRESULTS { Name = "General Structure Check", status = "REVIEW", comment = str });

                //MessageBox.Show("Tests Done");

                // After all tests are done, pass plancheckresults list to a thing to make a pdf report
                ReportData reportdata = new ReportData();
                reportdata.ApprovalStatus = plan.ApprovalStatus;
                reportdata.CourseId = plan.courseId;
                reportdata.CreationDateTime = plan.CreationDateTime;
                reportdata.CreationUser = plan.CreationUser;
                reportdata.UserName = plan.UserName;
                reportdata.DocName = plan.DocName;
                reportdata.LastModifiedDateTime = plan.LastModifiedDateTime;
                reportdata.LastModifiedUser = plan.LastModifiedUser;
                reportdata.PatDOB = plan.PatDOB;
                reportdata.PatFirstName = plan.PatFirstName;
                reportdata.PatLastName = plan.PatLastName;
                reportdata.PatSex = plan.patientsex;
                reportdata.PatHospitalName = plan.HospitalName;
                reportdata.PatHospitalAddress = plan.PatHospitalAddress;
                reportdata.PatId = plan.PatId;
                reportdata.PlanId = plan.planId;
                reportdata.CheckResults = checklist;

                // Want to actually make a place to store all these reports
                // Lahey Path  P:\LCN Scans\Script_Reports\Plan_Check_Reports
                string path = @"\\ntfs16\TherapyPhysics\LCN Scans\Script_Reports\Plan_Check_Reports\Plan_Check_Report_" + plan.PatId + "_" + plan.courseId + "_" + plan.planId + ".pdf"; // Lahey
                // string path = @"\\wvvrnimbp01ss\va_data$\filedata\ProgramData\Vision\Plan_Check_Report_" + plan.PatId + "_" + plan.courseId + "_" + plan.planId + ".pdf"; 
                string pathtemp = Path.GetTempFileName() + ".pdf";
                // PDFReport is not a static class, we must make a PDFReport object so we can call it's Export method in order to make a PDF
                PDFReport.PDFReport reportservice = new PDFReport.PDFReport();
                reportservice.Export(path, reportdata);

                Process.Start(path);

                // MessageBox.Show(path);
                //File.Create(path);
                //File.Copy(pathtemp, path);
                //MessageBox.Show("FIN");
                //Once checks are done, create PDF output report. Based on Dose Objective Check PDF.
            }
            catch (Exception e)
            {
                MessageBox.Show("problem in plancheck execute.\n\n" + e.ToString() + "\n\n" + e.Message + "\n\n" + e.StackTrace);
            }
        }
        //==============================================================PLAN CHECK METHODS BELOW=========================================================================================================

        // probably will never use this, just an easy thing to make as a test
        //public static bool MRNCheck(string EclipseMRN)
        //{
        //    bool B = false;
        //    string ARIAMRN = null;

        //    using (var aria = new ARIA())
        //    {
        //        var patients = aria.Patients.Where(p => p.PatientId.Equals(EclipseMRN)).ToList();

        //        ARIAMRN = patients.First().PatientId;

        //        if (ARIAMRN == EclipseMRN)
        //        {
        //            B = true;
        //        }
        //        else
        //        {
        //            MessageBox.Show("The MRN of this patient in Eclipse does not match their MRN in the Aria datbase!");
        //        }
        //    }

        //    return B;
        //}


        //this works
        public static string LateralityCheck(PLAN plan, bool PCTPNparseExists)
        {
            string B = "false";
            // do this if the plan Id has a "R" or "L" in it. 
            //Rectified to reflect coordinate system
            try
            {
                string lat = null;
                string actlat = "init"; 
                if (PCTPNparseExists == true)
                {
                    string PCTPNLaterality = null;
                    if (plan.parse.Site.Contains("Left") || plan.parse.Site.Contains("left"))
                    {
                        PCTPNLaterality = "Left";
                    }
                    else if (plan.parse.Site.Contains("Right") || plan.parse.Site.Contains("right"))
                    {
                        PCTPNLaterality = "Right";
                    }
                    else
                    {
                        // The MD could write something like "Bilateral", but we can't test it if it isn't explicitly left or right
                        PCTPNLaterality = "NA";
                    }

                    if (plan.Laterality != PCTPNLaterality)
                    {
                        B = "Warning: mismatch between laterality on PCTPN and selected laterality.";
                        return B;
                    }

                    lat = PCTPNLaterality;
                    actlat = "init";
                }
                else if(PCTPNparseExists == false)
                {
                    lat = plan.Laterality;
                }

                if (lat != "NA")
                {
                    Vector3d bodycenter = new Vector3d();
                    Vector3d targetcenter = new Vector3d();

                    try
                    {
                        foreach (STRUCTURE str in plan.StructureSet)
                        {
                            // MessageBox.Show("DicomType: " + str.DicomType);
                            if (str.name.Equals("Body") || str.DicomType.Equals("EXTERNAL"))
                            {
                                bodycenter = str.CenterPoint;
                            }
                            else if (str.name.Contains("_CTV") || str.name.Contains("_PTV") || str.name.Contains("_GTV") || str.DicomType.Equals("CTV") || str.DicomType.Equals("PTV") || str.DicomType.Equals("GTV"))
                            {
                                targetcenter = str.CenterPoint;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Laterality Check Structure loop Error!\n\n" + e.ToString());
                    }

                    //MessageBox.Show("Orientation: " + plan.TreatmentOrientation);
                    // MessageBox.Show("TargteCenter: " + targetcent);
                    if (plan.TreatmentOrientation == "HeadFirstSupine" || plan.TreatmentOrientation == "FeetFirstSupine")
                    {
                        //MessageBox.Show("TargteCenter: " + targetcent);
                        //MessageBox.Show("BodyCenter: " + bodycent);

                        if (targetcenter.x < bodycenter.x)
                        {
                            actlat = "Right";
                        }
                        else if (targetcenter.x > bodycenter.x)
                        {
                            actlat = "Left";
                        }
                    }
                    else if (plan.TreatmentOrientation == "HeadFirstProne" | plan.TreatmentOrientation == "FeetFirstProne")
                    {
                        //Because the DICOM coordinate system is based on the patient, if the patient orientation is flipped, so is the coordinate system.
                        //Of course the patient's "Left" and "Right" are flipped to, so this double negative effect cancels out and we are left with the same thing
                        if (targetcenter.x < bodycenter.x)
                        {
                            actlat = "Right";
                        }
                        else if (targetcenter.x > bodycenter.x)
                        {
                            actlat = "Left";
                        }
                    }

                    if (actlat == lat)
                    {
                        B = "Pass";
                        return B;
                    }
                    else
                    {
                        B = "The laterality of plan " + plan.planId + " was chosen as " + lat + " but, relative to the patient, the target is on the " + actlat + " of the body.";
                        return B;
                    }
                }
                else
                {
                    B = "No Laterality";
                    return B;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Problem in laterality Check." +
                    e.ToString() + "\n\n" + e.StackTrace);
            }
            return B;
        }

        // this works (might be some weird appointment situations where it gets messed up)
        public static string PatientLinacCheck(PLAN Plan)
        {
            string B = "false";
            string EclipseLinac;
            EclipseLinac = Plan.Beams.First().Linac;
            string dblinac = "";
            long PatSer = 0;
            List<long> ACTL = new List<long>();

            try
            {
                string ConnectionString = @"Data Source=WVARIASDBP01SS;Initial Catalog=VARIAN;Integrated Security=true;";
                SqlConnection conn = new SqlConnection(ConnectionString);
                SqlCommand command;
                SqlDataReader datareader;
                string sql;

                // MessageBox.Show("Trig0");

                conn.Open();
                sql = "USE VARIAN SELECT PatientSer FROM dbo.Patient WHERE PatientId = '" + Plan.PatId + "'";
                command = new SqlCommand(sql, conn);
                datareader = command.ExecuteReader();

                while (datareader.Read())
                {
                    PatSer = Convert.ToInt64(datareader["PatientSer"]);
                }
                conn.Close();

                //MessageBox.Show("Trig1");

                DateTime RN = DateTime.Now;
                string SQLRN = RN.ToString("MM/dd/yyyy");

                conn.Open();
                sql = "USE VARIAN SELECT ScheduledActivitySer FROM dbo.ScheduledActivity WHERE PatientSer = " + PatSer + " AND ScheduledStartTime > '" + SQLRN + "'";
                command = new SqlCommand(sql, conn);
                datareader = command.ExecuteReader();

                while (datareader.Read())
                {
                    ACTL.Add((long)datareader["ScheduledActivitySer"]);
                }
                conn.Close();

                // MessageBox.Show("Trig2");

                foreach (long act in ACTL)
                {
                    conn.Open();
                    sql = "USE VARIAN SELECT ResourceSer FROM dbo.ResourceActivity WHERE ScheduledActivitySer = " + act;
                    command = new SqlCommand(sql, conn);
                    datareader = command.ExecuteReader();
                    // will only ever output one row of information

                    if (datareader.Read())
                    {
                        if ((long)datareader["ResourceSer"] == 1319)
                        {
                            dblinac = "Novalis_TX";
                            // if (Plan.PlanType != VMS.TPS.Common.Model.Types.PlanType.Brachy)
                            // {
                            break;
                            // }
                        }
                        else if ((long)datareader["ResourceSer"] == 1027)
                        {
                            dblinac = "Varian 21EX";
                            //  if (Plan.PlanType != VMS.TPS.Common.Model.Types.PlanType.Brachy)
                            // {
                            break;
                            // }
                        }
                        else if ((long)datareader["ResourceSer"] == 2151)
                        {
                            dblinac = "TrueBeam1";
                            // if (Plan.PlanType != VMS.TPS.Common.Model.Types.PlanType.Brachy)
                            // {
                            break;
                            // }
                        }
                        else if ((long)datareader["ResourceSer"] == 1347)
                        {
                            dblinac = "Silhouette";
                            //  if (Plan.PlanType != VMS.TPS.Common.Model.Types.PlanType.Brachy)
                            //  {
                            break;
                            //}
                        }
                        else if ((long)datareader["ResourceSer"] == 1994)
                        {
                            dblinac = "GMed Burlington";
                            //  if (Plan.PlanType == VMS.TPS.Common.Model.Types.PlanType.Brachy)
                            // {
                            break;
                            // }
                        }
                        else if ((long)datareader["ResourceSer"] == 2004)
                        {
                            dblinac = "GMed Peabody";
                            // if (Plan.PlanType == VMS.TPS.Common.Model.Types.PlanType.Brachy)
                            // {
                            break;
                            // }
                        }
                    }
                    conn.Close();
                }

                // MessageBox.Show("Eclipse Linac: " + EclipseLinac);
                //  MessageBox.Show("DB Linac: " + dblinac);

                if (dblinac == EclipseLinac)
                {
                    B = "Pass";
                }
                else if (dblinac == "")
                {
                    //no future appointment found
                    B = "No future appointments on any of the treatment machines have been found for this patient.";
                }
                else
                {
                    B = "This plan " + Plan.planId + " is not made for the machine that the patient " + Plan.PatId + " is scheduled on! This patient is scheduled on the: " + dblinac;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ToString: " + e.ToString() + " message: " + e.Message + " Source: " + e.Source + " Stack: " + e.StackTrace);
            }

            return B;
        }

        public static string PCTPNBolusCheck(PLAN plan)
        {
            string B = null;
            bool PCTPNbolusexists = false;
            if(plan.parse.Bolus == "0.5 cm" || plan.parse.Bolus == "1 cm" || plan.parse.Bolus == "Custom" || plan.parse.Bolus == "3D Printed" || plan.parse.Bolus == "Eval based on plan" || plan.parse.Bolus == "Other")
            {
                //so we assume the MD means for there to be some kind of bolus in ths plan
                PCTPNbolusexists = true;
            }
            bool Eclipsebolusexists = plan.StructureSet.Any(S => (S.DicomType == "BOLUS" || S.name.Contains("bolus") || S.name.Contains("Bolus") || S.name.Contains("BOLUS")));

            if(Eclipsebolusexists == false)
            {
                if(PCTPNbolusexists == false)
                {
                    B = "The PCTPN does not indicate a bolus for this plan, and no bolus structure is present in Eclipse.";
                }
                else if(PCTPNbolusexists == true)
                {
                    if(plan.parse.Bolus == "Eval based on plan")
                    {
                        B = "No Bolus structure is present in Eclipse, however the MD selected \"Eval based on plan\" in the PCTPN. Please verify that no bolus is needed.";
                    }
                    else
                    {
                        B = "The PCTPN indicates a bolus for this plan, however no bolus structure is present in Eclipse!";
                    }
                }
            }
            else if (Eclipsebolusexists == true)
            {
                if(PCTPNbolusexists == false)
                {
                    B = "A bolus structure is present in Eclipse, however the PCTPN has no indication of a bolus (not even \"Eval based on plan\").";
                }
                else if(PCTPNbolusexists == true)
                {
                    B = "A bolus structure is present in Eclipse, and the PCTPN indicates a bolus for this plan.";
                }
            }
            return B;
        }

        // this works
        public static string BolusAssignedToBeamCheck(PLAN plan)
        {
            List<bool> boluslist = new List<bool>();
            string B = "";
            try
            {
                bool bolusexist = false;
                bool bolusmatch = false;
                foreach (STRUCTURE str in plan.StructureSet)
                {
                    bolusmatch = false;
                    if (str.DicomType == "BOLUS" || str.name.Contains("bolus") || str.name.Contains("Bolus") || str.name.Contains("BOLUS"))
                    {
                        bolusexist = true;
                        foreach (BEAM b in plan.Beams)
                        {
                            if (b.BolusId == str.name)
                            {
                                bolusmatch = true;
                            }
                        }

                        if (bolusmatch == false)
                        {
                            boluslist.Add(false);
                        }
                        else
                        {
                            boluslist.Add(true);
                        }
                    }
                }

                if(bolusexist == false)
                {
                    //no boluses found
                    B = "This plan has no boluses.";
                }
                else
                {
                    if(boluslist.Any(bl => bl.Equals(false)))
                    {
                        B = "There is at least one bolus structure in this plan which is not assigned to a beam.";
                    }
                    else
                    {
                        B = "All bolus structures are assigned to a beam.";
                    }
                }
            }
            catch(Exception e )
            {
                MessageBox.Show("Problem in Bolus Check." + e.ToString() + "\n\n" + e.StackTrace);
            }
            return B;
        }

        //checks that all beams have the same Iso
        public static bool IsoConstancy(PLAN plan)
        {
            bool B = true;
            Vector3d isof = plan.Beams.First().Isocenter;
            foreach (BEAM be in plan.Beams)
            {
                if (be.Isocenter != isof)
                {
                    B = false;
                    return B;
                }
            }
            return B;
        }

        //Makes sure table coords are not zero (for each beam)
        public static string TableCoordsExist(PLAN plan)
        {
            string BR = null;
            List<string> Blist = new List<string>();
            bool lo = false;
            bool la = false;
            bool ver = false;

            double longitudinal = plan.Beams.First().CouchLongitudinal;
            double lateral = plan.Beams.First().CouchLateral;
            double Vertical = plan.Beams.First().CouchVertical;

            foreach (BEAM be in plan.Beams)
            {
                string B = "PASS";
                lo = false;
                la = false;
                ver = false;
                // So in the database/backend the couch positions are apparently in an absolute scale. DB is actually in cm, but value returned from ESAPI is in mm.
                //need to test this vs. prone and supine
                //MessageBox.Show("Couch Long: " + be.CouchLongitudinal);
                //MessageBox.Show("Couch Lat: " + be.CouchLateral);
                //MessageBox.Show("Couch Vert: " + be.CouchVertical);

                if (be.CouchLongitudinal > 200.0 & be.CouchLongitudinal < 1600.0)
                {
                    lo = true;
                }

                if (be.CouchLateral < 180.0 & be.CouchLateral > -180.0)
                {
                    la = true;
                }

                if (be.CouchVertical > -700.0 & be.CouchVertical < 300.0)
                {
                    ver = true;
                }

                if (lo == false)
                {
                    B = "Longitudinal Couch position is not valid for beam " + be.beamId;
                }

                if (la == false)
                {
                    B = "Lateral Couch position is not valid for beam " + be.beamId;
                }

                if (ver == false)
                {
                    B = "Vertical Couch position is not valid for beam " + be.beamId;
                }

                if (lo == false & la == false)
                {
                    B = "Longitudinal and Lateral Couch positions are not valid for beam " + be.beamId;
                }

                if (lo == false & ver == false)
                {
                    B = "Longitudinal and Vertical Couch positions are not valid for beam " + be.beamId;
                }

                if (la == false & ver == false)
                {
                    B = "Lateral and Vertical Couch positions are not valid for beam " + be.beamId;
                }

                if (lo == false & la == false & ver == false)
                {
                    B = "Longitudinal and Lateral and Vertical Couch positions are not valid for beam " + be.beamId;
                }

                Blist.Add(B);
            }

            if (Blist.All(tr => tr.Equals("PASS")) == true)
            {
                BR = "PASS";
            }
            else
            {
                foreach (string bstr in Blist)
                {
                    if (bstr != "PASS")
                    {
                        BR = BR + bstr + ". ";
                    }
                }
            }

            return BR;
        }

        //make sure reference point does NOT have a location (locationless point used for Dose tracking)
        public static bool ReferencePointHasNoLocation(PLAN plan)
        {
            bool B = false;


            return B;
        }

        //Structure overide alert. This is a little nuanced. This is not neccessarily wrong, just alerting the user that the HU of a structure has been overridden, ask them to confirm.
        public static string HUOverride(PLAN plan)
        {
            string B = "PASS";


            return B;
        }

        //Ensure all beams have same Linac assigned
        public static bool MachineConstancy(PLAN plan)
        {
            bool B = true;

            string linacf = plan.Beams.First().Linac;

            foreach (BEAM be in plan.Beams)
            {
                if (be.Linac != linacf)
                {
                    B = false;
                    return B;
                }
            }
            return B;
        }

        //All beams have same dose rate
        public static bool DoseRateConstancy(PLAN plan)
        {
            bool B = true;
            int DRF = plan.Beams.First().DoseRate;
            foreach (BEAM be in plan.Beams)
            {
                if (be.DoseRate != DRF)
                {
                    B = false;
                    return B;
                }
            }
            return B;
        }

        public static bool ValidDoseCheck(PLAN plan)
        {
            bool B = false;
            if (plan.ValidDose == true)
            {
                B = true;
            }
            else
            {
                B = false;
            }

            return B;
        }

        public static string TreatmentPositionCheck(PLAN plan)
        {
            string B = null;
            if (plan.parse.TreatmentPosition == "Supine")
            {
                if(plan.TreatmentOrientation.Contains("Supine"))
                {
                    B = "The treatment orientation in Eclipse and the PCTPN match (Supine).";
                }
                else
                {
                    B = "The treatment orientation in Eclipse and the PCTPN do NOT match!";
                }
            }
            else if (plan.parse.TreatmentPosition == "Prone")
            {
                if (plan.TreatmentOrientation.Contains("Prone"))
                {
                    B = "The treatment orientation in Eclipse and the PCTPN match (Prone).";
                }
                else
                {
                    B = "The treatment orientation in Eclipse and the PCTPN do NOT match!";
                }
            }

            return B;
        }

        public static string FractionCheck(PLAN plan)
        {
            string B = null;
            if (plan.Fracs == Convert.ToInt32(plan.parse.Fractions) )
            {
                B = plan.Fracs + " fractions";
            }
            else
            {
                B = "Warning: The number of treatment fractions is different than what is written on the PCTPN.";
            }

            return B;
        }

        public static string ApprovalStatusCheck(PLAN plan)
        {
            string B = plan.ApprovalStatus;
            return B;
        }

        public static string DoseCheck(PLAN plan)
        {
            string B = null;
            if(plan.RXdose != Convert.ToDouble(plan.parse.TotalDose))
            {
                B = "Warning: THE PRESCRIBED DOSE OF THIS PLAN DOSE NOT MATCH THE DOSE WRITTEN IN THE PCTPN.";
            }
            else
            {
                B = "Prescribed dose matches PCTPN dose";
            }
            return B;
        }

        public static bool TechniqueConstancy(PLAN plan)
        {
            bool B = true;
            string Te = plan.Beams.First().Technique;
            foreach (BEAM be in plan.Beams)
            {
                if (be.Technique != Te)
                {
                    B = false;
                    return B;
                }
            }
            return B;
        }

        public static bool EnergyConstancy(PLAN plan)
        {
            bool B = true;
            string Te = plan.Beams.First().EnergyMode;
            foreach (BEAM be in plan.Beams)
            {
                if (be.EnergyMode != Te)
                {
                    B = false;
                    return B;
                }
            }
            return B;
        }


        // this checks the dose rates for the FFF beams on the Truebeam, since they are always the same
        public static string FFFDoseRateChecks(PLAN plan)
        {
            string B = "FAIL";
            List<string> results = new List<string>();

            foreach(BEAM beam in plan.Beams)
            {
                //MessageBox.Show(beam.EnergyMode);
                if(beam.EnergyMode == "10X-FFF")
                {
                    if(beam.DoseRate == 2400)
                    {
                        results.Add("PASS");
                    }
                    else
                    {
                        results.Add("Beam " + beam.beamId + " is a 10X-FFF beam and should have a dose rate of 2400 MU/sec.");
                    }
                }
                else if (beam.EnergyMode == "6X-FFF")
                {
                    if (beam.DoseRate == 1400)
                    {
                        results.Add("PASS");
                    }
                    else
                    {
                        results.Add("Beam " + beam.beamId + " is a 6X-FFF beam and should have a dose rate of 1400 MU/sec.");
                    }
                }
                else
                {
                    results.Add("NA");
                }
            }

            if(results.All(str => str.Equals("NA")))
            {
                B = "Not Applicable";
            }
            else if(results.All(str => str.Equals("PASS")))
            {
                B = "PASS";
            }
            else
            {
                B = null;
                foreach(string T in results)
                {
                    if(T.StartsWith("Beam"))
                    {
                        if(B == null)
                        {
                            B = T;
                        }
                        else
                        {
                            B = B + "\n" + T;
                        }
                    }
                }
            }

            return B;
        }

        public static string IMRTLeafMotionCalculatorEfficiency(PLAN plan)
        {
            string B = null;
            //if (plan.Beams.First().Linac == "TrueBeam1" || plan.Beams.First().Linac == "TrueBeam" || plan.Beams.First().Linac == "truebeam")
            //{
            //    B = "Does not apply to Trubeam plans";
            //    return B;
            //}

            List<string> beamstats = new List<string>();
            // this test only applies to Non-VMAT IMRT plans
            // need to parse through beam calculation logs in order to get required information
            double LMCMUpercentdiff = -1.0;

            foreach (BEAM beam in plan.Beams)
            {
                // MessageBox.Show(beam.Technique + " - " + beam.MLCtype);
                if (beam.LMCinfo.LMClog == true)
                {
                    if (beam.LMCinfo.MaxMUcr2 == -1.0 & beam.LMCinfo.MaxMUcr3 == -1.0)
                    {
                        //MessageBox.Show("MAX MU CR 1: " + beam.LMCinfo.MaxMUcr1);
                        //MessageBox.Show("MAX Lost MU CR 1: " + beam.LMCinfo.LostMUfactorCR1);

                        // No large field, only carriage 1
                        double LMCexpectedMU = beam.LMCinfo.MaxMUcr1 * beam.LMCinfo.LostMUfactorCR1;
                        LMCMUpercentdiff = ((beam.LMCinfo.ActualMU - LMCexpectedMU) / beam.LMCinfo.ActualMU) * 100.0;
                        // MessageBox.Show("MAX Expected MU CR 1: " + LMCexpectedMU);
                        //MessageBox.Show("MAX Actual MU CR 1: " + beam.LMCinfo.ActualMU);
                    }
                    else if (beam.LMCinfo.MaxMUcr3 == -1.0 & beam.LMCinfo.MaxMUcr2 != -1.0)
                    {
                        // Large-field IMRT. calculated MU of Carriage 1 and 2 need to be summed to get total MU
                        double LMCexpectedMU1 = beam.LMCinfo.MaxMUcr1 * beam.LMCinfo.LostMUfactorCR1;
                        double LMCexpectedMU2 = beam.LMCinfo.MaxMUcr2 * beam.LMCinfo.LostMUfactorCR2;
                        double totalexpectedMU = LMCexpectedMU1 + LMCexpectedMU2;
                        LMCMUpercentdiff = ((beam.LMCinfo.ActualMU - totalexpectedMU) / beam.LMCinfo.ActualMU) * 100.0;

                        //MessageBox.Show("Beam Id: " + beam.beamId);
                        //MessageBox.Show("MAX MU CR 1: " + beam.LMCinfo.MaxMUcr1);
                        //MessageBox.Show("Lost MU factor CR 1: " + beam.LMCinfo.LostMUfactorCR1);
                        //MessageBox.Show("Expected MU CR 1: " + LMCexpectedMU1);
                        //MessageBox.Show("MAX MU CR 2: " + beam.LMCinfo.MaxMUcr2);
                        //MessageBox.Show("Lost MU factor CR 2: " + beam.LMCinfo.LostMUfactorCR2);
                        //MessageBox.Show("Total Expected MU: " + totalexpectedMU);
                        //MessageBox.Show("Actual MU: " + beam.LMCinfo.ActualMU);
                        //MessageBox.Show("Percent Difference: " + LMCMUpercentdiff);
                    }
                    else if (beam.LMCinfo.MaxMUcr3 != -1.0)
                    {
                        double LMCexpectedMU1 = beam.LMCinfo.MaxMUcr1 * beam.LMCinfo.LostMUfactorCR1;
                        double LMCexpectedMU2 = beam.LMCinfo.MaxMUcr2 * beam.LMCinfo.LostMUfactorCR2;
                        double LMCexpectedMU3 = beam.LMCinfo.MaxMUcr3 * beam.LMCinfo.LostMUfactorCR3;
                        double totalexpectedMU = LMCexpectedMU1 + LMCexpectedMU2 + LMCexpectedMU3;
                        LMCMUpercentdiff = ((beam.LMCinfo.ActualMU - totalexpectedMU) / beam.LMCinfo.ActualMU) * 100.0;
                    }

                    beamstats.Add(beam.beamId + ": " + Math.Round(LMCMUpercentdiff, 2, MidpointRounding.AwayFromZero));
                }
                else
                {
                    // no LMC calculation logs present, so probably not an IMRT plan, Test not applicable
                    beamstats.Add("NA");
                }
            }
                
            foreach(string tr in beamstats)
            {
                B = B + tr + "\n";
            }
            
            return B;
        }

        public static string AllPatientStructuresInsideBodyContour(PLAN plan)
        {
            string B = "PASS";
            List<string> badstructs = new List<string>();
            STRUCTURE Body = plan.StructureSet.Find(S => S.name.Equals("Body") || S.DicomType.Equals("EXTERNAL"));

           // MessageBox.Show("Before Body close.");
           // IOWriteResult result56 = StandardMeshWriter.WriteFile(@"C:\Users\ztm00\Desktop\STL Files\PlanCheck\Body.stl", new List<WriteMesh>() { new WriteMesh(Body.Mesh) }, WriteOptions.Defaults);

            if (Body.Mesh.IsClosed() == false)
            {
                try
                {
                    gs.MeshAutoRepair repair = new gs.MeshAutoRepair(Body.Mesh);
                    repair.RemoveMode = gs.MeshAutoRepair.RemoveModes.None;
                    repair.Apply();

                  //  IOWriteResult result55 = StandardMeshWriter.WriteFile(@"C:\Users\ztm00\Desktop\STL Files\PlanCheck\BodyClosed.stl", new List<WriteMesh>() { new WriteMesh(Body.Mesh) }, WriteOptions.Defaults);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

           // MessageBox.Show("After Body close.");
            DMeshAABBTree3 spatialBody = new DMeshAABBTree3(Body.Mesh);
            spatialBody.Build();
            bool isinside = true;

           // MessageBox.Show("Inside body contour check begin");
            try
            {
                foreach (STRUCTURE str in plan.StructureSet.Where(S => S.DicomType.Equals("ORGAN") || S.DicomType.Equals("CTV") || S.DicomType.Equals("PTV") || S.DicomType.Equals("GTV") || S.DicomType.Equals("CAVITY")))
                {
                    if(str.name.Contains("Skin") || str.name.Contains("skin") || str.name.StartsWith("Ext") || str.name.StartsWith("ext"))
                    {
                        continue;
                    }
                    isinside = true;
                    foreach (Vector3d vp in str.Mesh.Vertices())
                    {
                        isinside = spatialBody.IsInside(vp);
                        if (isinside == false)
                        {
                            break;
                        }
                    }

                    if (isinside == false)
                    {
                        badstructs.Add(str.name);
                    }
                }

                if (badstructs.Count > 0)
                {
                    B = "The following anatomical patient structures are not fully within the Body structure. This could mean the structure has stray pixels that are contoured outside the body, or part of the structure is simply protruding out of the Body structure.\n\n";
                    foreach (string r in badstructs)
                    {
                        B = B + r + "\n";
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("inside body loop issue.\n\n" + e.ToString());
            }

            //MessageBox.Show("Inside body contour check done");
            return B;
        }

        public static string StructureCheck(PLAN plan)
        {
            // This test requires some explanation. This is a generalized test meant to check a number of things at once using a topological concept known as the Euler-Poincare characteristic.
            // The Euler-Poincare characteristic is an integer calculated using Euler's Polyhedron Formula, which was stated by Euler in 1758.
            // Euler's Polyhedron Formula is X = V - E + F, where X (actually the Greek letter chi) is the Euler-Poincare characteristic, an integer, V is the number of vertices in a polyhedra (or mesh for our purposes), E is the number of edges in a mesh, and F is the number of faces in a mesh.
            // The useful thing is that the Euler-Poincare characteristic X is equal to 2 for any convex polyhedra. This is very useful because it allows us to check a lot of things at once. 

            string B = null;
            List<string> structstatuslist = new List<string>();
            bool closed = true;
            int Chi = -500;
           // MessageBox.Show("Begin structure check");
            foreach (STRUCTURE str in plan.StructureSet.Where(S => S.DicomType.Equals("ORGAN") || S.DicomType.Equals("CTV") || S.DicomType.Equals("PTV") || S.DicomType.Equals("GTV") || S.DicomType.Equals("CAVITY") || S.DicomType.Equals("SUPPORT") || S.DicomType.Equals("FIXATION") || S.DicomType.Equals("BOLUS") || S.DicomType.Equals("EXTERNAL")))
            {
                closed = str.Mesh.IsClosed();
                if(closed == false)
                {
                    gs.MeshAutoRepair repair = new gs.MeshAutoRepair(str.Mesh);
                    repair.RemoveMode = gs.MeshAutoRepair.RemoveModes.None;
                    repair.Apply();
                }
                Chi = str.Mesh.VertexCount - str.Mesh.EdgeCount + str.Mesh.TriangleCount;
                structstatuslist.Add(str.name + ", " + closed.ToString() + ", " + Chi);
            }

            foreach (string R in structstatuslist)
            {
                B = B + R + "\n";
            }
           // MessageBox.Show("Structure check done");
            return B;
        }

        // 6.0 cm in the Y jaw
        public static string MinFieldSizeforEDWBeams(PLAN plan)
        {
            string B = null;
            List<string> el = new List<string>();
            foreach(BEAM beam in plan.Beams)
            {
                //MessageBox.Show("Beam: " + beam.beamId + "\n y1 jaw: " + (beam.ControlPoints.First().JawPositions.Item2 * -1) + "\nY2 jaw: " + beam.ControlPoints.First().JawPositions.Item4);
                if (beam.EDWPresent == true)
                {
                    //MessageBox.Show("Beam: " + beam.beamId + "EDW present.");
                    foreach(CONTROLPOINT p in beam.ControlPoints)
                    {
                        //MessageBox.Show("Control Point: " + p.Index + "\n y1 jaw: " + (p.JawPositions.Item2 * -1) + "\nY2 jaw: " + p.JawPositions.Item4);
                        if (((p.JawPositions.Item2 * -1) + p.JawPositions.Item4) < 60.0)
                        {
                            el.Add("Beam " + beam.beamId + " - Y jaw size less than 6 cm!");
                            //MessageBox.Show("EDW jaw position trigger, " + beam.beamId + "  jaw size (mm): " + ((p.JawPositions.Item2 * -1) + p.JawPositions.Item4));
                            break;
                        }
                        else
                        {
                            el.Add("Good");
                        }
                    }
                }
                else
                {
                    el.Add("No EDW, Not applicable.");
                    //MessageBox.Show("Beam: " + beam.beamId + "EDW NOT present.");
                }
            }

            if(el.All(l => l.Equals("No EDW, Not applicable.")))
            {
                B = "No EDW beams, Not applicable";
            }
            else if (el.All(l => l.Equals("Good")))
            {
                B = "All EDW beams have Y jaw field sizes over 6 cm.";
            }
            else if (el.Any(l => l.StartsWith("Beam")))
            {
                // there is an EDW beam with a Y jaw size less than 6 cm
                B = "The following EDW beams have a Y jaw size less than 6 cm.";
                foreach (string dtr in el)
                {
                    if (dtr.StartsWith("Beam"))
                    {
                        B = B + "\n" + dtr;
                    }
                }
            }
            else
            {
                // this means there is some combination of beams with no EDW and Passing EDW
                B = "Some of the beams in this plan have an EDW. Those that do have Y jaw field sizes over 6 cm.";
            }          

            return B;
        }

        public static string MaxSlicesinTPCT(PLAN plan)
        {
            string B = null;
            if (plan.ImageZsize == -1)
            {
                B = "Invalid. Plan needs to be approved.";
                return B;
            }
            //MessageBox.Show("Image Z size: " + plan.ImageZsize);
            B = Convert.ToString(plan.ImageZsize);

            return B;
        }

        //Report only
        public static string DoseCalcAlgorithim(PLAN plan)
        {
            string B = null;
            if(plan.ValidDose == false)
            {
                B = "This plan's dose matrix is not valid! Please recalculate.";
                return B;
            }
            else
            {
                B = plan.DoseCalcInfo.Substring(0, (plan.DoseCalcInfo.Count() - 30));
            }
            return B;
        }

        public static string DoseCalcGridSize(PLAN plan)
        {
            string B = null;
            //MessageBox.Show("Dose Grid X size: " + plan.DoseGridXSize);
            //MessageBox.Show("Dose Grid Y size: " + plan.DoseGridYSize);

            // Only X and Y are used for the dose grid size, not Z
            if(plan.DoseGridXSize == -1)
            {
                B = "Invalid. Plan needs to be approved.";
                return B;
            }

            if (plan.DoseGridXSize == plan.DoseGridYSize)
            {
                B = Convert.ToString(plan.DoseGridXSize);
               // MessageBox.Show("Dose calc grid size: " + B);
                if(plan.SRSstatus == "False")
                {
                    //MessageBox.Show("SRS False");
                    if (plan.DoseGridXSize == 2)
                    {
                        B = B + " mm - PASS";
                    }
                    else
                    {
                        B = B + " mm - FAIL";
                    }
                }
                else if(plan.SRSstatus == "True")
                {
                   // MessageBox.Show("SRS True");
                    if (plan.DoseGridXSize == 1)
                    {
                        B = B + " mm - PASS";
                    }
                    else
                    {
                        B = B + " mm - FAIL";
                    }
                }
            }
            else
            {
                B = "Mismatch between X and Y dimensions of dose voxels.";
            }

            // 0.1 for SRS, 0.2 for non-SRS
            //MessageBox.Show("Dose Calc Grid Size B : " + B);
            return B;
        }

        public static string MinMUEDWBeam(PLAN plan)
        {
            string B = null;
            List<string> bl = new List<string>();

            foreach(BEAM beam in plan.Beams)
            {
                //MessageBox.Show(beam.beamId + " MU: " + beam.MU + " " + beam.MUunit);
                if(beam.EDWPresent == true)
                {
                    if(beam.MU < 30)
                    {
                        bl.Add("Beam " + beam.beamId + " - MU less than 30!");
                       // MessageBox.Show("EDW MU Trigger: " + beam.beamId + "  MU: " + beam.MU);
                    }
                    else
                    {
                        bl.Add("Good");
                    }
                }
                else
                {
                    bl.Add("No EDW, Not applicable.");
                }
            }

            if (bl.All(l => l.Equals("No EDW, Not applicable.")))
            {
                B = "No EDW beams, Not applicable";
            }
            else if (bl.All(l => l.Equals("Good")))
            {
                B = "All EDW beams have MU over 30.";
            }
            else if (bl.Any(l => l.StartsWith("Beam")))
            {
                // there is an EDW beam with MU less than 30
                B = "The following EDW beams have MU less than 30.";
                foreach (string dtr in bl)
                {
                    if (dtr.StartsWith("Beam"))
                    {
                        B = B + "\n" + dtr;
                    }
                }
            }
            else
            {
                // this means there is some combination of beams with no EDW and Passing EDW
                B = "Some of the beams in this plan have an EDW. Those that do have 30 MU or more.";
            }

            return B;
        }

        public static string MinMUforStaticFiF(PLAN plan)
        {
            string B = null;
            List<string> sl = new List<string>();
            int te = 0;
            string tl = null;

            foreach(BEAM beam in plan.Beams)
            {
                if(beam.Technique.Contains("Static") || beam.Technique.Contains("static") || beam.Technique.Contains("STATIC"))
                {
                    sl.Add(beam.beamId + " MU: " + Math.Round(beam.MU, 2));
                    //MessageBox.Show("Beam MU: " + beam.MU);
                }
                else
                {
                    sl.Add("Not Applicable");
                }
            }

            if (sl.All(s => s.Equals("Not Applicable")))
            {
                B = "No Static beams, Not applicable";
                return B;
            }
            else
            {
                for(int k = 0; k < sl.Count; k++)
                {
                    te = sl[k].IndexOf(':');
                    tl = sl[k].Substring(te + 1);
                    //MessageBox.Show("tl: " + tl);
                    if (Convert.ToDouble(tl) < 10.0)
                    {
                        sl[k] = "Fail - " + sl[k];
                    }
                }
            }

            if (sl.Any(s => s.StartsWith("Fail")))
            {
                B = "At least one of the static beams in this plan has less then 10 MU.";
                foreach (string j in sl)
                {
                    B = B + "\n" + j;
                }
            }
            else
            {
                B = "These are the MU values of the following Static beams.";

                foreach (string sm in sl)
                {
                    B = B + "\n" + sm;
                }
            }

            return B;
        }

        //Report only
        public static string MinMUperDegArc(PLAN plan)
        {
            string B = null;
            double tempmeterweight = 0.0;
            double MUperDeg = 0.0;
            List<double> beamMUperDeg = new List<double>();
            double minMUperDeg = 0.0;
            List<string> LminMUperDeg = new List<string>();

            foreach(BEAM beam in plan.Beams)
            {
                if((beam.Technique.Contains("Arc") || beam.Technique.Contains("ARC")) & beam.ControlPoints.Count > 5)
                {
                    beamMUperDeg.Clear();
                    // MU/deg is the metersetweight of the current cp, minus the metersetweight of the previous cp, multiplied by the beam MU, divided by 2.
                    for(int i = 0; i < beam.ControlPoints.Count; i++)
                    {
                        // starts at third cp
                        if (i >= 2)
                        {
                            //MessageBox.Show("tempmetersetweight 1: " + beam.ControlPoints[i].MetersetWeight);
                           // MessageBox.Show("tempmetersetweight 2: " + beam.ControlPoints[i - 1].MetersetWeight);

                            tempmeterweight = beam.ControlPoints[i].MetersetWeight - beam.ControlPoints[i - 1].MetersetWeight;
                            MUperDeg = (tempmeterweight * beam.MU) / 2;
                            beamMUperDeg.Add(MUperDeg);
                            //if(i > 4 & i < 11)
                            //{
                            //    MessageBox.Show("tempmetersetweight comb: " + tempmeterweight);
                            //    MessageBox.Show("Beam MU: " + beam.MU);
                            //    MessageBox.Show("MU per Degree: " + MUperDeg);
                            //}

                        }
                    }

                    minMUperDeg = beamMUperDeg.Min();
                    LminMUperDeg.Add(beam.beamId + ": " + Math.Round(minMUperDeg, 2));
                }
                else
                {
                    LminMUperDeg.Add("Not an Arc beam, Not Applicable");
                }
            }

            if (LminMUperDeg.All(m => m.Equals("Not an Arc beam, Not applicable.")))
            {
                B = "No Arc beams, Not applicable";
            }
            else 
            {
                B = "These are the minimum MU per Degree values for the Arc beams found in this plan.";

                foreach(string str in LminMUperDeg)
                {
                    B = B + "\n" + str;
                }
            }

            return B;
        }

        //Report only
        public static string MinXandYJawSettingsacrossallbeams(PLAN plan)
        {
            string B = null;
            List<string> minfieldlist = new List<string>();
            List<Tuple<double, double>> kl = new List<Tuple<double, double>>();
            double FieldX = 0.0;
            double FieldY = 0.0;
            Tuple<double, double> MinField = new Tuple<double, double>(0.0, 0.0);

            foreach (BEAM beam in plan.Beams)
            {
                kl.Clear();
                //MessageBox.Show("X1 jaw: " + (beam.ControlPoints.First().JawPositions.Item1 * -1) + "\nX2 jaw: " + (beam.ControlPoints.First().JawPositions.Item3 ) + "\nY1 jaw: " + (beam.ControlPoints.First().JawPositions.Item2 * -1) + "\nY2 jaw: " + (beam.ControlPoints.First().JawPositions.Item4));
                foreach (CONTROLPOINT p in beam.ControlPoints)
                {
                    FieldX = (beam.ControlPoints.First().JawPositions.Item1 * -1) + (beam.ControlPoints.First().JawPositions.Item3);
                    FieldY = (beam.ControlPoints.First().JawPositions.Item2 * -1) + (beam.ControlPoints.First().JawPositions.Item4);
                    kl.Add(new Tuple<double, double>(FieldX, FieldY));
                }
                MinField = kl.Min();
                minfieldlist.Add(beam.beamId + " - (" + (MinField.Item1 / 10.0) + " cm, " + (MinField.Item2 / 10.0) + " cm)");
            }

            B = "These are the minimum field sizes for each beam.";

            foreach (string fs in minfieldlist)
            {
                B = B + "\n" + fs;
            }

            return B;
        }

        //checks that jaws are set to nearest millimeter
        public static bool XYJawPrecision(PLAN plan)
        {
            bool B = false;

            return B;
        }

        public static bool CTCheck()
        {
            bool B = false;




            return B;
        }

        public static bool UserOriginCheck()
        {
            bool B = false;



            return B;
        }


        public static string PrescriptionCheck(PLAN plan)
        {
            string str = null;

           // plan.p



            return str;
        }




        public static bool GantryAnglesAreIntegers(PLAN plan)
        {
            bool B = false;

            foreach(BEAM be in plan.Beams)
            {
                if((be.GantryStartAngle % 1) == 0)
                {
                    B = true;
                }
            }
            return B;
        }

        //public static bool NoBeamsAt0or180degreeGantryAngle()
        //{

        //}


        //public static bool XandYJawPositionsRoundedToNearest1mm()
        //{


        //}


        public static bool CourseIDCheck(PLAN plan)
        {
            bool B = false;
            if(plan.courseId.StartsWith("C") || plan.courseId.Contains("QA"))
            {
                B = true;
            }
            else
            {
                B = false;
            }

            return B;
        }

        public static bool PlanIDCheck(PLAN plan)
        {
            bool B = false;


            return B;
        }

        public static bool BeamIDCheck(PLAN plan)
        {
            //Arc_30_260
            //Static_70
            //T10_Static_230
            List<string> blist = new List<string>();

            bool B = false;
            int f = -5;
            double d = -5;
            string[] tokens;
            string str = null;

            foreach (BEAM beam in plan.Beams)
            {
                if(beam.beamId.StartsWith("T"))
                {
                    f = beam.beamId.IndexOf("_");
                    if(f == -1)
                    {
                        blist.Add(beam.beamId + " is an invalid beam name!");
                        continue;
                    }

                    if(f > 4 || f < 2)
                    {
                        blist.Add(beam.beamId + " is an invalid beam name!");
                        continue;
                    }

                    str = beam.beamId.Substring(f + 1);

                    if(str.StartsWith("Static"))
                    {
                        f = str.IndexOf("_");

                        if (f == -1)
                        {
                            blist.Add(beam.beamId + " is an invalid beam name!");
                            continue;
                        }

                        try
                        {
                            d = Convert.ToDouble(beam.beamId.Substring(f + 1));
                        }
                        catch (FormatException e)
                        {
                            blist.Add(beam.beamId + " is an invalid beam name!");
                            continue;
                        }

                        if (d >= 0 & d <= 360)
                        {
                            //good
                        }
                        else
                        {
                            blist.Add(beam.beamId + " is an invalid beam name!");
                            continue;
                        }
                    }
                    else if(str.StartsWith("Arc"))
                    {
                        tokens = str.Split('_');

                        try
                        {
                            d = Convert.ToDouble(tokens[1]);
                        }
                        catch (FormatException e)
                        {
                            blist.Add(beam.beamId + " is an invalid beam name!");
                            continue;
                        }

                        if (d >= 0 & d <= 360)
                        {
                            //good
                            try
                            {
                                d = Convert.ToDouble(tokens[2]);
                            }
                            catch (FormatException e)
                            {
                                blist.Add(beam.beamId + " is an invalid beam name!");
                                continue;
                            }

                            if (d >= 0 & d <= 360)
                            {
                                //good
                            }
                            else
                            {
                                blist.Add(beam.beamId + " is an invalid beam name!");
                                continue;
                            }
                        }
                        else
                        {
                            blist.Add(beam.beamId + " is an invalid beam name!");
                            continue;
                        }
                    }
                    else
                    {
                        blist.Add(beam.beamId + " is an invalid beam name!");
                        continue;
                    }
                }
                else if (beam.beamId.StartsWith("Arc"))
                {
                    tokens = beam.beamId.Split('_');

                    try
                    {
                        d = Convert.ToDouble(tokens[1]);
                    }
                    catch(FormatException e)
                    {
                        blist.Add(beam.beamId + " is an invalid beam name!");
                        continue;
                    }

                    if (d >= 0 & d <= 360)
                    {
                        //good
                        try
                        {
                            d = Convert.ToDouble(tokens[2]);
                        }
                        catch (FormatException e)
                        {
                            blist.Add(beam.beamId + " is an invalid beam name!");
                            continue;
                        }

                        if(d >= 0 & d <= 360)
                        {
                            //good
                        }
                        else
                        {
                            blist.Add(beam.beamId + " is an invalid beam name!");
                            continue;
                        }
                    }
                    else
                    {
                        blist.Add(beam.beamId + " is an invalid beam name!");
                        continue;
                    }
                }
                else if(beam.beamId.StartsWith("Static"))
                {
                    f = beam.beamId.IndexOf("_");

                    if (f == -1)
                    {
                        blist.Add(beam.beamId + " is an invalid beam name!");
                        continue;
                    }

                    try
                    {
                        d = Convert.ToDouble(beam.beamId.Substring(f));
                    }
                    catch(FormatException e)
                    {
                        blist.Add(beam.beamId + " is an invalid beam name!");
                        continue;
                    }

                    if(d >= 0 & d<= 360)
                    {
                        //good
                    }
                    else
                    {
                        blist.Add(beam.beamId + " is an invalid beam name!");
                        continue;
                    }
                }
            }

            return B;
        }


        //public static string HUOvverride(PLAN plan)
        //{
        //    plan.StructureSet.







        //}



    }
}
