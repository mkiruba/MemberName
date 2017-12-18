# MemberName

This is a document level addin for Word. It works in both Word 2013 and Word 2016.

The requirements are 

a) The picker should be able to be triggered via keyboard shortcut (e.g. Ctrl+m), and by clicking an icon.  

b)	The picker interface should be able to be intuitively controlled entirely via the keyboard.

c)	The user should be able to search through the list of current Members by typing part of the Member’s name or their constituency and select their chosen Member.  

d)	Following the pattern: Question - Answer, once a Member is selected the appropriate contribution type should be automatically selected (the user must be able to override this selection).  For example, if the picker was previously used to insert a Question contribution type, then the picker should default to the Answer contribution type when the answering Member is inserted.  

e)	Once the user selects a Member the Member’s name and contribution type should be clearly visible in the document at the current cursor position, and the document should be ready for text to be entered at that point.

f)	The first time a Member contributes to a debate their name should be followed by their constituency and party in brackets (e.g. “Member Name (Constituency) (Party)”); otherwise just the Member’s name should show.

g)	If the picker is triggered while the cursor is on a Member’s name, then it should default to show the corresponding Member name and contribution type and update that Member’s name accordingly.

#Installation

Please go to [release](https://github.com/mkiruba/MemberName/releases) folder and download and extract the Release.zip.

Open the MemberName.docm file.
If you see the yellow bar in the Word with "SECURITY WARNING Macros have been disabled.". Click enable content.(This is needed to enable the addin.)

Once you enable the addin a new tab "Member" appears.

#Acceptance Tests
