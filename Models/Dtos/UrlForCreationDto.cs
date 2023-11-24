using ProyectoRegularizador.Enum;
using System.ComponentModel.DataAnnotations;

namespace ProyectoRegularizador.Models.Dtos
{
    public class UrlForCreationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string UrlOrig { get; set; }
        public Categoria Categoria { get; set; }
    }
}
