using AutomationUtils.Utils;
using Newtonsoft.Json;

namespace RestSharpHomeWork.DTO
{
    public class SingleUserDTO
    {
        [JsonProperty("data")]
        public UserData Datas { get; set; }
        
        [JsonProperty("support")]
        public Support Supports { get; set; }

        public override bool Equals(object obj) => this.Equals(obj as SingleUserDTO);

        public bool Equals(SingleUserDTO obj)
        {
            Verify.AreEqual(this.Datas, obj.Datas, "Data not equals");
            Verify.AreEqual(this.Supports, obj.Supports, "Support not equals");
            return true;
        }
    }
}
