using System.ComponentModel.DataAnnotations;

namespace HOSPEDAJE.Areas.ListaEsperaArea.Payloads.EntidadesDTO
{
    public class ListaEsperaDTO
    {

        public int IdEspera { get; set; }
        public int IdCliente { get; set; }
        public string Prioridad { get; set; } = null!;
        public string Estado { get; set; } = "E";
        public string? Descripcion { get; set; }

    }
}
