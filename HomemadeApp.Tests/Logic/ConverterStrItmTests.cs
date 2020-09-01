using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomemadeApp.Logic;
using HomemadeApp.Models;
using Xunit;

namespace HomemadeApp.Tests.Logic
{
    public class ConverterStrItmTests
    {
        [Theory]
        [InlineData("1 kg marchew, diced", 1,"kg","marchew","diced")]
        public void StringToItemListModel_ShouldCreateItemCorrectly
            (string strItem, decimal expCount, string expUnit, string expName,  string expNotes)
        {
            //Arragne, Act, Assert
            ConverterStrItm converter = new ConverterStrItm();

            ItemListModel testItem = converter.StringToItemListModel(strItem);

            Assert.Equal(expCount, testItem.Count);
            Assert.Equal(expUnit, testItem.Unit);
            Assert.Equal(expName, testItem.IngName);
            Assert.Equal(expNotes, testItem.Notes);

        }


        [Theory]
        [InlineData("1 g carrot, cubed  ", "cubed", "1 g carrot")]
        [InlineData(" 1 g carrot ,cubed", "cubed", "1 g carrot")]
        [InlineData("1 g ,carrot,cubed", "", "")]
        public void FindNotes_ShouldSeperateNotesFromItems(string strItem, string expNotes, string expStrItem)
        {

            ConverterStrItm converter = new ConverterStrItm();
            string notes = converter.FindNotes(ref strItem);

            Assert.Equal(expNotes, notes);
            Assert.Equal(expStrItem, strItem);
        }

        [Theory]
        [InlineData("1 g carrot ", 1, "g carrot")]
        public void FindCount_ShouldSeperateNumberFromItems(string strItem, decimal expNumber, string expStrItem)
        {

            ConverterStrItm converter = new ConverterStrItm();
            decimal count = converter.FindCount(ref strItem);

            Assert.Equal(expNumber, count);
            Assert.Equal(expStrItem, strItem);
        }

        [Theory]
        [InlineData("g carrot ", "g", "carrot")]
        public void FindUnit_ShouldCheckUnitAndSeperateIt(string strItem, string expUnit, string expStrItem)
        {

            ConverterStrItm converter = new ConverterStrItm();
            string unit = converter.FindUnit(ref strItem);

            Assert.Equal(expUnit, unit);
            Assert.Equal(expStrItem, strItem);
        }


    }
}
