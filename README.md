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
### Download and Extract Releases
Please go to [release](https://github.com/mkiruba/MemberName/releases) folder and download and extract the Release.zip.

![Alt text](images/fileexplorer.png?raw=true "FileExplorer")

### Install certificates
Office application allows only the trusted addins to be installed, so the following steps needs to be done.
1. Right click on MemberNameCertificate in the extracted releases folder and choose Install Certificate.
![Alt text](images/cert1.png?raw=true "Warning")
2. Certification Import wizard appears, choose Current user and click next.
![Alt text](images/cert2.png?raw=true "Warning")
3. Choose Place all certificates in the following store.
4. Browse and choose Trusted Root Certification Authorities, then click next and finish.
![Alt text](images/cert3.png?raw=true "Warning")
5. Click Yes for security warning to install the certificate.

### Add trusted location
1. If you see the error message as below when you try opening MemberName.docm. It means the location is not trusted.
![Alt text](images/certwarn.png?raw=true "Warning")
2. To add the trusted location, Open Word, then click on File menu and Options.

3. Select Trust Center in the left hand side and click on the button Trust Center Settings button in the right side pane.
![Alt text](images/trust1.png?raw=true "Warning")
4. Trust Center window opens up, now choose Trusted Locations on the left and choose Add new location on the bottom right.
![Alt text](images/trust2.png?raw=true "Warning")
5. This opens up another window, browse and choose the releases extracted folder location.
6. Make sure Subfolders of this location are also trusted is checked.
7. Click ok and ok on all other windows and close them.

### Open the customized document
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
