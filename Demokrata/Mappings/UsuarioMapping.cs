using AutoMapper;
using Demokrata.DTOs;
using Demokrata.Models;

namespace Demokrata.Mappings
{
    public class UsuarioMapping : Profile
    {
        public UsuarioMapping()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
