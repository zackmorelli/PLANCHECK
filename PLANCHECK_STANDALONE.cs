using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;



/*
    External Beam PlanCheck - Standalone program
    Copyright (c) 2020 Radiation Oncology Department, Lahey Hospital and Medical Center
    Written by: Zackary T Morelli

    This program is expressely written for use with Varian's Eclipse Treatment Planning System, and requires Varian's API files to run properly.
    This program also requires .NET Framework 4.5.0 and Entity Framework.

    This is the source code for a .NET Framework assembly file, however this functions as an executable file in Eclipse.
    In addition to Varian's APIs and .NET Framework, this program uses the following commonly available libraries:

    ESAPIX - From Rex Cardan at the University of Alabama Medical Center Radiation Oncology Department (MIT Liscense)

    Description:
    This script performs a number of safety checks on External beam RT plans.
*/



namespace PLANCHECK_STANDALONE
{
    static class PLANCHECK_STANDALONE
    {
        // Right now this program just calls the GUI, which then handles getting information from the user and reporting back results of the plan checks

        [STAThread]
        static void Main()
        {

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.Run(new GUI());
        }

    /*
        public static EclipseData OpenEclipseMRN(string patientMRN, string EclipseUser, string EclipsePW)
        {
            EclipseData eclipseData = new EclipseData();
            List<ApiDataObject> ECList = new List<ApiDataObject>();
           
            try
            {
                using (VMS.TPS.Common.Model.API.Application app = VMS.TPS.Common.Model.API.Application.CreateApplication(EclipseUser, EclipsePW))
                {
                    VMS.TPS.Common.Model.API.Patient ECpatient = app.OpenPatientById(patientMRN);

                    ECList.Add(ECpatient);

                    VMS.TPS.Common.Model.API.Course ECcourse = ECpatient.Courses.First();
                    DateTime? mostrecent = null;
                    foreach (VMS.TPS.Common.Model.API.Course CNT in ECpatient.Courses)
                    {
                        if (mostrecent == null)
                        {
                            mostrecent = ECcourse.StartDateTime;
                            ECcourse = CNT;
                        }
                        else if (ECcourse.StartDateTime > mostrecent)
                        {
                            mostrecent = ECcourse.StartDateTime;
                            ECcourse = CNT;
                        }
                    }

                    ECList.Add(ECcourse);
                    eclipseData.RealECList = ECList;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error launching Eclipse - " + e.ToString());
            }

            return eclipseData;
        }

    */

        // A lot of the plan check methods are going to require the same information, and it is inefficient to do all the work to acquire them everytime (which may be a lot of work for certain things), so there is a utility method here which is going to gather a lot of the information we'll need 







    }
}
