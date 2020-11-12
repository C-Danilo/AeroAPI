using AeroportoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroportoAPI.DTO
{
    public class VooDTO
    {
        public DateTime dataIda { get; set; }

        public DateTime dataVolta { get; set; }

        public Local LocalOrigem { get; set; }

        public Local LocalDestino { get; set; }

        public int NumeroParadas { get; set; }

        public TimeSpan TempoIda { get; set; }

        public TimeSpan TempoVolta { get; set; }

        public double Preco { get; set; }
    }
}
