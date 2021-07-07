using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaInformatica.Web.Models
{
    public class modelFuncionario
    {
        [Display(Name = "Código")]
        [Key]
        public string cd_funcionario { get; set; }

        [Display(Name = "Nome completo")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string nm_funcionario { get; set; }

        [Display(Name = "Idade")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(2, ErrorMessage = "Máximo de 2 caracteres")]
        public string ida_funcionario { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string cpf_funcionario { get; set; }

        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string cd_genero { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(15, ErrorMessage = "Máximo de 10 caracteres")]
        public string cel_funcionario { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string eml_funcionario { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(9, ErrorMessage = "Máximo de 8 caracteres")]
        public string cep_funcionario { get; set; }

        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string nm_genero { get; set; }
    }
}