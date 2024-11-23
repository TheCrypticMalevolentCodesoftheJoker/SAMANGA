namespace HOSPEDAJE.Areas.UsuarioArea.Payloads.EntidadesDTO
{
    public class RegistrarUsuarioDTO
    {
        public int IdRol { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Contraseña { get; set; } = null!;

        public string Estado { get; set; } = null!;
    }
}
