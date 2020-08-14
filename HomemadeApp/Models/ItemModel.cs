using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Models
{
    class ItemModel
    {
        public decimal Count { get; set; }
        public string Unit { get; set; }
        public string Comment { get; set; }
        public string Type { get; set; }

        public ItemModel(decimal count, string unit, string comment, string type)
        {
            Count = count;
            Unit = unit;
            Comment = comment;
            Type = type;
        }


    }
}
