using ICI.ProvaCandidato.Dados.Entities;
using ICI.ProvaCandidato.Dados.Interface;
using ICI.ProvaCandidato.Negocio.Interface;
using System;
using System.Collections.Generic;

namespace ICI.ProvaCandidato.Negocio
{
    public class NoticiaService : INoticiaService
    {
        private readonly INoticiaDao _noticiaDao;

        public NoticiaService(INoticiaDao noticiaDao)
        {
            _noticiaDao = noticiaDao ?? throw new ArgumentNullException(nameof(noticiaDao));
        }

        public List<Noticia> ObterTodasNoticias()
        {
            return _noticiaDao.ObterTodasNoticias();
        }

        public Noticia ObterNoticiaPorId(int noticiaId)
        {
            return _noticiaDao.ObterNoticiaPorId(noticiaId);
        }

        public void AdicionarNoticia(Noticia noticia)
        {
            _noticiaDao.AdicionarNoticia(noticia);
        }

        public void AtualizarNoticia(Noticia noticia)
        {
            _noticiaDao.AtualizarNoticia(noticia);
        }

        public void ExcluirNoticia(int noticiaId)
        {
            _noticiaDao.ExcluirNoticia(noticiaId);
        }
    }
}
