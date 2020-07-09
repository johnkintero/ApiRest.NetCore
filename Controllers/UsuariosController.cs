using System.Collections.Generic;
using Alpha.Servicios.Data;
using Alpha.Servicios.Dtos;
using Alpha.Servicios.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

        //PUT api/usuario/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUsuario(int id, UsuarioUpdateDto usuarioUpdate)
        {
            var usuarioModelFromRepo = _repository.GetUsuarioById(id);
            if (usuarioModelFromRepo == null)
            {
                return NotFound();
            }
                _mapper.Map(usuarioUpdate, usuarioModelFromRepo);
                _repository.UpdateUsuario(usuarioModelFromRepo);
                _repository.SaveChanges();
                return NoContent();
        }

        //PATCH api/usuario/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUsuarioUpdate(int id, JsonPatchDocument<UsuarioUpdateDto> patchDoc)
        {
            var usuarioModelFromRepo = _repository.GetUsuarioById(id);
            if (usuarioModelFromRepo == null)
            {
                return NotFound();
            }
            var usuarioToPatch = _mapper.Map<UsuarioUpdateDto>(usuarioModelFromRepo);
            patchDoc.ApplyTo(usuarioToPatch, ModelState);
            if(!TryValidateModel(usuarioToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(usuarioToPatch, usuarioModelFromRepo);

            _repository.UpdateUsuario(usuarioModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/usuario/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUsuario(int id)
        {
            var usuarioModelFromRepo = _repository.GetUsuarioById(id);
            if (usuarioModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteUsuario(usuarioModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

    }
}