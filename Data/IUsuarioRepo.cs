using System.Collections.Generic;
using Alpha.Servicios.Models;

namespace Alpha.Servicios.Data
{
    public interface IUsuarioRepo
    {
        IEnumerable<Usuario> GetAllUsuarios();
        Usuario GetUsuarioById(int Id);

    

    }
}