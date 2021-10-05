using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

using Xceed.Words.NET;
using Spire.Doc;
using Spire.Doc.Documents;

namespace PLANCHECK
{
    //So this is a class that is used to both read in all the info we want from the PCTPN document
    //and then store all that info in one object in order to easily return it to the main program.
    //Having a class to deal with all this stuff makes it easier in the rest of the program.

    //So, the PCTPNparse class contains variables used to store information from the PCTPN.
    //It has a default constructor method that takes no parameters which we use to simply make empty objects of it
    //There is then an overloaded constructor method which takes an MRN string as a parameter. This constructor method has all
    //of the code for opening and reading info from the PCPTN. It then stores this info in its internal variables and returns the PCTPNparse object with all this information.
    //The contructor method also deletes the txt files of the PCTPN made by DocCheck so they don't get overridden all the time.
  
    public class PCTPNparse
    {
        //These are variables for all the info we are reading in from the PCPTN
        public string Diagnosis { get; set; }
        public string CourseObjective { get; set; }
        public string Site { get; set; }
        public string TreatmentPosition { get; set; }
        public string TotalDose { get; set; }
        public string Fractions { get; set; }
        public string TreatmentTechnique { get; set; }
        public string TargetAnatomy { get; set; }
        public string TargetAnatomyVerif { get; set; }
        public string CDTargetAnatomy { get; set; }
        public string AlternateImagingTargetAnatomy { get; set; }
        public string IGRTFreq2 { get; set; }
        public string StereotacticImagingFreq2 { get; set; }
        public string CustomImagingShift1 { get; set; }
        public string CustomImagingShift2 { get; set; }
        public string CustomImagingShift3 { get; set; }
        public string CustomImagingShift4 { get; set; }
        public string CustomImagingShift5 { get; set; }
        public string CustomImagingShift6 { get; set; }
        public string PrimaryImagingModality { get; set; }
        public string AlternateImagingModality { get; set; }
        public string IGRTImagingFreq { get; set; }
        public string StereotacticImagingFreq { get; set; }
        public string StandardImageSize1 { get; set; }
        public string StandardImageSize2 { get; set; }
        public string StandardImageSize3 { get; set; }
        public string StandardImageSize4 { get; set; }
        public string ConvTreat { get; set; }
        public string SRSTreat { get; set; }
        public bool SurfaceGuidedImaging { get; set; }
        public bool StandardImaging { get; set; }
        public bool StereotacticBrainImaging { get; set; }
        public bool StereotacticBodyImagingLevel1 { get; set; }
        public bool StereotacticBodyImagingLevel2 { get; set; }
        public bool StereotacticBodyImagingLevel3 { get; set; }
        public bool CustomImaging { get; set; }
        public string Bolus { get; set; }
        public bool Pacemaker { get; set; }
        public string ResearchProtocol { get; set; }
        public string FusionSeries1 { get; set; }
        public string FusionSeries2 { get; set; }
        public string SpecialMeasurementRequest { get; set; }
        public string SpecialCalculationRequest { get; set; }
        public string CTGuidance { get; set; }
        public string BladderInstructions { get; set; }
        public string ContrastRequested { get; set; }
        public string PreviousTreatment { get; set; }
        public string BrachytherapyApplicator { get; set; }
        public string SubsequentSims { get; set; }
        public string CustomImmobilization { get; set; }
        public string Markers { get; set; }
        public string Chemo { get; set; }
        public string Immunotherapy { get; set; }
        public string HormoneTherapy { get; set; }
        public string Fusion1 { get; set; }
        public string Fusion2 { get; set; }
        public string PreviousTreatmentOverlap { get; set; }
        public string SpecialPhysicsConsult { get; set; }
        public string SpecialTreatmentProcedure { get; set; }
        public string TreatmentSchedule { get; set; }
        public string FusionDate1 { get; set; }
        public string FusionDate2 { get; set; }
        public bool ResearchCheck { get; set; }
        public bool FusionCheck { get; set; }
        public bool FilmVerifyCheck { get; set; }
        public bool WeeklyFilmCheck { get; set; }
        public bool IGRTCheck { get; set; }

