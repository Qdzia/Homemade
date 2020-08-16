﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Models
{
    class ItemListModel
    {
        public string IngName { get; set; }
        public decimal Count { get; set; }
        public string Unit { get; set; }
        public string Notes { get; set; }

        public ItemListModel(string ingName, decimal count, string unit, string notes)
        {
            IngName = ingName;
            Count = count;
            Unit = unit;
            Notes = notes;
        }

        public override string ToString()
        {
            return $"{Count} {Unit} {IngName}, {Notes}";
        }

    }
}