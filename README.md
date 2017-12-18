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

## Installation

Please go to [release](https://github.com/mkiruba/MemberName/releases) folder and download and extract the Release.zip.

![Alt text](images/fileexplorer.png?raw=true "FileExplorer")

Open the MemberName.docm file.
If you see the yellow bar in the Word with "SECURITY WARNING Macros have been disabled.". Click enable content.(This is needed to enable the addin.)

![Alt text](images/warning.png?raw=true "Warning")

Once you enable the addin a new tab "Member" appears.

![Alt text](images/tab.png?raw=true "Tab")

## Acceptance Tests

- [x] Ticker should be triggered by clicking an icon and via keyboard shortcut(ctrl + m).
![Alt text](images/gifs/ButtonClick.gif?raw=true "ButtonClick")

![Alt text](images/gifs/shortcut.gif?raw=true "ButtonClick")

- [x] Pressing Alt key highlights shortcut keys and the tab order is sequenced.
![Alt text](images/gifs/keyboard.gif?raw=true "ButtonClick")

- [x] Initial load does not have any members, but as soon user types in the members are populated based on the match with name and constituency.
![Alt text](images/gifs/memberselect.gif?raw=true "ButtonClick")
- [x] When Question is inserted then selecting member next time it will default to answer. Users are allowed to change this behaviour.
![Alt text](images/gifs/Answerdefault.gif?raw=true "ButtonClick")
- [x] Member and the contribution types are entered at the cursor location.

- [x] First time the member is inserted as "Member Name (Constituency) (Party): " and then onwards "Member Name: "
![Alt text](images/gifs/shortname.gif?raw=true "ButtonClick")

- [x] If insert member is triggered with cursor in the member name control, the insert member defaults to the selected member.
![Alt text](images/gifs/getselection.gif?raw=true "ButtonClick")
