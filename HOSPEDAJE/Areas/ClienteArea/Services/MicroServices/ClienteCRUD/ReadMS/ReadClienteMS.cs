using HOSPEDAJE.Areas.ClienteArea.Repository;
using HOSPEDAJE.Areas.ClienteArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ClienteArea.Payloads.MensajesDTO;


namespace HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteCRUD.ReadMS
{
    public class ReadClienteMS : IReadClienteMS
    {
        private readonly IClienteRepository _IClienteRepository;
        public ReadClienteMS(IClienteRepository iClienteRepository)
        {
            _IClienteRepository = iClienteRepository;
        }

        public async Task<MensajeEstandarDTO> ValidarCorreo(string correo)
        {
            var RODR_Cliente = await _IClienteRepository.ValidarCorreo(correo);

            if (RODR_Cliente != null)
            {
                return new MensajeEstandarDTO(false, "Ya hay un cliente registrado con este correo.");
            }
            else
            {
                return new MensajeEstandarDTO(true, "El correo está disponible para registro.");
            }
        }
        public async Task<MensajeEstandarDTO> ValidarEstado(string Correo)
        {
            try
            {
                var RODR_Cliente = await _IClienteRepository.ValidarEstado(Correo);
                if (!RODR_Cliente)
                {
                    return new MensajeEstandarDTO(false, "Cuenta inactiva");
                }

                return new MensajeEstandarDTO(true, "Cuenta activa");
            }
            catch (Exception ex)
            {
                var mensajeError = $"Error al registrar cliente: {ex.Message}";
                return new MensajeEstandarDTO(false, mensajeError);
            }
        }
        public async Task<DetalleClienteDTO> DetalleCliente(int idCliente)
        {
            var cliente = await _IClienteRepository.ObtenerClientePorId(idCliente);
            var detalleCliente = await _IClienteRepository.ObtenerDetalleClientePorId(idCliente);

            if (cliente == null)
            {
                return new DetalleClienteDTO(false, "Detalle no encontrado", null, null, null, null, null);
            }
            return new DetalleClienteDTO(true, "Detalle encontrado",
                cliente.Nombre,
                cliente.Apellido,
                cliente.Correo,
                detalleCliente?.Genero,
                detalleCliente?.Telefono);
        }
    }
}
