namespace HOSPEDAJE.Models;
public partial class TblListaEspera
{
    public int IdEspera { get; set; }

    public int IdCliente { get; set; }

    public DateTime? FechaSolicitud { get; set; }

    public string Prioridad { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual TblCliente IdClienteNavigation { get; set; } = null!;
}
