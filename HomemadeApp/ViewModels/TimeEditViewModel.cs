using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.ViewModels
{
    class TimeEditViewModel : Screen
    {

        public string Heures 
        {
            get { return Time.Hours.ToString(); }
            set { ToHeures(value); }
        }
        public string Minutes 
        {
            get { return Time.Minutes.ToString(); }
            set { ToMinutes(value); }
        }

        public TimeSpan Time { get; set; }

        public TimeEditViewModel()
        {
            Time = new TimeSpan(12, 45, 37);
            NotifyOfPropertyChange(() => Heures);
        }

        private void ToHeures(string heur)
        {
            int number;
            bool isParsable = Int32.TryParse(heur, out number);

            if (isParsable)
            {
                if(number >= 0 && number <= 24)
                    Time = new TimeSpan(number, Time.Minutes, 0);
                else
                    Time = new TimeSpan(0, Time.Minutes, 0);
            }
            NotifyOfPropertyChange(() => Heures);
        }
        private void ToMinutes(string minutes)
        {
            int number;
            bool isParsable = Int32.TryParse(minutes, out number);

            if (isParsable)
            {
                if (number >= 0 && number <= 60)
                    Time = new TimeSpan(Time.Hours, number, 0);
                else
                    Time = new TimeSpan(Time.Hours, 0, 0);
            }
            NotifyOfPropertyChange(() => Minutes);
        }

    }
}
