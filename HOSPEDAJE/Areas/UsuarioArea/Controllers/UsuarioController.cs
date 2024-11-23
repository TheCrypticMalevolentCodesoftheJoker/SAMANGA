using Microsoft.AspNetCore.Mvc;
using HOSPEDAJE.Areas.UsuarioArea.Services;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.FluentDTO;
using HOSPEDAJE.Areas.UsuarioArea.Payloads.EntidadesDTO;

namespace HOSPEDAJE.Areas.UsuarioArea.Controllers
{
    [Area("UsuarioArea")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _IUsuarioService;
        public UsuarioController(IUsuarioService iUsuarioService)
        {
            _IUsuarioService = iUsuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> PerfilView()
        {
            var idUsuario = HttpContext.Session.GetInt32("UsuarioId");
            var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
            var apellidoUsuario = HttpContext.Session.GetString("ApellidoUsuario");
            if (!idUsuario.HasValue)
            {
                return RedirectToAction("LoginView", "Usuario", new { area = "UsuarioArea" });
            }
            var DetalleUsuario = await _IUsuarioService.DetalleUsuario(idUsuario.Value);
            if (DetalleUsuario == null)
            {
                return NotFound("No se encontró la información del usuario.");
            }

            ViewBag.IdUsuario = idUsuario;
            ViewBag.NombreUsuario = nombreUsuario;
            ViewBag.ApellidoUsuario = apellidoUsuario;

            return View(DetalleUsuario);
        }

        [HttpGet]
        public ActionResult RegistrarView()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegistrarProceso(RegistrarUsuarioDTO registrarUsuarioDTO)
        {
            var ValidarDatos = new FormRegistrarUsuarioDTO();
            var DatosValidados = ValidarDatos.Validate(registrarUsuarioDTO);

            if (!DatosValidados.IsValid)
            {
                foreach (var failure in DatosValidados.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }

                return View("RegistrarView", registrarUsuarioDTO);
            }
            var UsuarioRegistrado = await _IUsuarioService.RegistrarUsuario(registrarUsuarioDTO);

            if (!UsuarioRegistrado.EsExito)
            {
                ModelState.AddModelError("Error", UsuarioRegistrado.Descripcion);
                return View("RegistrarView");
            }

            else
            {
                return RedirectToAction("PanelAdministrador", "PanelUsuarios", new { area = "UsuarioArea" });
            }
        }

        [HttpGet]
        public IActionResult LoginView()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginProceso(LoginUsuarioDTO loginUsuarioDTO)
        {
            var ValidarDatos = new FormLoginUsuarioDTO();
            var DatosValidados = ValidarDatos.Validate(loginUsuarioDTO);

            if (!DatosValidados.IsValid)
            {
                foreach (var failure in DatosValidados.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }

                return View("LoginView");
            }
            var UsuarioRegistrado = await _IUsuarioService.LoginUsuario(loginUsuarioDTO);

            if (!UsuarioRegistrado.EsExito)
            {
                ModelState.AddModelError("Error", UsuarioRegistrado.Descripcion);
                return View("LoginView");
            }

            else
            {
                HttpContext.Session.SetInt32("UsuarioId", UsuarioRegistrado.IdUsuario);
                HttpContext.Session.SetString("NombreUsuario", UsuarioRegistrado.Nombre);
                HttpContext.Session.SetString("ApellidoUsuario", UsuarioRegistrado.Apellido);

                var returnUrl = TempData["ReturnUrl"] as string;
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                switch (UsuarioRegistrado.IdRol)
                {
                    case 1:
                        return RedirectToAction("PanelAdministrador", "PanelUsuarios", new { area = "UsuarioArea" });
                    case 2:
                        return RedirectToAction("PanelLimpieza", "PanelUsuarios", new { area = "UsuarioArea" });
                    case 3:
                        return RedirectToAction("PanelMantenimiento", "PanelUsuarios", new { area = "UsuarioArea" });
                    case 4:
                        return RedirectToAction("PanelRecepcionista", "PanelUsuarios", new { area = "UsuarioArea" });
                    default:
                        return RedirectToAction("RegistrarView", "Usuario", new { area = "UsuarioArea" });
                }

            }
        }

        [HttpGet]
        public IActionResult LogoutView()
        {
            var idUsuario = HttpContext.Session.GetInt32("UsuarioId");
            var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
            var apellidoUsuario = HttpContext.Session.GetString("ApellidoUsuario");
            if (!idUsuario.HasValue)
            {
                return RedirectToAction("LoginView", "Usuario", new { area = "UsuarioArea" });
            }
            else
            {
                ViewBag.IdUsuario = idUsuario;
                ViewBag.NombreUsuario = nombreUsuario;
                ViewBag.ApellidoUsuario = apellidoUsuario;

                return View();
            }
        }
        [HttpPost]
        public IActionResult LogoutProceso()
        {
            HttpContext.Session.Remove("UsuarioId");
            HttpContext.Session.Remove("NombreUsuario");
            HttpContext.Session.Remove("ApellidoUsuario");

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        public async Task<IActionResult> ActualizarView()
        {
            var idUsuario = HttpContext.Session.GetInt32("UsuarioId");
            var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
            var apellidoUsuario = HttpContext.Session.GetString("ApellidoUsuario");
            ViewBag.IdUsuario = idUsuario;
            ViewBag.NombreUsuario = nombreUsuario;
            ViewBag.ApellidoUsuario = apellidoUsuario;
            if (!idUsuario.HasValue)
            {
                return RedirectToAction("LoginView", "Usuario", new { area = "UsuarioArea" });
            }
            var DetalleUsuario = await _IUsuarioService.DetalleUsuario(idUsuario.Value);
            if (DetalleUsuario == null)
            {
                return NotFound("No se encontró la información del usuario.");
            }
            DetalleUsuario.Contraseña = null;
            return View(DetalleUsuario);
        }
        [HttpPost]
        public async Task<IActionResult> ActualizarProceso(DetalleUsuarioDTO detalleUsuarioDTO) 
        {
            var idUsuario = HttpContext.Session.GetInt32("UsuarioId");
            if (!idUsuario.HasValue)
            {
                return RedirectToAction("LoginView", "Usuario", new { area = "UsuarioArea" });
            }

            var DatosValidados = new FormDetalleUsuarioDTO().Validate(detalleUsuarioDTO);
            if (!DatosValidados.IsValid)
            {
                foreach (var failure in DatosValidados.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View("ActualizarView", detalleUsuarioDTO);
            }

            if (detalleUsuarioDTO.ImagenFile?.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await detalleUsuarioDTO.ImagenFile.CopyToAsync(memoryStream);
                    detalleUsuarioDTO.Imagen = memoryStream.ToArray();
                }
            }
            else if (detalleUsuarioDTO.Imagen == null)
            {
                ModelState.AddModelError("ImagenFile", "Por favor, seleccione una imagen válida.");
                return View("ActualizarView", detalleUsuarioDTO);
            }

            var actualizarUsuario = await _IUsuarioService.ActualizarUsuario(detalleUsuarioDTO, idUsuario.Value);
            if (!actualizarUsuario.EsExito)
            {
                ModelState.AddModelError("Error", actualizarUsuario.Descripcion);
                var detalleUsuario = await _IUsuarioService.DetalleUsuario(idUsuario.Value);
                if (detalleUsuario == null)
                {
                    return NotFound("No se encontró la información del usuario.");
                }
                return View("ActualizarView", detalleUsuario);
            }
            HttpContext.Session.SetInt32("UsuarioId", actualizarUsuario.IdUsuario);
            HttpContext.Session.SetString("NombreUsuario", actualizarUsuario.Nombre);
            HttpContext.Session.SetString("ApellidoUsuario", actualizarUsuario.Apellido);
            return RedirectToAction("PerfilView");
        }

        [HttpGet]
        public IActionResult EliminarView()
        {
            var idUsuario = HttpContext.Session.GetInt32("UsuarioId");
            var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
            var apellidoUsuario = HttpContext.Session.GetString("ApellidoUsuario");
            if (!idUsuario.HasValue)
            {
                return RedirectToAction("LoginView", "Usuario", new { area = "UsuarioArea" });
            }
            else
            {
                ViewBag.IdUsuario = idUsuario;
                ViewBag.NombreUsuario = nombreUsuario;
                ViewBag.ApellidoUsuario = apellidoUsuario;

                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> EliminarProceso()
        {
            var idUsuario = HttpContext.Session.GetInt32("UsuarioId");
            if (!idUsuario.HasValue)
            {
                return RedirectToAction("LoginView", "Usuario", new { area = "UsuarioArea" });
            }
            var EliminarUsuario = await _IUsuarioService.EliminarUsuario(idUsuario.Value);
            if (!EliminarUsuario.EsExito)
            {
                ModelState.AddModelError("Error", EliminarUsuario.Descripcion);
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
