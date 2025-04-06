#!/bin/bash

set -e

TAG=$1

if [ -z "$TAG" ]; then
  echo "❌ TAG parametresi eksik. Kullanım: ./generate-docs.sh <TAG>"
  exit 1
fi

echo "🚀 ArfBlocks CLI Docker imajı build ediliyor ve çalıştırılıyor..."

docker build \
  -t registry.git.hirovo.com.tr/arfblocks-cli:$TAG \
  --build-arg git_username=mstfa6060 \
  --build-arg git_password=GITHUB_PERSONAL_TOKEN \
  -f _devops/docker/Dockerfile-api-doc-generator .

echo "✅ Docker imajı oluşturuldu: registry.git.hirovo.com.tr/arfblocks-cli:$TAG"

echo "📂 Frontend ve mobil dizinlerine dokümantasyon kopyalanıyor..."

rm -rf /maden/maden-frontend/common || true
rm -rf /maden/mobileapp/common || true

cp -r ./_devops/tmp/webapp/common /maden/maden-frontend/
cp -r ./_devops/tmp/mobileapp/common /maden/mobileapp/

echo "✅ Dokümantasyon kopyalandı."

echo "📦 Git commit & push işlemi başlatılıyor..."

cd /maden/maden-frontend
git add .
git commit -m "🔄 ArfBlocks API dokümantasyonu güncellendi - $TAG" || true
git push origin main

cd /maden/mobileapp
git add .
git commit -m "🔄 ArfBlocks API dokümantasyonu güncellendi - $TAG" || true
git push origin main

echo "✅ Push işlemleri tamamlandı."
