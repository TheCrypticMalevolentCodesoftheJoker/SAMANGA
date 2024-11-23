using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.ListaEsperaArea.Services.MicroServices.ListaEsperaCRUD.CreateMS
{
    public interface ICreateListaEsperaMS
    {
        Task<MensajeEstandarDTO> RegistrarListaEspera(ListaEsperaDTO ServiceListaEsperaDTO);
    }
}
