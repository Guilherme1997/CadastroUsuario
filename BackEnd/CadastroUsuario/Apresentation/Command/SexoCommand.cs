using CadastroUsuario.Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroUsuario.Apresentation.Command
{
    [NotMapped]
    public class SexoCommand : Sexo, IRequest<string>
    {
    }
}