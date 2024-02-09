﻿using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Dados.Entities;
using System.Collections.Generic;

namespace ICI.ProvaCandidato.Negocio
{
    public interface INoticiaService
    {
        List<Noticia> ObterTodasNoticias();
        Noticia ObterNoticiaPorId(int noticiaId);
        void AdicionarNoticia(Noticia noticia);
        void AtualizarNoticia(Noticia noticia);
        void ExcluirNoticia(int noticiaId);
    }
}
