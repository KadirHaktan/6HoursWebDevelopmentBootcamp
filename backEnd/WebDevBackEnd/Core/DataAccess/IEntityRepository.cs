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
}
