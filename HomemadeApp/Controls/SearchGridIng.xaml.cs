using Caliburn.Micro;
using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomemadeApp.Controls
{
    /// <summary>
    /// Interaction logic for SearchGridIng.xaml
    /// </summary>
    public partial class SearchGridIng : UserControl
    {
        public BindableCollection<IngredientModel> IngredientsList { get; set; }
        //public BindableCollection<IngredientModel> IngredientsList
        //{
        //    get { return (BindableCollection<IngredientModel>)GetValue(IngredientsListProperty); }
        //    set { SetValue(IngredientsListProperty, value); }
        //}

        //public static readonly DependencyProperty IngredientsListProperty =
        //    DependencyProperty.Register("IngredientsList", typeof(BindableCollection<IngredientModel>), typeof(SearchGridIng), new PropertyMetadata(0));



        public SearchGridIng()
        {
            InitializeComponent();
            IngredientsList = new BindableCollection<IngredientModel>();
            IngredientsList.AddRange(DataAccess.Instance.GetAllIng());

            IngGrid.ItemsSource = IngredientsList;
        }
    }
}
