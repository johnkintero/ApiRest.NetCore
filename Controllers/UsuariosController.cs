using System.Collections.Generic;
using Alpha.Servicios.Data;
using Alpha.Servicios.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alpha.Servicios.Controllers
{
    //api/usuario
    [Route("api/usuario")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepo _repository;

        public UsuariosController(IUsuarioRepo repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult <IEnumerable<Usuario>> GetAllUsuarios()
        {
            var usuarios = _repository.GetAllUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public ActionResult <Usuario> GetUsuarioById(int id)
        {
            var usuario = _repository.GetUsuarioById(id);
            if (usuario != null)
            {
              return Ok(usuario);
            }  
            return NotFound();
        }
            


    }
}