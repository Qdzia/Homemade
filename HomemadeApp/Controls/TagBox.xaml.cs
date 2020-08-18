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
    /// Interaction logic for TagBox.xaml
    /// </summary>
    public partial class TagBox : UserControl
    {
        public BindableCollection<TagBoxModel> Tags { get; set; }
        public List<string> ActiveTags { get; set; }
        public TagBox()
        {
            InitializeComponent();
            ActiveTags = new List<string>();
            Tags = new BindableCollection<TagBoxModel>()
            {
                new TagBoxModel("Jedzenie",new SolidColorBrush(Colors.Blue),false),
                new TagBoxModel("chinese",new SolidColorBrush(Colors.Blue),false),
                new TagBoxModel("Italian",new SolidColorBrush(Colors.Blue),false)
            };
            TagList.ItemsSource = Tags;
        }


        public string Word
        {
            get { return (string)GetValue(WordProperty); }
            set { SetValue(WordProperty, value); }
        }

        public static readonly DependencyProperty WordProperty =
            DependencyProperty.Register("Word", typeof(string), typeof(TagBox), new PropertyMetadata("Brak"));

        private void ActiveTag(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string tagName = button.Content.ToString();

            for (int i = 0; i < Tags.Count; i++)
            {
                if (Tags[i].Tag == tagName)
                {
                    if (Tags[i].IsActive) ActiveTags.Remove(Tags[i].Tag);
                    else ActiveTags.Add(Tags[i].Tag);
                    Tags[i] = new TagBoxModel(Tags[i].Tag, Tags[i].TagColor, !Tags[i].IsActive);
                } 
            }
        }
    }
}
