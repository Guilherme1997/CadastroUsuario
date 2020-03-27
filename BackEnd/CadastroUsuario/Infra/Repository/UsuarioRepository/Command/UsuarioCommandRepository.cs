using CadastroUsuario.Infra.DAL;
using CadastroUsuario.Domain.Models;
using CadastroUsuario.Domain.Service;
using System.Data.Entity;
using System.Linq;

namespace CadastroUsuario.Repository.ContatoRepository.Command
{
    public class UsuarioCommandRepository : IUsuarioCommandRepository
    {
        private readonly UsuarioContexto _CadastroUsuarioContextoDb = new UsuarioContexto();

        private readonly UsuarioService _usuarioService = new UsuarioService();

        private DbSet<Usuario> ObterTabelaUsuario()
        {
            return _CadastroUsuarioContextoDb.Usuario;
        }

        public void Inserir(Usuario usuario)
        {
            _usuarioService.AtivarUsuario(usuario);

            ObterTabelaUsuario().Add(usuario);
            
            _CadastroUsuarioContextoDb.SaveChanges();
        }

        public void Deletar(int id)
        {
            ObterTabelaUsuario().Remove(ObterTabelaUsuario().Single(x => x.UsuarioID == id));
            _CadastroUsuarioContextoDb.SaveChanges();
        }

        public void Alterar(Usuario usuarioNovo, int id)
        {
            var usuarioAntigo = ObterTabelaUsuario().Single(x => x.UsuarioID == id);

            usuarioAntigo.Nome = usuarioNovo.Nome;
            usuarioAntigo.DataNascimento = usuarioNovo.DataNascimento;
            usuarioAntigo.Email = usuarioNovo.Email;
            usuarioAntigo.Senha = usuarioNovo.Senha;
            usuarioAntigo.SexoID = usuarioNovo.SexoID;
            usuarioAntigo.Ativo = usuarioNovo.Ativo;

            _CadastroUsuarioContextoDb.SaveChanges();
        }
    }
}