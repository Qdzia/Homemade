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
        public decimal Count { get; set; }
        public string Unit { get; set; }
        public string Notes { get; set; }

        public ContainModel(int recepieId, int ingId, decimal count, string unit, string notes)
        {
            RecepieId = recepieId;
            IngId = ingId;
            Count = count;
            Unit = unit;
            Notes = notes;
        }

        public override string ToString()
        {
            return $"{Count} {Unit} {Notes}";
        }

    }
}
