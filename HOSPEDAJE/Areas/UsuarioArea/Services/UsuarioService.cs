using HOSPEDAJE.Services.PatronUnitOfWork;
using HOSPEDAJE.Areas.UsuarioArea.Repository;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.MensajesDTO;
using HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioBcrypt;
using HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioCRUD.CreateMS;
using HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioCRUD.ReadMS;
using HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioCRUD.UpdateMS;
using HOSPEDAJE.Areas.UsuarioArea.Services.MicroServices.UsuarioCRUD.DeleteMS;


namespace HOSPEDAJE.Areas.UsuarioArea.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IUsuarioRepository _IUsuarioRepository;
        public readonly IBcryptUsuario _IBcryptUsuario;
        public readonly ICreateUsuarioMS _ICreateUsuarioMS;
        public readonly IReadUsuarioMS _IReadUsuarioMS;
        public readonly IUpdateUsuarioMS _IUpdateUsuarioMS;
        public readonly IDeleteUsuaerioMS _IDeleteUsuaerioMS;

        public UsuarioService(
            IUnitOfWork iUnitOfWork,
            IUsuarioRepository iUsuarioRepository,
            IBcryptUsuario iBcryptUsuario,
            ICreateUsuarioMS iCreateUsuarioMS,
            IReadUsuarioMS iReadUsuarioMS,
            IUpdateUsuarioMS iUpdateUsuarioMS,
            IDeleteUsuaerioMS iDeleteUsuaerioMS)
        {
            _IUnitOfWork = iUnitOfWork;
            _IUsuarioRepository = iUsuarioRepository;
            _IBcryptUsuario = iBcryptUsuario;
            _ICreateUsuarioMS = iCreateUsuarioMS;
            _IReadUsuarioMS = iReadUsuarioMS;
            _IUpdateUsuarioMS = iUpdateUsuarioMS;
            _IDeleteUsuaerioMS = iDeleteUsuaerioMS;
        }

        public async Task<MensajePersonalizadoDTO> RegistrarUsuario(RegistrarUsuarioDTO registrarUsuarioDTO)
        {
            try
            {
                await _IUnitOfWork.BeginTransactionAsync();

                var ValidarCorreo = await _IReadUsuarioMS.ValidarCorreo(registrarUsuarioDTO.Correo);
                if (!ValidarCorreo.EsExito)
                {
                    await _IUnitOfWork.RollbackTransactionAsync();
                    return new MensajePersonalizadoDTO(false, ValidarCorreo.Descripcion, 0, null, null, 0);
                }
                var EncriptarContraseña = await _IBcryptUsuario.EncriptarContraseña(registrarUsuarioDTO.Contraseña);
                if (!EncriptarContraseña.EsExito)
                {
                    await _IUnitOfWork.RollbackTransactionAsync();
                    return new MensajePersonalizadoDTO(false, EncriptarContraseña.Descripcion, 0, null, null, 0);
                }
                registrarUsuarioDTO.Contraseña = EncriptarContraseña.Descripcion;

                var RegistrarUsuario = await _ICreateUsuarioMS.RegistrarUsuario(registrarUsuarioDTO);
                if (!RegistrarUsuario.EsExito)
                {
                    await _IUnitOfWork.RollbackTransactionAsync();
                    return new MensajePersonalizadoDTO(false, RegistrarUsuario.Descripcion, 0, null, null, 0);
                }
                await _IUnitOfWork.SaveChangesAsync();
                await _IUnitOfWork.CommitTransactionAsync();
                return RegistrarUsuario;
            }
            catch (Exception ex)
            {
                await _IUnitOfWork.RollbackTransactionAsync();
                var mensajeError = $"Fallo uno de los microservicios: {ex.Message}. Detalle: {ex.InnerException?.Message}";
                return new MensajePersonalizadoDTO(false, mensajeError, 0, null, null, 0);
            }


        }
        public async Task<MensajePersonalizadoDTO> LoginUsuario(LoginUsuarioDTO loginUsuarioDTO)
        {
            var EstadoValidado = await _IReadUsuarioMS.ValidarEstado(loginUsuarioDTO.Correo);
            if (!EstadoValidado.EsExito)
            {
                return new MensajePersonalizadoDTO(false, EstadoValidado.Descripcion, 0, null, null, 0);
            }
            var ContraseñaValidada = await _IBcryptUsuario.DesencriptarContraseña(loginUsuarioDTO);
            if (!ContraseñaValidada.EsExito)
            {
                return new MensajePersonalizadoDTO(false, ContraseñaValidada.Descripcion, 0, null, null, 0);
            }
            return ContraseñaValidada;
        }
        public async Task<DetalleUsuarioDTO> DetalleUsuario(int idUsuario)
        {
            var DetalleUsuario = await _IReadUsuarioMS.DetalleUsuario(idUsuario);
            if (!DetalleUsuario.EsExito)
            {
                return new DetalleUsuarioDTO(false, DetalleUsuario.Descripcion,
                    0, 0, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            }
            return DetalleUsuario;
        }
        public async Task<MensajePersonalizadoDTO> ActualizarUsuario(DetalleUsuarioDTO detalleUsuarioDTO, int idUsuario)
        {
            try
            {
                await _IUnitOfWork.BeginTransactionAsync();

                var EncriptarContraseña = await _IBcryptUsuario.EncriptarContraseña(detalleUsuarioDTO.Contraseña);
                if (!EncriptarContraseña.EsExito)
                {
                    await _IUnitOfWork.RollbackTransactionAsync();
                    return new MensajePersonalizadoDTO(false, EncriptarContraseña.Descripcion, 0, null, null, 0);
                }
                detalleUsuarioDTO.Contraseña = EncriptarContraseña.Descripcion;

                var ActualizarUsuario = await _IUpdateUsuarioMS.ActualizarUsuario(detalleUsuarioDTO, idUsuario);
                if (!ActualizarUsuario.EsExito)
                {
                    await _IUnitOfWork.RollbackTransactionAsync();
                    return new MensajePersonalizadoDTO(false, ActualizarUsuario.Descripcion, 0, null, null, 0);
                }
                var ActualizarDetalleUsuario = await _IUpdateUsuarioMS.ActualizarDetalleUsuario(detalleUsuarioDTO, idUsuario);
                if (!ActualizarDetalleUsuario.EsExito)
                {
                    await _IUnitOfWork.RollbackTransactionAsync();
                    return new MensajePersonalizadoDTO(false, ActualizarDetalleUsuario.Descripcion, 0, null, null, 0);
                }
                await _IUnitOfWork.CommitTransactionAsync();
                return ActualizarUsuario;
            }
            catch (Exception ex)
            {
                await _IUnitOfWork.RollbackTransactionAsync();
                var mensajeError = $"Fallo uno de los microservicios: {ex.Message}. Detalle: {ex.InnerException?.Message}";
                return new MensajePersonalizadoDTO(false, mensajeError, 0, null, null, 0);
            }
        }
        public async Task<MensajeEstandarDTO> EliminarUsuario(int idUsuario)
        {
            var EliminarUsuario = await _IDeleteUsuaerioMS.EliminarUsuario(idUsuario);
            if (!EliminarUsuario.EsExito)
            {
                return new MensajeEstandarDTO(false, EliminarUsuario.Descripcion);
            }
            return EliminarUsuario;
        }
    }
}
