using CadastroUsuario.Domain.Models;
using System.Data.Entity;

namespace CadastroUsuario.Infra.DAL
{
    public class SexoContexto : ContextoBase
    {
        public DbSet<Sexo> Sexo { get; set; }

    }
}
