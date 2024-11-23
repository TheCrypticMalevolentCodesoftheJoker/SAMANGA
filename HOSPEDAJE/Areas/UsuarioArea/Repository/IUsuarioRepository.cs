using HOSPEDAJE.Models;

namespace HOSPEDAJE.Areas.UsuarioArea.Repository
{
    public interface IUsuarioRepository
    {
        Task<TblUsuario?> ValidarCorreo(string Correo);
        Task<bool> ValidarEstado(string correo);
        Task<bool> RegistrarUsuario(TblUsuario tblUsuario);
        Task<TblUsuario?> ObtenerUsuarioPorId(int idUsuario);
        Task<TblDetalleUsuario?> ObtenerDetalleUsuarioPorId(int idUsuario);
        Task<bool> ActualizarUsuario(TblUsuario tblUsuario);
        Task<bool> RegistrarDetalleUsuario(TblDetalleUsuario tblDetalleUsuario);
        Task<bool> ActualizarDetalleUsuario(TblDetalleUsuario tblDetalleUsuario);
        Task<bool> EliminarUsuario(int idUsuario, string nuevoEstado);
    }
}
