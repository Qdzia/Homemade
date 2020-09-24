using System;

namespace HomemadeApp
{
    public class RecepieSample
    {
        public RecepieSample(int RecepieId, string RecepieName,string Instruction)
        {
            this.RecepieId = RecepieId;
            this.RecepieName = RecepieName;
            this.Instruction = Instruction;
        }
        public int RecepieId { get; set; }
        public string RecepieName { get; set; }
        public string Instruction { get; set; }
        //public TimeSpan PrepTime { get; set; }
        //public TimeSpan TotalTime { get; set; }
        //public string Video { get; set; }
        //public string Photo { get; set; }

        public override string ToString()
        {
            return $"{RecepieId} {RecepieName} {Instruction}";
        }
    }
}
