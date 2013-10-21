[Setup]
AppName=CleanCodeSaver
AppVerName=CleanCodeSaver 1.0
AppVersion=1.0
AppContact=michael.knigge@gmx.de
AppPublisher=Michael Knigge
AppPublisherURL=http://cleancodesaver.sourceforge.net/

DefaultDirName={pf}\CleanCodeSaver
DefaultGroupName=CleanCodeSaver

OutputBaseFilename=CleanCodeSaver-Setup
OutputDir=.

[Languages]
Name: en; MessagesFile: "compiler:Default.isl"
Name: de; MessagesFile: "compiler:Languages\German.isl"

[Messages]
en.BeveledLabel=English
de.BeveledLabel=Deutsch

[Files]
Source: "README-DE.txt";                         DestDir: "{app}"; DestName: "README.txt"; Languages: de; Flags: isreadme
Source: "README-EN.txt";                         DestDir: "{app}"; DestName: "README.txt"; Languages: en; Flags: isreadme
Source: "..\xml\CleanCodeSaver.xsd";             DestDir: "{app}";

Source: "..\src\bin\Release\CleanCodeSaver.exe"; DestDir: "{sys}"; DestName: "CleanCodeSaver.scr"
Source: "..\xml\CleanCodeSaver-DE.xml";          DestDir: "{sys}"; DestName: "CleanCodeSaver.xml"; Languages: de
Source: "..\xml\CleanCodeSaver-EN.xml";          DestDir: "{sys}"; DestName: "CleanCodeSaver.xml"; Languages: en
