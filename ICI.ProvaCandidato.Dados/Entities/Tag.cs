using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Dados.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public string Descricao { get; set; }
    }
}
