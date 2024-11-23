namespace HOSPEDAJE.Models;
public partial class TblDetalleCliente
{
    public int IdDetalleCliente { get; set; }

    public int? IdCliente { get; set; }

    public byte[]? Imagen { get; set; }

    public string? Genero { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Preferencias { get; set; }

    public string? EstadoCivil { get; set; }

    public string? RedesSociales { get; set; }

    public string? Idioma { get; set; }

    public string? Ocupacion { get; set; }

    public string? NotasAdicionales { get; set; }

    public DateTime? FechaUltimaActualizacion { get; set; }

    public virtual TblCliente? IdClienteNavigation { get; set; }
}
