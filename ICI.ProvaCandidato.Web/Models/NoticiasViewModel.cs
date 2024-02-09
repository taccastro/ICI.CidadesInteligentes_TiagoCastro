using ICI.ProvaCandidato.Dados.Entities;
using System.Collections.Generic;

namespace ICI.ProvaCandidato.Web.Models
{
    public class NoticiasViewModel
    {
        public IEnumerable<Noticia> Noticias { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}
