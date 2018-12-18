using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class Cadastro
    {
        public int ID { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Nome { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Logradouro { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Bairro { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Cidade { get; set; }

        [StringLength(2, MinimumLength = 2)]
        [Required]
        [Display(Name = "UF")]
        public string UF { get; set; }


        [StringLength(8, MinimumLength = 8)]
        [Required]
        public string CEP { get; set; }

        public string Temperatura { get; set; }

    }
}