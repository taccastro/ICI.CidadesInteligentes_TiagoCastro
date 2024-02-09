using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Negocio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using ICI.ProvaCandidato.Dados.Entities;

public class NoticiaService : INoticiaService
{
    private readonly DataContext _dbContext;

    public NoticiaService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Noticia> ObterTodasNoticias()
    {
        return _dbContext.Noticias.Include(n => n.Usuario).ToList();
    }

    public Noticia ObterNoticiaPorId(int noticiaId)
    {
        return _dbContext.Noticias.Include(n => n.Usuario).FirstOrDefault(n => n.Id == noticiaId);
    }

    public void AdicionarNoticia(Noticia noticia)
    {
        
        if (noticia == null)
        {
            throw new ArgumentNullException(nameof(noticia));
        }
        
        _dbContext.Noticias.Add(noticia);
        _dbContext.SaveChanges();
    }

    public void AtualizarNoticia(Noticia noticia)
    {
        
        if (noticia == null)
        {
            throw new ArgumentNullException(nameof(noticia));
        }
        
        _dbContext.Entry(noticia).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void ExcluirNoticia(int noticiaId)
    {
        var noticia = _dbContext.Noticias.Find(noticiaId);

        // Lógica de validação antes de excluir a notícia
        if (noticia == null)
        {
            throw new Exception($"Erro genérico: Notícia com ID {noticiaId} não encontrada.");
        }
       
        _dbContext.Noticias.Remove(noticia);
        _dbContext.SaveChanges();
    }
}

