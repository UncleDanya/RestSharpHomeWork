using AutomationUtils.Utils;
using Newtonsoft.Json;

namespace RestSharpHomeWork.DTO
{
    public class UserData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        public override bool Equals(object obj) => this.Equals(obj as UserData);

        public bool Equals(UserData obj)
        {
            Verify.AreEqual(this.Id, obj.Id, "Name not equals");
            Verify.AreEqual(this.Email, obj.Email, "Job not equals");
            Verify.AreEqual(this.FirstName, obj.FirstName, "First name not equals");
            Verify.AreEqual(this.LastName, obj.LastName, "Last name not equals");
            Verify.AreEqual(this.Avatar, obj.Avatar, "Avatar not equals");
            return true;
        }
    }
}