namespace HOSPEDAJE.Models;
public partial class TblEstado
{
    public int IdEstado { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<TblHabitacion> TblHabitacions { get; set; } = new List<TblHabitacion>();
}
