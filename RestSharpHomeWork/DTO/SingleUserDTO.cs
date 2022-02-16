using System;
using AutomationUtils.Utils;
using Newtonsoft.Json;

namespace RestSharpHomeWork.DTO
{
    public class SingleUserDTO
    {
        public Data Data { get; set; }
        public Support Support { get; set; }
    }
    
    public class Data
    {
        [JsonProperty("id")] 
        public long Id { get; set; }

        [JsonProperty("email")] 
        public string Email { get; set; }

        [JsonProperty("first_name")] 
        public string FirstName { get; set; }

        [JsonProperty("last_name")] 
        public string LastName { get; set; }

        [JsonProperty("avatar")] 
        public Uri Avatar { get; set; }

        public override bool Equals(object obj) => this.Equals(obj as SingleUserDTO);

        public bool Equals(SingleUserDTO obj)
        {
            Verify.AreEqual(this, obj.Data.Email, "Email are not equal");
            return true;
        }
    }

    public class Support
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
