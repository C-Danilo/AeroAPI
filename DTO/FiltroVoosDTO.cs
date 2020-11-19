using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroportoAPI.DTO
{
    public class FiltroVoosDTO
    {
        public int OrigemId { get; set; }
        public int DestinoId { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }

        public int NumeroPasssagerios { get; set;}
    }
}
