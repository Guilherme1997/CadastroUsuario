using System.ComponentModel.DataAnnotations;

namespace CadastroUsuario.Domain.Models
{
    public class Sexo 
    {
        public int SexoID { get; set; }

        [StringLength(15)]
        public string Descricao { get; set; }
    }
}