using CadastroUsuario.Domain.Models;

namespace CadastroUsuario.Domain.Service
{
    public class UsuarioService
    {
        public void AtivarUsuario(Usuario usuario)
        {
            usuario.Ativo = true;
        }
    }
}