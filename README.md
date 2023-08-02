# FileUpload (Dosya Yükleme) Uygulaması (.NET 7)

Bu .NET 7 Core MVC projesi, kullanıcılara tek bir dosyayı yüklemelerine olanak tanır. Dosya sunucuya yüklenir ve yüklenen dosya adı sayfada gösterilir. Bu uygulamada jpg ve jpeg uzantılı dosyaları için yaptık isterseniz küçük bir refactoring ile istediğiniz uzantıyı seçebilirsiniz.
 
## Kullanılan Teknolojiler

- .NET Core 7.0
- Inversion of Control (IoC) prensibi kullanılmıştır. Bu sayede bağımlılıklar yönetilebilir ve test edilebilir hale gelir.
- Dependency Injection (DI) kullanılmıştır. Bağımlılıklar, DI mekanizması ile enjekte edilir, kodun daha esnek ve bakımı kolay hale gelir.
- Entity Framework Core, veri tabanı işlemleri için kullanılmıştır. Bu sayede veri tabanı işlemleri kolaylıkla gerçekleştirilir.
- Microsoft SQL Server (MSSQL), veri tabanı olarak kullanılmıştır.

### Önkoşullar

Proje için aşağıdaki yazılımların yüklü olması gerekmektedir:

- .NET SDK 7.0 (veya daha yeni bir sürüm)

### Kurulum

1. Projeyi klonlayın veya indirin.
2. Projeyi visual studio açın ve package manager console aşağıdaki komutu çalıştırın ve veritabanını oluşturun:

```sh
Add-Migration Init
Update-Database
