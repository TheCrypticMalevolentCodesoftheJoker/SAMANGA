using HOSPEDAJE.Data;
using HOSPEDAJE.Models;
using Microsoft.EntityFrameworkCore;

namespace HOSPEDAJE.Areas.UsuarioArea.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _DbContext;
        public UsuarioRepository(ApplicationDbContext applicationDbContext)
        {
            _DbContext = applicationDbContext;
        }

        public async Task<TblUsuario?> ValidarCorreo(string Correo)
        {
            return await _DbContext.TblUsuario
                .FirstOrDefaultAsync(u => u.Correo == Correo);
        }
        public async Task<bool> ValidarEstado(string correo)
        {
            return await _DbContext.TblUsuario
                .AnyAsync(c => c.Correo == correo && c.Estado == "A");
        }
        public async Task<bool> RegistrarUsuario(TblUsuario tblUsuario)
        {
            await _DbContext.TblUsuario.AddAsync(tblUsuario);
            await _DbContext.SaveChangesAsync();
            return true;
        }
        public async Task<TblUsuario?> ObtenerUsuarioPorId(int idUsuario)
        {
            return await _DbContext.TblUsuario
                                 .FirstOrDefaultAsync(c => c.IdUsuario == idUsuario);
        }
        public async Task<TblDetalleUsuario?> ObtenerDetalleUsuarioPorId(int idUsuario)
        {
            return await _DbContext.TblDetalleUsuario
                                 .FirstOrDefaultAsync(c => c.IdUsuario == idUsuario);
        }
        public async Task<bool> ActualizarUsuario(TblUsuario tblUsuario)
        {
            _DbContext.TblUsuario.Update(tblUsuario);
            return await _DbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> RegistrarDetalleUsuario(TblDetalleUsuario tblDetalleUsuario)
        {
            await _DbContext.TblDetalleUsuario.AddAsync(tblDetalleUsuario);
            var resultado = await _DbContext.SaveChangesAsync();
            return resultado > 0;
        }
        public async Task<bool> ActualizarDetalleUsuario(TblDetalleUsuario tblDetalleUsuario)
        {
            _DbContext.TblDetalleUsuario.Update(tblDetalleUsuario);
            return await _DbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> EliminarUsuario(int idUsuario, string nuevoEstado)
        {
            var EliminarUsuario = await _DbContext.TblUsuario.FindAsync(idUsuario);
            if (EliminarUsuario == null) return false;

            EliminarUsuario.Estado = nuevoEstado;
            _DbContext.TblUsuario.Update(EliminarUsuario);
            await _DbContext.SaveChangesAsync();
            return true;
        }
    }
}
