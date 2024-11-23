using AutoMapper;
using HOSPEDAJE.Areas.ClienteArea.Repository;
using HOSPEDAJE.Areas.ClienteArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ClienteArea.Payloads.MensajesDTO;
using HOSPEDAJE.Models;

namespace HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteCRUD.CreateMS
{
    public class CreateClienteMS : ICreateClienteMS
    {
        private readonly IMapper _IMapper;
        private readonly IClienteRepository _IClienteRepository;
        public CreateClienteMS(IMapper iMapper, IClienteRepository iClienteRepository)
        {
            _IMapper = iMapper;
            _IClienteRepository = iClienteRepository;
        }

        public async Task<MensajePersonalizadoDTO> RegistrarCliente(RegistrarClienteDTO registrarClienteDTO)
        {
            try
            {
                var RODR_Cliente = _IMapper.Map<TblCliente>(registrarClienteDTO);
                await _IClienteRepository.RegistrarCliente(RODR_Cliente);

                return new MensajePersonalizadoDTO(true, "Cliente registrado exitosamente", RODR_Cliente.IdCliente, RODR_Cliente.Nombre, RODR_Cliente.Apellido);
            }
            catch (Exception ex)
            {
                var mensajeError = $"Error al registrar cliente: {ex.Message}";
                return new MensajePersonalizadoDTO(false, mensajeError, 0, null, null);
            }
        }
    }
}