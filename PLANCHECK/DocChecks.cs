using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


using Xceed.Document.NET;
using Xceed.Words.NET;
using System.Diagnostics;

namespace PLANCHECK
{
    public class DocChecks
    {
        //So DocChecks is a class used to find the PCTPN for the plan that Plancheck is running on.
        //The variables below are used to indicate which eocuments have been identified. Originally the idea was it would find the treatment consent
        //and HIPPA Consent documents as well, but currently it just finds the PCPTN.
        //So the DocCheck object is very simple, it just contains bools inidicating what it has found.

        //Their is a default constructor method which just makes a DocCheck object where eveything is set to false.
        //The overloaded constructor method which requires the plan creation DateTime and the patient's MRN contains the code for finding the PCTPN document,
        //and then assigns a value to the "PCTPNpresent" bool and returns a DocCheck Object.

        //The overloaded constructor method takes the docx PCTPN document (assuming it finds it) and makes a txt document out of it.
        //The PCTPNparse class then uses these txt docs to extract the info from the PCTPN.

        public bool PCTPNpresent { get; set; }
        public bool HIPAApresent { get; set; }
        public bool CONSENTpresent { get; set; }


        public DocChecks()
        {
            PCTPNpresent = false;
            HIPAApresent = false;
            CONSENTpresent = false;
        }

