using HOSPEDAJE.Models;

namespace HOSPEDAJE.Areas.ListaEsperaArea.Repository
{
    public interface IListaEsperaRepository
    {
        Task RegistrarListaEspera(TblListaEspera listaesperaregistrar);
        Task<List<TblListaEspera>> ObtenerTodos();
        Task<TblListaEspera?> ObtenerPorId(int id);
        void Actualizar(TblListaEspera listaEspera);
        Task Eliminar(int id);
        Task<bool> TieneRegistroPendiente(int idCliente);

    }
}
