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

        //private Color _tagColor;
        //public Color TagColor 
        //{
        //    get { if (IsActive) return _tagColor; else return Colors.Gray; }
        //    set { _tagColor = value; } 
        //}

        public SolidColorBrush TagColor { get; set; }
        public bool IsActive { get; set; }

       
        public TagBoxModel(string tag, SolidColorBrush tagColor, bool isActive)
        {
            Tag = tag;
            TagColor = tagColor;
            IsActive = isActive;
        }

    }
}