        public DocChecks(DateTime plancreation, string MRN)
        {
            //So DocCheck conducts a SQL Query of the ARIA SQL database to construct a list of all the docx or docm files in the documents folder of the ARIA file server
            //that have been modified within 8 days of the creations DatTime of the plan. This is why a user of the DocCheck module needs Database access.

            //A .NET library for reading Word documents call DocX is then used to open every one of these files to ascertain if it is for the patient in question and a PCTPN document.
            //If it is, a simple txt file is written out which starts with the modification DateTime of the document and its filepath in the documents folder.
            //Then, the entirety of the PCTPNdocument is written out to the txt file.

            //Because every revision of a document in the ARIA document module results in separate files saved in the ARIA File Server's Documents folder,
            //most likely this will result in severla txt docs being made.

            //The PCTPNparse class will then read these text files and use the DateTime to figure out which one is the most recent, and then use the filepath provided
            //to open the original docx PCTPN document using a library (different than DocX) capable of reading Content Controls, which is where most of the info that
            //we are interested in in the PCTPN is kept.

            //DocCheck serves to keep the SQL query code contained within a relatively short method, while the complicated logic for picking apart the PCTPN document is
            //contained within PCTPNparse.

            //MessageBox.Show("DocCheck Start");
            PCTPNpresent = false;
            HIPAApresent = false;
            CONSENTpresent = false;

            List<string> FileNames = new List<string>();

            string ConnectionString = @"Data Source=WVARIASDBP01SS;Initial Catalog=VARIAN;Integrated Security=true;";

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand command;
            SqlDataReader datareader;
            string sql;

            DateTime eightdaysminus = plancreation.Subtract(new TimeSpan(8, 0, 0, 0));
            DateTime eightdaysplus = plancreation.AddDays(8.0);
            string SQL8pdays = eightdaysplus.ToString("MM/dd/yyyy");
            string SQL8mdays = eightdaysminus.ToString("MM/dd/yyyy");

            //MessageBox.Show("Before SQL");
            conn.Open();
            sql = "USE VARIAN SELECT FolderName1, FileName FROM dbo.FileLocation WHERE HstryDateTime BETWEEN '" + SQL8mdays + "' AND '" + SQL8pdays + "' AND (FileExtension = 'docx' OR FileExtension = 'docm')"; 
            command = new SqlCommand(sql, conn);
            datareader = command.ExecuteReader();

            string str = null;
            while (datareader.Read())
            {
                str = (datareader["FolderName1"] as string) + "\\" + (datareader["FileName"] as string);
                FileNames.Add(str);
            }
            conn.Close();
            //MessageBox.Show("After SQL");

            int PCTPNcount = 0;
            string doctext = null;
            DateTime DocMod;

            //MessageBox.Show("Filenames size: " + FileNames.Count);
            int count = 0;
            try
            {
                foreach (string fn in FileNames)
                {
                    DocMod = File.GetLastWriteTime(fn);
                    if (fn.EndsWith("docx") || fn.EndsWith("docm"))
                    {
                        using (DocX doc = DocX.Load(fn))
                        {
                            //So unfortunatley, although only one Document will be displayed in the Aria interface, the documents folder on the Aria File server actaully can contain
                            //multiple versions of the same document. Like if the Doctor makes changes to the PCTPN, there will be multiple versions of it saved on the file server.
                            //So we need to sort by datetime to get the most recent one. Ecspecially with the PCTPN, this is important.
                            doctext = doc.Text;
                            if (doctext.Contains("LC#: " + MRN))
                            {
                                if(doctext.Contains("Physician Clinical Treatment Planning Note"))
                                {
                                    PCTPNcount++;
                                    //MessageBox.Show("Document modification datetime is: " + DocMod);
                                    PCTPNpresent = true;
                                    //MessageBox.Show(fn);
                                    using (StreamWriter Lwrite = File.AppendText(@"\\wvariafssp01ss\VA_DATA$\ProgramData\Vision\DocChecks\" + MRN + "_PCTPN_" + PCTPNcount + ".txt"))
                                    {
                                        Lwrite.WriteLine(DocMod);
                                        Lwrite.WriteLine();
                                        Lwrite.WriteLine(fn);
                                        Lwrite.WriteLine();
                                        for (int i = 0; i < doc.Paragraphs.Count; i++)
                                        {
                                            //MessageBox.Show(doc.Paragraphs[i].Text);
                                            Lwrite.WriteLine(doc.Paragraphs[i].Text);
                                        }
                                        Lwrite.WriteLine();
                                        Lwrite.WriteLine("END");
                                    }
                                }
                            }
                        }
                    }
                   // else if (fn.EndsWith("pdf"))
                    //{
                        //System.Drawing.Image[] images;
                        //using (PdfDocument pdf = new PdfDocument(fn))
                        //{
                        //    images = pdf.Pages[0].ExtractImages();

                           
                        //}



                        ////we know each page only has one image, because it is a scan saved as a pdf
                        //string tesstext = null;
                        //System.Drawing.Image im = images[0];
                        //int k = fn.LastIndexOf("\\");
                        //string fname = fn.Substring(k);
                        //im.Save(@"\\wvariafssp01ss\VA_DATA$\ProgramData\Vision\DocChecks\Image" + fname);

                        //using (var engine = new TesseractEngine(@"\\wvariafssp01ss\VA_DATA$\ProgramData\Vision\PublishedScripts\tessdata", "eng", EngineMode.LstmOnly))
                        //{
                        //    Pix pix = Pix.LoadFromFile(@"\\wvariafssp01ss\VA_DATA$\ProgramData\Vision\DocChecks\Image" + fname);
                        //    using (var page = engine.Process(pix))
                        //    {
                        //        tesstext = page.GetText();
                        //    }
                        //}

                        //if (tesstext.Contains("MRN: " + MRN) || tesstext.Contains("LCN#: " + MRN))
                        //{
                        //    if(tesstext.Contains("HIPAA - PATIENT PRIVACY ACKNOWLEDGMENT STATEMENT"))
                        //    {
                        //        //telephone consent document
                        //        HIPAApresent = true;
                        //        //using (StreamWriter Lwrite = File.AppendText(@"\\wvariafssp01ss\VA_DATA$\ProgramData\Vision\DocChecks\TESSERACT_OUTPUT_HIPAA_" + pdfmod + ".txt"))
                        //        //{
                        //        //    Lwrite.Write(tesstext);
                        //        //}
                        //    }
                        //    else if(tesstext.Contains("CONSENT TO RADIOTHERAPY"))
                        //    {
                        //        //consent to treat document
                        //        CONSENTpresent = true;
                        //        //using (StreamWriter Lwrite = File.AppendText(@"\\wvariafssp01ss\VA_DATA$\ProgramData\Vision\DocChecks\TESSERACT_OUTPUT_CONSENT_" + pdfmod + ".txt"))
                        //        //{
                        //        //    Lwrite.Write(tesstext);
                        //        //}
                        //    }
                        //}
                    //}
                }
                count++;
            }
            catch (Exception e)
            {
                MessageBox.Show("Problem opening a patient document.\n\n" + e.ToString() + "\n\n" + e.StackTrace);
            }
        }
    }
}
