﻿namespace EPES.Services.AuthAPI.Models.Dto
{
	public class ApplicationUserDto
	{
		public string ID { get; set; }
		public string UserName { get; set; }
		public string Name {  get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	
		public string PhoneNumber { get; set; }
	}
}
