using AutomationUtils.Utils;
using Newtonsoft.Json;

namespace RestSharpHomeWork.DTO
{
    public class Support
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        public override bool Equals(object obj) => this.Equals(obj as Support);

        public bool Equals(Support obj)
        {
            Verify.AreEqual(this.Url, obj.Url, "Url not equals");
            Verify.AreEqual(this.Text, obj.Text, "Text not equals");
            return true;
        }
    }
}