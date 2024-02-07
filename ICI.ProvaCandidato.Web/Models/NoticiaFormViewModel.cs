using ICI.ProvaCandidato.Dados;
using Microsoft.CodeAnalysis.CodeStyle;
using System.Collections;
using System.Collections.Generic;

namespace ICI.ProvaCandidato.Web.Models
{
    public class NoticiaFormViewModel
    {
        public IEnumerable<Usuario> Usuarios {  get; set; }
        public Noticia Noticia { get; set; }
    }
}
