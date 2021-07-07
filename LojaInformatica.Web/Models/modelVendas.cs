using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaInformatica.Web.Models
{
    public class modelVendas
    {
        [Display(Name = "Código")]
        [Key]
        public string cd_venda { get; set; }

        [Display(Name = "Cliente")]
        public string cd_cliente { get; set; }

        [Display(Name = "Produto")]
        public string cd_produto { get; set; }

        [Display(Name = "Quantidade")]
        public string qt_produto { get; set; }

        [Display(Name = "Valor total")]
        public string vl_total { get; set; }

        [Display(Name = "Funcionário")]
        public string cd_funcionario { get; set; }

        [Display(Name = "Cliente")]
        public string nm_cliente { get; set; }

        [Display(Name = "Produto")]
        public string nm_produto { get; set; }

        [Display(Name = "Funcionário")]
        public string nm_funcionario { get; set; }

        [Display(Name = "CPF do Cliente")]
        public string cpf_cliente { get; set; }

        [Display(Name = "Pagamento")]
        public string cd_pagamento { get; set; }

        [Display(Name = "Forma de Pagamento")]
        public string fr_pagamento { get; set; }
    }
}