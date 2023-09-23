using EPES.Services.AuthAPI.Models.Dto;
using EPES.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers ;
using System.Text;

namespace EPES.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    
    public class AuthAPIController : Controller
    {
        private readonly IAuthService _authService;
        protected ResponseDto _response;
        private IHttpClientFactory _httpClientFactory;
        private IConfiguration _configuration;

        public AuthAPIController(IAuthService authService, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _authService = authService;
            _response = new();
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        [HttpPost("register")]
       /* [Authorize(Policy = "ManagerOnly")]*/
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {

            var errorMessage = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            //  await _messageBus.PublishMessage(model.Email, _configuration.GetValue<string>("TopicAndQueueNames:RegisterUserQueue"));
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login( LoginRequestDto model)
        {
            string identityApiUrl = _configuration["ServiceUrls:UserMangementAPI"];
            try
            {
                var httpClient = _httpClientFactory.CreateClient();

                var searchResults = new LoginResponseDto();

                // Serialize the requestDTO to JSON
                var requestContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                // Send the POST request with the requestDTO in the request body
                var candidateResponse = await httpClient.PostAsync("https://localhost:7003/login", requestContent);

                if (candidateResponse.IsSuccessStatusCode)
                {
                    candidateResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var responseJson = candidateResponse.Content.ReadAsStringAsync().Result;
                    var candidates = JsonConvert.DeserializeObject<LoginResponseDto>(responseJson);
                    searchResults = candidates;
                }

                return Ok(searchResults);
            }
            catch (Exception ex)
            {
                throw;
            }

        }


       /* [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);

        }*/

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            if (!assignRoleSuccessful)
            {
                _response.IsSuccess = false;
                _response.Message = "Error encountered";
                return BadRequest(_response);
            }
            return Ok(_response);

        }
    }
}
