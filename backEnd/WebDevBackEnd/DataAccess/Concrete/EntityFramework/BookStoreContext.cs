using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class BookStoreContext:DbContext
    {

        string connectionString = "";
        //kendi local'nizde connection string neyse ona girmelisiniz

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connectionString);
            //entity framework orm'i hangi veritabanını kullanacak ve connection string ne ise parametre olarak geçiriyoruz
        }
        public DbSet<Book> Books { get; set; }
        //Books diye tanımlanan property aslında veritabanı tablosunun gerçek ismi yani Books(BookStore veritabanı içindeki bir tablo)

        
    }
}
