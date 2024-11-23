namespace HOSPEDAJE.Areas.UsuarioArea.Payloads.MensajesDTO
{
    public class MensajePersonalizadoDTO
    {
        public bool EsExito { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdRol { get; set; }
        public MensajePersonalizadoDTO(bool esExito, string descripcion, int idUsuario, string nombre, string apellido, int idRol)
        {
            EsExito = esExito;
            Descripcion = descripcion;
            IdUsuario = idUsuario;
            Nombre = nombre;
            Apellido = apellido;
            IdRol = idRol;
        }
    }
}
