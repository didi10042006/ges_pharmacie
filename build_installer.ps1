<#
.SYNOPSIS
    Script automatisé de publication de l'application et génération du Setup (Inno Setup).
.DESCRIPTION
    1. Compile et publie l'exécutable autonome (Self-contained, Single-file, Release win-x64).
    2. Détecte le compilateur Inno Setup (ISCC.exe) ou propose son installation.
    3. Génère le fichier d'installation final Setup.exe dans dist\installer.
#>

param(
    [string]$Configuration = "Release",
    [string]$Runtime = "win-x64"
)

$ErrorActionPreference = "Stop"

Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host " PHARMACIE OFFICINALE - BUILD & PACKAGING DE PRODUCTION   " -ForegroundColor Cyan
Write-Host " Auteur : Dzaba Diliane Merveille (Licence MIT)           " -ForegroundColor Cyan
Write-Host "==========================================================" -ForegroundColor Cyan

$rootDir = $PSScriptRoot
$publishDir = Join-Path $rootDir "dist\publish\$Runtime"
$installerDir = Join-Path $rootDir "dist\installer"
$issPath = Join-Path $rootDir "installer\GestionPharmacieSetup.iss"

# 1. Nettoyage et création des dossiers
Write-Host "`n[1/3] Nettoyage et préparation des dossiers de sortie..." -ForegroundColor Yellow
if (Test-Path $publishDir) { Remove-Item -Recurse -Force $publishDir }
New-Item -ItemType Directory -Force -Path $publishDir | Out-Null
New-Item -ItemType Directory -Force -Path $installerDir | Out-Null

# 2. Publication .NET Release win-x64 autonome
Write-Host "`n[2/3] Publication .NET 8 (Self-contained, Single-file, $Runtime)..." -ForegroundColor Yellow
$projectPath = Join-Path $rootDir "src\GestionPharmacie.UI\GestionPharmacie.UI.csproj"

dotnet publish $projectPath `
    -c $Configuration `
    -r $Runtime `
    --self-contained true `
    -p:PublishSingleFile=true `
    -p:IncludeNativeLibrariesForSelfExtract=true `
    -p:EnableCompressionInSingleFile=true `
    -o $publishDir

if ($LASTEXITCODE -ne 0) {
    Write-Error "Échec lors de la publication dotnet publish."
    exit 1
}

Write-Host "Publication terminée avec succès dans : $publishDir" -ForegroundColor Green

# 3. Compilation Inno Setup
Write-Host "`n[3/3] Recherche du compilateur Inno Setup (ISCC.exe)..." -ForegroundColor Yellow

$isccCandidates = @(
    (Get-Command iscc.exe -ErrorAction SilentlyContinue | Select-Object -ExpandProperty Source -ErrorAction SilentlyContinue),
    "${env:ProgramFiles(x86)}\Inno Setup 6\ISCC.exe",
    "$env:ProgramFiles\Inno Setup 6\ISCC.exe",
    "${env:LocalAppData}\Programs\Inno Setup 6\ISCC.exe"
) | Where-Object { $_ -and (Test-Path $_) }

if ($isccCandidates.Count -gt 0) {
    $iscc = $isccCandidates[0]
    Write-Host "Compilateur Inno Setup détecté : $iscc" -ForegroundColor Green
    Write-Host "Compilation de l'assistant d'installation Setup.exe..." -ForegroundColor Cyan

    & $iscc $issPath
    if ($LASTEXITCODE -eq 0) {
        Write-Host "`n==========================================================" -ForegroundColor Green
        Write-Host " SUCCÈS : L'installateur a été généré avec succès !" -ForegroundColor Green
        Write-Host " Emplacement : $installerDir" -ForegroundColor Green
        Write-Host "==========================================================" -ForegroundColor Green
    } else {
        Write-Warning "Inno Setup a retourné un code d'erreur : $LASTEXITCODE"
    }
} else {
    Write-Host "`n[INFO] Le compilateur Inno Setup n'est pas encore installé sur cette machine." -ForegroundColor Magenta
    Write-Host "Pour installer Inno Setup en une commande :" -ForegroundColor Yellow
    Write-Host "   winget install JRSoftware.InnoSetup" -ForegroundColor White
    Write-Host "Ou téléchargez-le gratuitement depuis : https://jrsoftware.org/isdl.php" -ForegroundColor White
    Write-Host "`nUne fois Inno Setup installé, vous pourrez ouvrir directement le fichier :" -ForegroundColor Cyan
    Write-Host "   $issPath" -ForegroundColor White
    Write-Host "et cliquer sur 'Compile' (F9), ou relancer ce script build_installer.ps1." -ForegroundColor Cyan
}
