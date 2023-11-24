using System.ComponentModel.DataAnnotations;

namespace ProyectoRegularizador.Models.Dtos
{
    public class AuthenticationRequestDto
    {
        [Required]
        public string? Name { get; set; }


        [Required]
        public string? Password { get; set; }
    }
}
