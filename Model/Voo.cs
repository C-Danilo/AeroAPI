using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroportoAPI.Model
{
    public class Voo
    {
        public int Id { get; set; } // o Entity sabe que é primary key por ser Id

        public DateTime dataIda { get; set; }

        public DateTime dataVolta { get; set; }

        public Local LocalOrigemID { get; set; }

        public Local LocalDestinoID { get; set; }

        public int NumeroParadas { get; set; }

        public TimeSpan TempoIda { get; set; }

        public TimeSpan TempoVolta { get; set; }

        public double Preco { get; set; }
    }
}
