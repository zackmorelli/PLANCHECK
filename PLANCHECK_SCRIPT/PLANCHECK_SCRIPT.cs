using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Windows.Media.Media3D;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

using g3;
using PLANCHECK;
using PLANCHECK_SCRIPT;


// Description: This is the Top-Level program of the Eclipse Script form of the Plan Check Program. This program runs a script in Eclipse which gathers all of the required information
//  about the currently selected plan in Eclipse and stores it in an independent, custom PLAN class. The PLANCHECKEXECUTE method of the PLANCHECK class, which is used by this script, 
//  the standalone Plan Check program, and Tiamat, is then called on a separate thread, and has PLAN passed to it. The Script then ends, while the PLANCHECK analysis continues on a separate thread 
//  and generates a PDF report of the results. A simple GUI, which runs a separate thread, is displayed while the plan runs.

namespace VMS.TPS
{
    public class Script
    {
        public void Execute(ScriptContext context)
        {
            //Variable declaration space
            bool nogood = false;
            //this is used to signify that this plan is missing something needed for the program to run properly and is used to stop the handoff to PLANCHECK. 

            List<PlanSetup> Plans = (List<PlanSetup>)context.PlansInScope;
            Patient patient = context.Patient;
            User User = context.CurrentUser;
            //Image image = context.Image;

            if (context.Patient == null)
            {
                System.Windows.Forms.MessageBox.Show("Please load a patient with a treatment plan before running this script!");
                nogood = true;
                return;
            }

            List<string> planids = new List<string>();

            foreach(PlanSetup pla in Plans)
            {
                if (pla.Id == "pretximg" | pla.Id == "PreTximg" | pla.Id == "PretxImg" | pla.Id == "preTxImg" | pla.Id == "PreTxImg" | pla.ApprovalStatus == PlanSetupApprovalStatus.Rejected | pla.ApprovalStatus == PlanSetupApprovalStatus.Retired)
                {
                    continue;
                }
                planids.Add(pla.Id);
            }

            //This GUI runs on this thread. It is used to get selections from the user, like what plan they want to run Plancheck on, the laterality of the plan, if it is an SRS plan,
            //and if they want to run the DocCheck module. The DocCheck module involves running another GUI that returns an object, so it must be awaited and therefore it is done
            //in Plancheck (if the user selected it), not here in Script execute where multithreading will not work. This isn't a problem, because DocCheck, (and PCTPNparse) get info
            //from the PCTPN document and having nothing to do with Eclipse itself. Everything pertaining to Eclipse itself is done here in script execute, put in the custom classes,
            //and then passed off to Plancheck where the program continues on another thread, and the Eclipse script terminates.
            GUI gui = new GUI(planids);
            System.Windows.Forms.Application.Run(gui);
            string[] pl = gui.str;
            //pl 0 plan id
            //pl 1 laterality
            //pl 2 SRS status
            //pl 3 DocumentCheck

            //populate my own classes with ESAPI info in order to completley isolate ESAPI, that way we can multi-thread.
            // that requires figuring out a lot of stuff here though before we call the GUI (on its own thread)

            string user = User.Name;
            string progtype = "script";
            string strctid = null;
            PLAN CHPLAN = new PLAN();

            try
            {
                foreach (PlanSetup plan in Plans)
                {
                    if (plan.Id == pl[0])
                    {
                        //First some basic sanity checks
                        try
                        {
                            strctid = plan.StructureSet.Id;
                        }
                        catch (NullReferenceException e)
                        {
                            MessageBox.Show("The plan " + plan.Id + " does not have a structure set! Plan checks cannot performed.\n\nThe program will now close.");
                            nogood = true;
                            // no structure set, skip
                            continue;
                        }

                        if (plan.PlanType == PlanType.Brachy)
                        {
                            MessageBox.Show("Sorry, the Plancheck program is currently only designed for External Beam plans.\n\nThe program will now close.");
                            nogood = true;
                            continue;
                        }

                        //These are plan-wide variables. Beam specific variables are declared further below before the beam loop.
                        //The first group of variables are really just for the PDF report.

                        //MessageBox.Show("TRIG 7");
                        //MessageBox.Show("plan id: " + plan.Id);
                        //MessageBox.Show("TRIG 7.5");
                        string patientId = plan.Course.Patient.Id;
                        DateTime? CreationDateTime = plan.CreationDateTime;
                        string patientsex = null;
                        string courseId = null;
                        string PatFirstName = null;
                        string PatLastName = null;
                        DateTime? PatDOB = null;
                        string DocName = null;
                        string HospitalName = null;
                        string HospitalAddress = null;
                        string ApprovalStatus = null;
                        string CreationUser = null;
                        DateTime LastModifiedDateTime = new DateTime(1991, 9, 24);
                        string LastModifiedUser = null;

                        double RXdose = -1;
                        int Fractions = -1;
                        bool ValidDose = false;
                        double DosePerFraction = -1;
                        string BolusThickness = null;
                        string Site = null;
                        string RxTechnique = null;
                        double DoseXsize = -1;
                        double DoseYsize = -1;
                        double DoseZsize = -1;
                        double Zvoxels = -1;
                        double Zvoxelsize = -1;

                        try
                        {
                            patientsex = plan.Course.Patient.Sex;
                            courseId = plan.Course.Id;
                            PatFirstName = plan.Course.Patient.FirstName;
                            PatLastName = plan.Course.Patient.LastName;
                            PatDOB = plan.Course.Patient.DateOfBirth;
                            DocName = plan.Course.Patient.PrimaryOncologistId;
                            HospitalName = plan.Course.Patient.Hospital.Name;
                            HospitalAddress = plan.Course.Patient.Hospital.Location;
                            ApprovalStatus = plan.ApprovalStatus.ToString();
                            CreationUser = plan.CreationUserName;
                            LastModifiedDateTime = plan.HistoryDateTime;
                            LastModifiedUser = plan.HistoryUserName;

                            RXdose = plan.TotalDose.Dose;
                            Fractions = (int)plan.NumberOfFractions;
                            ValidDose = plan.IsDoseValid;
                            DosePerFraction = plan.DosePerFraction.Dose;
                            BolusThickness = plan.RTPrescription.BolusThickness;
                            Site = plan.RTPrescription.Site;
                            RxTechnique = plan.RTPrescription.Technique;
                            DoseXsize = plan.Dose.XRes;
                            DoseYsize = plan.Dose.YRes;
                            DoseZsize = plan.Dose.ZRes;
                            Zvoxels = plan.StructureSet.Image.ZSize;
                            Zvoxelsize = plan.StructureSet.Image.ZRes;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Problem instatiating one of the plan-wide variables. This is probably because this plan/patient is missing some info." +
                                "\n\n" + e.ToString() + "\n\n" + e.StackTrace);
                        }

                        //MessageBox.Show("TRIG 8");
                        //most of the information that we need to check is in the individual beam objects
                        //However, before we get to that we'll get mesh info for all the structures, and then figure out the patient orientation.
                        List<STRUCTURE> StructureSet = new List<STRUCTURE>();
                        List<Vector3d> VertexList = new List<Vector3d>();
                        Vector3d CP = new Vector3d();
                        List<int> IndexList = new List<int>();
                        foreach (Structure STR in plan.StructureSet.Structures)
                        {
                            if (STR.IsEmpty == true || STR.Volume < 0.0)
                            {
                                //System.Windows.Forms.MessageBox.Show("The Couch Interior structure is not contoured!");
                                continue;
                            }

                            VertexList.Clear();
                            IndexList.Clear();
                            foreach (Point3D p in STR.MeshGeometry.Positions)
                            {
                                Vector3d vect = new Vector3d(p.X, p.Y, p.Z);
                                VertexList.Add(vect);
                            }

                            foreach (int I in STR.MeshGeometry.TriangleIndices)
                            {
                                IndexList.Add(I);
                            }

                            CP = new Vector3d(STR.CenterPoint.x, STR.CenterPoint.y, STR.CenterPoint.z);
                            Tuple<double, double, double> Bounds = new Tuple<double, double, double>(STR.MeshGeometry.Bounds.SizeX, STR.MeshGeometry.Bounds.SizeY, STR.MeshGeometry.Bounds.SizeZ);
                            StructureSet.Add(new STRUCTURE(VertexList, IndexList, CP, STR.Id, STR.DicomType, Bounds));
                        }

                        if (StructureSet.Any(S => S.name.Equals("Body")) || StructureSet.Any(S => S.DicomType.Equals("EXTERNAL")))
                        {
                            //Body contour present
                        }
                        else
                        {
                            // missing body contour, which is crucuial to a number of tests
                            nogood = true;
                            MessageBox.Show("The program could not detect a Body contour. This is crucial to a number of tests and neccessary for the Plancheck program to work properly. Please make a Body contour and run the program again.\n\nThe program will now close.");
                            continue;
                        }

                        //MessageBox.Show(plan.TreatmentOrientation.ToString());
                        string PATIENTORIENTATION = null;
                        // Head first prone
                        if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine)
                        {
                            PATIENTORIENTATION = "HeadFirstSupine";
                        }
                        else if (plan.TreatmentOrientation == PatientOrientation.HeadFirstProne)
                        {
                            PATIENTORIENTATION = "HeadFirstProne";
                        }
                        else if (plan.TreatmentOrientation == PatientOrientation.FeetFirstSupine)
                        {
                            PATIENTORIENTATION = "FeetFirstSupine";
                        }
                        else if (plan.TreatmentOrientation == PatientOrientation.FeetFirstProne)
                        {
                            PATIENTORIENTATION = "FeetFirstProne";
                        }

                        //These are the beam-specific variables. the beam loop starts below.
                        //Note that there is a beam-specific Technique here, while there already is a Technique string pulled from the Prescription object of the plan.
                        string mlctype = null;
                        bool EDW = false;
                        double MU = -1.0;
                        string MUunit = null;
                        string BeamTechnique = null;
                        string bolusID = null;
                        string Linac = null;
                        int DoseRate = -1;
                        string EnergyMode = null;
                        double CouchLongitudinal = -1.0;
                        double CouchLateral = -1.0;
                        double CouchVertical = -1.0;
                        string DoseCalcInfo = null;
                        string DoseFieldNormalization = null;
                        string DoseHeterogeneityCorrection = null;
                        bool LMClogsexist = false;

                        List<BEAM> Beams = new List<BEAM>();
                        foreach (Beam beam in plan.Beams)
                        {
                            if (beam.IsSetupField)
                            {
                                continue;
                            }

                            MU = beam.Meterset.Value;
                            MUunit = beam.Meterset.Unit.ToString();
                            foreach (Wedge w in beam.Wedges)
                            {
                                if (w is EnhancedDynamicWedge)
                                {
                                    EDW = true;
                                }
                            }

                            foreach (BeamCalculationLog log in beam.CalculationLogs)
                            {
                                if (log.Category == "Dose")
                                {
                                    foreach (string dtr in log.MessageLines)
                                    {
                                        if (dtr.StartsWith("Information: Service: "))
                                        {
                                            DoseCalcInfo = dtr.Substring(21);
                                        }
                                    }
                                }
                            }

                            if (beam.CalculationLogs.Any(l => l.Category.Equals("LMC")))
                            {
                                LMClogsexist = true;
                                // MessageBox.Show("LMClogsexist: " + LMClogsexist);
                            }

                            LMC_CALC_INFO lmcinfo = new LMC_CALC_INFO();
                            if (beam.MLCPlanType == MLCPlanType.Static)
                            {
                                mlctype = "Static";
                            }
                            else if (beam.MLCPlanType == MLCPlanType.DoseDynamic)
                            {
                                mlctype = "DoseDynamic";
                            }
                            else if (beam.MLCPlanType == MLCPlanType.ArcDynamic)
                            {
                                mlctype = "ArcDynamic";
                            }
                            else if (beam.MLCPlanType == MLCPlanType.VMAT)
                            {
                                mlctype = "VMAT";
                            }

                            foreach (Bolus bolus in beam.Boluses)
                            {
                                bolusID = bolus.Id;
                            }

                            BeamTechnique = beam.Technique.ToString();
                            //MessageBox.Show("Beam Technique: " + Technique);
                            if (LMClogsexist == true)
                            {
                                lmcinfo.LMClog = true;
                                lmcinfo.ActualMU = beam.Meterset.Value;
                                //MessageBox.Show("Beam " + beam.Id + " MU value: " + lmcinfo.ActualMU);
                                foreach (BeamCalculationLog log in beam.CalculationLogs)
                                {
                                    if (log.Category == "LMC")
                                    {
                                        lmcinfo.MaxMUcr1 = -1;
                                        lmcinfo.MaxMUcr2 = -1;
                                        lmcinfo.MaxMUcr3 = -1;
                                        lmcinfo.LostMUfactorCR1 = -1;
                                        lmcinfo.LostMUfactorCR2 = -1;
                                        lmcinfo.LostMUfactorCR3 = -1;
                                        foreach (string str in log.MessageLines)
                                        {
                                            if (str.StartsWith("Information: Maximum MU for carriage group 1"))
                                            {
                                                lmcinfo.MaxMUcr1 = Convert.ToDouble(str.Substring(46));
                                                // MessageBox.Show("Beam " + beam.Id + " Max MU value CR1: " + lmcinfo.MaxMUcr1);
                                            }

                                            if (str.StartsWith("Information: Maximum MU for carriage group 2"))
                                            {
                                                lmcinfo.MaxMUcr2 = Convert.ToDouble(str.Substring(46));
                                                // MessageBox.Show("Beam " + beam.Id + " Max MU value CR2: " + lmcinfo.MaxMUcr2);
                                            }

                                            if (str.StartsWith("Information: Maximum MU for carriage group 3"))
                                            {
                                                lmcinfo.MaxMUcr3 = Convert.ToDouble(str.Substring(46));
                                                // MessageBox.Show("Beam " + beam.Id + " Max MU value CR2: " + lmcinfo.MaxMUcr2);
                                            }

                                            if (str.StartsWith("Information: Lost MU factor for carriage group 1"))
                                            {
                                                lmcinfo.LostMUfactorCR1 = Convert.ToDouble(str.Substring(50));
                                                //MessageBox.Show("Beam " + beam.Id + " Lost MU factor value CR1: " + lmcinfo.LostMUfactorCR1);
                                            }

                                            if (str.StartsWith("Information: Lost MU factor for carriage group 2"))
                                            {
                                                lmcinfo.LostMUfactorCR2 = Convert.ToDouble(str.Substring(50));
                                                //MessageBox.Show("Beam " + beam.Id + " Lost MU factor value CR2: " + lmcinfo.LostMUfactorCR2);
                                            }

                                            if (str.StartsWith("Information: Lost MU factor for carriage group 3"))
                                            {
                                                lmcinfo.LostMUfactorCR3 = Convert.ToDouble(str.Substring(50));
                                                //MessageBox.Show("Beam " + beam.Id + " Lost MU factor value CR2: " + lmcinfo.LostMUfactorCR2);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                lmcinfo.LMClog = false;
                            }

                            Linac = beam.TreatmentUnit.Id;
                            DoseRate = beam.DoseRate;
                            EnergyMode = beam.EnergyModeDisplayName;
                            CouchLongitudinal = beam.ControlPoints.First().TableTopLongitudinalPosition;
                            CouchLateral = beam.ControlPoints.First().TableTopLateralPosition;
                            CouchVertical = beam.ControlPoints.First().TableTopVerticalPosition;

                            Vector3d iso = new Vector3d(beam.IsocenterPosition.x, beam.IsocenterPosition.y, beam.IsocenterPosition.z);
                            string gantrydir = null;
                            if (beam.GantryDirection == GantryDirection.Clockwise)
                            {
                                gantrydir = "Clockwise";
                            }
                            else if (beam.GantryDirection == GantryDirection.CounterClockwise)
                            {
                                gantrydir = "CounterClockwise";
                            }
                            else if (beam.GantryDirection == GantryDirection.None)
                            {
                                gantrydir = "None";
                            }

                            string beamId = beam.Id;
                            bool setupfield = beam.IsSetupField;
                            double arclength = beam.ArcLength;

                            List<CONTROLPOINT> controlpoints = new List<CONTROLPOINT>();
                            foreach (ControlPoint cp in beam.ControlPoints)
                            {
                                controlpoints.Add(new CONTROLPOINT { Index = cp.Index, Couchangle = cp.PatientSupportAngle, Gantryangle = cp.GantryAngle, CollimatorAngle = cp.CollimatorAngle, MetersetWeight = cp.MetersetWeight, JawPositions = new Tuple<double, double, double, double>(cp.JawPositions.X1, cp.JawPositions.Y1, cp.JawPositions.X2, cp.JawPositions.Y2) });
                            }
                            Beams.Add(new BEAM { MLCtype = mlctype, MU = MU, MUunit = MUunit, Technique = BeamTechnique, EDWPresent = EDW, LMCinfo = lmcinfo, Linac = Linac, EnergyMode = EnergyMode, CouchLongitudinal = CouchLongitudinal, CouchLateral = CouchLateral, CouchVertical = CouchVertical, DoseRate = DoseRate, BolusId = bolusID, Isocenter = iso, gantrydirection = gantrydir, beamId = beamId, ControlPoints = controlpoints, setupfield = setupfield, arclength = arclength });
                        }

                        //MessageBox.Show("TRIG 9");
                        CHPLAN = new PLAN {Laterality = pl[1], SRSstatus = pl[2], Fracs = Fractions, RXdose = RXdose, planId = plan.Id, UserName = user, StructureSet = StructureSet, progtype = progtype, ValidDose = ValidDose, ImageZsize = Zvoxels, ImageZRes = Zvoxelsize, DoseGridXSize = DoseXsize, DoseGridYSize = DoseYsize, DoseGridZSize = DoseZsize, DoseCalcInfo = DoseCalcInfo, ApprovalStatus = ApprovalStatus, CreationDateTime = CreationDateTime, CreationUser = CreationUser, DocName = DocName, HospitalName = HospitalName, PatHospitalAddress = HospitalAddress, LastModifiedDateTime = LastModifiedDateTime, LastModifiedUser = LastModifiedUser, PatDOB = PatDOB, PatFirstName = PatFirstName, PatLastName = PatLastName, StructureSetId = plan.StructureSet.Id, TreatmentOrientation = PATIENTORIENTATION, Beams = Beams, PatId = patientId, patientsex = patientsex, courseId = courseId };

                        //MessageBox.Show("SRS Status: " + pl[2]);
                        // System.Windows.Forms.MessageBox.Show(Plan.planId + "START body vector conversion");
                        //System.Windows.Forms.MessageBox.Show("Body positions size: " + Plan.Body.Positions.Count);

                    }  // ends if plan.id == pl

                }  //ends for reach plansetup
            }
            catch (Exception e)
            {

                MessageBox.Show("Problem in Plancheck_script\n\n\n" + e.ToString() + "\n\n\n" + e.StackTrace + "\n\n\n" + e.InnerException);
            }

            //IMAGE Image = new IMAGE();
            //Image.imageuserorigin = new Vector3d(image.UserOrigin.x, image.UserOrigin.y, image.UserOrigin.z);
            //Image.imageorigin = new Vector3d(image.Origin.x, image.Origin.y, image.Origin.z);

            CHPLAN.progtype = "script";

            //Task.Run(() => System.Windows.Forms.Application.Run(new simpleGUI(pl)));

            //MessageBox.Show("Script done, handoff to PLANCHECK");

            if (nogood == false)
            {
                Task.Run(() => PLANCHECK.PLANCHECK.PLANCHECKEXECUTE(CHPLAN));
            }
            
            return;
        }
















    }
}
