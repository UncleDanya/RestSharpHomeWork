using Newtonsoft.Json;

namespace RestSharpHomeWork.DTO
{
    public class RegisterUserDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
