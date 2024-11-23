using HOSPEDAJE.Areas.ReservaArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ReservaArea.Payloads.ViewModel;
using HOSPEDAJE.Areas.ReservaArea.Services;
using Microsoft.AspNetCore.Mvc;

namespace HOSPEDAJE.Areas.ReservaArea.Controllers
{
    [Area("ReservaArea")]
    public class ReservaController : Controller
    {
        private readonly IReservaService _IReservaService;
        public ReservaController(IReservaService iReservaService)
        {
            _IReservaService = iReservaService;
        }

        [HttpPost]
        public IActionResult RegistrarView([FromForm] int IdHabitacion)
        {

            var idCliente = HttpContext.Session.GetInt32("ClienteId");
            var nombreCliente = HttpContext.Session.GetString("NombreCliente");
            var apellidoCliente = HttpContext.Session.GetString("ApellidoCliente");
            if (!idCliente.HasValue)
            {
                return RedirectToAction("LoginView", "Cliente", new { area = "ClienteArea" });
            }
            ViewBag.IdCliente = idCliente;
            ViewBag.NombreCliente = nombreCliente;
            ViewBag.ApellidoCliente = apellidoCliente;
            ViewBag.IdHabitacion = IdHabitacion;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegistrarProceso(ReservaDTO reservaDTO, DetalleReservaDTO detalleReservaDTO)
        {
            var registrarReserva = await _IReservaService.RegistrarReserva(reservaDTO, detalleReservaDTO);
            var viewModel = new ReservaViewModel
            {
                ReservaDTO = reservaDTO,
                DetalleReservaDTO = detalleReservaDTO
            };
            if (!registrarReserva.EsExito)
            {
                ViewData["Error"] = registrarReserva.Descripcion;
                return View("RegistrarView", viewModel);
            }
            return View("RegistrarView", viewModel);
        }


        public async Task<IActionResult> ListaCheckOut()
        {
            return View();
        }
    }
}
