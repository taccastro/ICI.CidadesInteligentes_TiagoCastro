using ICI.ProvaCandidato.Dados;
using Microsoft.AspNetCore.Mvc;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly DataContext _dataContext;
        public UsuariosController(DataContext context)
        {
            _dataContext = context;
        }

        public IActionResult Index()
        {
            var usuarios = _dataContext.Usuarios;

            return View(usuarios);
        }
    }
}
