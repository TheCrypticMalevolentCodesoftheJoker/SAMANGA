using Microsoft.AspNetCore.Mvc;
using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.EntidadesDTO;
using HOSPEDAJE.Areas.ListaEsperaArea.Payloads.FluentDTO;
using HOSPEDAJE.Areas.ListaEsperaArea.Services;

namespace HOSPEDAJE.Areas.ListaEsperaArea.Controllers
{
    [Area("ListaEsperaArea")]
    public class ListEsperaController : Controller
    {
        private readonly IListaEsperaService _listaEsperaService;

        public ListEsperaController(IListaEsperaService listaEsperaService)
        {
            _listaEsperaService = listaEsperaService;
        }

        [HttpGet]
        public IActionResult RegistrarListaEsperaView()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarListaEsperaProceso(ListaEsperaDTO viewListaEsperaDTO)
        {
            // Validar el DTO
            var validacion = new FormListaEsperaDTOValidacion();
            var resultado = validacion.Validate(viewListaEsperaDTO);

            if (!resultado.IsValid)
            {
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View("RegistrarListaEsperaView");
            }

            var resultadoServicio = await _listaEsperaService.RegistrarListaEspera(viewListaEsperaDTO);

            if (!resultadoServicio.EsExito)
            {
                ViewData["Error"] = resultadoServicio.Descripcion;
                return View("RegistrarListaEsperaView");
            }
            return RedirectToAction("index");
        }

        // Listar todos los registros
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listaEspera = await _listaEsperaService.ObtenerTodos();
            return View(listaEspera);
        }

        // Ver detalle de un registro
        [HttpGet]
        public async Task<IActionResult> Detalle(int id)
        {
            var listaEspera = await _listaEsperaService.ObtenerPorId(id);
            if (listaEspera == null)
            {
                return NotFound();
            }
            return View(listaEspera);
        }

        // Editar (GET)
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var listaEspera = await _listaEsperaService.ObtenerPorId(id);
            if (listaEspera == null)
            {
                TempData["ErrorMessage"] = "El registro no fue encontrado.";
                return RedirectToAction("Index");
            }
            return View(listaEspera);
        }


        // Editar (POST)
        [HttpPost]
        public async Task<IActionResult> Editar(ListaEsperaDTO listaEspera)
        {
            if (!ModelState.IsValid)
            {
                return View(listaEspera);
            }

            var resultado = await _listaEsperaService.Actualizar(listaEspera);

            if (!resultado.EsExito)
            {
                TempData["ErrorMessage"] = resultado.Descripcion;
                return View(listaEspera);
            }

            TempData["SuccessMessage"] = resultado.Descripcion;
            return RedirectToAction("Index");
        }
        // Eliminar (POST)
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            var resultado = await _listaEsperaService.Eliminar(id);
            if (!resultado.EsExito)
            {
                TempData["ErrorMessage"] = resultado.Descripcion;
            }
            else
            {
                TempData["SuccessMessage"] = resultado.Descripcion;
            }
            return RedirectToAction("Index");
        }
    }
}