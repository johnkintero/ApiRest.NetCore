using System.Collections.Generic;
using System.Linq;
using System;
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

        public void CreateUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }
            _context.Usuario.Add(usuario);
        }

        public void DeleteUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }
            _context.Usuario.Remove(usuario);
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return _context.Usuario.ToList();
        }

        public Usuario GetUsuarioById(int Id)
        {
            return _context.Usuario.FirstOrDefault(u=> u.Id == Id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateUsuario(Usuario usuario)
        {
            
        }
    }
}