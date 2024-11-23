namespace HOSPEDAJE.Models;
public partial class TblRol
{
    public int IdRol { get; set; }

    public string Rol { get; set; } = null!;

    public virtual ICollection<TblUsuario> TblUsuarios { get; set; } = new List<TblUsuario>();
}
