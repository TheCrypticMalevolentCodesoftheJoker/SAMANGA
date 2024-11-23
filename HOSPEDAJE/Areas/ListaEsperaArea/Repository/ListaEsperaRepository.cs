using HOSPEDAJE.Data;
using HOSPEDAJE.Models;
using Microsoft.EntityFrameworkCore;

namespace HOSPEDAJE.Areas.ListaEsperaArea.Repository
{
    public class ListaEsperaRepository : IListaEsperaRepository
    {
        public readonly ApplicationDbContext _DBContext;

        public ListaEsperaRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        public async Task RegistrarListaEspera(TblListaEspera listaesperaregistrar)
        {
            await _DBContext.TblListaEspera.AddAsync(listaesperaregistrar);

        }

        public async Task<List<TblListaEspera>> ObtenerTodos()
        {
            return await _DBContext.TblListaEspera.ToListAsync();
        }

        public async Task<TblListaEspera?> ObtenerPorId(int id)
        {
            return await _DBContext.TblListaEspera.FindAsync(id);
        }

        public void Actualizar(TblListaEspera listaEspera)
        {
            var entidadExistente = _DBContext.TblListaEspera.Find(listaEspera.IdEspera);
            if (entidadExistente != null)
            {
                entidadExistente.Prioridad = listaEspera.Prioridad;
                entidadExistente.Estado = listaEspera.Estado;
                entidadExistente.Descripcion = listaEspera.Descripcion;

                // Otras propiedades si es necesario
                _DBContext.Entry(entidadExistente).State = EntityState.Modified;
            }
        }

        public async Task Eliminar(int id)
        {
            var listaEspera = await _DBContext.TblListaEspera.FindAsync(id);
            if (listaEspera != null)
            {
                _DBContext.TblListaEspera.Remove(listaEspera);
            }
            _DBContext.TblListaEspera.Remove(listaEspera);
        }


        public async Task<bool> TieneRegistroPendiente(int idCliente)
        {
            return await _DBContext.TblListaEspera
                .AnyAsync(le => le.IdCliente == idCliente && le.Estado == "E");
        }


    }
}
