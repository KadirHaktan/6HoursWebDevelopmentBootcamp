using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {

        private IBookDal _bookdal { get; set; }

        public BookManager(IBookDal _dal)
        {
            this._bookdal = _dal;
        }
        //Depency Injection Tasarım deseni uygulamaktayız şöyle ki soyut nesne üzerinden
        //yarın öbür gün bu class'ı new yaparken istersek Ef ile constructor'a verilebilir
        //istersek Dapper için de verilebilir.Sonuçta hepsi IBookDal'dan implemente ediliyor
        //Bu kod ile herhangi bir third party kütüphane olan ORM aracına bağımlılığı kaldırmakta.
        //Yukarıda da bahsettiğimiz Depency Injection tasarım deseni işte bunun için önemli.

            //Örnek BookManager manager=new BookManager(new EfDal())
            //      BookManager manager=new BookManager(new DapperDal())

            // işte istenilen ORM tool sınıfı kullanma imkanı veriyor gördüğünüz bu Hibernate vs ... artabilir
        
        public void Add(Book book)
        {
            _bookdal.Add(book);
        }

        public void Delete(Book book)
        {
            _bookdal.Delete(book);
        }

        public List<Book> GetAll()
        {
            return _bookdal.GetAll();
        }

        public List<Book> GetByAuthorId(int authorId)
        {
            return _bookdal.GetAll(b => b.AuthorId == authorId).ToList();
        }

        public Book GetById(int id)
        {
            return _bookdal.Get(b => b.Id == id);
        }

        public void Update(Book book)
        {
            _bookdal.Update(book);
        }
    }
}
