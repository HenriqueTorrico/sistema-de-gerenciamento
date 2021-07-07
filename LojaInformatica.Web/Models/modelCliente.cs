using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaInformatica.Web.Models
{
    public class modelCliente
    {
        [Display(Name = "Código")]
        [Key]
        public string cd_cliente { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(20, ErrorMessage = "Máximo de 20 caracteres")]
        public string nm_cliente { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(20, ErrorMessage = "Máximo de 20 caracteres")]
        public string sob_cliente { get; set; }

        [Display(Name = "Idade")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(3, ErrorMessage = "Máximo de 3 caracteres")]
        public string ida_cliente { get; set; }

        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string cd_genero { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(15, ErrorMessage = "Máximo de 10 caracteres")]
        public string cel_cliente { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string eml_cliente { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(14, ErrorMessage = "Máximo de 11 caracteres")]
        public string cpf_cliente { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string cd_estado { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(9, ErrorMessage = "Máximo de 8 caracteres")]
        public string cep_cliente { get; set; }

        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string nm_genero { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string uf_estado { get; set; }
    }
}