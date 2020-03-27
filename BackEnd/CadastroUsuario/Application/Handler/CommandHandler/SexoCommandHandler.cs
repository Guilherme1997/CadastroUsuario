using CadastroUsuario.Apresentation.Command;
using CadastroUsuario.Apresentation.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace CadastroUsuario.Application.Handler.CommandHandler
{
    public class SexoCommandHandler : IRequestHandler<SexoCommand,string>
    {
        public async Task<string> Handle(SexoCommand request, CancellationToken cancellationToken)
        {
            var result = Task.Run(() => "Cadastrado com sucesso");
            
            return await result;
        }
    }
}