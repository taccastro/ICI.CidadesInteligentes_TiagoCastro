using ICI.ProvaCandidato.Dados.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Interface
{
    public interface INoticiaTagDao
    {
        void AdicionarNoticiaTag(NoticiaTag noticiaTag);
        void EditarNoticiaTag(NoticiaTag noticiaTag);
        void ExcluirNoticiaTag(int noticiaTagId);
        IEnumerable<NoticiaTag> ObterTodasTags();
        List<NoticiaTag> ObterTag();

    }
}
