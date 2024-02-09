using ICI.ProvaCandidato.Dados.Entities;
using System.Collections.Generic;

namespace ICI.ProvaCandidato.Dados.Interface
{
    public interface INoticiaDao
    {
        List<Noticia> ObterTodasNoticias();
        Noticia ObterNoticiaPorId(int noticiaId);
        void AdicionarNoticia(Noticia noticia);
        void AtualizarNoticia(Noticia noticia);
        void ExcluirNoticia(int noticiaId);

    }
}