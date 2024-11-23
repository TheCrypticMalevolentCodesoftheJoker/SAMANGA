using AutoMapper;
using HOSPEDAJE.Models;
using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.MensajesDTO;
using HOSPEDAJE.Areas.ListaEsperaArea.Repository;

namespace HOSPEDAJE.Areas.ListaEsperaArea.Services.MicroServices.ListaEsperaCRUD.CreateMS
{
    public class CreateListaEsperaMS : ICreateListaEsperaMS
    {
        public readonly IMapper _mapper;
        public readonly IListaEsperaRepository _iListaEsperaRepository;
        public CreateListaEsperaMS(IListaEsperaRepository iListaEsperaRepository, IMapper iMapper)
        {
            _mapper = iMapper;
            _iListaEsperaRepository = iListaEsperaRepository;
        }

        public async Task<MensajeEstandarDTO> RegistrarListaEspera(ListaEsperaDTO ServiceListaEsperaDTO)
        {
            var listaesperaregistrar = _mapper.Map<TblListaEspera>(ServiceListaEsperaDTO);
            await _iListaEsperaRepository.RegistrarListaEspera(listaesperaregistrar);
            return new MensajeEstandarDTO(true, "Registro Exitoso en la Lista de Espera");
        }
    }
}