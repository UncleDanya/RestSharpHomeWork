using RestSharp;
using RestSharpHomeWork.Providers;

namespace RestSharpHomeWork.Utils
{
    public class RestWebClient
    {
        public RestWebClient()
        {
            regresApi = new RestClient(UrlProvider.BaseUrl);
        }

        public RestClient regresApi { get; }
    }
}
