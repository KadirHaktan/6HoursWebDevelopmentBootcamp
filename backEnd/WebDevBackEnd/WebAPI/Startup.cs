using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IBookService, BookManager>();
            services.AddSingleton<IBookDal, EfBookDal>();
            //Baðýmlýlýklarý projemizin anlamasý açýsýnda soyut bir referans tipinde
            //nesne çaðrýldýðýnda gerçek sýnýf neye karþýlýk geliyor bunu çözümlüyoruz

            //Tabi bu baðýmlýlýklarý çözmek Autofac ya da Ninject tarzý kütüphanelerle
            //ayrý birimde baðýmlýlýklarý çözümlemek daha profesyonel olacaktýr.Özellikle
            //Autofac'in Interceptor yapýsý olmasý itibariyle AOP denilen nesne yönelimli kodlama
            //tekniði uygulamamýza yardýmcý oluyor.O yüzden Autofac kullanýlabilir

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());
            });

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());
            //UseCors middleware ile api'yi kullanacak olan bir origine izin saðlanýyor burada 4200 portlu olan angular uygulamasýna
            //api'nin kendisini kullanmasýna izin veriliyor.
            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
