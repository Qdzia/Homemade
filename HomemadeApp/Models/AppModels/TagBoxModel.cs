using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HomemadeApp.Models
{
    public class TagBoxModel
    {
        public string Tag { get; set; }
        public SolidColorBrush TagColor { get; set; }
        public bool IsActive { get; set; }

       
        public TagBoxModel(string tag, SolidColorBrush tagColor, bool isActive)
        {
            Tag = tag;
            TagColor = tagColor;
            IsActive = isActive;
        }

        public TagBoxModel(TagModel tag)
        {
            Tag = tag.Tag;
            TagColor = new SolidColorBrush(
                (Color)ColorConverter.ConvertFromString(tag.TagColor));
            IsActive = false;
        }

        public TagBoxModel(TagBoxModel tag)
        {
            Tag = tag.Tag;
            TagColor = tag.TagColor;
            IsActive = !tag.IsActive;
        }
    }
}
