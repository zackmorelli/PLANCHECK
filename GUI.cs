using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows.Forms;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using PLANCHECK;
using g3;


namespace PLANCHECK_STANDALONE
{
    public partial class GUI : Form
    {
        //global GUI variable declaration

        string pl = null;
        int c = 0;
        List<string> plannames = new List<string>();
        List<string> sumnames = new List<string>();


        public GUI()
        {
            InitializeComponent();

            button1.Click += (sender, EventArgs) => { buttonNext_Click(sender, EventArgs); };
        }

        private void EXECUTE()
        {
            // so, first declare a bunch of variables of things we will need from Eclipse to make checks against, and then open Eclipse to get that stuff. 

            string datefrom = DateFrom.Text;
            string dateto = DateTo.Text;
            List<RealPatientAppointments> ActualPatientAppts = new List<RealPatientAppointments>();

            datefrom = datefrom + " 1:00:00";
            dateto = dateto + " 23:00:00";

            OutputBox.AppendText(Environment.NewLine);
            OutputBox.AppendText("Running checks for all patients with an appointment between " + datefrom + " and " + dateto + ".");

            pBar.Style = ProgressBarStyle.Marquee;
            pBar.Visible = true;

            string ConnectionString = @"Data Source=WVVRNDBP01SS;Initial Catalog=variansystem;Integrated Security = False;User Id=RadOncPhysicist;Password=84!l94y5!C!5T";
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand command;
            SqlDataReader datareader;
            string sql;


            //TODO: change sql string to get only actual patient treatment appointments
            // think this is good, currently uses activity codes of new starts.
            conn.Open();
            sql = "USE variansystem SELECT PatientSer, ActivityInstanceSer FROM dbo.ScheduledActivity WHERE ScheduledStartTime >= '" + datefrom + "' AND ScheduledStartTime <= '" + dateto + "' AND PatientSer IS NOT NULL";
            //Sql Server datetime string literal format -  YYYY-MM-DD 00:00:00.000
            command = new SqlCommand(sql, conn);
            datareader = command.ExecuteReader();

            while (datareader.Read())
            {
                ActualPatientAppts.Add(new RealPatientAppointments() { PatientSerial = Convert.ToInt64(datareader["PatientSer"]), ActivityInstanceSerial = Convert.ToInt64(datareader["ActivityInstanceSer"]) });
            }
            conn.Close();

            foreach (RealPatientAppointments A in ActualPatientAppts)
            {
                conn.Open();
                sql = "USE variansystem SELECT ActivitySer FROM dbo.ActivityInstance WHERE ActivityInstanceSer = " + A.ActivityInstanceSerial;
                command = new SqlCommand(sql, conn);
                datareader = command.ExecuteReader();
                if (datareader.Read())
                {
                    A.ActivitySerial = Convert.ToInt64(datareader["ActivitySer"]);
                }
                conn.Close();

                conn.Open();
                sql = "USE variansystem SELECT ActivityCode FROM dbo.Activity WHERE ActivitySer = " + A.ActivitySerial;
                command = new SqlCommand(sql, conn);
                datareader = command.ExecuteReader();
                if (datareader.Read())
                {
                    A.ActivityCode = Convert.ToString(datareader["ActivityCode"]);
                }
                conn.Close();

                conn.Open();
                sql = "USE variansystem SELECT PatientId FROM dbo.Patient WHERE PatientSer = " + A.PatientSerial;
                command = new SqlCommand(sql, conn);
                datareader = command.ExecuteReader();
                if (datareader.Read())
                {
                    A.PatientId = Convert.ToString(datareader["PatientId"]);
                }
                conn.Close();
            }

            //using (StreamWriter fs = new StreamWriter(@"C:\Users\ztm00\Desktop\Reports\TEMPB.txt"))
            //{
            //    foreach (RealPatientAppointments A in ActualPat)
            //    {
            //        fs.WriteLine(A);
            //    }
            //}

            // this is a list of all the patients that have either a NewStart or BoostTx appointment in the date range we are interested in. If a patient has one of those appts, they will be added to the list. So a patient could be on the list twice, for different plans.                        
            List<PlansForAnalysis> PLANSINITIAL = new List<PlansForAnalysis>();
            for (int i = ActualPatientAppts.Count - 1; i >= 0; i--)
            {
                if (ActualPatientAppts[i].ActivitySerial == 21 | ActualPatientAppts[i].ActivitySerial == 242 | ActualPatientAppts[i].ActivitySerial == 295 | ActualPatientAppts[i].ActivitySerial == 334 | ActualPatientAppts[i].ActivitySerial == 401)
                {
                    // those are the ActivitySers for New Starts
                    PLANSINITIAL.Add(new PlansForAnalysis {PatientId = ActualPatientAppts[i].PatientId, NewStart = true, BoostStart = false});
                    continue;
                }
                else if (ActualPatientAppts[i].ActivitySerial == 23 | ActualPatientAppts[i].ActivitySerial == 244 | ActualPatientAppts[i].ActivitySerial == 293 | ActualPatientAppts[i].ActivitySerial == 332 | ActualPatientAppts[i].ActivitySerial == 403)
                {
                    // those are the ActivitySers for Boost Tx. There are more than one Boost Tx appts., there is no boost start appt.
                    PLANSINITIAL.Add(new PlansForAnalysis { PatientId = ActualPatientAppts[i].PatientId, BoostStart = true, NewStart = false});
                    continue;
                }
                else
                {
                    ActualPatientAppts.RemoveAt(i);
                }
            }

            List<PlansForAnalysis> PLANS = new List<PlansForAnalysis>();
            foreach (PlansForAnalysis kj in PLANSINITIAL)
            {
                if(PLANS.Any(l => l.Equals(kj)))
                {
                    continue;
                }
                else
                {
                    PLANS.Add(kj);
                }
            }

            //using (StreamWriter fs = new StreamWriter(@"C:\Users\ztm00\Desktop\Reports\TEMPA.txt"))
            //{
            //    foreach (PlansForAnalysis A in PLANS)
            //    {
            //        fs.WriteLine(A);
            //    }
            //}

            //no need to enter user credentials because in V16 the CreateApplication method uses the credentials of the currently logged-in user, no inputs required.
            using (VMS.TPS.Common.Model.API.Application app = VMS.TPS.Common.Model.API.Application.CreateApplication())
            {
                pBar.Visible = false;
                pBar.Style = ProgressBarStyle.Continuous;
                pBar.Visible = true;
                pBar.Minimum = 0;
                pBar.Value = 0;
                pBar.Maximum = PLANS.Count;
                pBar.Step = 1;
                string strctid = null;
                string user = "ZTM00";
                string progtype = "standalone";

                foreach (PlansForAnalysis M in PLANS)
                {
                    try
                    {
                        //The objects are declared here so they are re-instantiated for each patient. This is very important becuase if we try to access an object related to a closed patient, the Varian API throws a cryptic error.
                        List<PlanSetup> planlist = new List<PlanSetup>();
                        DateTime? mostrecent = null;

                        OutputBox.AppendText(Environment.NewLine);
                        OutputBox.AppendText(Environment.NewLine);
                        OutputBox.AppendText("Running plan checks for patient " + M.PatientId);

                        //=========== Very Important, this is where the patient is opened using the Application object. the patient is closed at the end of the appointment loop.
                        VMS.TPS.Common.Model.API.Patient ECpatient = app.OpenPatientById(M.PatientId);

                        VMS.TPS.Common.Model.API.Course ECcourse = ECpatient.Courses.First(c => c.Id.StartsWith("C"));    // just use the first course so we can instantiate a course object
                        PLAN CHPLAN = new PLAN();

                        mostrecent = null;               // finds the most recent course to perform checks on
                        foreach (VMS.TPS.Common.Model.API.Course CNT in ECpatient.Courses)
                        {
                            if (CNT.Id.StartsWith("C"))
                            {
                                if (mostrecent == null)
                                {
                                    mostrecent = CNT.StartDateTime;
                                    ECcourse = CNT;
                                }
                                else if (CNT.StartDateTime > mostrecent)
                                {
                                    mostrecent = CNT.StartDateTime;
                                    ECcourse = CNT;
                                }
                            }
                        }

                        VMS.TPS.Common.Model.API.PlanSetup plan = ECcourse.PlanSetups.First();
                        mostrecent = null;
                        bool nogood = false;

                        foreach (VMS.TPS.Common.Model.API.PlanSetup PLN in ECcourse.ExternalPlanSetups)
                        {
                            planlist.Add(PLN);
                        }

                        //A lot of shenanigans here to get rid of invalid plans
                        //planlist.RemoveAll(p => (p.Id == "pretximg" | p.Id == "PreTximg" | p.Id == "PretxImg" | p.Id == "preTxImg" | p.Id == "PreTxImg" | p.Id.Contains("DNU") | p.Id.Contains("dnu") | p.Id.Contains("QA") | p.Id.Contains("qa") | p.ApprovalStatus == PlanSetupApprovalStatus.Rejected | p.ApprovalStatus == PlanSetupApprovalStatus.Completed | p.ApprovalStatus == PlanSetupApprovalStatus.CompletedEarly | p.ApprovalStatus == PlanSetupApprovalStatus.Retired));
                        //MessageBox.Show("Planlist size: " + planlist.Count());
                        //foreach(PlanSetup PLN in planlist)
                        //{
                        //    MessageBox.Show("Plan Id: " + PLN.Id);
                        //}

                        try
                        {
                            planlist.RemoveAll(p => p.Id == "pretximg");
                            planlist.RemoveAll(p => p.Id.Contains("DNU"));
                            planlist.RemoveAll(p => p.Id.Contains("dnu"));
                            planlist.RemoveAll(p => p.Id.Contains("QA"));
                            planlist.RemoveAll(p => p.Id.Contains("qa"));
                            planlist.RemoveAll(p => p.ApprovalStatus == PlanSetupApprovalStatus.Rejected);
                            planlist.RemoveAll(p => p.ApprovalStatus == PlanSetupApprovalStatus.Completed);
                            planlist.RemoveAll(p => p.ApprovalStatus == PlanSetupApprovalStatus.CompletedEarly);
                            planlist.RemoveAll(p => p.ApprovalStatus == PlanSetupApprovalStatus.Retired);
                            planlist.RemoveAll(p => p.Id == "PreTximg");
                            planlist.RemoveAll(p => p.Id == "PretxImg");
                            planlist.RemoveAll(p => p.Id == "preTxImg");
                            planlist.RemoveAll(p => p.Id == "PreTxImg");
                            //planlist.RemoveAll(p =>  );
                            //planlist.RemoveAll(p =>  );
                            //planlist.RemoveAll(p =>  );
                            //planlist.RemoveAll(p =>  );
                            //planlist.RemoveAll(p =>  );
                        }
                        catch (ArgumentNullException e)
                        {
                            MessageBox.Show("Planlist removeAll problem\n\n" + e.ToString() + "\n\n" + e.Source + "\n\n" + e.TargetSite);
                            foreach (PlanSetup pl in planlist)
                            {
                                MessageBox.Show("plan " + pl.Id);
                            }
                        }

                        if (M.NewStart == true)
                        {
                            planlist.RemoveAll(p => p.Id.Contains("CD") | p.Id.Contains("Boost") | p.Id.Contains("boost"));
                        }
                        else if (M.BoostStart == true)
                        {
                            planlist.RemoveAll(p => !p.Id.Contains("CD") | !p.Id.Contains("Boost") | !p.Id.Contains("boost"));
                        }

                        for (int i = 0; i < planlist.Count; i++)
                        {
                            try
                            {
                                strctid = planlist[i].StructureSet.Id;
                            }
                            catch (NullReferenceException e)
                            {
                                MessageBox.Show("The plan " + plan.Id + " does not have a structure set! Plan checks cannot performed on this plan. This plan will be skipped.");
                                planlist.RemoveAt(i);
                                continue;
                            }

                            if (planlist[i].PlanType == PlanType.Brachy)
                            {
                                MessageBox.Show("Sorry, the Plancheck program is currently only designed for External Beam plans. This plan will be skipped.");
                                planlist.RemoveAt(i);
                                continue;
                            }
                        }

                        foreach (PlanSetup p in planlist)
                        {
                            if (mostrecent == null)
                            {
                                mostrecent = p.CreationDateTime;
                                plan = p;
                            }
                            else if (p.CreationDateTime > mostrecent)
                            {
                                mostrecent = p.CreationDateTime;
                                plan = p;
                            }
                        }
                        //so we are left with the most recent, and valid, plan in the most recent course of the patient, who has a New TX appointment within the date range specified by the user, to run the program on. 

                        //PlanCheck information gathering

                        // this is all stuff for the PDF Report
                        string patientId = plan.Course.Patient.Id;
                        string patientsex = plan.Course.Patient.Sex;
                        string courseId = plan.Course.Id;
                        string PatFirstName = plan.Course.Patient.FirstName;
                        string PatLastName = plan.Course.Patient.LastName;
                        DateTime? PatDOB = plan.Course.Patient.DateOfBirth;
                        string DocName = plan.Course.Patient.PrimaryOncologistId;
                        string HospitalName = plan.Course.Patient.Hospital.Name;
                        string HospitalAddress = plan.Course.Patient.Hospital.Location;
                        string ApprovalStatus = plan.ApprovalStatus.ToString();
                        DateTime? CreationDateTime = plan.CreationDateTime;
                        string CreationUser = plan.CreationUserName;
                        DateTime LastModifiedDateTime = plan.HistoryDateTime;
                        string LastModifiedUser = plan.HistoryUserName;
                        // string TreatmentSite 

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
                            MessageBox.Show("The program could not detect a Body contour. This is crucial to a number of tests and neccessary for the Plancheck program to work properly. This plan will be skipped for now.");
                            continue;
                        }

                        //System.Windows.Forms.MessageBox.Show(plan.TreatmentOrientation.ToString());
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

                        string mlctype = null;
                        bool EDW = false;
                        double MU = -1.0;
                        string MUunit = null;
                        string Technique = null;
                        string bolusID = null;
                        string Linac = null;
                        int DoseRate = -1;
                        string EnergyMode = null;
                        double CouchLongitudinal = -1.0;
                        double CouchLateral = -1.0;
                        double CouchVertical = -1.0;
                        bool ValidDose = false;
                        string DoseCalcInfo = null;
                        string DoseFieldNormalization = null;
                        string DoseHeterogeneityCorrection = null;
                        double DoseXsize = -1.0;
                        double DoseYsize = -1.0;
                        double DoseZsize = -1.0;
                        double Zvoxels = -1.0;
                        double Zvoxelsize = -1.0;
                        bool LMClogsexist = false;

                        if (plan.IsDoseValid == true)
                        {
                            ValidDose = true;
                        }
                        else
                        {
                            ValidDose = false;
                        }

                        DoseXsize = plan.Dose.XRes;
                        DoseYsize = plan.Dose.YRes;
                        DoseZsize = plan.Dose.ZRes;
                        Zvoxels = plan.StructureSet.Image.ZSize;
                        Zvoxelsize = plan.StructureSet.Image.ZRes;

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

                            Technique = beam.Technique.ToString();
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

                            Beams.Add(new BEAM { MLCtype = mlctype, MU = MU, MUunit = MUunit, Technique = Technique, EDWPresent = EDW, LMCinfo = lmcinfo, Linac = Linac, EnergyMode = EnergyMode, CouchLongitudinal = CouchLongitudinal, CouchLateral = CouchLateral, CouchVertical = CouchVertical, DoseRate = DoseRate, BolusId = bolusID, Isocenter = iso, gantrydirection = gantrydir, beamId = beamId, ControlPoints = controlpoints, setupfield = setupfield, arclength = arclength });
                        }

                        CHPLAN = new PLAN { planId = plan.Id, UserName = user, StructureSet = StructureSet, progtype = progtype, ValidDose = ValidDose, ImageZsize = Zvoxels, ImageZRes = Zvoxelsize, DoseGridXSize = DoseXsize, DoseGridYSize = DoseYsize, DoseGridZSize = DoseZsize, DoseCalcInfo = DoseCalcInfo, ApprovalStatus = ApprovalStatus, CreationDateTime = CreationDateTime, CreationUser = CreationUser, DocName = DocName, HospitalName = HospitalName, PatHospitalAddress = HospitalAddress, LastModifiedDateTime = LastModifiedDateTime, LastModifiedUser = LastModifiedUser, PatDOB = PatDOB, PatFirstName = PatFirstName, PatLastName = PatLastName, StructureSetId = plan.StructureSet.Id, TreatmentOrientation = PATIENTORIENTATION, Beams = Beams, PatId = patientId, patientsex = patientsex, courseId = courseId };

                        if (nogood == false)
                        {
                            Task.Run(() => PLANCHECK.PLANCHECK.PLANCHECKEXECUTE(CHPLAN));
                        }

                        app.ClosePatient();
                        OutputBox.AppendText(Environment.NewLine);
                        OutputBox.AppendText(Environment.NewLine);
                        OutputBox.AppendText("Plan Checks Complete for patient " + M.PatientId + " - " + PatLastName + ", " + PatFirstName + ". PDF report will appear shortly.");
                        pBar.PerformStep();


                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("An error occurred somewhere during the information gathering for this plan. This plan will be skipped for now so the program can continue.\n\n\n\nError Information: \nToString:  " + e.ToString() + "\n\n Message:  " + e.Message + " \n\nSource:  " + e.Source + "\n\nStack Trace:  " + e.StackTrace);
                        app.ClosePatient();  // must close this patient in Eclipse before iterating loop via continue statement;
                        continue;
                    }
                } // Ends the PLANS loop
                OutputBox.AppendText(Environment.NewLine);
                OutputBox.AppendText(Environment.NewLine);
                OutputBox.AppendText("Done with all plan checks.");
                OutputBox.AppendText(Environment.NewLine);
                OutputBox.AppendText(Environment.NewLine);
                OutputBox.AppendText("Logging out of Eclipse... ");
            }  // CLOSES ECLIPSE

