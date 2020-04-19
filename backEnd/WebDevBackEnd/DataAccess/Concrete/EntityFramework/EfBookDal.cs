using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{

    //EfBookDal dikkat edin EfEntityRepositoryBase'den kalıtım almış
    //kalıtım aldığı için artık EntityFramework'deki add delete tarzı CRUD operasyonların Ef kodlarını
    //tekrar tekrar bu sınıfın içinde yazma ithiyacını ortadan kaldırıyor ve aynı zamanda EfBookDal
    //IBookDal'dan implemente edilmiş.

    //IBookDal çünkü tüm ORM sistemleri imzalayan ve destekleyen genel bir referans tip
    //Bu genel referans olabilmesi sayesinde bir üst katmanda yani iş katmanı sınıfının herhangi bir ORM
    //sınıfına bağımlı kalmasını önlemiş olacak.

    //IBookDal interface'i bildiğiniz gibi aynı zamanda IEntityRepository interface'inden besleniyor ki
    //aynı şekilde burada EfBookDal'dan kendi repository'si olan EfEntityRepositoryBase<Book,BookStoreContext>'den besleniyor ki
    //Beslenmeleri sayesinde de genel CRUD operasyonları tek bir merkezden yönetebiliyor ve ilgili operasyonları kullanabiliyorlar.

    //Bir detay daha EfEntityRepositoryBase'de IEntityRepository'den implemente edildi.Başka bir ORM için de bir repository
    //yazılacağı zaman Ef ellenmeden başka bir class tanımlanıp yeniden IEntityRepository'den implemente edilebilmekte
    //IEntityRepository'de işte tam burda genel CRUD operasyonların imzası görevi görüyor ve başka sınıflar bu interface'den
    //implemente edildikçe sadece operasyonların kod syntax gereği olması gereken değişiklikler yapılabilmekte ve mevcut sistemler de ellenmemekte



    public class EfBookDal:EfEntityRepositoryBase<Book,BookStoreContext>,IBookDal
    {
    }
}
