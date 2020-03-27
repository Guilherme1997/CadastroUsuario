using CadastroUsuario.Infra.DAL;
using CadastroUsuario.Domain.Models;
using System.Data.Entity;

namespace CadastroUsuario.Infra.Repository.SexoRepository.Command
{
    public class SexoCommandRepository : ISexoCommandRepository
    {
        private readonly SexoContexto CadastroUsuarioContextoDb = new SexoContexto();

        private DbSet<Sexo> ObterTabelaSexo()
        {
            return CadastroUsuarioContextoDb.Sexo;
        }


        public void Inserir(Sexo sexo)
        {
            ObterTabelaSexo().Add(sexo);
            CadastroUsuarioContextoDb.SaveChanges();
        }
    }
}