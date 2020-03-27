using CadastroUsuario.Apresentation.ViewModel;
using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Domain.Factory
{
    public class SexoFactory
    {
        public static SexoViewModel Create(Sexo sexo) => new SexoViewModel
        {
            Descricao = sexo.Descricao,
            SexoID = sexo.SexoID
        };
    }
}