using EPES.Services.AuthAPI.Data;
using EPES.Services.AuthAPI.Models.Dto;
using EPES.Services.AuthAPI.Service.IService;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EPES.Services.AuthAPI.Service
{
	public class ProfileByEmail : IProfileByEmail
	{
	
		private readonly IConfiguration _configuration;
		private readonly AppDbContext _dbContext;
		public ProfileByEmail( IConfiguration configuration, AppDbContext dbContext)

		{
			_configuration= configuration;
			_dbContext= dbContext;


		}
		public List<UserDto> FetchUserDataByUserId(string userId)
		{
			List<UserDto> profiles = new List<UserDto>();

			using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				connection.Open();

				using (var command = new SqlCommand("FetchUserDataByUserId", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(new SqlParameter("@UserId", userId));



					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							profiles.Add(new UserDto
							{
								ID = reader["ID"].ToString(),
								Name = reader["Name"].ToString(),
								Email = reader["Email"].ToString(),

								PhoneNumber = reader["PhoneNumber"].ToString(),
								
							});
						}
					}
				}
			}



			return profiles;
		}


	}
}

