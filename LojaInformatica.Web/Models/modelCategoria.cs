using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaInformatica.Web.Models
{
    public class modelCategoria
    {
        [Display(Name = "Código")]
        [Key]
        public string cd_categoria { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string nm_categoria { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string desc_categoria { get; set; }
    }
}