; Installer for wtranslu (fork of RSTGameTranslation), built with Inno Setup 6 by the release workflow:
;   iscc /DAppVersion=6.3 /DSourceDir=<folder with rst.exe> installer\wtranslu.iss
; Installs per user (no admin rights): RST writes its config, cache and logs next to rst.exe,
; which would fail under Program Files.

#ifndef AppVersion
  #define AppVersion "6.3"
#endif
#ifndef SourceDir
  #define SourceDir "..\dist\RSTGameTranslation"
#endif

[Setup]
AppId={{6F1C2A57-3B8E-4D2A-9E51-7C4B0D2A9F31}
AppName=wtranslu - RST Game Translation
AppVersion={#AppVersion}
AppVerName=wtranslu {#AppVersion}
AppPublisher=phat-05
AppPublisherURL=https://github.com/phat-05/wtranslu
AppSupportURL=https://github.com/phat-05/wtranslu/issues
AppUpdatesURL=https://github.com/phat-05/wtranslu/releases
DefaultDirName={localappdata}\Programs\wtranslu
DefaultGroupName=wtranslu
DisableProgramGroupPage=yes
PrivilegesRequired=lowest
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
OutputDir=..\dist
OutputBaseFilename=wtranslu-setup-{#AppVersion}
SetupIconFile=..\media\AppIcon.ico
UninstallDisplayIcon={app}\rst.exe
LicenseFile=..\LICENSE.md
Compression=lzma2
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Files]
Source: "{#SourceDir}\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\wtranslu"; Filename: "{app}\rst.exe"
Name: "{group}\{cm:UninstallProgram,wtranslu}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\wtranslu"; Filename: "{app}\rst.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\rst.exe"; Description: "{cm:LaunchProgram,wtranslu}"; Flags: nowait postinstall skipifsilent
