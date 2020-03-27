using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CadastroUsuario.Infra.DAL
{
    public class ContextoBase : DbContext
    {
        public ContextoBase() : base("CadastroUsuarioConnectionString") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ContextoBase>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}