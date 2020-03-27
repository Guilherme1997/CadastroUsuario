using CadastroUsuario.Domain.Models;
using CadastroUsuario.Repository.ContatoRepository.Command;
using CadastroUsuario.Repository.Query;
using System.Collections.Generic;
using System.Web.Http;

namespace CadastroUsuario.Application.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private readonly UsuarioQueryRepository usuarioQueryRepository = new UsuarioQueryRepository();

        private readonly UsuarioCommandRepository usuarioCommandRepository = new UsuarioCommandRepository();

        [Route("")]
        [HttpGet]
        public IEnumerable<Usuario> Obter()
        {
            return usuarioQueryRepository.Listar();
        }

        [Route("{nome}/{flagAtivo}")]
        [HttpGet]
        public IEnumerable<Usuario> Obter(string nome, bool flagAtivo)
        {
            return usuarioQueryRepository.Obter(nome, flagAtivo);
        }

        [Route("{usuarioID:int}")]
        [HttpGet]
        public Usuario Obter(int usuarioID)
        {
            return usuarioQueryRepository.Obter(usuarioID);
        }

        [Route("")]
        [HttpPost]
        public void Inserir([FromBody]Usuario usuario)
        {
            usuarioCommandRepository.Inserir(usuario);
        }

        [Route("{usuarioID:int}")]
        [HttpPut]
        public void Atualizar([FromBody]Usuario contato, int usuarioID)
        {
            usuarioCommandRepository.Alterar(contato, usuarioID);
        }

        [Route("{usuarioID}")]
        [HttpDelete]
        public void Deletar(int usuarioID)
        {
            usuarioCommandRepository.Deletar(usuarioID);
        }
    }
}
