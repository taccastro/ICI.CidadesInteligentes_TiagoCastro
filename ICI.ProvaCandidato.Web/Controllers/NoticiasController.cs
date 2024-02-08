using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Negocio;
using ICI.ProvaCandidato.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class NoticiasController : Controller
    {

        private readonly INoticiaService _noticiaService;
        private readonly DataContext _dataContext;

        public NoticiasController(INoticiaService noticiaService, DataContext context)
        {
            _noticiaService = noticiaService;
            _dataContext = context;
        }

        public IActionResult Index()
        {
            var noticias = _noticiaService.ObterTodasNoticias();
            var tags = _dataContext.Tags.ToList();

            var viewModel = new NoticiasViewModel
            {
                Noticias = noticias,
                Tags = tags
            };

            return View(viewModel);
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

            try
            {
                if (noticia.Id == 0)
                {
                    _noticiaService.AdicionarNoticia(noticia);
                }
                else
                {
                    var noticiaToUpdate = _noticiaService.ObterNoticiaPorId(noticia.Id);

                    if (noticiaToUpdate == null)
                    {
                        return NotFound();
                    }

                    noticiaToUpdate.Titulo = noticia.Titulo;
                    noticiaToUpdate.Texto = noticia.Texto;
                    noticiaToUpdate.UsuarioId = noticia.UsuarioId;

                    _noticiaService.AtualizarNoticia(noticiaToUpdate);
                }

                return RedirectToAction("Index", "Noticias");
            }
            catch (Exception ex)
            {
                // Lide com exceções apropriadamente, como registrar o erro, retornar uma página de erro, etc.
                return View("Error");
            }
        }

        public IActionResult Edit(int id)
        {
            var noticia = _noticiaService.ObterNoticiaPorId(id);

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
            try
            {
                _noticiaService.ExcluirNoticia(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Lide com exceções apropriadamente, como registrar o erro, retornar uma página de erro, etc.
                return View("Error");
            }
        }

        //public IActionResult AdicionarTag(int noticiaId, int tagId)
        //{
        //    var tagNoticia = new NoticiaTag
        //    {
        //        NoticiaId = noticiaId,
        //        TagId = tagId
        //    };

        //    _dataContext.NoticiasTags.Add(tagNoticia);
        //    _dataContext.SaveChanges();

        //    return Ok();
        //}
    }
}
