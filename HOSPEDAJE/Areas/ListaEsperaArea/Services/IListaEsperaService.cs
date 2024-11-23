using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.ListaEsperaArea.Services
{
    public interface IListaEsperaService
    {
        Task<MensajeEstandarDTO> RegistrarListaEspera(ListaEsperaDTO ControladorListaEsperaDTO);
        Task<List<ListaEsperaDTO>> ObtenerTodos();
        Task<ListaEsperaDTO?> ObtenerPorId(int id);
        Task<MensajeEstandarDTO> Actualizar(ListaEsperaDTO listaEspera);
        Task<MensajeEstandarDTO> Eliminar(int id);
    }
}
