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
            //equals two fields above

            return true;
        }
    }
}
