using Core.DataAccess;
using Entities.Concrete;


namespace DataAccess.Abstract
{
    public interface IBookDal:IEntityRepository<Book>
    {
    }
    //IBookDal kendisinden implemente edecek olan bir Ef için ya da Dapper vs ... farklı ORM sistemlerin dal sınıfların
    //implemente edildi interface'nin ta kendisidir.Dikkat edin yine bir interface'den de implemente edilmiş o da
    //genel CRUD veritabanı işlemlerin imzalandığı ve Repository tasarım deseni uygulayan interface'nin ta kendisidir.
    //Repository tasarım deseni burada aslında uygulanıyor diyebiliriz ki IBookDal interface'i içinde tekrar tekrar
    //Add ya da Delete operasyonunu burada imzalı olarak tanımlama ithiyacımız ortadan kaldırıyor.Çünkü bu işlemler
    //IEntityRepository interface'i içinde merkezileştirerek imzalanmıştır.
}
