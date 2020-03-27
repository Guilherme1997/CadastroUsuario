using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Repository.ContatoRepository.Command
{
    public interface IUsuarioCommandRepository
    {
        void Inserir(Usuario contato);
        void Deletar(int id);
        void Alterar(Usuario contatoNovo, int id);
    }
}
