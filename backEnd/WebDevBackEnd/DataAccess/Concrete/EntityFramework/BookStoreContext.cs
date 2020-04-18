using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class BookStoreContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=DESKTOP-0KLVU2P\SQLEXPRESS;Database=BookStore;Trusted_Connection=true");
        }
        public DbSet<Book> Books { get; set; }

        
    }
}
