using Alpha.Servicios.Dtos;
using Alpha.Servicios.Models;
using AutoMapper;

namespace Alpha.Servicios.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            //source -> target
            CreateMap<Usuario, UsuarioReadDto>();
            CreateMap<UsuarioCreateDto, Usuario>();     
            CreateMap<UsuarioUpdateDto, Usuario>();
            CreateMap<Usuario,UsuarioUpdateDto>();
        }
    }
}