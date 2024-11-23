using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.ListaEsperaArea.Services.MicroServices.ListaEsperaCRUD.DeleteMS
{
    public interface IDeleteListaEsperaMS
    {
        Task<MensajeEstandarDTO> Eliminar(int id);
    }
}
