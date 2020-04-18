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

        public BooksController(IBookService _services)
        {
            this._bookServices = _services;
        }
        //Manager sınıfında olduğu gibi burda da bağımlılığı kaldırmak amacıyla
        //Depency Injection tasarım deseni uygulanmakta

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(_bookServices.GetAll());
        }
    }
}