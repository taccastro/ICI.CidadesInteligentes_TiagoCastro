using ICI.ProvaCandidato.Dados;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface INoticiaTagService
{
    void AdicionarNoticiaTag(NoticiaTag noticiaTag);
    void EditarNoticiaTag(NoticiaTag noticiaTag);
    void ExcluirNoticiaTag(int noticiaTagId);
    IEnumerable<NoticiaTag> ObterTodasTags();
    List<Tag> ObterTags();
}
