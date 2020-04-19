# Engin Demiroğ'un 19 Nisan'da canlı yayında yaptığı 6 saatlik Web Geliştirme kampına ait kod örneği

# Proje'de kullanılan teknolojiler 
* ASP.NET Core Web API(.NET Core 3.1)=>BackEnd
* Angular 9=>FrontEnd

# Proje'de uygulanan Back-End mantiletesi

## Katmanlı Mimari 
* Veri Erişim Katmanı(Data Access Layer):Bu katmanda sadece ama sadece veritabanı ile alakalı operasyonların gerçekleştiği kısımlar.
  Bunlar kayıt ekleme,silme,güncelleme,belirli filtre ya da filtresiz getirme,veritabanına bağlanma vs...Bu tarz işlemleri sadece
  burada gerçekleştiririz

* İş Mantık Katmanı(Business Logic Layer):Bu katmanda ise veritabanında gelen işlemin belirli kontrolleri ya da bir kurala göre
 işleyebilmesi için sadece bu kuralların ya da kontrollerin yapıldığı katmandır.Bakın dikkatinizi çekmek isterim aslda veritabanı
 işlemi yapılmıyor sadece veritabanındaki işleminin istenilen kurallara bağlanarak işlemini tamamlayıp ardından kullanıcı arayüze
 belirli bir sonuç dönülebilmesi gerekli kuralların,kontrollerin ya da filtrelemelerin yapıldığı katmandır.Bu kontrollerin
 mesela arayüzden gelen verinin istenilen şekilde gelip gelmediğini kontrolü(validasyon(validation)) olabilir ya da belirli bir kullanıcı
 rolünün sadece ilgili sayfa üzerinde ekleme,silme vb. işlemleri yapabilmesi yetkilendirmeler yapılabilir ya da verileri tablo şeklinde
 sayfamızda görüntülemek istediğimiz her seferinde veritabanına gitmektense,bir sefer veritabanı tarafından veriler çekilip bunları
 geçici bir sürede tampon hafızada(cache bellek) saklayıp sonraki isteklerden cache'den veriyi alabiliriz.İşte bunlar yapılan projenin
 doğabilecek ithiyaçlarıdır ya da müşterinin ithiyaçlarına göre farklı kurallandırmalar getirelebilir.İşte iş mantık kavramı da sadece
 bu kurallandırmaları yapmamıza imkan sunan katmandır

* Varlık Katmanı(Entity Layer):Entity katmanı ise veritabanı tablolarımıza ait sınıfları barındıran ve tabiki tablo sınıflarının
  propertyler yani veritabanındaki tabloya ait column'larına karşılık gelen yapılar burada oluşturulmakta.Aynı zamanda kullanıcı arayüzünde kullanıcıya göstermek istediğimiz ya da görmek istediği kolumn'lara göre oluşabilecek Dto's(Data Transfer Object) ya Kompleks tipler olabilir.Bu Dto'lar iki ya da üç tablonun joinlenip join'den döndürmek istediğimiz column'lar vs olabilir.Sonuçta 
  normal tablo column'lar üzerinden değişiklik yapıldığı hallere Dto'lar ya da Kompleks tipler diyebiliriz.

* Çekirdek Katmanı(Core Layer):Core katmanını hemen her bir projede kullanabileceğimiz ortak yapıların yer aldığı katman diyebiliriz.
  Mesela repository sınıflarının hemen her projede kullanılabilir çünkü amaç genel CRUD operasyonları merkezileştirmek olduğu için ki
  veritabanı bağlantısı olan her bir proje de CRUD operasyonlarına ithiyac doğacaktır ki Repository tasarım desenin uygulandığı sınıfların Çekirdek Katmanı üzerinde kullanmak açıkçası mantıklı olacaktır.Ya da üyelik sistemin olduğu her bir projede şifre ile
  giriş yapılırken güvenlik açısında şifreyi veritabanına hash'li bir şekilde veritabanına kaydetmek yine Core Katmanında Hash işlemini gerçekleştiren bir araç(tool) yazabiliriz ve hemen her üyelik sistemi(login) olan projelerde bunu kullanabiliriz.

* Kullanıcı Arayüz Katmanı(User Interface Layer):Kullanıcı arayüz dediğimiz aslında bizim görüntülediğimiz web sayfası,mobil 
  uygulamanın telefondaki görünümü ya da masaüstündeki bir masaüstü uygulamasın görüntüsü diyebiliriz.Sonuçta veri erişimden başlayan
  operasyonun iş katmanındaki kurallar doğrultusunda en sonunda kullanıcıya sonuç belirli bir sonuç dönüldüğü katmandır.

  



