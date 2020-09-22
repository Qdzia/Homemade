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
                result = MergeIngList(DataAccess.Instance.GetRecepieIngById(rec.RecepieId),result);
            }

            return result;
        }

        List<IngListModel> MergeIngList(List<IngListModel> first, List<IngListModel> second) 
        {
            for (int i = 0; i < first.Count; i++)
            {
                for (int j = 0; j < second.Count; j++)
                {
                    if (second[j].IngName == first[i].IngName)
                    {
                        first[i].Number += second[j].Number;
                        second.RemoveAt(j);
                        break;
                    }
                }
            }
            first.AddRange(second);

            return first;
        }
    }
}
