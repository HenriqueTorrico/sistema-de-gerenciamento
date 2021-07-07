using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaInformatica.Web.Models
{
    public class modelFornecedor
    {
        [Display(Name = "Código")]
        [Key]
        public string cd_fornecedor { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string nm_fornecedor { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string tel_fornecedor { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string cnpj_fornecedor { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string cd_estado { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string cep_fornecedor { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string uf_estado { get; set; }
    }
}