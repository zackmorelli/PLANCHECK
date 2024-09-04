# Plancheck

This program is for use with ARIA/Eclipse, which is a commerical radiation treatment planning software suite made by Varian Medical Systems which is used in Radiation Oncology. This is one of several programs which I have made while working in the Radiation Oncology department at Lahey Hospital and Medical Center in Burlington, MA. I have licensed it under GPL V3 so it is open-source and publicly.

There is also a .docx README file in the repo that describes what the program does and how it is organized.

Plancheck is an EBRT (External Beam Radiation Therapy) plan quality and safety check program for use with ARIA/Eclipse systems. Plancheck can run on its own as an Eclipse script, but it’s modular backend allows it to be easily used by other programs as well. It also produces PDF reports of all the checks it performs.

The Plancheck repository has three projects. The solution file contains the PLANCHECK and PLANCHECK_SCRIPT projects, while the PLANCHECK_STANDALONE is in the repo separately alongside the Plancheck solution.

The PLANCHECK project is the modular backend of Plancheck which performs all the quality and safety checks and produces PDF reports. It can be used by other programs as a compiled library.

PLANCHECK_SCRIPT is an Eclipse Scripting API (ESAPI) script which calls the Plancheck backend from Eclipse, for a particular Radiation Treatment (RT) plan. The script passes information about the RT plan to the plancheck backend.

PLANCHECK_STANDALONE is an older standalone version of plancheck which runs outside of Eclipse. This program actually runs plancheck against many RT plans at once; whatever falls within the provided date range. PLANCHECK_STANDALONE accesses Eclipse and makes queries against the ARIA variansystem database to gather information about each RT plan that falls within the provided date range, and then calls the plancheck backend using a compiled class library of the PLANCHECK project that is kept in the PLANCHECK_STANDALONE project. This standalone version of plancheck is very useful because it can be used to quickly check all RT plans that a clinic has scheduled next week, for example, very quickly and all at once.

Plancheck is a back-end program/class library that contains and executes all of the actually plan checks. It uses a custom PLAN class. Other programs call Plancheck and pass it a PLAN object for it to use in executing the Plancheck program. This modular design makes it easier to use Plancheck in different places.

Part of the reason I did this is because of the standalone program that used Plancheck as well as the Eclipse script. The standalone plancheck program was capable of running checks on many patients at once back when the plancheck program was much smaller and organized differently. However I greatly reorganized the program (as I’ve done many times with many of my programs) when I moved to the more modular organization and started adding a lot more checks. I didn’t get to refactoring the separate standalone program using the current organization of plancheck because I was still working on adding new features to it, with the Document Check module being the latest thing. 

It is important to note that you need the PatientScansOCRBackground worker program (a separate repo) to be running in order for the Document Check module in Plancheck to work. Refer to the read me about that program for more information.
Plancheck can also be called by Tiamat (a separate repo that attempts to semi-automate RT plan creation), although not in its current state, but the code is there. 
	
Plancheck has a lot of different checks that it does, but I’m not going to go into detail on them. It is pretty easy to read through the source code to read them all, especially since Plancheck is a back-end program which has a lot of the bloat removed.

Please note that the “ARIA_QUERY” folder is a generated Entity Framework DB model of the ARIA variansystem DB, however the plancheck program does not use it.

