using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp
{
    public class UnitTesting
    {
        public double Addition(double x, double y)
        {
            return x + y;
        }

        public double Divide(double x, double y)
        {
            return x / y;
        }

        public void AddRecepieToList(List<RecepieSample> list, RecepieSample rec)
        {
           if (string.IsNullOrEmpty(rec.RecepieName)) throw new ArgumentException("Name is Empty", "RecepieName");
           if (string.IsNullOrEmpty(rec.Instruction)) throw new ArgumentException("Name is Empty", "Instruction");
           list.Add(rec);
        }
    }
}
