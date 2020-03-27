using CadastroUsuario.Apresentation.Command;
using CadastroUsuario.Apresentation.Query;
using CadastroUsuario.Apresentation.ViewModel;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;

namespace CadastroUsuario.Application.Controllers
{
    [RoutePrefix("api/sexo")]
    public class SexoController : ApiController
    {        
        private readonly IMediator _mediator;

        private readonly IServiceCollection _serviceCollection;

        public SexoController(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;

            _serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());

            _mediator = _serviceCollection.BuildServiceProvider().GetService<IMediator>();
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Inserir([FromBody]SexoCommand sexo)
        {
           return  Ok(await _mediator.Send(sexo));
        }

        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<SexoViewModel>> Obter()
        {
            var query = new  SexoQuery();

            return await _mediator.Send(query);
        }

    }
}
