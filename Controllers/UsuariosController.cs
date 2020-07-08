using System.Collections.Generic;
using Alpha.Servicios.Data;
using Alpha.Servicios.Dtos;
using Alpha.Servicios.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Alpha.Servicios.Controllers
{
    //api/usuario
    [Route("api/usuario")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepo _repository;

        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/usuario
        [HttpGet]
        public ActionResult <IEnumerable<UsuarioReadDto>> GetAllUsuarios()
        {
            var usuarios = _repository.GetAllUsuarios();
            return Ok(_mapper.Map<IEnumerable<UsuarioReadDto>>(usuarios));
        }
        
        //GET api/usuario/{id}
        [HttpGet("{id}", Name="GetUsuarioById")]
        public ActionResult <UsuarioReadDto> GetUsuarioById(int id)
        {
            var usuario = _repository.GetUsuarioById(id);
            if (usuario != null)
            {
              return Ok(_mapper.Map<UsuarioReadDto>(usuario));
            }  
            return NotFound();
        }
            
        //POST api/usuario/
        [HttpPost]
        public ActionResult <UsuarioReadDto> CreateUsuario(UsuarioCreateDto usuarioCreateDto)
        {
            var usuarioModel = _mapper.Map<Usuario>(usuarioCreateDto);
            _repository.CreateUsuario(usuarioModel);
            _repository.SaveChanges();
            var usuarioReadDto = _mapper.Map<UsuarioReadDto>(usuarioModel);
            return CreatedAtRoute(nameof(GetUsuarioById), new {Id = usuarioReadDto.Id},usuarioReadDto );
            //return Ok(usuarioReadDto);
        }

    }
}