using System.Collections.Generic;
using Alpha.Servicios.Models;

namespace Alpha.Servicios.Data
{
    /// <summary>
    /// Esta clase es para generar data de prueba manual que se eliminara al final
    /// </summary>
    public class MockUsuarioRepo : IUsuarioRepo
    {
        public IEnumerable<Usuario> GetAllUsuarios()
        {
            var usuarios = new List<Usuario>
            {
                new Usuario{Id=0,Nombres="test",Apellidos="Test"},
                new Usuario{Id=1,Nombres="test",Apellidos="Test"},
                new Usuario{Id=2,Nombres="test",Apellidos="Test"}
            };
            return usuarios;
        }

        public Usuario GetUsuarioById(int Id)
        {
            return new Usuario{Id=0,Nombres="test",Apellidos="Test"};
        }
    }
}