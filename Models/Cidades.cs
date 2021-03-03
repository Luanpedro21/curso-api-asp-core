using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace curso_aula1.Models
{
    public class Cidades
    {
        [Key]
        public int cod_cidade { get; set; }

        public string nome_cidade { get; set; }

        public string uf { get; set; }


    }
}
