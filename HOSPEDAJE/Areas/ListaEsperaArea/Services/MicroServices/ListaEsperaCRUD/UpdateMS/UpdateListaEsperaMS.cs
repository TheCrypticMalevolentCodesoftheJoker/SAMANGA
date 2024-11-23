using AutoMapper;
using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.MensajesDTO;
using HOSPEDAJE.Areas.ListaEsperaArea.Repository;
using HOSPEDAJE.Models;
using HOSPEDAJE.Services.PatronUnitOfWork;

namespace HOSPEDAJE.Areas.ListaEsperaArea.Services.MicroServices.ListaEsperaCRUD.UpdateMS
{
    public class UpdateListaEsperaMS : IUpdateListaEsperaMS
    {
        private readonly IUnitOfWork _iunitOfWork;
        private readonly IMapper _mapper;
        private readonly IListaEsperaRepository _iListaEsperaRepository;
        public UpdateListaEsperaMS(IUnitOfWork iunitOfWork,  IListaEsperaRepository iListaEsperaRepository, IMapper iMapper)
        {
            _iunitOfWork = iunitOfWork;
            _mapper = iMapper;
            _iListaEsperaRepository = iListaEsperaRepository;
        }
        public async Task<MensajeEstandarDTO> Actualizar(ListaEsperaDTO listaEspera)
        {
            try
            {
                var entidad = _mapper.Map<TblListaEspera>(listaEspera);
                _iListaEsperaRepository.Actualizar(entidad);
                await _iunitOfWork.SaveChangesAsync();
                return new MensajeEstandarDTO(true, "Actualización exitosa");
            }
            catch (Exception ex)
            {
                return new MensajeEstandarDTO(false, $"Error al actualizar: {ex.Message}");
            }
        }
    }
}
