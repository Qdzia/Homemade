using Caliburn.Micro;
using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace HomemadeApp.ViewModels
{
    class TagBarViewModel : Screen
    {
        public string Header { get; set; }

        public BindableCollection<TagBoxModel> Tags { get; set; }

        public BindableCollection<string> ActiveTags { get; set; }

        public event EventHandler OnTagChange;

        public void TagClicked(TagBoxModel selectedTag, TextBlock textBox)
        {
            if (selectedTag.IsActive)
                textBox.Background = selectedTag.TagColor;
            else
                textBox.Background = new SolidColorBrush(Colors.Blue);

            OnTagChange?.Invoke(this,null);

            for (int i = 0; i < Tags.Count; i++)
            {
                if (Tags[i].Tag == selectedTag.Tag)
                {
                    //This Constructor copy tag and toggle IsActive propery
                    Tags[i] = new TagBoxModel(Tags[i]);
                }
            }
        }


        //Changing the color of Tag and add/remove it from Active Tags List
        //private void ActiveTag(object sender, RoutedEventArgs e)
        //{
        //    Button button = sender as Button;
        //    string tagName = button.Content.ToString();

        //    for (int i = 0; i < Tags.Count; i++)
        //    {
        //        if (Tags[i].Tag == tagName)
        //        {
        //            if (Tags[i].IsActive) ActiveTags.Remove(Tags[i].Tag);
        //            else ActiveTags.Add(Tags[i].Tag);
        //            Tags[i] = new TagBoxModel(Tags[i].Tag, Tags[i].TagColor, !Tags[i].IsActive);

        //        }
        //    }
        //}
    }
}