            OutputBox.AppendText(Environment.NewLine);
            OutputBox.AppendText(Environment.NewLine);
            OutputBox.AppendText("Program Done.");

        } // End of EXECUTE


        //==============================Below are some Helper Classes===============================================================================================================================================================================================================================================================================================



        private void ECMRN_TextChanged(object sender, EventArgs args)
        {
            button1.Visible = true;
        }

        private void DateTo_TextChanged(object sender, EventArgs args)
        {
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs args)
        {
            //  MessageBox.Show("Organ: " + org.ToString());
            //  MessageBox.Show("Trig 12 - First Click");
        }

        void buttonNext_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Trig MORTY");
            EXECUTE();
        }

    }

    public class RealPatientAppointments
    {
       public long PatientSerial { get; set; }
       public long ActivityInstanceSerial { get; set; }
       public long ActivitySerial { get; set; }
       public string PatientId { get; set; }
       public string ActivityCode { get; set; }


        public override string ToString()
        {
            string str = "PatientSer: " + PatientSerial + " | ActivityInstanceSerial: " + ActivityInstanceSerial + " | ActivitySerial: " + ActivitySerial + " | ActivityCode: " + ActivityCode + " | PatientId: " + PatientId;
            return str;
        }

    }

    //This is a class for looping through the plans, to accomodate for a patient having a normal Tx or a boost. Both plans will be analyzed if the appointments fall in the time window.
    public class PlansForAnalysis
    {
        public string PatientId { get; set; }

        public bool NewStart { get; set; }

        public bool BoostStart { get; set; }

        public override string ToString()
        {
            string str = "PatientSer: " + PatientId + " | New Start Tx: " + NewStart + " | Boost Tx: " + BoostStart;
            return str;
        }

        public override bool Equals(object value)
        {
            if(value == null)
            {
                return false;
            }

            PlansForAnalysis pl = value as PlansForAnalysis;

            return (pl != null) && (PatientId == pl.PatientId) && (NewStart == pl.NewStart) && (BoostStart == pl.BoostStart);
        }


    }


}
