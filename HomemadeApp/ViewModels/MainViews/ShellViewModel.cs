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

        private FreeSearchViewModel _freeSearch;
        private AddRecepieViewModel _addRecepie;
        private PlannerViewModel _planner;
        private GroceryListViewModel _groceryList;
        private DayPlannerViewModel _dayPlanner;
        private AccountViewModel _account;
        private HomeViewModel _home;

        private Stack<Screen> _next;
        private Stack<Screen> _previous;
        private Screen currentScreen;
        public ShellViewModel()
        {
            ApiHelper.InitializeClient();
            InitViews();
        }

        private void InitViews()
        {
            _next = new Stack<Screen>();
            _previous = new Stack<Screen>();

            _freeSearch = new FreeSearchViewModel();
            _addRecepie = new AddRecepieViewModel();
            _planner = new PlannerViewModel();
            _groceryList = new GroceryListViewModel();
            _dayPlanner = new DayPlannerViewModel();
            _account = new AccountViewModel();
            _home = new HomeViewModel();

            currentScreen = _planner;
            ActivateItem(currentScreen);

            _freeSearch.OnRecepieClick += GoToRecepie;
            _freeSearch.OnEditClick += GoToAddRecepie;
            _dayPlanner.OnRecepieClick += GoToRecepie;
            _planner.OnRecepieClick += GoToRecepie;
            _planner.OnEditClick += GoToDayPlanner;
        }

        private void ChangeScreen(Screen view)
        {
            if (view == currentScreen) return;

            _previous.Push(currentScreen);
            currentScreen = view;
            ActivateItem(currentScreen);
            _next = new Stack<Screen>();
        }
        public void NextScreen()
        {
            if (_next.Count == 0) return;

            _previous.Push(currentScreen);
            currentScreen = _next.Pop();
            ActivateItem(currentScreen);
        }
        public void PreviousScreen()
        {
            if (_previous.Count == 0) return;

            _next.Push(currentScreen);
            currentScreen = _previous.Pop();
            ActivateItem(currentScreen);
        }
        public void GotoGroceryList() => ChangeScreen(_groceryList);
        public void GotoFreeSearch() => ChangeScreen(_freeSearch);
        public void GotoUserAccount() => ChangeScreen(_account);
        public void GotoPlanner() => ChangeScreen(_planner);
        public void GotoMenu() => ChangeScreen(_home); 
        public void GotoHome() => ChangeScreen(_home);


        public void GoToRecepie(object sender, int recId)
        {
            ChangeScreen(new RecepieViewModel(recId));
        }

        public void GoToDayPlanner(object sender, EventArgs e)
        {
            ChangeScreen(_dayPlanner);
        }
        public void GoToAddRecepie(object sender, EventArgs e)
        {
            ChangeScreen(_addRecepie);
        }
    }
}
