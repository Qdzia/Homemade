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

        public TagBarViewModel()
        {
            ActiveTags = new BindableCollection<string>();
            Tags = new BindableCollection<TagBoxModel>();
        }

        public void TagClicked(TagBoxModel tag, Border border)
        {
            ToggleColour(tag, border);

            UpdateActiveTags(tag);
        }

        private void UpdateActiveTags(TagBoxModel tag)
        {
            if (ActiveTags.Contains(tag.Tag))
            {
                ActiveTags.Remove(tag.Tag);
            }
            else
            {
                ActiveTags.Add(tag.Tag);
            }
              
            OnTagChange?.Invoke(this, null);

        }

        private void ToggleColour(TagBoxModel tag, Border border)
        {
            if (tag.IsActive)
            {
                border.Background = tag.TagColor;
            }
            else
            {
                border.Background = new SolidColorBrush(Colors.Blue);
            }

            for (int i = 0; i < Tags.Count; i++)
            {
                if (Tags[i].Tag == tag.Tag)
                {
                    //This Constructor copy tag and toggle IsActive propery
                    Tags[i] = new TagBoxModel(Tags[i]);
                }
            }
        }
    }
}
