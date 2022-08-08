using Bogus;
using Example.API.DataAccess;
using Example.API.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Example.API.Middleware
{
    public class UserAddMiddleware
    {

        //BURADA ÖRNEK OLMASI AMACIYLA MIDDLEWARE TETIKLENDIGI ESNADA SAHTE VERİ OLUSTURMAK ISTEDIM.
        RequestDelegate next;
        public UserAddMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            
            //Bogus adlı paketimizi kurduktan sonra fake data üretmeye başlıyoruz.
            //Burada oluşturduğumuz nesne tipinde rastgele sahte veriler oluşturuyoruz.
            var fakeUser = new Faker<User>()
               .RuleFor(x => x.LastName, x => x.Name.LastName())
               .RuleFor(x => x.Name /*Değer vereceğin değişken*/, x => x.Name.FirstName()/*Değişkene verilecek değer*/)
               .RuleFor(x => x.Address, x => x.Address.County())
               .RuleFor(x => x.Age, x => x.Random.Byte(18, 90))
               .Generate(100)/*Bİzim için 100 adet üretmesini söylüyoruz.*/;

               Context.UserAdd(fakeUser);

            //Burada boş boş bekleme git diğerlerine haber var çalışmaya başlasınlar. Bitirdikçede geriye doğru gelin.
            await next.Invoke(context);
        }
    }
}
