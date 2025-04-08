# === BASE PATHS (Dinamik & Sürücüsüz) ===

# Script'in çalıştığı dizini al (örnek: maden/backend/_devops/scripts)
$scriptRoot = Split-Path -Parent $MyInvocation.MyCommand.Definition

# maden klasörünün kökünü bul
$backendPath = Resolve-Path "$scriptRoot\..\.."
$madenRoot = Resolve-Path "$backendPath\.."

# === CONFIGURABLE PATHS ===
$cliConfigPath = "$backendPath\_devops\arfblocks-cli\hirovo.arfblocks-cli.json"

$frontendPath = "$madenRoot\maden-frontend\frontend-hirovo"
$frontendBranch = "main"

$mobilePath = "$madenRoot\mobileapp\hirovo-mobileapp"
$mobileBranch = "main"

# === 1. ArfBlocks CLI çıktısını oluştur ===
Write-Host "`n📦 ArfBlocks CLI çıktısı oluşturuluyor..."
cd $backendPath
arfblocks-cli exec --file $cliConfigPath
Write-Host "✅ CLI çıktısı tamamlandı.`n"

# === 2. Frontend push ===
if (Test-Path $frontendPath) {
    Write-Host "🚀 Frontend'e gönderiliyor..."
    cd $frontendPath
    git add .
    git commit -m "🔄 Otomatik ArfBlocks güncellemesi [frontend]" --allow-empty
    git push origin $frontendBranch
    Write-Host "✅ Frontend güncellendi.`n"
} else {
    Write-Host "❌ Frontend yolu bulunamadı: $frontendPath"
}

# === 3. MobileApp push ===
if (Test-Path $mobilePath) {
    Write-Host "🚀 Mobil app'e gönderiliyor..."
    cd $mobilePath
    git add .
    git commit -m "🔄 Otomatik ArfBlocks güncellemesi [mobileapp]" --allow-empty
    git push origin $mobileBranch
    Write-Host "✅ Mobil app güncellendi.`n"
} else {
    Write-Host "❌ Mobil app yolu bulunamadı: $mobilePath"
}
