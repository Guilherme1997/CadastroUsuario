using CadastroUsuario.Apresentation.Query;
using CadastroUsuario.Apresentation.ViewModel;
using CadastroUsuario.Infra.Repository.SexoRepository.Query;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroUsuario.Application.Handler.QueryHandler
{
    public class SexoQueryHandler : IRequestHandler<SexoQuery, IEnumerable<SexoViewModel>>
    {
        private readonly SexoQueryRepository _sexoQueryRepository = new SexoQueryRepository();

        public async Task<IEnumerable<SexoViewModel>> Handle(SexoQuery request, CancellationToken cancellationToken)
        {
            return await _sexoQueryRepository.Listar();
        }
    }
}