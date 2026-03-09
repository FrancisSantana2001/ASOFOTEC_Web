using ASOFOTEC_Web.DTOs;
using System.Text.Json;

namespace ASOFOTEC_Web.Services
{
    public class PostServiceUser : IPostSeviceUser
    {
        private  HttpClient _httpClient;
        public PostServiceUser(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UsersDto>> GetUsers()
        {
            var result = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var body = await result.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var users = JsonSerializer.Deserialize<IEnumerable<UsersDto>>(body, options);
            return users;
        }
    }
}
