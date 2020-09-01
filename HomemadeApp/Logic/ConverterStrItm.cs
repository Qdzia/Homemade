using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomemadeApp.Logic
{
    public class ConverterStrItm
    {

        //"-","g","dag","kg","ml","tbsp","tsp" (-|g|kg|ml|tbsp|tsp) (\d+)\s+(g|kg|ml|tbsp|tsp)
        public ItemListModel StringToItemListModel(string strItem)
        {
            var item = new ItemListModel();

            item.Notes = FindNotes(ref strItem);
            item.Count = FindCount(ref strItem);
            item.Unit = FindUnit(ref strItem);
            item.IngName = strItem;

            return item;
        }

        public string FindNotes(ref string strItem)
        {
            if (strItem.Contains(','))
            {
                string[] notesTab = strItem.Split(',');
                if (notesTab.Length == 2)
                {
                    strItem = notesTab[0].Trim();
                    return notesTab[1].Trim();
                }
                else strItem = "";
            }
            return "";
        }

        public decimal FindCount(ref string strItem)
        {
            Regex r = new Regex(@"(\d+)\s+([\s\S]*)", RegexOptions.IgnoreCase);
            Match m = r.Match(strItem);

            decimal count = 0;

            if (m.Success)
            {
                string numberStr = m.Groups[1].ToString();
                Decimal.TryParse(numberStr, out count);

                strItem = m.Groups[2].ToString().Trim();
            }
            return count;
        }

        public string FindUnit(ref string strItem)
        {
            Regex r = new Regex(@"(g|kg|ml|tbsp|tsp)\s+([\s\S]*)", RegexOptions.IgnoreCase);
            Match m = r.Match(strItem);

            string unit = "";

            if (m.Success)
            {
                unit = m.Groups[1].ToString().Trim();
                strItem = m.Groups[2].ToString().Trim();
            }
            return unit;
        }
    }
}
