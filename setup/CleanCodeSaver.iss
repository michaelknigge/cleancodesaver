[Setup]
AppName=CleanCodeSaver
AppVerName=CleanCodeSaver 1.0
AppVersion=1.0
AppContact=michael.knigge@gmx.de
AppPublisher=Michael Knigge
AppPublisherURL=http://cleancodesaver.sourceforge.net/

DefaultDirName={pf}\CleanCodeSaver
DefaultGroupName=CleanCodeSaver

[Files]
Source: "src\bin\Release\CleanCodeSaver.exe"; DestDir: "{sys}"
Source: "xml\CleanCodeSaver-DE.xml";          DestDir: "{sys}";  DestName: "CleanCodeSaver.xml"
