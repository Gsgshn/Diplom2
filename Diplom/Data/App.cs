﻿namespace Diplom.Data
{
    public class App
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? UserId { get; set; }
        public User? Users { get; set; } 
    }
}
