using HOSPEDAJE.Areas.ClienteArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteCRUD.DeleteMS
{
    public interface IDeleteClienteMS
    {
        Task<MensajeEstandarDTO> EliminarCliente(int idCliente);
    }
}
