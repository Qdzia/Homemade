using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Models.DBModels
{
    class UserModel
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastActive { get; set; }
        public string FullName { get; set; }
        public string PhysicalActivity { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public UserModel(   int userId, 
                            string login, 
                            string password, 
                            string email, 
                            DateTime createdAt, 
                            DateTime lastActive, 
                            string fullName, 
                            string physicalActivity, 
                            int height, 
                            int weight  )
        {
            UserId = userId;
            Login = login;
            Password = password;
            Email = email;
            CreatedAt = createdAt;
            LastActive = lastActive;
            FullName = fullName;
            PhysicalActivity = physicalActivity;
            Height = height;
            Weight = weight;
        }

        
      
    }
}
