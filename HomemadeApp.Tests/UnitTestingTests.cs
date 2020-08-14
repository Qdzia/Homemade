using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomemadeApp;
using Xunit;

namespace HomemadeApp.Tests
{
    public class UnitTestingTests
    {
        [Fact]
        public void Add_SouldAddsimpleValues()
        {
            //Arragne 
            double expected = 5;
            //Act 
            UnitTesting Test = new UnitTesting();
            double actual = Test.Addition(1, 4);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4, 2, 2)]
        [InlineData(8, 2, 4)]
        public void Divide_ShouldDivideSimpleValues(double x, double y, double expected)
        {
            UnitTesting Test = new UnitTesting();
            double actual = Test.Divide(x, y);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddRecepieToList_ShouldWork()
        {
            List<RecepieSample> list = new List<RecepieSample>();
            RecepieSample rec = new RecepieSample(1, "Chiken", "Do It");
            UnitTesting Test = new UnitTesting();

            Test.AddRecepieToList(list,rec);

            Assert.Contains<RecepieSample>(rec,list);
            Assert.True(list.Count == 1);
        }

        [Theory]
        [InlineData("Chiken", "", "Instruction")]
        [InlineData("", "Do It", "RecepieName")]
        public void AddRecepieToList_ShouldFail(string name,string inst, string argument)
        {
            List<RecepieSample> list = new List<RecepieSample>();
            RecepieSample rec = new RecepieSample(1, name, inst);
            UnitTesting Test = new UnitTesting();

            Assert.Throws<ArgumentException>(argument, () => Test.AddRecepieToList(list, rec));

        }
    }
}
