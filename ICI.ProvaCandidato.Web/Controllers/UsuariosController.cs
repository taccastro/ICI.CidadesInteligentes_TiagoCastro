using ICI.ProvaCandidato.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuariosService _usuariosService;

        public UsuariosController(UsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        public IActionResult Index()
        {
            var usuarios = _usuariosService.ObterTodosUsuarios();

            return View(usuarios);
        }
    }
}