using System;
using AutomationUtils.Extensions;
using AutomationUtils.Utils;

namespace RestSharpHomeWork.Providers
{
    public class UrlProvider
    {
        public static string BaseUrl
        {
            get
            {
                switch (Config.Read.ByKey("baseUrl"))
                {
                    case "regressApiEnv":
                    {
                        return Config.Read.ByKey("regressApiEnv");
                    }
                    default:
                    {
                        throw new Exception("Unable to get base url");
                    }
                }
                
            }
        }
    }
}
