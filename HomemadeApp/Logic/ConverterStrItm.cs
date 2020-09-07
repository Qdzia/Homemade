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

        //"-","g","dag","kg","ml","tbsp","tsp" (-|g|kg|ml|tbsp|tsp) (\d+)\s+(g|kg|ml|l|tbsp|tsp|cloves)

        public List<ItemListModel> TextToItemListModel(string text)
        {
            text = text.Trim();
            text = text.Replace("teaspoon", "tsp");
            text = text.Replace("tablespoon", "tbsp");
            var lines = text.Split('\n');
            List<ItemListModel> list = new List<ItemListModel>();

            foreach (var line in lines)
            {
                list.Add(LineToItemListModel(line.Trim()));
            }

            return list;
        }
        public ItemListModel LineToItemListModel(string strItem)
        {
            var item = new ItemListModel();

            item.Notes = FindNotes(ref strItem);
            item.Number = FindCount(ref strItem);
            item.Unit = FindUnit(ref strItem);
            item.IngName = strItem;

            return item;
        }

        public bool IsNameExistInDB(string name) 
        {
            var allIng = DataAccess.Instance.GetAllIng();
            List<string> allIngNames = new List<string>();
            allIng.ForEach(x => allIngNames.Add(x.IngName));

            foreach (var ingName in allIngNames)
            {
                if (ingName == name) return true;
            }
            return false;
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
            Regex r = new Regex(@"(g|kg|ml|l|tbsp|tsp|cloves)\s+([\s\S]*)", RegexOptions.IgnoreCase);
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
