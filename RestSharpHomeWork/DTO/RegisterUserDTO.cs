using AutomationUtils.Utils;
using Newtonsoft.Json;

namespace RestSharpHomeWork.DTO
{
    public class RegisterUserDTO
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        public override bool Equals(object obj) => this.Equals(obj as RegisterUserDTO);

        public bool Equals(RegisterUserDTO obj)
        {
            Verify.AreEqual(this.Id, obj.Id, "Name not equals");
            Verify.AreEqual(this.Token, obj.Token, "Token not equals");
            Verify.AreEqual(this.Error, obj.Error, "Error not equals");
            return true;
        }
    }
}
