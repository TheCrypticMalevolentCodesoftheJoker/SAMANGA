namespace HOSPEDAJE.Areas.UsuarioArea.Payloads.MensajesDTO
{
    public class MensajeEstandarDTO
    {
        public bool EsExito { get; set; }
        public string Descripcion { get; set; }
        public MensajeEstandarDTO(bool esExito, string descripcion)
        {
            EsExito = esExito;
            Descripcion = descripcion;
        }
    }
}
