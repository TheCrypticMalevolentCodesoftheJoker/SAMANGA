using HOSPEDAJE.Models;
using HOSPEDAJE.Areas.UsuarioArea.Repository;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioCRUD.UpdateMS
{
    public class UpdateUsuarioMS : IUpdateUsuarioMS
    {
        private readonly IUsuarioRepository _IUsuarioRepository;

        public UpdateUsuarioMS(IUsuarioRepository iUsuarioRepository)
        {
            _IUsuarioRepository = iUsuarioRepository;
        }
        public async Task<MensajePersonalizadoDTO> ActualizarUsuario(DetalleUsuarioDTO detalleUsuarioDTO, int idUsuario)
        {
            var BuscarUsuario = await _IUsuarioRepository.ObtenerUsuarioPorId(idUsuario);
            if (BuscarUsuario == null)
            {
                return new MensajePersonalizadoDTO(false, "Usuario no encontrado", 0, null, null, 0);
            }
            BuscarUsuario.Nombre = detalleUsuarioDTO.Nombre;
            BuscarUsuario.Apellido = detalleUsuarioDTO.Apellido;
            BuscarUsuario.Correo = detalleUsuarioDTO.Correo;
            BuscarUsuario.Contraseña = detalleUsuarioDTO.Contraseña;

            var ActualizarUsuario = await _IUsuarioRepository.ActualizarUsuario(BuscarUsuario);
            if (!ActualizarUsuario)
            {
                return new MensajePersonalizadoDTO(false, "Error al actualizar datos", 0, null, null, 0);
            }
            return new MensajePersonalizadoDTO(true, "Datos actualizado", BuscarUsuario.IdUsuario, BuscarUsuario.Nombre, BuscarUsuario.Apellido, BuscarUsuario.IdRol);
        }
        public async Task<MensajeEstandarDTO> ActualizarDetalleUsuario(DetalleUsuarioDTO detalleUsuarioDTO, int idUsuario)
        {
            var buscarDetalleUsuario = await _IUsuarioRepository.ObtenerDetalleUsuarioPorId(idUsuario);

            if (buscarDetalleUsuario == null)
            {
                var nuevoDetalleUsuario = new TblDetalleUsuario()
                {
                    IdUsuario = idUsuario,
                    Imagen = detalleUsuarioDTO.Imagen,
                    Genero = detalleUsuarioDTO.Genero,
                    Telefono = detalleUsuarioDTO.Telefono,
                    Direccion = detalleUsuarioDTO.Direccion,
                    FechaNacimiento = detalleUsuarioDTO.FechaNacimiento,
                    Preferencias = detalleUsuarioDTO.Preferencias,
                    EstadoCivil = detalleUsuarioDTO.EstadoCivil,
                    RedesSociales = detalleUsuarioDTO.RedesSociales,
                    Idioma = detalleUsuarioDTO.Idioma,
                    Ocupacion = detalleUsuarioDTO.Ocupacion,
                    NotasAdicionales = detalleUsuarioDTO.NotasAdicionales,
                    FechaUltimaActualizacion = detalleUsuarioDTO.FechaUltimaActualizacion
                };
                var crearDetalleUsuario = await _IUsuarioRepository.RegistrarDetalleUsuario(nuevoDetalleUsuario);
                if (!crearDetalleUsuario)
                {
                    return new MensajeEstandarDTO(false, "Error al crear los datos del usuario");
                }

                return new MensajeEstandarDTO(true, "Datos creados con éxito");
            }
            else
            {
                buscarDetalleUsuario.Imagen = detalleUsuarioDTO.Imagen;
                buscarDetalleUsuario.Genero = detalleUsuarioDTO.Genero;
                buscarDetalleUsuario.Telefono = detalleUsuarioDTO.Telefono;
                buscarDetalleUsuario.Direccion = detalleUsuarioDTO.Direccion;
                buscarDetalleUsuario.FechaNacimiento = detalleUsuarioDTO.FechaNacimiento;
                buscarDetalleUsuario.Preferencias = detalleUsuarioDTO.Preferencias;
                buscarDetalleUsuario.EstadoCivil = detalleUsuarioDTO.EstadoCivil;
                buscarDetalleUsuario.RedesSociales = detalleUsuarioDTO.RedesSociales;
                buscarDetalleUsuario.Idioma = detalleUsuarioDTO.Idioma;
                buscarDetalleUsuario.Ocupacion = detalleUsuarioDTO.Ocupacion;
                buscarDetalleUsuario.NotasAdicionales = detalleUsuarioDTO.NotasAdicionales;
                buscarDetalleUsuario.FechaUltimaActualizacion = detalleUsuarioDTO.FechaUltimaActualizacion;

                var actualizarDetalleUsuario = await _IUsuarioRepository.ActualizarDetalleUsuario(buscarDetalleUsuario);
                if (!actualizarDetalleUsuario)
                {
                    return new MensajeEstandarDTO(false, "Error al actualizar los datos");
                }

                return new MensajeEstandarDTO(true, "Datos actualizados con éxito");
            }
        }
    }
}
