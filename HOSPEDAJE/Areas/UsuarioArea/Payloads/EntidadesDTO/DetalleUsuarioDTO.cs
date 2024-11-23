namespace HOSPEDAJE.Areas.UsuarioArea.Payloads.EntidadesDTO
{
    public class DetalleUsuarioDTO
    {
        public bool EsExito { get; set; }
        public string Descripcion { get; set; }
        //usuario
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string Estado { get; set; } = null!;
        //Detalle
        public IFormFile? ImagenFile { get; set; }
        public byte[]? Imagen { get; set; }
        public DateOnly? FechaContratacion { get; set; }
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
        public DetalleUsuarioDTO() { }
        public DetalleUsuarioDTO(bool esExito, string descripcion, int idUsuario, int idRol, string nombre, string apellido, string correo, string contraseña, string estado, byte[]? imagen, DateOnly? fechaContratacion, string? genero, string? telefono, string? direccion, DateOnly? fechaNacimiento, string? preferencias, string? estadoCivil, string? redesSociales, string? idioma, string? ocupacion, string? notasAdicionales, DateTime? fechaUltimaActualizacion)
        {
            EsExito = esExito;
            Descripcion = descripcion;
            IdUsuario = idUsuario;
            IdRol = idRol;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Contraseña = contraseña;
            Estado = estado;
            Imagen = imagen;
            FechaContratacion = fechaContratacion;
            Genero = genero;
            Telefono = telefono;
            Direccion = direccion;
            FechaNacimiento = fechaNacimiento;
            Preferencias = preferencias;
            EstadoCivil = estadoCivil;
            RedesSociales = redesSociales;
            Idioma = idioma;
            Ocupacion = ocupacion;
            NotasAdicionales = notasAdicionales;
            FechaUltimaActualizacion = fechaUltimaActualizacion;
        }
    }
}
