using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaInformatica.Web.Models
{
    public class modelProdutos
    {
        [Display(Name = "Código")]
        [Key]
        public string cd_produto { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string nm_produto { get; set; }

        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string cd_fornecedor { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string cd_categoria { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string vl_produto { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string qt_produto { get; set; }

        [Display(Name = "Fabricante")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string cd_fabricante { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string nm_categoria { get; set; }

        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string nm_fornecedor { get; set; }

        [Display(Name = "Fabricante")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string nm_fabricante { get; set; }

        [Display(Name = "Imagem do Produto")]
        public string img_produto { get; set; }
    }
}