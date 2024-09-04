# Plancheck

Zackary Morelli
1/17/2022
zackmorelli@gmail.com

Eclipse Scripting API (ESAPI) script with modular backend.

Plancheck is an External Beam Radiation Treatment (EBRT) plan quality and safety check program that I made. It is structured a little differently than my other ESAPI programs. The VS solution in this folder actually has two projects, Plancheck and Plancheck_Script. Plancheck is a back-end program/class library that contains and executes all of the actual plan checks. It uses a custom PLAN class that I made. Other programs call Plancheck and pass it a PLAN object for it to use in executing the Plancheck program. This modular design makes it easier to use Plancheck in different places. Part of the reason I did this was because I meant to make a standalone program that used Plancheck as well as an Eclipse script. I actually had a standalone plancheck program that was capable of running checks on many patients at once when the plancheck program was much smaller and organized differently. However I greatly reorganized the program (as I’ve done many times with many of my programs) when I moved to the more modular organization and started adding a lot more checks. I didn’t get to making a separate standalone program using the current organization of plancheck because I was still working on adding things to it, with the Document Check module being the latest thing. It is important to note that you need the PatientScansOCRBackground worker program to be running in order for the Document check module in Plancheck to work. Refer to the read me about that program for more information.

Plancheck_Script is an Eclipse script which passes through information in a plan and creates a custom PLAN object out of it, and then spins up a separate task where it calls Placncheck and passes the PLAN object to it. Plancheck can also be called by Tiamat, although not in its current state, but the code is there. 
	
Plancheck has a lot of different checks that it does, but I’m not going to go into detail on them. It is pretty easy to read through the source code to read them all, especially since Plancheck is a back-end program which has a lot of the bloat removed. In any case, Plancheck will be replaced by Radformation’s scripts which do the same thing with a better interface, and more tests.

