using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Dados.Entities;
using ICI.ProvaCandidato.Dados.Interface;
using System.Collections.Generic;
using System.Linq;

namespace ICI.ProvaCandidato.Negocio
{
    public class UsuariosService
    {
        private readonly IUsuariosDao _usuariosDao;

        public UsuariosService(IUsuariosDao usuariosDao)
        {
            _usuariosDao = usuariosDao;
        }

        public List<Usuario> ObterTodosUsuarios()
        {
            return _usuariosDao.ObterTodosUsuarios();
        }
    }
}