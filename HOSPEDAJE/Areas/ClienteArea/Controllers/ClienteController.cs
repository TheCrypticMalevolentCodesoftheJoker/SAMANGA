using Microsoft.AspNetCore.Mvc;
using HOSPEDAJE.Areas.ClienteArea.Services;
using HOSPEDAJE.Areas.ClienteArea.Payloads.FluentDTO;
using HOSPEDAJE.Areas.ClienteArea.Payloads.EntidadesDTO;

namespace HOSPEDAJE.Areas.ClienteArea.Controllers
{
    [Area("ClienteArea")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _IClienteService;
        public ClienteController(IClienteService iclienteService)
        {
            _IClienteService = iclienteService;
        }

        [HttpGet]
        public IActionResult IndexView()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> PerfilView()
        {
            var idCliente = HttpContext.Session.GetInt32("ClienteId");
            var nombreCliente = HttpContext.Session.GetString("NombreCliente");
            var apellidoCliente = HttpContext.Session.GetString("ApellidoCliente");

            if (!idCliente.HasValue)
            {
                return RedirectToAction("Login", "Auth");
            }

            var clienteDetalle = await _IClienteService.DetalleCliente(idCliente.Value);
            if (clienteDetalle == null)
            {
                return NotFound("No se encontró la información del cliente.");
            }
            ViewBag.IdCliente = idCliente;
            ViewBag.NombreCliente = nombreCliente;
            ViewBag.ApellidoCliente = apellidoCliente;
            return View(clienteDetalle);
        }

        [HttpGet]
        public ActionResult RegistrarView()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegistrarProceso(RegistrarClienteDTO ViewRegistrarClienteDTO)
        {
            var ValidarDatos = new FormRegistrarClienteDTO();
            var DatosValidados = ValidarDatos.Validate(ViewRegistrarClienteDTO);
            if (!DatosValidados.IsValid)
            {
                foreach (var failure in DatosValidados.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View("RegistrarView");
            }

            var RODS_Cliente = await _IClienteService.RegistrarCliente(ViewRegistrarClienteDTO);

            if (!RODS_Cliente.EsExito)
            {
                ModelState.AddModelError("Error", RODS_Cliente.Descripcion);
                return View("RegistrarView");
            }
            else
            {
                HttpContext.Session.SetInt32("ClienteId", RODS_Cliente.IdCliente);
                HttpContext.Session.SetString("NombreCliente", RODS_Cliente.Nombre);
                HttpContext.Session.SetString("ApellidoCliente", RODS_Cliente.Apellido);

                var returnUrl = TempData["ReturnUrl"] as string;
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "" });
                }
            }
        }

        [HttpGet]
        public IActionResult LoginView()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginProceso(LoginClienteDTO ViewLoginClienteDTO)
        {
            var ValidarDatos = new FormLoginClienteDTO();
            var DatosValidados = ValidarDatos.Validate(ViewLoginClienteDTO);

            if (!DatosValidados.IsValid)
            {
                foreach (var failure in DatosValidados.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View("LoginView");
            }

            var RODS_Cliente = await _IClienteService.LoginCliente(ViewLoginClienteDTO);

            if (!RODS_Cliente.EsExito)
            {
                ModelState.AddModelError("Error", RODS_Cliente.Descripcion);
                return View("LoginView");
            }
            else
            {
                HttpContext.Session.SetInt32("ClienteId", RODS_Cliente.IdCliente);
                HttpContext.Session.SetString("NombreCliente", RODS_Cliente.Nombre);
                HttpContext.Session.SetString("ApellidoCliente", RODS_Cliente.Apellido);

                var returnUrl = TempData["ReturnUrl"] as string;
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "" });
                }
            }
        }

        [HttpGet]
        public ActionResult LogoutView()
        {
            var idCliente = HttpContext.Session.GetInt32("ClienteId");
            var nombreCliente = HttpContext.Session.GetString("NombreCliente");
            var apellidoCliente = HttpContext.Session.GetString("ApellidoCliente");

            ViewBag.IdCliente = idCliente;
            ViewBag.NombreCliente = nombreCliente;
            ViewBag.ApellidoCliente = apellidoCliente;

            return View();
        }
        [HttpPost]
        public IActionResult LogoutProceso()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        public async Task<ActionResult> ActualizarView()
        {
            var idCliente = HttpContext.Session.GetInt32("ClienteId");
            var nombreCliente = HttpContext.Session.GetString("NombreCliente");
            var apellidoCliente = HttpContext.Session.GetString("ApellidoCliente");

            ViewBag.IdCliente = idCliente;
            ViewBag.NombreCliente = nombreCliente;
            ViewBag.ApellidoCliente = apellidoCliente;
            if (!idCliente.HasValue)
            {
                return RedirectToAction("LoginView", "Cliente", new { area = "ClienteArea" });
            }

            var clienteDetalle = await _IClienteService.DetalleCliente(idCliente.Value);
            if (clienteDetalle == null)
            {
                return NotFound("No se encontró la información del cliente.");
            }
            return View(clienteDetalle);
        }
        [HttpPost]
        public async Task<IActionResult> ActualizarProceso(DetalleClienteDTO viewDetalleClienteDTO)
        {
            var idCliente = HttpContext.Session.GetInt32("ClienteId");
            if (!idCliente.HasValue)
            {
                return RedirectToAction("Login", "Auth");
            }

            var RODS_Cliente = await _IClienteService.ActualizarCliente(viewDetalleClienteDTO, idCliente.Value);

            if (!RODS_Cliente.EsExito)
            {
                ModelState.AddModelError("Error", RODS_Cliente.Descripcion);
                return View("ActualizarView");
            }
            else
            {
                HttpContext.Session.SetInt32("ClienteId", RODS_Cliente.IdCliente);
                HttpContext.Session.SetString("NombreCliente", RODS_Cliente.Nombre);
                HttpContext.Session.SetString("ApellidoCliente", RODS_Cliente.Apellido);

                return RedirectToAction("DetallesView");
            }
        }

        [HttpGet]
        public ActionResult EliminarView()
        {
            var idCliente = HttpContext.Session.GetInt32("ClienteId");
            var nombreCliente = HttpContext.Session.GetString("NombreCliente");
            var apellidoCliente = HttpContext.Session.GetString("ApellidoCliente");
            
            ViewBag.IdCliente = idCliente;
            ViewBag.NombreCliente = nombreCliente;
            ViewBag.ApellidoCliente = apellidoCliente;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EliminarProceso()
        {
            var idCliente = HttpContext.Session.GetInt32("ClienteId");
            if (!idCliente.HasValue)
            {
                return RedirectToAction("LoginView", "Cliente", new { area = "ClienteArea" });
            }

            var resultado = await _IClienteService.EliminarCliente(idCliente.Value);

            if (!resultado.EsExito)
            {
                ModelState.AddModelError("Error", resultado.Descripcion);
                return View("EliminarView");
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }
    }
}
