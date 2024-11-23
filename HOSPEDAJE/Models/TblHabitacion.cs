namespace HOSPEDAJE.Models;
public partial class TblHabitacion
{
    public int IdHabitacion { get; set; }

    public int IdCategoria { get; set; }

    public int IdEstado { get; set; }

    public string Numero { get; set; } = null!;

    public decimal Precio { get; set; }

    public string? Descripcion { get; set; }

    public virtual TblCategoria IdCategoriaNavigation { get; set; } = null!;

    public virtual TblEstado IdEstadoNavigation { get; set; } = null!;

    public virtual ICollection<TblDetalleHabitacion> TblDetalleHabitacion { get; set; } = new List<TblDetalleHabitacion>();

    public virtual ICollection<TblDetalleReserva> TblDetalleReserva { get; set; } = new List<TblDetalleReserva>();

    public virtual ICollection<TblImagenHabitacion> TblImagenHabitacion { get; set; } = new List<TblImagenHabitacion>();

    public virtual ICollection<TblMantenimientoLimpieza> TblMantenimientoLimpieza { get; set; } = new List<TblMantenimientoLimpieza>();

    public virtual ICollection<TblReporteProblema> TblReporteProblema { get; set; } = new List<TblReporteProblema>();
}
