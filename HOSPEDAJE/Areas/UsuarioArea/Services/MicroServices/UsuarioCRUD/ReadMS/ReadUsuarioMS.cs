using AutoMapper;
using HOSPEDAJE.Areas.UsuarioArea.Repository;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioCRUD.ReadMS
{
    public class ReadUsuarioMS : IReadUsuarioMS
    {
        private readonly IMapper _IMapper;
        private readonly IUsuarioRepository _IUsuarioRepository;
        public ReadUsuarioMS(IMapper iMapper, IUsuarioRepository iUsuarioRepository)
        {
            _IMapper = iMapper;
            _IUsuarioRepository = iUsuarioRepository;
        }
        public async Task<MensajeEstandarDTO> ValidarCorreo(string correo)
        {
            var Buscarcorreo = await _IUsuarioRepository.ValidarCorreo(correo);
            if (Buscarcorreo != null)
            {
                return new MensajeEstandarDTO(false, "Ya hay un usuario registrado con este correo.");
            }
            else
            {
                return new MensajeEstandarDTO(true, "El correo está disponible para registro.");
            }
        }
        public async Task<MensajeEstandarDTO> ValidarEstado(string correo)
        {
            var EstadoValidado = await _IUsuarioRepository.ValidarEstado(correo);
            if (!EstadoValidado)
            {
                return new MensajeEstandarDTO(false, "Cuenta inactiva o no existe");
            }

            return new MensajeEstandarDTO(true, "Cuenta activa");
        }
        public async Task<DetalleUsuarioDTO> DetalleUsuario(int idUsuario)
        {
            var Usuario = await _IUsuarioRepository.ObtenerUsuarioPorId(idUsuario);
            var DetalleUsuario = await _IUsuarioRepository.ObtenerDetalleUsuarioPorId(idUsuario);

            if (Usuario == null)
            {
                return new DetalleUsuarioDTO(false, "Usuario no encontrado",
                    0, 0, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            }

            if (DetalleUsuario == null)
            {
                return new DetalleUsuarioDTO(true, "Usuario encontrado, pero no se encontró el detalle",
                    Usuario.IdUsuario,
                    Usuario.IdRol,
                    Usuario.Nombre,
                    Usuario.Apellido,
                    Usuario.Correo,
                    Usuario.Contraseña,
                    Usuario.Estado,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                );
            }

            return new DetalleUsuarioDTO(true, "Detalle encontrado",
                Usuario.IdUsuario,
                Usuario.IdRol,
                Usuario.Nombre,
                Usuario.Apellido,
                Usuario.Correo,
                Usuario.Contraseña,
                Usuario.Estado,
                DetalleUsuario.Imagen,
                DetalleUsuario.FechaContratacion,
                DetalleUsuario.Genero,
                DetalleUsuario.Telefono,
                DetalleUsuario.Direccion,
                DetalleUsuario.FechaNacimiento,
                DetalleUsuario.Preferencias,
                DetalleUsuario.EstadoCivil,
                DetalleUsuario.RedesSociales,
                DetalleUsuario.Idioma,
                DetalleUsuario.Ocupacion,
                DetalleUsuario.NotasAdicionales,
                DetalleUsuario.FechaUltimaActualizacion
            );
        }
    }
}
