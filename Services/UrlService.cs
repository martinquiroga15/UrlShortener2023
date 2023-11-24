using Microsoft.AspNetCore.Mvc;
using ProyectoRegularizador.Data;
using ProyectoRegularizador.Entities;
using ProyectoRegularizador.Enum;
using ProyectoRegularizador.Helpers;
using ProyectoRegularizador.Models.Dtos;
using System;

namespace ProyectoRegularizador.Services
{
    public class UrlService
    {
        private ShortenerContext _context;
        public UrlService(ShortenerContext context)
        {
            _context = context;
        }


        public IEnumerable<Url> getAll()
        {
            return _context.Urls.ToList();
        }


        public IActionResult GetUrlByShortUrl(string shortUrl)
        {
            var urlEntity = _context.Urls.FirstOrDefault(u => u.UrlShort == shortUrl);

            if (urlEntity == null)
            {
                return new NotFoundObjectResult("no existe");
            }
            else
            {
                urlEntity.Count++;
                _context.SaveChanges();
                return new RedirectResult(urlEntity.UrlOrig);
            }
        }



        public IActionResult CreateUrl(UrlForCreationDto newUrl)
        {
            var existingUrl = _context.Urls.FirstOrDefault(u => u.UrlOrig == newUrl.UrlOrig);
            if (existingUrl != null)
            {
                return new ConflictObjectResult("ya existe");
            }

            string shortUrl = CreateShortUrl.GenerateShortUrl();

            var urlEntity = new Url()
            {
                Name = newUrl.Name,
                UrlOrig = newUrl.UrlOrig,
                UrlShort = shortUrl,
                Count = 0,
                Categoria = newUrl.Categoria,
            };

            _context.Urls.Add(urlEntity);
            _context.SaveChanges();

            return new RedirectResult(newUrl.UrlOrig);
        }


  
    }
}
