using HOSPEDAJE.Services.PatronUnitOfWork;
using HOSPEDAJE.Areas.ClienteArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ClienteArea.Payloads.MensajesDTO;
using HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteBcrypt;
using HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteCRUD.CreateMS;
using HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteCRUD.ReadMS;
using HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteCRUD.UpdateMS;
using HOSPEDAJE.Areas.ClienteArea.Services.MicroServices.ClienteCRUD.DeleteMS;

namespace HOSPEDAJE.Areas.ClienteArea.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IBcryptCliente _IBcryptCliente;
        private readonly ICreateClienteMS _ICreateClienteMS;
        private readonly IReadClienteMS _IReadClienteMS;
        private readonly IUpdateClienteMS _IUpdateClienteMS;
        private readonly IDeleteClienteMS _IDeleteClienteMS;
        public ClienteService(
            IUnitOfWork iUnitOfWork,
            IBcryptCliente iBcryptCliente,
            ICreateClienteMS iCreateClienteMS,
            IReadClienteMS iReadClienteMS,
            IUpdateClienteMS iUpdateClienteMS,
            IDeleteClienteMS iDeleteClienteMS)
        {
            _IUnitOfWork = iUnitOfWork;
            _IBcryptCliente = iBcryptCliente;
            _ICreateClienteMS = iCreateClienteMS;
            _IReadClienteMS = iReadClienteMS;
            _IUpdateClienteMS = iUpdateClienteMS;
            _IDeleteClienteMS = iDeleteClienteMS;
        }

        public async Task<MensajePersonalizadoDTO> RegistrarCliente(RegistrarClienteDTO registrarClienteDTO)
        {
            try
            {
                await _IUnitOfWork.BeginTransactionAsync();

                var RODMS_CorreoValidado = await _IReadClienteMS.ValidarCorreo(registrarClienteDTO.Correo);
                if (!RODMS_CorreoValidado.EsExito)
                {
                    await _IUnitOfWork.RollbackTransactionAsync();
                    return new MensajePersonalizadoDTO(false, RODMS_CorreoValidado.Descripcion, 0, null, null);
                }

                var RODMS_ContraseñaEncriptada = await _IBcryptCliente.EncriptarContraseña(registrarClienteDTO.Contraseña);
                if (!RODMS_ContraseñaEncriptada.EsExito)
                {
                    await _IUnitOfWork.RollbackTransactionAsync();
                    return new MensajePersonalizadoDTO(false, RODMS_ContraseñaEncriptada.Descripcion, 0, null, null);
                }
                registrarClienteDTO.Contraseña = RODMS_ContraseñaEncriptada.Descripcion;

                var RODMS_ClienteRegistrado = await _ICreateClienteMS.RegistrarCliente(registrarClienteDTO);
                if (!RODMS_ClienteRegistrado.EsExito)
                {
                    await _IUnitOfWork.RollbackTransactionAsync();
                    return new MensajePersonalizadoDTO(false, RODMS_ClienteRegistrado.Descripcion, 0, null, null);
                }

                await _IUnitOfWork.SaveChangesAsync();
                await _IUnitOfWork.CommitTransactionAsync();

                return RODMS_ClienteRegistrado;
            }
            catch (Exception ex)
            {
                await _IUnitOfWork.RollbackTransactionAsync();
                var mensajeError = $"Fallo uno de los microservicios: {ex.Message}. Detalle: {ex.InnerException?.Message}";
                return new MensajePersonalizadoDTO(false, mensajeError, 0, null, null);
            }
        }
        public async Task<MensajePersonalizadoDTO> LoginCliente(LoginClienteDTO loginClienteDTO)
        {
            var RODMS_EstadoValidado = await _IReadClienteMS.ValidarEstado(loginClienteDTO.Correo);
            if (!RODMS_EstadoValidado.EsExito)
            {
                await _IUnitOfWork.RollbackTransactionAsync();
                return new MensajePersonalizadoDTO(false, RODMS_EstadoValidado.Descripcion, 0, null, null);
            }

            var RODMS_ContraseñaValidada = await _IBcryptCliente.DesencriptarContraseña(loginClienteDTO);
            if (!RODMS_ContraseñaValidada.EsExito)
            {
                await _IUnitOfWork.RollbackTransactionAsync();
                return new MensajePersonalizadoDTO(false, RODMS_ContraseñaValidada.Descripcion, 0, null, null);
            }
            return RODMS_ContraseñaValidada;
        }
        public async Task<DetalleClienteDTO> DetalleCliente(int idCliente)
        {
            var RODMS_DetalleCliente = await _IReadClienteMS.DetalleCliente(idCliente);
            if (!RODMS_DetalleCliente.EsExito)
            {
                return new DetalleClienteDTO(false, RODMS_DetalleCliente.Descripcion, null, null, null, null, null);
            }
            return RODMS_DetalleCliente;
        }
        public async Task<MensajePersonalizadoDTO> ActualizarCliente(DetalleClienteDTO detalleClienteDTO, int idCliente)
        {
            try
            {
                await _IUnitOfWork.BeginTransactionAsync();

                var RODMS_ActualizarCliente = await _IUpdateClienteMS.ActualizarCliente(detalleClienteDTO, idCliente);
                if (!RODMS_ActualizarCliente.EsExito)
                {
                    await _IUnitOfWork.RollbackTransactionAsync();
                    return new MensajePersonalizadoDTO(false, RODMS_ActualizarCliente.Descripcion, 0, null, null);
                }

                var RODMS_ActualizarDetalleClient = await _IUpdateClienteMS.ActualizarDetalleCliente(detalleClienteDTO, idCliente);
                if (!RODMS_ActualizarDetalleClient.EsExito)
                {
                    await _IUnitOfWork.RollbackTransactionAsync();
                    return new MensajePersonalizadoDTO(false, RODMS_ActualizarDetalleClient.Descripcion, 0, null, null);
                }

                await _IUnitOfWork.CommitTransactionAsync();
                return RODMS_ActualizarCliente;
            }
            catch (Exception ex)
            {
                await _IUnitOfWork.RollbackTransactionAsync();
                var mensajeError = $"Fallo uno de los microservicios: {ex.Message}. Detalle: {ex.InnerException?.Message}";
                return new MensajePersonalizadoDTO(false, mensajeError, 0, null, null);
            }
        }
        public async Task<MensajeEstandarDTO> EliminarCliente(int idCliente)
        {
            try
            {
                var RODMS_EliminarCliente = await _IDeleteClienteMS.EliminarCliente(idCliente);
                if (!RODMS_EliminarCliente.EsExito)
                {
                    await _IUnitOfWork.RollbackTransactionAsync();
                    return new MensajeEstandarDTO(false, RODMS_EliminarCliente.Descripcion);
                }
                return RODMS_EliminarCliente;
            }
            catch (Exception ex)
            {
                var mensajeError = $"Fallo uno de los microservicios: {ex.Message}. Detalle: {ex.InnerException?.Message}";
                return new MensajeEstandarDTO(false, mensajeError);
            }
        }
    }
}