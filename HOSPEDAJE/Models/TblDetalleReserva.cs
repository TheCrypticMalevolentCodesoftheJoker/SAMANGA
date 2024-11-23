namespace HOSPEDAJE.Models;
public partial class TblDetalleReserva
{
    public int IdReserva { get; set; }

    public int IdHabitacion { get; set; }

    public int CantidadPersonas { get; set; }

    public string? TipoServicio { get; set; }

    public decimal? CostoServicio { get; set; }

    public decimal? PagoParcial { get; set; }

    public DateTime? FechaPago { get; set; }

    public string EstadoPago { get; set; } = null!;

    public DateTime? FechaUltimaModificacion { get; set; }

    public virtual TblHabitacion IdHabitacionNavigation { get; set; } = null!;

    public virtual TblReserva IdReservaNavigation { get; set; } = null!;
}
