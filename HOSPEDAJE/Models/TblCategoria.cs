namespace HOSPEDAJE.Models;
public partial class TblCategoria
{
    public int IdCategoria { get; set; }

    public string Categoria { get; set; } = null!;

    public virtual ICollection<TblHabitacion> TblHabitacions { get; set; } = new List<TblHabitacion>();
}
