using HOSPEDAJE.Models;

namespace HOSPEDAJE.Areas.ClienteArea.Repository
{
    public interface IClienteRepository
    {
        Task<TblCliente?> ValidarCorreo(string Correo);
        Task<bool> ValidarEstado(string correo);
        Task<bool> RegistrarCliente(TblCliente tblCliente);
        Task<TblCliente?> ObtenerClientePorId(int idCliente);
        Task<TblDetalleCliente?> ObtenerDetalleClientePorId(int idCliente);
        Task<bool> ActualizarCliente(TblCliente tblCliente);
        Task<bool> ActualizarDetalleCliente(TblDetalleCliente tblDetalleCliente);
        Task<bool> EliminarCliente(int idCliente, string nuevoEstado);
    }
}
