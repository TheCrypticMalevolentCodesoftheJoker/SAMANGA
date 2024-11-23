using HOSPEDAJE.Areas.ClienteArea.Repository;
using HOSPEDAJE.Areas.ClienteArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteCRUD.DeleteMS
{
    public class DeleteClienteMS : IDeleteClienteMS
    {
        private readonly IClienteRepository _IClienteRepository;
        public DeleteClienteMS(IClienteRepository iClienteRepository)
        {
            _IClienteRepository = iClienteRepository;
        }

        public async Task<MensajeEstandarDTO> EliminarCliente(int idCliente)
        {
            var cliente = await _IClienteRepository.ObtenerClientePorId(idCliente);
            if (cliente == null)
            {
                return new MensajeEstandarDTO(false, "Cliente no encontrado.");
            }

            bool estadoActualizado = await _IClienteRepository.EliminarCliente(idCliente, "I");

            if (!estadoActualizado)
            {
                return new MensajeEstandarDTO(false, "Error al intentar eliminar cliente.");
            }

            return new MensajeEstandarDTO(true, "Tu cuenta ha sido eliminada con éxito.");
        }
    }
}
