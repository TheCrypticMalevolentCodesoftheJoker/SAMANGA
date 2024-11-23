namespace HOSPEDAJE.Models;
public partial class TblMantenimientoLimpieza
{
    public int IdManLimp { get; set; }

    public int IdHabitacion { get; set; }

    public int IdUsuario { get; set; }

    public string TipoActividad { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public string? Observaciones { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual TblHabitacion IdHabitacionNavigation { get; set; } = null!;

    public virtual TblUsuario IdUsuarioNavigation { get; set; } = null!;
}
