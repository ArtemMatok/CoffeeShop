﻿using Coffee.Data.Enum;

namespace Coffee.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        
        
    }
}
