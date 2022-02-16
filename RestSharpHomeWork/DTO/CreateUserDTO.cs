using System;
using AutomationUtils.Utils;
using Newtonsoft.Json;

namespace RestSharpHomeWork.DTO
{
    public class CreateUserDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("job")]
        public string Job { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        public override bool Equals(object obj) => this.Equals(obj as CreateUserDTO);

        public bool Equals(CreateUserDTO obj)
        {
            Verify.AreEqual(this.Name, obj.Name, "Name are not equal");
            return true;
        }
    }
}
