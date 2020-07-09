using System.Collections.Generic;
using Alpha.Servicios.Models;

namespace Alpha.Servicios.Data
{
    public interface IUsuarioRepo
    {
        bool SaveChanges();
        IEnumerable<Usuario> GetAllUsuarios();
        Usuario GetUsuarioById(int Id);
        void CreateUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(Usuario usuario);

    

    }
}