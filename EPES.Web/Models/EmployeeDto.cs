﻿using EPES.Web.Utility;

namespace EPES.Web.Models
{
    public class EmployeeDto
    {
      /*  internal SD.ApiType ApiType;
*/
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
       /* public EmployeeDto Data { get; internal set; }
        public string Url { get; internal set; }*/
    }
}
