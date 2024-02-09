using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Dados.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        [StringLength(128)]
        public string Senha { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
    }
}
