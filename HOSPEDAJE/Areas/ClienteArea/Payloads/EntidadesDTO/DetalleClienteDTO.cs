namespace HOSPEDAJE.Areas.ClienteArea.Payloads.EntidadesDTO
{
    public class DetalleClienteDTO
    {
        public bool EsExito { get; set; }
        public string Descripcion { get; set; }
        //Cliente
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Correo { get; set; } = null!;

        //DETALLE

        public string? Genero { get; set; }

        public string? Telefono { get; set; }

        public DetalleClienteDTO(){}
        public DetalleClienteDTO(bool esExito, string descripcion, string nombre, string apellido, string correo, string? genero, string? telefono)
        {
            EsExito = esExito;
            Descripcion = descripcion;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Genero = genero;
            Telefono = telefono;
        }
    }
}
