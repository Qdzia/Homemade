using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Logic
{
    class IngListHandler
    {
        public List<IngListModel> SumUpIng(List<RecepieModel> recList)
        {
            List<IngListModel> result = new List<IngListModel>();

            foreach (var rec in recList)
            {
                result = MergeIngList(result,DataAccess.Instance.GetRecepieIngById(rec.RecepieId));
            }

            return result;
        }

        List<IngListModel> MergeIngList(List<IngListModel> first, List<IngListModel> second) 
        {
            for (int i = 0; i < first.Count; i++)
            {
                foreach (var item in second)
                {
                    if (item.IngId == first[i].IngId) first[i].Number += item.Number;
                }
            }

            return first;
        }
    }
}
