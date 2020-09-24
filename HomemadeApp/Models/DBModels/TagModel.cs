using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Models
{
    public class TagModel
    {
        public int TagId { get; set; }
        public string Tag { get; set; }
        public string TagColor { get; set; }

        public TagModel(int tagId, string tag, string tagColor)
        {
            TagId = tagId;
            Tag = tag;
            TagColor = tagColor;
        }
    }
}
