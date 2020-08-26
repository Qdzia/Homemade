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
        List<Screen> Screens { get; set; }
        public ShellViewModel()
        {
            
        }

        public void GotoRecepie() => ActivateItem(new RecepieViewModel());
        public void GotoFreeSearch() => ActivateItem(new FreeSearchViewModel());
        public void GotoPlanner() => ActivateItem(new PlannerViewModel());
        
    }
}
