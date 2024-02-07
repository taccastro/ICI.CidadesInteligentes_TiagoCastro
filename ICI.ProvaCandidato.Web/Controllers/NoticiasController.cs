using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly DataContext _dataContext;
        public NoticiasController(DataContext context)
        {
            _dataContext = context;
        }

        public IActionResult Index()
        {
            var noticias = _dataContext.Noticias.Include(o => o.Usuario).Include(o => o.TagsNoticia);
            var tags = _dataContext.Tags.ToList();
            var viewmodel = new NoticiasViewModel
            {
                Noticias = noticias,
                Tags = tags
            };

            return View(viewmodel);
        }

        public IActionResult Form()
        {
            var usuarios = _dataContext.Usuarios.ToList();
            var viewModel = new NoticiaFormViewModel
            {
                Noticia = new Noticia(),
                Usuarios = usuarios
            };

            return View("NoticiaForm", viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Save(Noticia noticia)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NoticiaFormViewModel
                {
                    Noticia = noticia,
                    Usuarios = _dataContext.Usuarios.ToList()
                };

                return View("NoticiasForm", viewModel);
            }

            if (noticia.Id == 0)
                _dataContext.Noticias.Add(noticia);
            else
            {
                var noticiaToUpdate = _dataContext.Noticias.Single(o => o.Id == noticia.Id);
                noticiaToUpdate.Titulo = noticia.Titulo;
                noticiaToUpdate.Texto = noticia.Texto;
                noticiaToUpdate.UsuarioId = noticia.UsuarioId;
            }

            _dataContext.SaveChanges();

            return RedirectToAction("Index", "Noticias");
        }

        public IActionResult Edit(int id)
        {
            var noticia = _dataContext.Noticias.Single(o => o.Id == id);

            if (noticia == null)
                return NotFound();

            var usuarios = _dataContext.Usuarios.ToList();
            var viewModel = new NoticiaFormViewModel
            {
                Noticia = noticia,
                Usuarios = usuarios
            };

            return View("NoticiaForm", viewModel);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var noticiaInDb = _dataContext.Noticias.SingleOrDefault(o => o.Id == id);

            if (noticiaInDb == null)
                return NotFound();

            _dataContext.Noticias.Remove(noticiaInDb);
            _dataContext.SaveChanges();
            
            return Ok();
        }

        public IActionResult AdicionarTag(int noticiaId, int tagId)
        {
            var tagNoticia = new NoticiaTag
            {
                NoticiaId = noticiaId,
                TagId = tagId
            };

            _dataContext.NoticiasTags.Add(tagNoticia);
            _dataContext.SaveChanges();

            return Ok();
        }
    }
}
