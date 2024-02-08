using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class TagsController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly INoticiaTagService _tagService;

        public TagsController(DataContext context, INoticiaTagService tagService)
        {
            _dataContext = context;
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            //var noticiaTags = _tagService.ObterTodasTags();
            //var tags = noticiaTags.Select(nt => nt.Tag).ToList();
            //return View(tags);

            ////desse jeito funciona
            var tags = _dataContext.Tags;
            return View(tags);
        }

        public IActionResult Form()
        {
            var viewmodel = new TagFormViewModel
            {
                Tag = new Tag()
            };

            return View("TagForm", viewmodel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Save(Tag tag)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TagFormViewModel
                {
                    Tag = tag
                };

                return View("TagForm", viewModel);
            }

            var noticiaTag = new NoticiaTag
            {
                // Atribuir propriedades de 'tag' à 'noticiaTag', se necessário
            };

            _tagService.AdicionarNoticiaTag(noticiaTag);

            return RedirectToAction("Index", "Tags");
        }

        public IActionResult Edit(Tag tag)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TagFormViewModel
                {
                    Tag = tag
                };

                return View("TagForm", viewModel);
            }

            var noticiaTag = new NoticiaTag
            {
                // Atribuir propriedades de 'tag' à 'noticiaTag', se necessário
            };

            _tagService.EditarNoticiaTag(noticiaTag);

            return RedirectToAction("Index", "Tags");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _tagService.ExcluirNoticiaTag(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Se necessário, logar a exceção
                return BadRequest($"Erro ao excluir a notícia/tag: {ex.Message}");
            }
        }
    }
}
