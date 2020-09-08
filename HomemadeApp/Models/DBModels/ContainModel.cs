using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Models
{
    class ContainModel
    {
        public int RecepieId { get; set; }
        public int IngId { get; set; }
        public decimal Number { get; set; }
        public string Unit { get; set; }
        public string Notes { get; set; }

        public ContainModel(int recepieId,int ingId, decimal number, string unit, string notes)
        {
            RecepieId = recepieId;
            IngId = ingId;
            Number = number;
            Unit = unit;
            Notes = notes;
        }
    }
}
