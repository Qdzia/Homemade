using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Models
{
    class RecepieModel
    {
        public int RecepieId { get; set; }
        public string RecepieName { get; set; }
        public string Instruction { get; set; }
        public TimeSpan PrepTime { get; set; }
        public TimeSpan TotalTime { get; set; }
        public string Video { get; set; }
        public string Photo { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public byte Rating { get; set; }

        public RecepieModel(int recepieId, string recepieName, string instruction, TimeSpan prepTime, 
            TimeSpan totalTime, string video, string photo, int userId, DateTime createdAt, byte rating)
        {
            RecepieId = recepieId;
            RecepieName = recepieName;
            Instruction = instruction;
            PrepTime = prepTime;
            TotalTime = totalTime;
            Video = video;
            Photo = photo;
            UserId = userId;
            CreatedAt = createdAt;
            Rating = rating;
        }

      

    }
}
