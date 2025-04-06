# Hirovo Backend

Bu repo, Hirovo platformunun .NET 8 ve Docker tabanlı backend servislerini içermektedir. API katmanı ArfBlocks mimarisiyle oluşturulmuş ve tamamen RESTful yaklaşımla geliştirilmiştir.

## 🚀 Başlangıç

### Gerekli Araçlar
- .NET 8 SDK
- Docker & Docker Compose
- Linux tabanlı sunucu (Ubuntu 22 önerilir)
- GitHub Actions entegrasyonu (otomatik build ve deploy için)

### Kurulum

```bash
cd HirovoBackend/_devops/docker
docker-compose up -d --build
```

> **Not:** Proje başarıyla ayağa kalktıktan sonra API, yalnızca Nginx reverse proxy üzerinden dış dünyaya açılır.


## 🌐 API Adresi

- HTTPS: [https://api.hirovo.com](https://api.hirovo.com)
- HTTP istekleri otomatik olarak HTTPS'ye yönlendirilir.


## 🔐 SSL Sertifikası

- Sertifika: Let's Encrypt (ücretsiz)
- Yönetim: Docker üzerinden `certbot` ile yapılır.
- Otomatik yenileme cron servisi Docker içerisinde tanımlıdır.

```bash
docker exec certbot certbot renew --dry-run
```


## 🔧 Servisler

- `hirovo-api`: Uygulamanın asıl .NET Core API servisidir
- `sqlserver`: MS SQL Server 2022 container
- `nginx`: Reverse proxy + SSL terminate işlemleri
- `certbot`: SSL oluşturma ve yenileme


## 🧪 Test İçin Giriş Örneği

```http
POST https://api.hirovo.com/Auth/Login
Content-Type: application/json

{
  "provider": "native",
  "userName": "johndo1e1",
  "password": "SecureP@ss123",
  "platform": 0
}
```

---

## 📁 Klasör Yapısı

```bash
HirovoBackend/
├── _devops/
│   └── docker/               # Dockerfile, docker-compose.yml, nginx.conf
├── BaseModules/             # IAM, Logging, Notification gibi altyapı modülleri
├── BusinessModules/         # Workers, Employers, Jobs modülleri
├── Jobs/                    # Migration job'ları ve background işler
└── README.md                # Bu dosya :)
```

---

## ✍️ Katkı Sağlama
Pull request gönderebilir veya issue açarak katkıda bulunabilirsiniz.

---

## 📜 Lisans
MIT License

