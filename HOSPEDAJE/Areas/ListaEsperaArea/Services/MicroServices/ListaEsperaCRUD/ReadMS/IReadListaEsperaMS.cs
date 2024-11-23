using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.EntidadesDTO;

namespace HOSPEDAJE.Areas.ListaEsperaArea.Services.MicroServices.ListaEsperaCRUD.ReadMS
{
    public interface IReadListaEsperaMS
    {
        Task<List<ListaEsperaDTO>> ObtenerTodos();
        Task<ListaEsperaDTO?> ObtenerPorId(int id);
    }
}
