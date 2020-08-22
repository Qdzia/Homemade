using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.ViewModels
{
    class PlannerViewModel
    {
        public FreeSearchRecViewModel FreeSearchRecViewModel { get; set; }


        public PlannerViewModel()
        {
            this.FreeSearchRecViewModel = new FreeSearchRecViewModel();
        }
    }
}
