using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.ListaEsperaArea.Services.MicroServices.ListaEsperaCRUD.UpdateMS
{
    public interface IUpdateListaEsperaMS
    {
        Task<MensajeEstandarDTO> Actualizar(ListaEsperaDTO listaEspera);
    }
}
