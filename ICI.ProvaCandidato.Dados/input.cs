using ICI.ProvaCandidato.Dados.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados
{
    public class input
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Usuarios.Any() || context.Tags.Any() || context.Noticias.Any() || context.NoticiasTags.Any()) return;

            var usuarios = new List<Usuario>
            {
                new Usuario
                {
                    Id = 1,
                    Nome = "Pedro",
                    Email = "pedro@teste.com",
                    Senha = "senhaPedro456"
                },
                new Usuario
                {
                    Id = 2,
                    Nome = "Isabel",
                    Email = "isabel@teste.com",
                    Senha = "senhaIsabel789"
                },
                new Usuario
                {
                    Id = 3,
                    Nome = "Rafaela",
                    Email = "rafaela@teste.com",
                    Senha = "senhaRafaela123"
                },
            };

            var tags = new List<Tag>
            {
                new Tag
                {
                    Id = 1,
                    Descricao = "Notícias de Futebol"
                },
                new Tag
                {
                    Id = 2,
                    Descricao = "Notícias do Mundo"
                }
            };

            var noticias = new List<Noticia>
            {
                new Noticia
                {
                    Id = 1,
                    Titulo = "Empresa de Tecnologia é considerada a melhor para de trabalhar",
                    Texto = "De acordo com dados de diversos sites de recrutamento empresa x se sobressaiu dentre as demais.",
                    UsuarioId = 2
                },
                new Noticia
                {
                    Id = 2,
                    Titulo = "Carros inovadores chega ao mercado",
                    Texto = "teste teste teste teste",
                    UsuarioId = 1
                },
                new Noticia
                {
                    Id = 3,
                    Titulo = "Exploração espacial alcança marcos históricos",
                    Texto = "teste teste teste teste",
                    UsuarioId = 1
                },               
            };

            var noticiasTags = new List<NoticiaTag>
            {
                new NoticiaTag
                {
                    Id = 1,
                    NoticiaId = 1,
                    TagId = 2
                },
                new NoticiaTag
                {
                    Id = 2,
                    NoticiaId = 1,
                    TagId = 1
                },
                new NoticiaTag
                {
                    Id = 3,
                    NoticiaId = 2,
                    TagId = 1
                },
                new NoticiaTag
                {
                    Id = 4,
                    NoticiaId = 3,
                    TagId = 1
                },
                new NoticiaTag
                {
                    Id = 5,
                    NoticiaId = 3,
                    TagId = 2
                }
            };

            await context.Usuarios.AddRangeAsync(usuarios);
            await context.Tags.AddRangeAsync(tags);
            await context.Noticias.AddRangeAsync(noticias);
            await context.NoticiasTags.AddRangeAsync(noticiasTags);

            await context.SaveChangesAsync();
        }
    }
}
