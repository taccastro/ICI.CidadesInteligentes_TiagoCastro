using ICI.ProvaCandidato.Dados.Entities;
using System.Collections.Generic;

namespace ICI.ProvaCandidato.Web.Models
{
    public class NoticiaFormViewModel
    {
        public IEnumerable<Usuario> Usuarios { get; set; }
        public Noticia Noticia { get; set; }
    }
}
