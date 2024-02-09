using ICI.ProvaCandidato.Dados.Entities;
using ICI.ProvaCandidato.Dados.Interface;
using System;
using System.Collections.Generic;

public class NoticiaTagService : INoticiaTagService
{
    private readonly INoticiaTagDao _noticiaTagDao;

    public NoticiaTagService(INoticiaTagDao noticiaTagDao)
    {
        _noticiaTagDao = noticiaTagDao;
    }

    public IEnumerable<NoticiaTag> ObterTodasTags()
    {
        var result = _noticiaTagDao.ObterTodasTags();

        return result;
    }

    public List<Tag> ObterTags()
    {
        var listTags = _noticiaTagDao.ObterTag();

        List<Tag> listTag = new List<Tag>();

        foreach (var tag in listTags)
        {
            if (tag.Tag != null)
            {
                listTag.Add(tag.Tag);
            }
        }

        return listTag;
    }

    public void AdicionarNoticiaTag(NoticiaTag noticiaTag)
    {
        if (noticiaTag == null)
        {
            throw new ArgumentNullException(nameof(noticiaTag));
        }

        _noticiaTagDao.AdicionarNoticiaTag(noticiaTag);
    }

    public void EditarNoticiaTag(NoticiaTag noticiaTag)
    {

        _noticiaTagDao.EditarNoticiaTag(noticiaTag);

    }

    public void ExcluirNoticiaTag(int noticiaTagId)
    {
        _noticiaTagDao.ExcluirNoticiaTag(noticiaTagId);
    }
}
