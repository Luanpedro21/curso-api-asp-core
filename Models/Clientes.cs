using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace curso_aula1.Models
{
    public class Clientes
    {
        [Key]
        public int cod_cliente { get; set; }

        public string nome_cliente { get; set; }

        public string tel_cliente { get; set; }

        public int cod_cidade { get; set; }

        [ForeignKey("cod_cidade")]
        public Cidades cidade { get; set; }




    }
}
