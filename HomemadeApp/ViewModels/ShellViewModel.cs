using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.ViewModels
{
    class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            
        }

        public void GotoRecepie() 
        {
            ActivateItem(new RecepieViewModel());
        }

        public void GotoFreeSearchRec()
        {
            ActivateItem(new FreeSearchViewModel());
        }

        public void GotoPlanner()
        {
            ActivateItem(new PlannerViewModel());
        }

        public void GotoFreeSearchIng()
        {
            ActivateItem(new PlannerViewModel());
        }
    }
}
