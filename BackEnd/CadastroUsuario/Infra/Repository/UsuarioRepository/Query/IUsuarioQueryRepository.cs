using CadastroUsuario.Domain.Models;
using System.Collections.Generic;

namespace CadastroUsuario.Repository.ContatoRepository.Leitura
{
    public interface IUsuarioQueryRepository
    {
        IEnumerable<Usuario> Listar();

        Usuario Obter(int id);

        IEnumerable<Usuario> Obter(string nome, bool flagAtivo);

    }
}