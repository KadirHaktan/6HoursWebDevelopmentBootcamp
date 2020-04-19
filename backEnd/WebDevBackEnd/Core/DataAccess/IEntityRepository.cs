using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{

    //IEntity den implemente edilen nesneler(T generic tipi ne olacak ise) veritabanı tablosu olacağını ifade ediyor

                                                 //class derken aslında class olacak değil tip olarak **referans bir tip** olabilir
                                                 // abstract class da olabilir mesela ama new dersek abstract olmayacaktır
                                                 // bildiğimiz bir class olacaktır yani new lenebilecek bir class
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }

    //Repository tasarım deseni amacı bu tarz veritabanındaki CRUD tarzı klasik operasyonları
    //her bir data access sınıflarında yazmaktansa ortak bir depo tarz bir alanda CRUD operasyonları
    //tanımlayıp içlerini doldurup ardından ilgili data access sınıfının kullanabilmesi sadece
    //data access kalıtım(inherit) yoluyla aktararak data access'te klasik CRUD operasyonları bir daha tanımlama
    //ithiyacını ortadan kaldırıyor.

    //Repository sınıfları için kısacası **genel CRUD operasyonları** yazılmış olduğu **bir merkez noktadır**.

    //Peki bu IEntityRepository neden şundan yarın öbür gün Dapper ORM için de bir Repository ithiyacı da duyulabilir
    //ya da NHibernate için de bir Repository ithiyacı duyulabilir.Hee gidip de EntityFramework ORM'ne ait repository'deki
    //operasyonların içeriğini mi değiştirecez.Bu SOLID'ın O'suna(Open-Closed Principle) aykırı olduğu gibi geliştirme sürecinde
    //kodu bir daha sil değiştir bir uğraştırıcı bakıldığında.

    //Open-Closed Principle'da der ki:Yapılan genel bir sisteme yeni bir eklenti ya da mevcut eklentiye alternatif 
    // **yeni bir eklenti eklenebilmeli** ama yeni bir eklenti eklenirken asla
    // **mevcut sistem üzerinde oynama ya da değişiklik yapmamak gerekir**

    //Yani gidip de NHibernate alakalı bir repository yazacağımız zaman eğer EFEntityRepositoryBase sınıfında da değişiklik yaparsak
    //fullden işte bu prensibe aykırı olacaktır.IEntityRepository'de bunun için var aslında.Bu interface'de belirli crud operasyonlar
    //metotlar imzalı olarak oluşturulmakta sonrasında bundan implemente bir gerçek Repository sınıfı(NHibernate ya da Entity Framework...)
    //bu imzalı metotları kendisine alıp sadece kendi third party teknolojisi gereği kodu nasıl yazılmalı ise
    //kodu yazılmakta ama sonuçta o metotun her türlü amacı aynı sadece kod içeriği farklı.Add ister NHibernate olsun isterse Dapper
    //hiç farketmez hepsinin amacı veritabanına yeni bir kayıt eklemektedir sadece kod yazımları farklı olacaktır ve tabi performansları vs...

   //Ef için yazılan bir sistemi Dapper için de yazmak için sadece yeni bir sınıf oluşturup IEntityRepository'den implemente etmek
   //yeterli olacaktır bundan sonrası Dapper kodu neyse o metotlara yazılır ama bu esnada Ef sınıfına dokunmuyoruz o yerinde kalmaya devam ediyor.



}
