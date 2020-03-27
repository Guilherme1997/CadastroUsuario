using CadastroUsuario.Apresentation.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroUsuario.Infra.Repository.SexoRepository.Query
{
    interface ISexoQueryRepository
    {
        Task<IEnumerable<SexoViewModel>> Listar();

    }
}
