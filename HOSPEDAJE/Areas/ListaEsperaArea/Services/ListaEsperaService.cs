using HOSPEDAJE.Services.PatronUnitOfWork;
using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.MensajesDTO;
using HOSPEDAJE.Areas.ListaEsperaArea.Services.MicroServices.ListaEsperaCRUD.CreateMS;
using HOSPEDAJE.Areas.ListaEsperaArea.Services.MicroServices.ListaEsperaCRUD.ReadMS;
using HOSPEDAJE.Areas.ListaEsperaArea.Services.MicroServices.ListaEsperaCRUD.UpdateMS;
using HOSPEDAJE.Areas.ListaEsperaArea.Services.MicroServices.ListaEsperaCRUD.DeleteMS;
using HOSPEDAJE.Areas.ListaEsperaArea.Repository;

namespace HOSPEDAJE.Areas.ListaEsperaArea.Services
{
    public class ListaEsperaService : IListaEsperaService
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IListaEsperaRepository _IListaEsperaRepository;
        private readonly ICreateListaEsperaMS _ICreateListaEsperaMS;
        private readonly IReadListaEsperaMS _IReadListaEsperaMS;
        private readonly IUpdateListaEsperaMS _IUpdateListaEsperaMS;
        private readonly IDeleteListaEsperaMS _IDeleteListaEsperaMS;

        public ListaEsperaService(
            IUnitOfWork iUnitOfWork,
            IListaEsperaRepository iListaEsperaRepository,
            ICreateListaEsperaMS iCreateListaEsperaMS,
            IReadListaEsperaMS iReadListaEsperaMS,
            IUpdateListaEsperaMS iUpdateListaEsperaMS,
            IDeleteListaEsperaMS iDeleteListaEsperaMS)
        {
            _IUnitOfWork = iUnitOfWork;
            _IListaEsperaRepository = iListaEsperaRepository;
            _ICreateListaEsperaMS = iCreateListaEsperaMS;
            _ICreateListaEsperaMS = iCreateListaEsperaMS;
            _IReadListaEsperaMS = iReadListaEsperaMS;
            _IUpdateListaEsperaMS = iUpdateListaEsperaMS;
            _IDeleteListaEsperaMS = iDeleteListaEsperaMS;
        }

        public async Task<MensajeEstandarDTO> RegistrarListaEspera(ListaEsperaDTO ControladorListaEsperaDTO)
        {
            try
            {
                bool tienePendiente = await _IListaEsperaRepository.TieneRegistroPendiente(ControladorListaEsperaDTO.IdCliente);

                if (tienePendiente)
                {
                    return new MensajeEstandarDTO(false, "USTED TIENE UN REGISTRO DE ESPERA PENDIENTE");
                }
                ControladorListaEsperaDTO.Estado = "E";

                await _IUnitOfWork.BeginTransactionAsync();
                var mensajeregistrolistaespera = await _ICreateListaEsperaMS.RegistrarListaEspera(ControladorListaEsperaDTO);

                if (!mensajeregistrolistaespera.EsExito)
                {
                    await _IUnitOfWork.RollbackTransactionAsync();
                    return new MensajeEstandarDTO(false, mensajeregistrolistaespera.Descripcion);
                }

                await _IUnitOfWork.SaveChangesAsync();
                await _IUnitOfWork.CommitTransactionAsync();

                return new MensajeEstandarDTO(true, "Registro exitoso.");
            }
            catch (Exception ex)
            {
                await _IUnitOfWork.RollbackTransactionAsync();
                return new MensajeEstandarDTO(false, $"Error al registrar: {ex.Message}");
            }
        }
        public async Task<List<ListaEsperaDTO>> ObtenerTodos()
        {
            return await _IReadListaEsperaMS.ObtenerTodos();
        }
        public async Task<ListaEsperaDTO?> ObtenerPorId(int id)
        {
            return await _IReadListaEsperaMS.ObtenerPorId(id);
        }
        public async Task<MensajeEstandarDTO> Actualizar(ListaEsperaDTO listaEspera)
        {
            return await _IUpdateListaEsperaMS.Actualizar(listaEspera);
        }
        public async Task<MensajeEstandarDTO> Eliminar(int id)
        {
            return await _IDeleteListaEsperaMS.Eliminar(id);
        }
    }
}
