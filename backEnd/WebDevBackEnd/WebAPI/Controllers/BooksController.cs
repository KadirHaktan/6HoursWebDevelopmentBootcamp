using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookService _bookServices { get; set; }
        //IBookService referans tipinde bir property oluşturulmakta ve yapıcı metotta
        //yine kendisi türünde başka bir nesne parametre olarak verip ardından
        //propertnin kendisini parametrede verilen IBookService referans tipine atılıyor.Tabi bundaki amaç şu ki;

        //Yani Neden BookManager değil de IBookService şöyle ki yarın öbür gün başka bir IBookService'dan implemente
        //edilen bir sınıftan nesneyi Controller sınıfımızın içinde kullanabiliriz.

        //İşte bu sebeple başka bir class'dan
        //referans tipi kullanılabileceği için biz bu class'ları genel olarak metot yapısını 
        //imzalayan interface'i property ve parametre veriyoruz
        //böylelikle Controller sınıfımızın herhangi bir sınıfa bağlı kalmadan istediği 
       //IBookService'dan implemente eden bir sınıfı kullanabilmekte
        

        

        public BooksController(IBookService _services)
        {
            this._bookServices = _services;
        }
        //Yukarıda söylediğimiz ve Manager sınıfında olduğu gibi burda da bağımlılığı kaldırmak amacıyla
        //Depency Injection tasarım deseni uygulanmakta.

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(_bookServices.GetAll());
        }
    }
}