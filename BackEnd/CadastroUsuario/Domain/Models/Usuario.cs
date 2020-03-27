using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroUsuario.Domain.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }

        [StringLength(200)]
        public string Nome { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }


        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Senha { get; set; }

        public bool Ativo { get; set; }

        public int SexoID { get; set; }

        [ForeignKey("SexoID")]
        public virtual Sexo Sexo { get; set; }
    }
}