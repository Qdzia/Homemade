using Caliburn.Micro;
using HomemadeApp.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.ViewModels
{
    class AccountViewModel : Screen
    {
        public RestrictionsPanelViewModel RestrictionsPanel { get; set; }
        public UserModel User { get; set; }
        public AccountViewModel()
        {
            User = DataAccess.Instance.GetUserById(2);
            RestrictionsPanel = new RestrictionsPanelViewModel();
        }
        
    }
}
