using Caliburn.Micro;
using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        #region Dependacy
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(TagBox), new PropertyMetadata("None"));

        public BindableCollection<TagBoxModel> Tags
        {
            get { return (BindableCollection<TagBoxModel>)GetValue(TagsProperty); }
            set { SetValue(TagsProperty, value);  }
        }

        public static readonly DependencyProperty TagsProperty =
            DependencyProperty.Register("Tags", typeof(BindableCollection<TagBoxModel>), typeof(TagBox), new PropertyMetadata(null));

        public BindableCollection<string> ActiveTags
        {
            get { return (BindableCollection<string>)GetValue(ActiveTagsProperty); }
            set { SetValue(ActiveTagsProperty, value); }
        }

        public static readonly DependencyProperty ActiveTagsProperty =
            DependencyProperty.Register("ActiveTags", typeof(BindableCollection<string>), typeof(TagBox), new PropertyMetadata(null));



        #endregion

        public event EventHandler OnTagChange;
        public TagBox()
        {
            InitializeComponent();
        }

        //Changing the color of Tag and add/remove it from Active Tags List
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
