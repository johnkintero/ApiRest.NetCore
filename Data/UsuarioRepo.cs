using System.Collections.Generic;
using System.Linq;
using Alpha.Servicios.Models;

namespace Alpha.Servicios.Data
{
    public class UsuarioRepo : IUsuarioRepo
    {
        private readonly AlphaAppContext _context;
        public UsuarioRepo(AlphaAppContext context)
        {
            _context = context;
        }
        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return _context.Usuario.ToList();
        }

        public Usuario GetUsuarioById(int Id)
        {
            return _context.Usuario.FirstOrDefault(u=> u.Id == Id);
        }
    }
}