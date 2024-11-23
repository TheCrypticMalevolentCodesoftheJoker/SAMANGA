using HOSPEDAJE.Areas.ReservaArea.Payloads.EntidadesDTO;

namespace HOSPEDAJE.Areas.ReservaArea.Payloads.ViewModel
{
    public class ReservaViewModel
    {
        public ReservaDTO ReservaDTO { get; set; } = new ReservaDTO();
        public DetalleReservaDTO DetalleReservaDTO { get; set; } = new DetalleReservaDTO();
    }
}
