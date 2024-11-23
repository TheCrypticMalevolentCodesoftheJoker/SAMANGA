using AutoMapper;
using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ListaEsperaArea.Repository;

namespace HOSPEDAJE.Areas.ListaEsperaArea.Services.MicroServices.ListaEsperaCRUD.ReadMS
{
    public class ReadListaEsperaMS : IReadListaEsperaMS
    {
        public readonly IMapper _mapper;
        public readonly IListaEsperaRepository _iListaEsperaRepository;
        public ReadListaEsperaMS(IListaEsperaRepository iListaEsperaRepository, IMapper iMapper)
        {
            _mapper = iMapper;
            _iListaEsperaRepository = iListaEsperaRepository;
        }
        public async Task<List<ListaEsperaDTO>> ObtenerTodos()
        {
            var entidades = await _iListaEsperaRepository.ObtenerTodos();
            return _mapper.Map<List<ListaEsperaDTO>>(entidades);
        }

        public async Task<ListaEsperaDTO?> ObtenerPorId(int id)
        {
            var entidad = await _iListaEsperaRepository.ObtenerPorId(id);
            return _mapper.Map<ListaEsperaDTO?>(entidad);
        }
    }
}
