using ICI.ProvaCandidato.Dados.Entities;
using System.Collections.Generic;

public interface INoticiaTagService
{
    void AdicionarNoticiaTag(NoticiaTag noticiaTag);
    void EditarNoticiaTag(NoticiaTag noticiaTag);
    void ExcluirNoticiaTag(int noticiaTagId);
    IEnumerable<NoticiaTag> ObterTodasTags();
    List<Tag> ObterTags();
}