        public PCTPNparse()
        {
            //empty default constructor
        }

        public PCTPNparse(string MRN)
        {
            //MessageBox.Show("START PCPTN Constructor");
            List<string> Files = Directory.EnumerateFiles(@"\\wvariafssp01ss\VA_DATA$\ProgramData\Vision\DocChecks").ToList();
            List<string> PCTPNs = Files.FindAll(s => s.Contains(MRN + "_PCTPN_"));

            //So first we need to find the most recent version of this particular PCTPN document, since every revision to the ARIA document is saved as a separate Word file
            //in the documents folder on the ARIA file server.

            //DocCheck generates txt files for all the revisions of the PCPTN. DocCheck puts the DateTime of the file on the first line.
            //Here, we determine which one is the most recent and that we actually want to use.
            //DocCheck puts the original filepath of the PCTPN form the ARIA docuemnts folder on the third line, that way we have the path top open the
            //most recent document once we figure out which one it is.

            int count = 0;
            string date = null;
            string origfilepath = null; 
            List<DateTime> dates = new List<DateTime>();
            foreach(string str in PCTPNs)
            {
                using (StreamReader Lread = File.OpenText(str))
                {
                    date = Lread.ReadLine();
                    dates.Add(Convert.ToDateTime(date));
                    Lread.ReadLine();
                    origfilepath = Lread.ReadLine();
                }
            }

            DateTime MostRecentDate = dates.Max();
            int MostRecentInd = dates.IndexOf(MostRecentDate);

            //So, because almost all the information in the PCTPN doc is in Content Controls, I use a library called Spire.Doc to read the docx PCTPN document.
            //With the Spire.Doc library, we can identify the Content Controls and then read the selections the MD has made in them.

            //However, one thing that isn't in a Content Control that we don't have yet in Eclipse is the Diagnosis, which apparently is somehow pulled in from ARIA
            //when the Docuemt is made. This is normal text, so we simply read it in from the txt file that DocCheck made with a StreamReader.

            //MessageBox.Show("The most recent PCTPN document has a datetime of: " + MostRecentDate);

            string PCTPN = PCTPNs[MostRecentInd];

            //MessageBox.Show("PCTPN Name: " + PCTPN);

            string line = null;
            int tempind = 0;
            string tempstr = null;
            using (StreamReader Lread = File.OpenText(PCTPN))
            {
                while ((line = Lread.ReadLine()) != "END")
                {
                    if(line.StartsWith("Diagnosis:"))
                    {
                        tempind = line.IndexOf(":");
                        tempstr = line.Substring(tempind + 1);
                        Diagnosis = tempstr;
                        break;
                        // break because all we are using the line by line read for right now is the diagnosis
                    }
                }
            }

           //Now we use Spire to read the actual docx document. Spire's object model is somewhat frustrating, but it does work.
           // MessageBox.Show("Start Spire Read.");
            try
            {
                Section S;
                Paragraph P;
                Spire.Doc.Interface.ITable T;
                TableRow R;
                TableCell C;
                DocumentObject dobj;
                StructureDocumentTagInline sd;
                SdtText txtbox;
                SdtDropDownList dropdown;
                SdtCheckBox chbox;
                SdtDate datepick;
                string content;
                string tag;

                //So Content Controls in a Word doc are represented by "StructureDocumentTagInline" objects in the Spire.Doc object model.
                //We want to find these objects and then get the information contained in them, as that represents the selections the user has made in all the
                //Content Controls in the PCPTN. The TagInline objects are accessed from a "ChildObjects" collection, and are only found within paragraph objects,
                //or more specifically by accessing the ChildObjects collection of a paragraph object. This is confusing because all of the objects in the Spire.Doc
                //model have a ChildObjects collection that contain a bunch of things, but TagInlines only show up in paragraphs.

                //Documents in the Spire.Doc object model are made up of sections, which represent like section breaks.
                //Sections then contain paragraphs that represent normal text in the word document. Some of the information in the PCTPN are in Tables in the word doc,
                //but the info that is just normal text in the word doc can be accessed through first iterating through the sections in the docment,
                //and then iterating through the paragraphs in each section, and then searching each paragraph for the TagInlineObjects. this is done below.

                using (Document doc = new Document(origfilepath))
                {
                    for (int i = 0; i < doc.Sections.Count; i++)
                    {
                        S = doc.Sections[i];
                        for (int k = 0; k < S.Paragraphs.Count; k++)
                        {
                            P = S.Paragraphs[k];
                            for (int j = 0; j < P.ChildObjects.Count; j++)
                            {
                                dobj = P.ChildObjects[j];
                                if (dobj.DocumentObjectType == DocumentObjectType.StructureDocumentTagInline)
                                {
                                    sd = (StructureDocumentTagInline)dobj;
                                    if (sd.SDTProperties.SDTType == SdtType.Text)
                                    {
                                        tag = sd.SDTProperties.Tag;
                                        content = sd.SDTContent.Text;
                                        //MessageBox.Show("Paragraph loop, Text type");
                                        //MessageBox.Show("SDT Text Tag: " + tag);
                                        //MessageBox.Show("SDT Text Text: " + content);

                                        switch (tag)
                                        {
                                            case "TotalDose":
                                                TotalDose = content;
                                                break;
                                            case "Fractions":
                                                Fractions = content;
                                                break;
                                            case "TargetAnatomy":
                                                TargetAnatomy = content;
                                                break;
                                            case "TargetAnatomy2":
                                                TargetAnatomyVerif = content;
                                                break;
                                            case "CDTargetAnatomy":
                                                CDTargetAnatomy = content;
                                                break;
                                            case "TargetAnatomy3":
                                                AlternateImagingTargetAnatomy = content;
                                                break;
                                            case "IGRTImagingFreq2":
                                                IGRTFreq2 = content;
                                                break;
                                            case "StereotacticImagingFreq2":
                                                StereotacticImagingFreq2 = content;
                                                break;
                                            case "Custom1":
                                                CustomImagingShift1 = content;
                                                break;
                                            case "Custom2":
                                                CustomImagingShift2 = content;
                                                break;
                                            case "Custom3":
                                                CustomImagingShift3 = content;
                                                break;
                                            case "Custom4":
                                                CustomImagingShift4 = content;
                                                break;
                                            case "Custom5":
                                                CustomImagingShift5 = content;
                                                break;
                                            case "Custom6":
                                                CustomImagingShift6 = content;
                                                break;
                                        }
                                    }
                                    else if (sd.SDTProperties.SDTType == SdtType.DropDownList)
                                    {
                                        tag = sd.SDTProperties.Tag;
                                        content = sd.SDTContent.Text;
                                        //MessageBox.Show("Paragraph loop, DropDownList type");
                                        //MessageBox.Show("SDT dropdown Tag: " + tag);
                                        //MessageBox.Show("SDT dropdown Text: " + content);

                                        switch (tag)
                                        {
                                            case "CourseDropDown":
                                                CourseObjective = content;
                                                break;
                                            case "TreatmentTechnique":
                                                TreatmentTechnique = content;
                                                break;
                                            case "PrimaryImagingModality":
                                                PrimaryImagingModality = content;
                                                break;
                                            case "AlternateImagingModality":
                                                AlternateImagingModality = content;
                                                break;
                                            case "IGRTImagingFreq":
                                                IGRTImagingFreq = content;
                                                break;
                                            case "StereotacticImagingFreq":
                                                StereotacticImagingFreq = content;
                                                break;
                                            case "StandardImageSize1":
                                                StandardImageSize1 = content;
                                                break;
                                            case "StandardImageSize2":
                                                StandardImageSize2 = content;
                                                break;
                                            case "StandardImageSize3":
                                                StandardImageSize3 = content;
                                                break;
                                            case "StandardImageSize4":
                                                StandardImageSize4 = content;
                                                break;
                                            case "ConvTreat":
                                                ConvTreat = content;
                                                break;
                                            case "SRSTreat":
                                                SRSTreat = content;
                                                break;
                                        }
                                    }
                                    else if (sd.SDTProperties.SDTType == SdtType.CheckBox)
                                    {
                                        tag = sd.SDTProperties.Tag;
                                        content = sd.SDTContent.Text;

                                        //MessageBox.Show("Paragraph loop, CheckBox type");
                                        //MessageBox.Show("SDT  Tag: " + tag);
                                        //MessageBox.Show("SDT Text: " + content);

                                        switch (tag)
                                        {
                                            case "PrimaryImagingModalityCheck":
                                                if (content == "\u2610")
                                                {
                                                    //unchecked box
                                                    SurfaceGuidedImaging = true;
                                                }
                                                else if (content == "\u2611")
                                                {
                                                    //checked box
                                                    SurfaceGuidedImaging = false;
                                                }
                                                break;
                                            case "StandardImagingCheck":
                                                if (content == "\u2610")
                                                {
                                                    //unchecked box
                                                    StandardImaging = true;
                                                }
                                                else if (content == "\u2611")
                                                {
                                                    //checked box
                                                    StandardImaging = false;
                                                }
                                                break;
                                            case "StereotacticBrainCheck":
                                                if (content == "\u2610")
                                                {
                                                    //unchecked box
                                                    StereotacticBrainImaging = true;
                                                }
                                                else if (content == "\u2611")
                                                {
                                                    //checked box
                                                    StereotacticBrainImaging = false;
                                                }
                                                break;
                                            case "Level1Check":
                                                if (content == "\u2610")
                                                {
                                                    //unchecked box
                                                    StereotacticBodyImagingLevel1 = true;
                                                }
                                                else if (content == "\u2611")
                                                {
                                                    //checked box
                                                    StereotacticBodyImagingLevel1 = false;
                                                }
                                                break;
                                            case "Level2Check":
                                                if (content == "\u2610")
                                                {
                                                    //unchecked box
                                                    StereotacticBodyImagingLevel2 = true;
                                                }
                                                else if (content == "\u2611")
                                                {
                                                    //checked box
                                                    StereotacticBodyImagingLevel2 = false;
                                                }
                                                break;
                                            case "Level3Check":
                                                if (content == "\u2610")
                                                {
                                                    //unchecked box
                                                    StereotacticBodyImagingLevel3 = true;
                                                }
                                                else if (content == "\u2611")
                                                {
                                                    //checked box
                                                    StereotacticBodyImagingLevel3 = false;
                                                }
                                                break;
                                            case "CustomCheck":
                                                if (content == "\u2610")
                                                {
                                                    //unchecked box
                                                    CustomImaging = true;
                                                }
                                                else if (content == "\u2611")
                                                {
                                                    //checked box
                                                    CustomImaging = false;
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                        } //ends paragraph loop

                        //Remember there is also important information in the PCTPN that is kept in Tables, instead of just normal paragraphs
                        //Now that we are done finding all the TagInlineObjects for the paragraphs in the section (we are still in the section loop),
                        //we can now find the TagInline objects for the tables in this section.

                        //However, the Tables are more complicated. Tables are composed of Rows, which then have Cells. Each Cell contains a paragraph, which is just how Spire works.
                        //I don't know if all empty cells contain an empty paragraph object or what the deal is exactly, but the paragraph object inside each cell is where
                        //we will find the TagInline objects. unfortunatley it is neccessary to manually loop through these layers of object hierarchy; there is no top-down
                        //easy way way to find all the TagInlines in a Document object that I found.
                        //So, that is what is going on below.

                        for(int t = 0; t < S.Tables.Count; t++)
                        {
                            //MessageBox.Show("Table: " + t);
                            T = S.Tables[t];
                            for(int r = 0; r < T.Rows.Count; r++)
                            {
                                //MessageBox.Show("Row: " + r);
                                R = T.Rows[r];
                                for(int c = 0; c < R.Cells.Count; c++)
                                {
                                    //MessageBox.Show("Cell: " + c );
                                    C = R.Cells[c];
                                    for(int p = 0; p < C.Paragraphs.Count; p++)
                                    {
                                        //MessageBox.Show("Paragraph: " + p);
                                        P = C.Paragraphs[p];
                                        for (int j = 0; j < P.ChildObjects.Count; j++)
                                        {
                                            dobj = P.ChildObjects[j];
                                            //MessageBox.Show("DocumentObject: " + j + ". DocumentObjectType: " + dobj.DocumentObjectType.ToString());
                                            if (dobj.DocumentObjectType == DocumentObjectType.StructureDocumentTagInline)
                                            {
                                                //MessageBox.Show("TagInline Trigger");
                                                sd = (StructureDocumentTagInline)dobj;
                                                if (sd.SDTProperties.SDTType == SdtType.Text)
                                                {
                                                    tag = sd.SDTProperties.Tag;
                                                    content = sd.SDTContent.Text;
                                                    //MessageBox.Show("Table loop, Text type");
                                                    //MessageBox.Show("SDT Text Tag: " + tag);
                                                    //MessageBox.Show("SDT Text Text: " + content);

                                                    switch (tag)
                                                    {
                                                        case "Site":
                                                            Site = content;
                                                            //MessageBox.Show("SDT Text Text SITE: " + content);
                                                            break;
                                                        case "Research":
                                                            ResearchProtocol = content;
                                                            break;
                                                        case "FusionSeries1":
                                                            FusionSeries1 = content;
                                                            break;
                                                        case "FusionSeries2":
                                                            FusionSeries2 = content;
                                                            break;
                                                        case "SpecMeas":
                                                            SpecialMeasurementRequest = content;
                                                            break;
                                                        case "SpecCalc":
                                                            SpecialCalculationRequest = content;
                                                            break;
                                                    }
                                                }
                                                else if (sd.SDTProperties.SDTType == SdtType.DropDownList)
                                                {
                                                    tag = sd.SDTProperties.Tag;
                                                    content = sd.SDTContent.Text;
                                                    //MessageBox.Show("Table loop, DropDownList type");
                                                    //MessageBox.Show("SDT dropdown Tag: " + tag);
                                                    //MessageBox.Show("SDT dropdown Text: " + content);

                                                    switch (tag)
                                                    {
                                                        case "CourseDropDown":
                                                            CourseObjective = content;
                                                            break;
                                                        case "CTGuidance":
                                                            CTGuidance = content;
                                                            break;
                                                        case "BladderInstructions":
                                                            BladderInstructions = content;
                                                            break;
                                                        case "Contrast":
                                                            ContrastRequested = content;
                                                            break;
                                                        case "PrevTreat":
                                                            PreviousTreatment = content;
                                                            break;
                                                        case "Brachy":
                                                            BrachytherapyApplicator = content;
                                                            break;
                                                        case "Sims":
                                                            SubsequentSims = content;
                                                            break;
                                                        case "PatientPosition":
                                                            TreatmentPosition = content;
                                                            break;
                                                        case "Custom Immobilization":
                                                            CustomImmobilization = content;
                                                            break;
                                                        case "Markers":
                                                            Markers = content;
                                                            break;
                                                        case "Bolus":
                                                            Bolus = content;
                                                            break;
                                                        case "Chemo":
                                                            Chemo = content;
                                                            break;
                                                        case "Immunotherapy":
                                                            Immunotherapy = content;
                                                            break;
                                                        case "HormoneTherapy":
                                                            HormoneTherapy = content;
                                                            break;
                                                        case "Fusion1":
                                                            Fusion1 = content;
                                                            break;
                                                        case "Fusion2":
                                                            Fusion2 = content;
                                                            break;
                                                        case "PrevTreatOv":
                                                            PreviousTreatmentOverlap = content;
                                                            break;
                                                        case "SpecPhysicsConsult":
                                                            SpecialPhysicsConsult = content;
                                                            break;
                                                        case "SpecTreatPro":
                                                            SpecialTreatmentProcedure = content;
                                                            break;
                                                        case "TreatSched":
                                                            TreatmentSchedule = content;
                                                            break;
                                                    }
                                                }
                                                else if (sd.SDTProperties.SDTType == SdtType.DatePicker)
                                                {
                                                    tag = sd.SDTProperties.Tag;
                                                    content = sd.SDTContent.Text;
                                                    //MessageBox.Show("Table loop, DatePicker type");
                                                    //MessageBox.Show("SDT Tag: " + tag);
                                                    //MessageBox.Show("SDT Text: " + content);

                                                    switch (tag)
                                                    {
                                                        case "FusionDate1":
                                                            FusionDate1 = content;
                                                            break;
                                                        case "FusionDate2":
                                                            FusionDate2 = content;
                                                            break;
                                                    }
                                                }
                                                else if (sd.SDTProperties.SDTType == SdtType.CheckBox)
                                                {
                                                    tag = sd.SDTProperties.Tag;
                                                    content = sd.SDTContent.Text;

                                                    //MessageBox.Show("Table loop, CheckBox type");
                                                    //MessageBox.Show("SDT dropdown Tag: " + tag);
                                                    //MessageBox.Show("SDT dropdown Text: " + content);

                                                    switch (tag)
                                                    {
                                                        case "PacemakerCheck":
                                                            if (content == "\u2610")
                                                            {
                                                                //unchecked box
                                                                Pacemaker = true;
                                                            }
                                                            else if (content == "\u2611")
                                                            {
                                                                //checked box
                                                                Pacemaker = false;
                                                            }
                                                            break;
                                                        case "ResearchCheck":
                                                            if (content == "\u2610")
                                                            {
                                                                //unchecked box
                                                                ResearchCheck = true;
                                                            }
                                                            else if (content == "\u2611")
                                                            {
                                                                //checked box
                                                                ResearchCheck = false;
                                                            }
                                                            break;
                                                        case "FusionCheck":
                                                            if (content == "\u2610")
                                                            {
                                                                //unchecked box
                                                                FusionCheck = true;
                                                            }
                                                            else if (content == "\u2611")
                                                            {
                                                                //checked box
                                                                FusionCheck = false;
                                                            }
                                                            break;
                                                        case "PortFilmVerifyCheck":
                                                            if (content == "\u2610")
                                                            {
                                                                //unchecked box
                                                                FilmVerifyCheck = true;
                                                            }
                                                            else if (content == "\u2611")
                                                            {
                                                                //checked box
                                                                FilmVerifyCheck = false;
                                                            }
                                                            break;
                                                        case "WeeklyFilmCheck":
                                                            if (content == "\u2610")
                                                            {
                                                                //unchecked box
                                                                WeeklyFilmCheck = true;
                                                            }
                                                            else if (content == "\u2611")
                                                            {
                                                                //checked box
                                                                WeeklyFilmCheck = false;
                                                            }
                                                            break;
                                                        case "IGRTCheck":
                                                            if (content == "\u2610")
                                                            {
                                                                //unchecked box
                                                                IGRTCheck = true;
                                                            }
                                                            else if (content == "\u2611")
                                                            {
                                                                //checked box
                                                                IGRTCheck = false;
                                                            }
                                                            break;
                                                    }
                                                }
                                            }
                                        }//end Child Object loop
                                    }//end paragraph loop
                                }//end cell loop
                            }//end row loop
                        }//end table loop
                        
                        //Now that we are done with the normal paragraphs and the tables, we end the section loop

                    }//end section loop

                } //close document

                //delete the relevant text documents so they don't get overwritten every time.
                foreach (string str in PCTPNs)
                {
                    File.Delete(str);
                }

            }
            catch(Exception e)
            {
                MessageBox.Show("PCTPNparse error reading .docx with spire library.\n\n" + e.ToString() + "\n\n" + e.Message + "\n\n" + e.StackTrace);
            }


           // MessageBox.Show("Done with PCTPNparse");
            return;
        } //end constructor method

    }

}
