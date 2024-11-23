namespace HOSPEDAJE.Models;
public partial class TblReporteProblema
{
    public int IdProblema { get; set; }

    public int IdHabitacion { get; set; }

    public int? IdCliente { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateTime? FechaReporte { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime? FechaResolucion { get; set; }

    public virtual TblCliente? IdClienteNavigation { get; set; }

    public virtual TblHabitacion IdHabitacionNavigation { get; set; } = null!;
}
