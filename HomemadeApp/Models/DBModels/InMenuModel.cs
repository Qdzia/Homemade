using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Models
{
    class InMenuModel
    {
        public int MenuId { get; set; }
        public int RecepieId { get; set; }
        public int Day { get; set; }
        public int Number { get; set; }
        public RecepieModel Recepie { get; set; }

        public InMenuModel(RecepieModel recepie, int day, int number)
        {
            Recepie = recepie;
            RecepieId = recepie.RecepieId;
            Day = day;
            Number = number;
        }

    }
}
