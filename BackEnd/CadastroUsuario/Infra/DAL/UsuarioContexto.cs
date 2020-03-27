using CadastroUsuario.Domain.Models;
using System.Data.Entity;

namespace CadastroUsuario.Infra.DAL
{
    public class UsuarioContexto : ContextoBase
    {
        public DbSet<Usuario> Usuario { get; set; }

    }
}