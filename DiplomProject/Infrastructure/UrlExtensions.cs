using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DiplomProject.Infrastructure
{
    //Расширяющий метод генерирует
    //URL, по которому браузер будет возвращаться после обновления корзины, принимая
    //во внимание строку запроса, если она есть.
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue
                ? $"{request.Path}{request.QueryString}"
                : request.Path.ToString();
    }
}
