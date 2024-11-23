using HOSPEDAJE.Data;
using HOSPEDAJE.Models;
using Microsoft.EntityFrameworkCore;

namespace HOSPEDAJE.Areas.ClienteArea.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _DbContext;
        public ClienteRepository(ApplicationDbContext applicationDbContext)
        {
            _DbContext = applicationDbContext;
        }

        public async Task<TblCliente?> ValidarCorreo(string Correo)
        {
            return await _DbContext.TblCliente
                .FirstOrDefaultAsync(c => c.Correo == Correo);
        }
        public async Task<bool> ValidarEstado(string correo)
        {
            return await _DbContext.TblCliente
                .AnyAsync(c => c.Correo == correo && c.Estado == "A");
        }
        public async Task<bool> RegistrarCliente(TblCliente tblCliente)
        {
            try
            {
                await _DbContext.TblCliente.AddAsync(tblCliente);
                await _DbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<TblCliente?> ObtenerClientePorId(int idCliente)
        {
            return await _DbContext.TblCliente
                                 .FirstOrDefaultAsync(c => c.IdCliente == idCliente);
        }
        public async Task<TblDetalleCliente?> ObtenerDetalleClientePorId(int idCliente)
        {
            return await _DbContext.TblDetalleCliente
                                 .FirstOrDefaultAsync(dc => dc.IdCliente == idCliente);
        }
        public async Task<bool> ActualizarCliente(TblCliente tblCliente)
        {
            _DbContext.TblCliente.Update(tblCliente);
            return await _DbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> ActualizarDetalleCliente(TblDetalleCliente tblDetalleCliente)
        {
            _DbContext.TblDetalleCliente.Update(tblDetalleCliente);
            return await _DbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> EliminarCliente(int idCliente, string nuevoEstado)
        {
            var cliente = await _DbContext.TblCliente.FindAsync(idCliente);
            if (cliente == null) return false;

            cliente.Estado = nuevoEstado;
            _DbContext.TblCliente.Update(cliente);
            await _DbContext.SaveChangesAsync();
            return true;
        }
    }
}