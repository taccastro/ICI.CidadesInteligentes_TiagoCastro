using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Dados.Entities
{
    public class Noticia
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Favor informar o título da notícia.")]
        [StringLength(255)]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Favor informar o texto da notícia.")]
        public string Texto { get; set; }
        [Required(ErrorMessage = "Favor selecionar um usuário.")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public ICollection<NoticiaTag> TagsNoticia { get; set; } = new List<NoticiaTag>();
    }
}
