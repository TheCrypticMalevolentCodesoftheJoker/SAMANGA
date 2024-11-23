using HOSPEDAJE.Areas.ReservaArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ReservaArea.Payloads.MensajesDTO;
using HOSPEDAJE.Areas.ReservaArea.Payloads.ViewModel;
using HOSPEDAJE.Areas.ReservaArea.Repository;

namespace HOSPEDAJE.Areas.ReservaArea.Services.MicroServices.ReservaCRUD.CreateMS
{
    public class CreateReservaMS : ICreateReservaMS
    {
        private readonly IReservaRepository _IReservaRepository;
        public CreateReservaMS(IReservaRepository iReservaRepository)
        {
            _IReservaRepository = iReservaRepository;
        }

        public async Task<MensajeEstandarDTO> RegistrarReserva(ReservaDTO reservaDTO, DetalleReservaDTO detalleReservaDTO)
        {
            // Registrar Reserva
            var reservaRegistrada = await _IReservaRepository.RegistrarReserva(reservaDTO);
            if (reservaRegistrada.IdReserva <= 0)
            {
                return new MensajeEstandarDTO
                {
                    EsExito = false,
                    Descripcion = "No se pudo registrar la reserva."
                };
            }

            // Registrar Detalle de Reserva
            detalleReservaDTO.IdReserva = reservaRegistrada.IdReserva;
            var detalleReservaRegistrado = await _IReservaRepository.RegistrarDetalleReserva(detalleReservaDTO);

            if (detalleReservaRegistrado == null)
            {
                return new MensajeEstandarDTO
                {
                    EsExito = false,
                    Descripcion = "No se pudo registrar el detalle de la reserva."
                };
            }

            return new MensajeEstandarDTO
            {
                EsExito = true,
                Descripcion = "Reserva registrada exitosamente."
            };
        }


    }
}
