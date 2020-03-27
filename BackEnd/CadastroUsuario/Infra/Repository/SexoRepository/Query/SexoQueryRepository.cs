using CadastroUsuario.Apresentation.ViewModel;
using CadastroUsuario.Infra.DAL;
using CadastroUsuario.Domain.Factory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuario.Infra.Repository.SexoRepository.Query
{
    public class SexoQueryRepository : ISexoQueryRepository
    {
        private readonly SexoContexto CadastroUsuarioContextoDb = new SexoContexto();

        public async Task<IEnumerable<SexoViewModel>> Listar()
        {
            return await Task.Run(() => CadastroUsuarioContextoDb.Sexo.Select(SexoFactory.Create));
        } 
    }
}