using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class TagsController : Controller
    {
        private readonly DataContext _dataContext;
        public TagsController(DataContext context)
        {
            _dataContext = context;
        }

        public IActionResult Index()
        {
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

            if (tag.Id == 0)
                _dataContext.Tags.Add(tag);
            else
            {
                var tagToUpdate = _dataContext.Tags.Single(o => o.Id == tag.Id);
                tagToUpdate.Descricao = tag.Descricao;
            }

            _dataContext.SaveChanges();

            return RedirectToAction("Index", "Tags");
        }

        public IActionResult Edit(int id)
        {
            var tag = _dataContext.Tags.Single(o => o.Id == id);

            if (tag == null)
                return NotFound();

            var viewModel = new TagFormViewModel
            {
                Tag = tag
            };

            return View("TagForm", viewModel);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var tagInDb = _dataContext.Tags.SingleOrDefault(o => o.Id == id);

            if (tagInDb == null)
                return NotFound();

            // Verifique se existem notícias que utilizam a tag a ser excluída
            var hasNewsWithTag = _dataContext.Noticias.Any(n => n.TagsNoticia.Any(t => t.TagId == id));

            if (hasNewsWithTag)
            {
                return BadRequest("Não é possível excluir a tag, pois há notícias que a utilizam.");
            }

            _dataContext.Tags.Remove(tagInDb);
            _dataContext.SaveChanges();

            return Ok();
        }


    }
}
