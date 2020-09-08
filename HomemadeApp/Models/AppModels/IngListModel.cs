using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Models
{
    public class IngListModel
    {
        public int IngId { get; set; }
        public string IngName { get; set; }
        public decimal Number { get; set; }
        public string Unit { get; set; }
        public string Notes { get; set; }

        public IngListModel(string ingName, decimal number, string unit, string notes)
        {
            IngName = ingName;
            Number = number;
            Unit = unit;
            Notes = notes;
        }
        public IngListModel()
        {
            IngName = null;
            Number = 0;
            Unit = null;
            Notes = null;
        }

        public override string ToString()
        {
            return $"{Number} {Unit} {IngName}, {Notes}";
        }

    }
}
