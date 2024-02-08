using ICI.ProvaCandidato.Dados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class NoticiaTagService : INoticiaTagService
{
    private readonly DataContext _dbContext;

    public NoticiaTagService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }    

    public IEnumerable<NoticiaTag> ObterTodasTags()
    {
        return _dbContext.NoticiasTags
            .Include(nt => nt.Tag)            
            .ToList();
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
