using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Models
{
    public class ItemListModel
    {
        public string IngName { get; set; }
        public decimal Number { get; set; }
        public string Unit { get; set; }
        public string Notes { get; set; }

        public ItemListModel(string ingName, decimal count, string unit, string notes)
        {
            IngName = ingName;
            Number = count;
            Unit = unit;
            Notes = notes;
        }
        public ItemListModel()
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
