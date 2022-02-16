using System;
using System.Collections.Generic;
using AutomationUtils.Utils;
using Newtonsoft.Json;

namespace RestSharpHomeWork.DTO
{
    public class ListOfUsersDTO
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }
        
        [JsonProperty("total")]
        public long Total { get; set; }
        
        [JsonProperty("total_page")]
        public long TotalPages { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }
        
        [JsonProperty("support_data")]
        public Support SupportData { get; set; }

        public class Datum
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
        }

        public class Support
        {
            [JsonProperty("uri")]
            public Uri Url { get; set; }
            
            [JsonProperty("text")]
            public string Text { get; set; }
        }

       public override bool Equals(object obj) => this.Equals(obj as ListOfUsersDTO);

       public bool Equals(ListOfUsersDTO obj)
       {
            Verify.AreEqual(this.PerPage, obj.PerPage, "PerPage are not equal");
            return true;
       }
    }
}
