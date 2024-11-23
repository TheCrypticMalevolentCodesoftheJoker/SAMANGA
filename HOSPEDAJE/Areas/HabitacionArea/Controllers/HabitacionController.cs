using Microsoft.AspNetCore.Mvc;
using HOSPEDAJE.Areas.HabitacionArea.Services;

namespace HOSPEDAJE.Areas.HabitacionArea.Controllers
{
    [Area("HabitacionArea")]
    public class HabitacionController : Controller
    {
        private readonly IHabitacionService _IHabitacionService;
        public HabitacionController(IHabitacionService iHabitacionService)
        {
            _IHabitacionService = iHabitacionService;
        }

        [HttpPost]
        public async Task<IActionResult> DetalleHabitacion([FromForm] int IdHabitacion)
        {
            var detalleHabitacion = await _IHabitacionService.DetalleHabitacion(IdHabitacion);
            if (!detalleHabitacion.EsExito)
            {
                ViewData["Error"] = detalleHabitacion.Descripcion;
                return View("DetalleHabitacion", detalleHabitacion);
            }
            return View("DetalleHabitacion", detalleHabitacion);
        }

    }
}
