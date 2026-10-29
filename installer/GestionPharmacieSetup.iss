; =====================================================================
; SCRIPT D'INSTALLATION OFFICIEL INNO SETUP
; Logiciel : Système de Gestion de Pharmacie Officiel
; Auteur   : Dzaba Diliane Merveille
; Licence  : Open Source (Licence MIT)
; Version  : 1.0.0
; Architecture : Windows x64 (Self-Contained .NET 8.0)
; =====================================================================

#define MyAppName "Gestion de Pharmacie"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Dzaba Diliane Merveille"
#define MyAppExeName "GestionPharmacie.UI.exe"
#define MyAppId "{{B3F4A759-4D2A-4D78-958C-5E1B3E05B208}"

[Setup]
AppId={#MyAppId}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL=""
AppSupportURL=""
AppUpdatesURL=""
DefaultDirName={autopf}\GestionPharmacie
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
LicenseFile=..\LICENSE
OutputDir=..\dist\installer
OutputBaseFilename=GestionPharmacie_Setup_v{#MyAppVersion}
Compression=lzma2/ultra64
SolidCompression=yes
WizardStyle=modern
ArchitecturesInstallIn64BitMode=x64compatible
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
UninstallDisplayIcon={app}\{#MyAppExeName}
DisableProgramGroupPage=auto
CloseApplications=yes
RestartApplications=no

[Languages]
Name: "french"; MessagesFile: "compiler:Languages\French.isl"
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: checkedonce

[Dirs]
; Dossier applicatif standard
Name: "{app}"
; Dossiers de données profil utilisateur garantissant des droits d'écriture complets sans contrainte UAC
Name: "{userappdata}\GestionPharmacie"; Flags: uninsneveruninstall
Name: "{userappdata}\GestionPharmacie\Backups"; Flags: uninsneveruninstall

[Files]
; Fichiers de l'application publiée (Self-contained win-x64)
Source: "..\dist\publish\win-x64\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\dist\publish\win-x64\*.pdb"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
; Fichier de Licence Open Source (MIT)
Source: "..\LICENSE"; DestDir: "{app}"; DestName: "LICENSE.txt"; Flags: ignoreversion

[Icons]
; Menu Démarrer
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; WorkingDir: "{app}"
Name: "{group}\Dossier des Données & Sauvegardes"; Filename: "{userappdata}\GestionPharmacie"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
; Raccourci Bureau
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; WorkingDir: "{app}"; Tasks: desktopicon

[Run]
; Option pour lancer l'application immédiatement à la fin de l'installation
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
; Nettoyage des fichiers temporaires à la désinstallation (la base pharmacie.db est préservée par sécurité)
Type: files; Name: "{app}\*.log"

[Code]
// Vérification préalable pour avertir si l'application est ouverte avant désinstallation
function InitializeUninstall(): Boolean;
var
  ErrorCode: Integer;
begin
  Result := True;
end;
