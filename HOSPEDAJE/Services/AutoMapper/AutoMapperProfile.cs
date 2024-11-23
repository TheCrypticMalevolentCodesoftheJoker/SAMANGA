using AutoMapper;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ClienteArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Models;

namespace HOSPEDAJE.Services.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Cliente
            CreateMap<TblCliente, RegistrarClienteDTO>().ReverseMap();

            // Usuario
            CreateMap<TblUsuario, RegistrarUsuarioDTO>().ReverseMap();
            CreateMap<TblDetalleUsuario, DetalleUsuarioDTO>().ReverseMap();
        }
    }
}
