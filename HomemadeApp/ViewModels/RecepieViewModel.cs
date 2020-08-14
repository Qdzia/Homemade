using Caliburn.Micro;
using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.ViewModels
{
    class RecepieViewModel : Screen
    {
        //D:\Documents\RecepieDB\AppTest\ChickenChowMein.mp4

        //BindableCollection<string>


        public string RecepieName { get; }
        public string Instruction { get; }
        //public TimeSpan PrepTime { get; set; }
        //public TimeSpan TotalTime { get; set; }
        public string Video { get;}
        public string Photo { get;}

        public RecepieModel Recepie { get; set; }

    }
}
