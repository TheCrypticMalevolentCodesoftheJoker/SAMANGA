namespace HOSPEDAJE.Areas.ClienteArea.Payloads.EntidadesDTO
{
    public class RegistrarClienteDTO
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string Estado { get; set; } = null!;
    }
}
