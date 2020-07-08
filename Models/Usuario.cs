
namespace   Alpha.Servicios.Models
{
    public  class Usuario
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
    }
}