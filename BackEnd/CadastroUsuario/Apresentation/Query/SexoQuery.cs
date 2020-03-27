using CadastroUsuario.Apresentation.ViewModel;
using MediatR;
using System.Collections.Generic;

namespace CadastroUsuario.Apresentation.Query
{
    public class SexoQuery : IRequest<IEnumerable<SexoViewModel>>
    {
    }
}