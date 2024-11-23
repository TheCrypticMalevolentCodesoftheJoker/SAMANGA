namespace HOSPEDAJE.Models;
public partial class TblReserva
{
    public int IdReserva { get; set; }

    public int IdCliente { get; set; }

    public DateTime? FechaReserva { get; set; }

    public DateOnly FechaEntrada { get; set; }

    public DateOnly FechaSalida { get; set; }

    public string Estado { get; set; } = null!;

    public decimal TotalPago { get; set; }

    public string MetodoPago { get; set; } = null!;

    public virtual TblCliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<TblDetalleReserva> TblDetalleReservas { get; set; } = new List<TblDetalleReserva>();
}
