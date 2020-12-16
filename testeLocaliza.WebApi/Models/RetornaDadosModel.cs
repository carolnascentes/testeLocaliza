using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testeLocaliza.WebApi.Models
{
    public class RetornaDadosModel
    {
        public string Divisores { get; set; }
        public string DivisoresPrimos { get; set; }

        public RetornaDadosModel(string divisores, string divisoresPrimos)
        {
            Divisores = divisores;
            DivisoresPrimos = divisoresPrimos;
        }
    }
}
