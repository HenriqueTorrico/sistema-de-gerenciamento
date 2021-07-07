using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaInformatica.Web.Models
{
    public class modelFabricante
    {
        [Display(Name = "Código")]
        [Key]
        public string cd_fabricante { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string nm_fabricante { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string tel_fabricante { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string cnpj_fabricante { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string eml_fabricante { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string cd_estado { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string cep_fabricante { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string uf_estado { get; set; }
    }
}