using ProyectoRegularizador.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoRegularizador.Entities
{
    public class Url
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UrlOrig { get; set; }
        public string? UrlShort { get; set; }
        public string? Name { get; set; }
        public int Count { get; set; }
        public Categoria Categoria { get; set; }

    }
}
