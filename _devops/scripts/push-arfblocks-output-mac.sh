#!/bin/bash

# === BASE PATHS ===
script_dir="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
backend_path="$(cd "$script_dir/../.." && pwd)"
maden_root="$(cd "$backend_path/.." && pwd)"

# === CONFIGURABLE PATHS ===
cli_config_path="$backend_path/_devops/arfblocks-cli/hirovo.arfblocks-cli.json"
frontend_path="$maden_root/maden-frontend/frontend-hirovo"
frontend_branch="main"
mobile_path="$maden_root/mobileapp/hirovo-mobileapp"
mobile_branch="main"

# === 1. ArfBlocks CLI çıktısını oluştur ===
echo -e "\n📦 ArfBlocks CLI çıktısı oluşturuluyor..."
cd "$backend_path" || exit
arfblocks-cli exec --file "$cli_config_path"
echo "✅ CLI çıktısı tamamlandı."

# === 2. Frontend push ===
if [ -d "$frontend_path" ]; then
  echo "🚀 Frontend'e gönderiliyor..."
  cd "$frontend_path" || exit
  git add .
  git commit -m "🔄 Otomatik ArfBlocks güncellemesi [frontend]" --allow-empty
  git push origin "$frontend_branch"
  echo "✅ Frontend güncellendi."
else
  echo "❌ Frontend yolu bulunamadı: $frontend_path"
fi

# === 3. MobileApp push ===
if [ -d "$mobile_path" ]; then
  echo "🚀 Mobil app'e gönderiliyor..."
  cd "$mobile_path" || exit
  git add .
  git commit -m "🔄 Otomatik ArfBlocks güncellemesi [mobileapp]" --allow-empty
  git push origin "$mobile_branch"
  echo "✅ Mobil app güncellendi."
else
  echo "❌ Mobil app yolu bulunamadı: $mobile_path"
fi
