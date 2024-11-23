using Microsoft.AspNetCore.Mvc;

namespace HOSPEDAJE.Areas.UsuarioArea.Controllers
{
    [Area("UsuarioArea")]
    public class PanelUsuariosController : Controller
    {
        [HttpGet]
        public ActionResult PanelAdministrador()
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
        [HttpGet]
        public ActionResult PanelLimpieza()
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
        [HttpGet]
        public ActionResult PanelMantenimiento()
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
        [HttpGet]
        public ActionResult PanelRecepcionista()
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
    }
}
