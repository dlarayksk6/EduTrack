# EduTrack - Akıllı ve Güvenli Öğrenci Not Takip Sistemi

Merhaba, ben Dilara.
  EduTrack, yazılım öğrenme sürecimde hem pratik yapmak hem de kendimi geliştirmek için örnek olarak geliştirdiğim bir projedir.
Oldukça basit tutulmasına rağmen, gerçek bir okul ortamını temel alarak; kullanıcı kayıtları, rol bazlı erişim ve not işlemleri gibi temel işlevleri içermektedir.
Bu proje sayesinde çok katmanlı yapı, veri yönetimi ve kullanıcı arayüzü geliştirme konularında deneyim kazandım.
---

## Proje Özeti

EduTrack; öğrenci, öğretmen ve idare kullanıcılarının sisteme kendi kayıtlarını oluşturduğu;  
okula özel erişim mantığıyla notların **eklenebildiği, listelenebildiği ve yönetilebildiği** web tabanlı bir platformdur.

> Öğretmen, kendi girdiği sınıflardaki öğrencilere not girer.  
> Öğrenci, kendi notlarını görür.  
> İdare, kendi okulundaki tüm notları görüntüler.  

---

## Özellikler

- Kullanıcı kayıt ve giriş (JWT ile kimlik doğrulama)  
- Rol bazlı yetkilendirme (İdare, Öğretmen, Öğrenci)  
- Öğretmen tarafından not ekleme  
- Öğrenci tarafından not görüntüleme  
- İdare tarafından tüm okul verilerini izleme  
- Katmanlı mimari: Domain, Data, Application, API, Client  
- Güvenli oturum yönetimi

---

##  Kullandığım Teknolojiler

| Teknoloji             | Açıklama                            |
|----------------------|-------------------------------------|
| ASP.NET Core Web API | Backend & iş mantığı                |
| Blazor WebAssembly   | Etkileşimli kullanıcı arayüzü       |
| MSSQL + T-SQL        | Veritabanı yönetimi                 |
| Entity Framework Core| ORM & Migration yönetimi            |
| JWT                  | Token tabanlı güvenli kimlik doğrulama |

---

## Rol ve Yetkiler

| Rol        | Yetkileri                                                              |
|------------|------------------------------------------------------------------------|
| **İdare**   | Kendi okulunun tüm notlarını görüntüler, kullanıcı atamalarını yapar   |
| **Öğretmen**| Sadece yetkili olduğu derslerde not ekler/günceller                    |
| **Öğrenci** | Sadece kendi notlarını görüntüler                                      |

> Her okul için sadece bir idare hesabı olabilir.

---

## Proje İşleyişi

1. Okullar ve dersler veritabanına manuel olarak eklenmiştir.  
2. Kullanıcılar kayıt olurken okul seçer.  
3. Öğretmen ve öğrenciler okullarına göre atanır.  
4. Not işlemleri sadece yetkili roller tarafından yapılır.  
5. Her kullanıcı yalnızca yetkili olduğu verilere erişebilir.

---

## Neler Öğrendim?

- ASP.NET Core ile API geliştirme ve kimlik doğrulama  
- Blazor WebAssembly ile modern frontend mimarisi  
- Entity Framework ile veritabanı ilişkileri ve migration yönetimi  
- Katmanlı mimariyle sürdürülebilir yazılım tasarımı  
- Rol bazlı güvenli sistem inşası

---

## Eksikler & Geliştirilecekler (To-Do)

- [ ] Not **güncelleme** ve **silme** işlemleri (öğretmen için)  
- [ ] İdarenin kullanıcıları **listeleme ve filtreleme** arayüzü  
- [ ] Daha detaylı **not analiz grafiklerinin** eklenmesi  
- [ ] Ders programı/haftalık plan özelliği (planlama modülü)

---

