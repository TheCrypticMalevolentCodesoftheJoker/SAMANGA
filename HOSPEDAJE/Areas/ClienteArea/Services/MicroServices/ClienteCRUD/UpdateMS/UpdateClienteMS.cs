using HOSPEDAJE.Areas.ClienteArea.Repository;
using HOSPEDAJE.Areas.ClienteArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ClienteArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteCRUD.UpdateMS
{
    public class UpdateClienteMS : IUpdateClienteMS
    {
        private readonly IClienteRepository _IClienteRepository;
        public UpdateClienteMS(IClienteRepository iClienteRepository)
        {
            _IClienteRepository = iClienteRepository;
        }

        public async Task<MensajePersonalizadoDTO> ActualizarCliente(DetalleClienteDTO detalleClienteDTO, int idCliente)
        {
            var RODR_ClienteID = await _IClienteRepository.ObtenerClientePorId(idCliente);
            if (RODR_ClienteID == null)
            {
                return new MensajePersonalizadoDTO(false, "Cliente no encontrado.", 0, null, null);
            }

            RODR_ClienteID.Nombre = detalleClienteDTO.Nombre;
            RODR_ClienteID.Apellido = detalleClienteDTO.Apellido;
            RODR_ClienteID.Correo = detalleClienteDTO.Correo;

            var RODR_ActualizarCliente = await _IClienteRepository.ActualizarCliente(RODR_ClienteID);
            if (!RODR_ActualizarCliente)
            {
                return new MensajePersonalizadoDTO(false, "Error al actualizar los datos del cliente.", 0, null, null);
            }

            return new MensajePersonalizadoDTO(true, "Cliente actualizado.", RODR_ClienteID.IdCliente, RODR_ClienteID.Nombre, RODR_ClienteID.Apellido);
        }
        public async Task<MensajeEstandarDTO> ActualizarDetalleCliente(DetalleClienteDTO detalleClienteDTO, int idCliente)
        {
            var RODR_DetalleClienteID = await _IClienteRepository.ObtenerDetalleClientePorId(idCliente);
            if (RODR_DetalleClienteID == null)
            {
                return new MensajeEstandarDTO(false, "Detalle del cliente no encontrado.");
            }

            RODR_DetalleClienteID.Genero = detalleClienteDTO.Genero;
            RODR_DetalleClienteID.Telefono = detalleClienteDTO.Telefono;

            var resultado = await _IClienteRepository.ActualizarDetalleCliente(RODR_DetalleClienteID);
            if (!resultado)
            {
                return new MensajeEstandarDTO(false, "Error al actualizar los detalles del cliente.");
            }

            return new MensajeEstandarDTO(true, "Detalles actualizados.");
        }
    }
}
