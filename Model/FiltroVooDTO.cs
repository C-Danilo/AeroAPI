using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroportoAPI.Model
{
    public class FiltroVooDTO
    {
        public int OrigemId {get; set;}
        public int DestinoId {get; set;}
        public DateTime dataInicial {get; set;}
        public DateTime dataFinal { get; set; }
    }
}
