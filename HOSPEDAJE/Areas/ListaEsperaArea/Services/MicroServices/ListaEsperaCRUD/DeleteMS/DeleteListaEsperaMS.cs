using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.MensajesDTO;
using HOSPEDAJE.Areas.ListaEsperaArea.Repository;
using HOSPEDAJE.Services.PatronUnitOfWork;

namespace HOSPEDAJE.Areas.ListaEsperaArea.Services.MicroServices.ListaEsperaCRUD.DeleteMS
{
    public class DeleteListaEsperaMS : IDeleteListaEsperaMS
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IListaEsperaRepository _IListaEsperaRepository;

        public DeleteListaEsperaMS(
            IUnitOfWork iUnitOfWork,
            IListaEsperaRepository iListaEsperaRepository)
        {
            _IUnitOfWork = iUnitOfWork;
            _IListaEsperaRepository = iListaEsperaRepository;
        }
        public async Task<MensajeEstandarDTO> Eliminar(int id)
        {
            try
            {
                await _IListaEsperaRepository.Eliminar(id);
                await _IUnitOfWork.SaveChangesAsync();
                return new MensajeEstandarDTO(true, "Eliminación exitosa");
            }
            catch (Exception ex)
            {
                return new MensajeEstandarDTO(false, $"Error al eliminar: {ex.Message}");
            }
        }
    }
}
