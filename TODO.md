# FABRIKA ERP - GECE MESAİSİ PLANI (TIER 1)

Bu dosya, Architect Agent ve Sub-Agent'lar tarafından otonom (insansız) modda adım adım işlenecektir. Her bir kural MVVM ve C# standartlarına uygun olacaktır. Her adım tamamlandığında, ilgili test çalıştırılacak ve başarılı olduktan sonra sonraki adıma geçilecektir.

## Kural
**İNSAN ONAYI İSTEME!** Kullanıcı uyuyor. Verilen görevleri kendi başına terminalde yürüt, dosyaları oluştur ve test et! Eğer takılırsan hata ayıklama (systematic-debugging) yeteneğini kullanarak kendi hatanı kendin çöz. Bu dosyadaki tüm maddeleri bitiresiye kadar durma.

---

## 🏗️ Görev Listesi

### Görev 1: User Management (Kullanıcı Yönetimi) Veritabanı Entity'leri
- [ ] `Models/User.cs`, `Models/Role.cs`, `Models/Shift.cs` dosyalarını oluştur.
- [ ] Bu dosyalar için Id, Ad, Vardiya, Rol seviyesi gibi basit Properties (özellikler) ekle.
- [ ] `Data/FabrikaDbContext.cs` içine bu objeleri `DbSet` olarak ekle.
- [ ] EF Core migration (tablo yaratma) kodunu çalıştır (Terminalden `dotnet ef migrations add InitialCreate` yapıp `dotnet ef database update` ile SQLite dosyasını yarat).

### Görev 2: Kullanıcı (User) Servisi ve Giriş Ekranı (Login)
- [ ] `Services/IAuthService.cs` ve implementasyonu `Services/AuthService.cs` yaz (Kullanıcı adı ve şifre kontrolü).
- [ ] `ViewModels/LoginViewModel.cs` yaz (Kullanıcı adı, şifre tutan ve Login basılınca AuthService'i çağıran yapı). MVVM (ObservableObject, RelayCommand) kullan.
- [ ] `Views/LoginWindow.xaml` çiz (Modern, karanlık (dark theme) basit bir arayüz, şifre kutusu ve Giriş butonu).

### Görev 3: Dashboard (Ana Ekran) İskeleti
- [ ] `Views/DashboardWindow.xaml` çiz (Sol tarafta menü (Kullanıcılar, Üretim, Raporlar), sağda içerik).
- [ ] `ViewModels/DashboardViewModel.cs` yaz (Menü geçişlerini yöneten yapı).
- [ ] Uygulama açılış noktasını (`App.xaml.cs`) `MainWindow.xaml` yerine `LoginWindow.xaml` olarak ayarla. Başarılı login olunca `DashboardWindow.xaml` açılsın.

### Görev 4: Oturum ve İzin Kontrolü (Authentication State)
- [ ] Sisteme bir Singleton `SessionManager` ekle, kimin giriş yaptığını, rolünü ve vardiyasını tutsun.
- [ ] Dashboard üzerindeki butonlardan yetkisi olmayanları görünmez veya disable (pasif) yap.

### Görev 5: Birleştirme ve Gece Testi
- [ ] Tüm dosyaları derle (`dotnet build`). Hata varsa kendin düzelt (Systematic debugging kullan).
- [ ] Basit bir NUnit veya MSTest test projesi yaratıp `AuthService` testlerini yaz.
- [ ] Tüm testler %100 başarılı (Green) olana kadar kodlarını revize et.

---
**GECE MESAİSİ BİTİŞ KONTROLÜ:** 
Eğer bu adımları tamamen bitirdiysen, `BUILD_SUCCESS.md` adında bir dosya oluşturup içine sabah kullanıcı uyandığında okuması için bir günaydın mesajı ve gece yapılanların kısa özetini bırak.
