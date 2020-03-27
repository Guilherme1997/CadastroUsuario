using CadastroUsuario.Infra.DAL;
using System.Collections.Generic;
using System.Linq;
using CadastroUsuario.Repository.ContatoRepository.Leitura;
using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Repository.Query
{
    public class UsuarioQueryRepository : IUsuarioQueryRepository
    {
        private readonly UsuarioContexto CadastroUsuarioContextoDb = new UsuarioContexto();

        public IEnumerable<Usuario> Listar()
        {
            return CadastroUsuarioContextoDb.Usuario.ToList();
        }

        public Usuario Obter(int id)
        {
            return CadastroUsuarioContextoDb.Usuario.Where(x => x.UsuarioID == id).FirstOrDefault();
        }

        public IEnumerable<Usuario> Obter(string nome, bool flagAtivo)
        {
            if (nome == "null")
            {
                return CadastroUsuarioContextoDb.Usuario.Where(x=> x.Ativo == flagAtivo).ToList();
            }

            return CadastroUsuarioContextoDb.Usuario.Where(x => x.Nome.Contains(nome) && x.Ativo == flagAtivo).ToList();
        }
    }
}