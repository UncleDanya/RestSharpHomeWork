using AutomationUtils.Api;
using RestSharp;

namespace RestSharpHomeWork.Appis
{
    public class UserApi : BaseApiMethods
    {
        public RestResponse GetUserInfo()
        {
            RestRequest req = new RestRequest("api/users", Method.Get);
            req.AddHeader("Accept", "application/json");
            req.AddParameter("page", "2");
            req.RequestFormat = DataFormat.Json;
            var responseTask = Client.ExecuteAsync(req);
            var result = responseTask.Result;
            return result;
        }

        public RestResponse CreateUserPost(string name, string job)
        {
            RestRequest req = new RestRequest("/api/users", Method.Post);
            req.AddHeader("Accept", "application/json");
            req.AddParameter("name", name);
            req.AddParameter("job", job);
            var responseTask = Client.ExecuteAsync(req);
            var result = responseTask.Result;
            return result;
        }

        public RestResponse FieldJobChangeUserPut(string change)
        {
            RestRequest req = new RestRequest("/api/users", Method.Put);
            req.AddHeader("Accept", "application/json");
            req.AddParameter("id", "1");
            req.AddParameter("job", change);
            var responseTask = Client.ExecuteAsync(req);
            var result = responseTask.Result;
            return result;
        }

        public RestResponse DeleteUser(string userName)
        {
            RestRequest req = new RestRequest("/api/users", Method.Delete);
            req.AddHeader("Accept", "application/json");
            req.AddParameter("id", "2");
            req.AddParameter("last_name", userName);
            var responseTask = Client.ExecuteAsync(req);
            var result = responseTask.Result;
            return result;
        }

        public RestResponse RegisterUserPost(string email, string password)
        {
            RestRequest req = new RestRequest("/api/register", Method.Post);
            req.AddHeader("Accept", "application/json");
            req.AddParameter("email", email);
            req.AddParameter("password", password);
            var responseTask = Client.ExecuteAsync(req);
            var result = responseTask.Result;
            return result;
        }

        public RestResponse GetSingleUser()
        {
            RestRequest req = new RestRequest("/api/users", Method.Get);
            req.AddHeader("Accept", "application/json");
            req.AddParameter("id", "2");
            var responseTask = Client.ExecuteAsync(req);
            var result = responseTask.Result;
            return result;
        }

        public RestResponse SuccessfulLoginPost(string email, string password)
        {
            RestRequest req = new RestRequest("/api/login", Method.Post);
            req.AddHeader("Accept", "application/json");
            req.AddParameter("email", email);
            req.AddParameter("password", password);
            var responseTask = Client.ExecuteAsync(req);
            var result = responseTask.Result;
            return result;
        }
    }
}