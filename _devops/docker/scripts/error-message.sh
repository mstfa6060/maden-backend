#!/bin/bash

TAG=$1
if [ -z "$TAG" ]; then
  echo "❌ TAG parametresi eksik. Örn: ./error-message.sh 100_COMabc123"
  exit 1
fi

echo "📦 Başladı: ErrorMessage Export ($TAG)"

dotnet run --project Jobs/SpecialPurpose/DevTasks/ErrorCodeExporter/ErrorCodeExporter.csproj || true

WEBAPP_PATH=../../webapp/common/hirovo-api/src/errors/locales/modules
MOBILEAPP_PATH=../../mobileapp/common/hirovo-api/src/errors/locales/modules

echo "📤 Kopyalanıyor: WEBAPP"
cp -r ${WEBAPP_PATH} ./_devops/tmp/webapp/common/hirovo-api/src/errors/locales/modules

echo "📤 Kopyalanıyor: MOBILEAPP"
cp -r ${MOBILEAPP_PATH} ./_devops/tmp/mobileapp/common/hirovo-api/src/errors/locales/modules

echo "✅ Tamamlandı: ErrorMessage Export"
