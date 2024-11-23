using HOSPEDAJE.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace HOSPEDAJE.Services.PatronUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _DbContext;
        private IDbContextTransaction? _transaccionActual = null;

        public UnitOfWork(ApplicationDbContext context)
        {
            _DbContext = context;
        }

        public async Task BeginTransactionAsync()
        {
            _transaccionActual = await _DbContext.Database.BeginTransactionAsync();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _DbContext.SaveChangesAsync();
        }
        public async Task CommitTransactionAsync()
        {
            if (_transaccionActual != null)
            {
                await _transaccionActual.CommitAsync();
                await _transaccionActual.DisposeAsync();
                _transaccionActual = null;
            }
        }
        public async Task RollbackTransactionAsync()
        {
            if (_transaccionActual != null)
            {
                await _transaccionActual.RollbackAsync();
                await _transaccionActual.DisposeAsync();
                _transaccionActual = null;
            }
        }

        public void Dispose()
        {
            _DbContext.Dispose();
        }
    }

}
