using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.ViewModels
{
    class PlannerViewModel
    {
        public TagBarViewModel TagBarViewModel { get; set; }


        public PlannerViewModel()
        {
            this.TagBarViewModel = new TagBarViewModel();
            
        }
    }
}
