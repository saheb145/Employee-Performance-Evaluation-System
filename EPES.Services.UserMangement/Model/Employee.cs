﻿namespace EPES.Services.UserMangement.Model
{
    public class Employee
    {
        public int Id {  get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}
