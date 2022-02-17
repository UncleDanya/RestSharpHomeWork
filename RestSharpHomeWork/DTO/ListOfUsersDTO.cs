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
        public int Total { get; set; }

        [JsonProperty("total_page")]
        public int TotalPages { get; set; }

        [JsonProperty("data")]
        public List<UserData> Data { get; set; }

        [JsonProperty("support_data")]
        public Support SupportData { get; set; }

        public override bool Equals(object obj) => this.Equals(obj as ListOfUsersDTO);

        public bool Equals(ListOfUsersDTO obj)
        {
            Verify.AreEqual(this.PerPage, obj.PerPage, "PerPage not equals");
            Verify.AreEqual(this.Page, obj.Page, "Page not equals");
            Verify.AreEqual(this.Total, obj.Total, "Total not equals");
            Verify.AreEqual(this.TotalPages, obj.TotalPages, "TotalPage not equals");
            return true;
        }
    }
}
