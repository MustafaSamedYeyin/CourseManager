using DTOs.Auth;
using System.Net.Http;

namespace Mvc.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        internal async Task<RegisterDto> RegisterAsync(RegisterDto registerDto)
        {
            var response = await _httpClient.PostAsJsonAsync<RegisterDto>("api/Auth/Register", registerDto);
            if (response.IsSuccessStatusCode == true)
            {

                var responseMessage = await response.Content.ReadFromJsonAsync<RegisterDto> ();
                return responseMessage;
            }
            else
            {
                return null;
            }
        } 
        internal async Task<string> LoginAsync(LoginDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync<LoginDto>("api/Auth/Login", loginDto);
            if (response != null)
            {
                var responsMessage = await response.Content.ReadAsStringAsync();
                return responsMessage;
            }
            return string.Empty;
        }
    }
}
