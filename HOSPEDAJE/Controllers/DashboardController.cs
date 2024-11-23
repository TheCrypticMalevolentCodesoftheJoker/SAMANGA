using HOSPEDAJE.Areas.HabitacionArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.HabitacionArea.Payloads.ViewModel;
using HOSPEDAJE.Areas.HabitacionArea.Services;
using Microsoft.AspNetCore.Mvc;

namespace HOSPEDAJE.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHabitacionService _IHabitacionService;
        public DashboardController(IHabitacionService iHabitacionService)
        {
            _IHabitacionService = iHabitacionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var habitacionesDisponibles = await _IHabitacionService.ListaHabitacionesDisponibles();
            var categorias = await _IHabitacionService.ListaCategorias();

            var viewModel = new HabitacionesCategoriasViewModel
            {
                Habitaciones = habitacionesDisponibles,
                Categorias = categorias
            };
            if (!habitacionesDisponibles.EsExito)
            {
                ViewData["Error"] = habitacionesDisponibles.Descripcion;
                return View("Index", viewModel);
            }
            if (!categorias.EsExito)
            {
                ViewData["Error"] = categorias.Descripcion;
                return View("Index", viewModel);
            }
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> IndexProceso(FormBuscarHDDTO formBuscarHDDTO)
        {
            var habitacionesDisponibles = await _IHabitacionService.FiltrarHabitacionesDisponibles(formBuscarHDDTO);
            var categorias = await _IHabitacionService.ListaCategorias();

            var viewModel = new HabitacionesCategoriasViewModel
            {
                Habitaciones = habitacionesDisponibles,
                Categorias = categorias,
                FormBuscarHDDTO = formBuscarHDDTO
            };

            if (!habitacionesDisponibles.EsExito)
            {
                ViewData["Error"] = habitacionesDisponibles.Descripcion;
                return View("Index", viewModel);
            }

            if (!categorias.EsExito)
            {
                ViewData["Error"] = categorias.Descripcion;
                return View("Index", viewModel);
            }
            return View("Index", viewModel);
        }
    }
}
