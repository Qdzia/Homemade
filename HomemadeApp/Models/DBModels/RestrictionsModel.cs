using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Models
{
    class RestrictionsModel
    {
        public int ResId { get; set; }
        public int UserId { get; set; }
        public int MaxNum { get; set; }
        public int MinNum { get; set; }
        public string ResName { get { return DataAccess.Instance.Restrictions[ResId]; } }
        public int Num { get; set; }

        public RestrictionsModel() { }
        public RestrictionsModel(int resId, int userId, int maxNum, int minNum)
        {
            ResId = resId;
            UserId = userId;
            MaxNum = maxNum;
            MinNum = minNum;
        }
    }
}
