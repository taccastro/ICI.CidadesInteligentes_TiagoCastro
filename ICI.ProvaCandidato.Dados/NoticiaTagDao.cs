using ICI.ProvaCandidato.Dados.Entities;
using ICI.ProvaCandidato.Dados.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICI.ProvaCandidato.Dados
{
    public class NoticiaTagDao : INoticiaTagDao
    {
        private readonly DataContext _dbContext;

        public NoticiaTagDao(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<NoticiaTag> ObterTodasTags()
        {
            var result = _dbContext.NoticiasTags
                .Include(nt => nt.Tag)
                .ToList();

            return result;
        }

        public List<NoticiaTag> ObterTag()
        {
            var result = _dbContext.NoticiasTags
                .Include(nt => nt.Tag)
                .Where(x => x.Tag != null)
                .GroupBy(x => x.Tag)
                .Select(group => group.First())
                .ToList();

            return result;
        }

        public void AdicionarNoticiaTag(NoticiaTag noticiaTag)
        {
            if (noticiaTag == null)
            {
                throw new ArgumentNullException(nameof(noticiaTag));
            }

            _dbContext.NoticiasTags.Add(noticiaTag);
            _dbContext.SaveChanges();
        }

        public void EditarNoticiaTag(NoticiaTag noticiaTag)
        {
            if (noticiaTag == null)
            {
                throw new ArgumentNullException(nameof(noticiaTag));
            }

            var noticiaTagExistente = _dbContext.NoticiasTags.Find(noticiaTag.Id);

            if (noticiaTagExistente == null)
            {
                throw new Exception($"Erro genérico: Notícia com ID {noticiaTag.Id} não encontrada.");
            }


            noticiaTagExistente.NoticiaId = noticiaTag.NoticiaId;
            noticiaTagExistente.Noticia = noticiaTag.Noticia;
            noticiaTagExistente.TagId = noticiaTag.TagId;
            noticiaTagExistente.Tag = noticiaTag.Tag;

            _dbContext.SaveChanges();
        }

        public void ExcluirNoticiaTag(int noticiaTagId)
        {
            var noticiaTag = _dbContext.NoticiasTags.Find(noticiaTagId);

            if (noticiaTag == null)
            {
                throw new Exception($"Erro genérico: Notícia com ID {noticiaTagId}  não encontrada.");
            }


            _dbContext.NoticiasTags.Remove(noticiaTag);
            _dbContext.SaveChanges();
        }
    }
}