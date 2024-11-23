namespace HOSPEDAJE.Areas.ClienteArea.Payloads.MensajesDTO
{
    public class MensajePersonalizadoDTO
    {
        public bool EsExito { get; set; }
        public string Descripcion { get; set; }
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public MensajePersonalizadoDTO(bool esExito, string descripcion, int idCliente, string nombre, string apellido)
        {
            EsExito = esExito;
            Descripcion = descripcion;
            IdCliente = idCliente;
            Nombre = nombre;
            Apellido = apellido;
        }
    }
}
