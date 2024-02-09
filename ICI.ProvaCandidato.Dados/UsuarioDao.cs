using ICI.ProvaCandidato.Dados.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ICI.ProvaCandidato.Dados.Interface
{
    public interface IUsuariosDao
    {
        List<Usuario> ObterTodosUsuarios();
    }

    public class UsuariosDao : IUsuariosDao
    {
        private readonly DataContext _dataContext;

        public UsuariosDao(DataContext context)
        {
            _dataContext = context;
        }

        public List<Usuario> ObterTodosUsuarios()
        {
            return _dataContext.Usuarios.ToList();
        }
    }
}