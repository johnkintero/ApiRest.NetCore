using System.ComponentModel.DataAnnotations;

namespace   Alpha.Servicios.Dtos
{
    public  class UsuarioUpdateDto
    {
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
    }
}