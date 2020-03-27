namespace CadastroUsuario.Infra.Migrations
{

    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CadastroUsuario.Infra.DAL.ContextoBase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CadastroUsuario.Infra.DAL.ContextoBase context)
        {

        }
    }
}
