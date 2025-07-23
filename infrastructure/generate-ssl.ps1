# PowerShell script for SSL certificate generation on Windows
param(
    [string]$Domain = "localhost"
)

Write-Host "Generating SSL certificates for $Domain..." -ForegroundColor Green

# Create ssl directory if it doesn't exist
if (!(Test-Path -Path "ssl")) {
    New-Item -ItemType Directory -Path "ssl"
    Write-Host "Created ssl directory" -ForegroundColor Yellow
}

# Method 1: Try OpenSSL if available
$opensslPath = Get-Command openssl -ErrorAction SilentlyContinue

if ($opensslPath) {
    Write-Host "Using OpenSSL..." -ForegroundColor Cyan
    
    & openssl req -x509 -nodes -days 365 -newkey rsa:2048 `
        -keyout ssl/server.key `
        -out ssl/server.crt `
        -subj "/C=US/ST=State/L=City/O=Organization/CN=$Domain" `
        -addext "subjectAltName=DNS:$Domain,DNS:host.docker.internal,IP:127.0.0.1"
    
    if ($LASTEXITCODE -eq 0) {
        Write-Host "SSL certificates generated successfully with OpenSSL!" -ForegroundColor Green
        exit 0
    }
}

# Method 2: Use PowerShell's New-SelfSignedCertificate (Windows 10+)
Write-Host "Trying PowerShell New-SelfSignedCertificate..." -ForegroundColor Cyan

try {
    # Create the certificate
    $cert = New-SelfSignedCertificate `
        -DnsName @($Domain, "host.docker.internal", "127.0.0.1") `
        -CertStoreLocation "cert:\CurrentUser\My" `
        -KeyAlgorithm RSA `
        -KeyLength 2048 `
        -Provider "Microsoft Enhanced RSA and AES Cryptographic Provider" `
        -NotAfter (Get-Date).AddDays(365) `
        -Subject "CN=$Domain"

    # Export the certificate (public key)
    $certPath = "ssl/server.crt"
    Export-Certificate -Cert $cert -FilePath $certPath -Type CERT | Out-Null
    
    # Convert to PEM format for nginx
    $certContent = [System.Convert]::ToBase64String([System.IO.File]::ReadAllBytes($certPath))
    $pemCert = "-----BEGIN CERTIFICATE-----`n"
    for ($i = 0; $i -lt $certContent.Length; $i += 64) {
        $line = $certContent.Substring($i, [Math]::Min(64, $certContent.Length - $i))
        $pemCert += "$line`n"
    }
    $pemCert += "-----END CERTIFICATE-----"
    [System.IO.File]::WriteAllText($certPath, $pemCert)

    # Export the private key
    $keyPath = "ssl/server.key"
    
    # Get the private key
    $privateKey = [System.Security.Cryptography.X509Certificates.RSACertificateExtensions]::GetRSAPrivateKey($cert)
    $privateKeyBytes = $privateKey.ExportRSAPrivateKey()
    
    # Convert to PEM format
    $privateKeyBase64 = [System.Convert]::ToBase64String($privateKeyBytes)
    $pemKey = "-----BEGIN RSA PRIVATE KEY-----`n"
    for ($i = 0; $i -lt $privateKeyBase64.Length; $i += 64) {
        $line = $privateKeyBase64.Substring($i, [Math]::Min(64, $privateKeyBase64.Length - $i))
        $pemKey += "$line`n"
    }
    $pemKey += "-----END RSA PRIVATE KEY-----"
    [System.IO.File]::WriteAllText($keyPath, $pemKey)

    # Remove from certificate store (cleanup)
    Remove-Item -Path "cert:\CurrentUser\My\$($cert.Thumbprint)" -Force

    Write-Host "SSL certificates generated successfully with PowerShell!" -ForegroundColor Green
    Write-Host "Files created:" -ForegroundColor Yellow
    Write-Host "  - ssl/server.key (private key)" -ForegroundColor Gray
    Write-Host "  - ssl/server.crt (certificate)" -ForegroundColor Gray
    
} catch {
    Write-Host "PowerShell certificate generation failed: $($_.Exception.Message)" -ForegroundColor Red
    
    # Method 3: Fallback instructions
    Write-Host "" -ForegroundColor Yellow
    Write-Host "=== MANUAL SETUP REQUIRED ===" -ForegroundColor Yellow
    Write-Host "Please install one of the following options:" -ForegroundColor White
    Write-Host ""
    Write-Host "Option 1 - Git Bash (Recommended):" -ForegroundColor Cyan
    Write-Host "  1. Install Git for Windows: https://git-scm.com/download/win"
    Write-Host "  2. Open Git Bash in this directory"
    Write-Host "  3. Run: ./generate-ssl.sh"
    Write-Host ""
    Write-Host "Option 2 - Chocolatey + OpenSSL:" -ForegroundColor Cyan
    Write-Host "  1. Install Chocolatey: https://chocolatey.org/install"
    Write-Host "  2. Run: choco install openssl"
    Write-Host "  3. Run: ./generate-ssl.ps1"
    Write-Host ""
    Write-Host "Option 3 - WSL (Windows Subsystem for Linux):" -ForegroundColor Cyan
    Write-Host "  1. Install WSL: wsl --install"
    Write-Host "  2. Run: wsl ./generate-ssl.sh"
    Write-Host ""
    Write-Host "Option 4 - Docker-based generation:" -ForegroundColor Cyan
    Write-Host "  Run: docker run --rm -v `${PWD}/ssl:/certs alpine/openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout /certs/server.key -out /certs/server.crt -subj '/CN=localhost'"
    
    exit 1
}