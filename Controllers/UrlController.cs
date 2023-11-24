using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ProyectoRegularizador.Data;
using ProyectoRegularizador.Data.Entities;
using ProyectoRegularizador.Enum;
using ProyectoRegularizador.Helpers;
using ProyectoRegularizador.Models.Dtos;
using ProyectoRegularizador.Services;
using System.Xml;

namespace ProyectoRegularizador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UrlController : ControllerBase
    {

        private ShortenerContext _context;
        private UrlService _urlService;
        public UrlController(ShortenerContext context,UrlService urlService)
        {
            _context = context;
            _urlService = urlService;
        }

       



        [HttpPost]
        public IActionResult PostUrl([FromBody] UrlForCreationDto NewUrl )
        {
            return _urlService.CreateUrl(NewUrl);
        }





        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetUrls() 
        {
            return Ok(_urlService.getAll());
        }

    

        [HttpGet("get/{Url}")]
        [AllowAnonymous]
        public IActionResult GetUrl(string Url) 
        { 
            return Ok(_urlService.GetUrlByShortUrl(Url));

        }




        [HttpGet("api/url/getByCategories")]
        public IActionResult getByCategories(Categoria categorias)
        {
            var urls = _context.Urls.Where(u => u.Categoria == categorias).ToList();
            if (urls == null)
            {
                return NotFound("No hay nada");
            }
            else
            {
                return Ok(urls);
            }

        }

    }
}

