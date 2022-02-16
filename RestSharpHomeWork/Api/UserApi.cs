using AutomationUtils.Api;
using RestSharp;

namespace RestSharpHomeWork.Appis
{
    public class UserApi : BaseApiMethods
    {
        public RestResponse GetUserInfo()
        {
            RestRequest req = new RestRequest("api/users?page=2", Method.Get);
            req.AddHeader("Accept", "application/json");
            req.RequestFormat = DataFormat.Json;
            var responseTask = Client.ExecuteAsync(req);
            var result = responseTask.Result;
            return result;
        }

        public RestResponse CreateUser(string name, string job)
        {
            RestRequest req = new RestRequest("/api/users", Method.Post);
            req.AddHeader("Accept", "application/json");
            req.AddParameter("name", name);
            req.AddParameter("job", job);
            var responseTask = Client.ExecuteAsync(req);
            var result = responseTask.Result;
            return result;
        }

        public RestResponse FieldJobChangeUser(string change)
        {
            RestRequest req = new RestRequest("/api/users/2", Method.Put);
            req.AddHeader("Accept", "application/json");
            req.AddParameter("job", change);
            var responseTask = Client.ExecuteAsync(req);
            var result = responseTask.Result;
            return result;
        }

        public RestResponse DeleteUser(string userName)
        {
            RestRequest req = new RestRequest("/api/users/2", Method.Delete);
            req.AddHeader("Accept", "application/json");
            req.AddParameter("name", userName);
            var responseTask = Client.ExecuteAsync(req);
            var result = responseTask.Result;
            return result;
        }

        public RestResponse RegisterUser(string email, string password)
        {
            RestRequest req = new RestRequest("/api/register", Method.Post);
            req.AddHeader("Accept", "application/json");
            req.AddParameter("email", email);
            req.AddParameter("password", password);
            var responseTask = Client.ExecuteAsync(req);
            var result = responseTask.Result;
            return result;
        }

        public RestResponse UnsuccessfulLogin(string email)
        {
            RestRequest req = new RestRequest("/api/login", Method.Post);
            req.AddHeader("Accept", "application/json");
            req.AddParameter("email", email);
            var responseTask = Client.ExecuteAsync(req);
            var result = responseTask.Result;
            return result;
        }

        public RestResponse GetSingleUser()
        {
            RestRequest req = new RestRequest("/api/users/2", Method.Get);
            req.AddHeader("Accept", "application/json");
            var responseTask = Client.ExecuteAsync(req);
            var result = responseTask.Result;
            return result;
        }

        public RestResponse RegisterUnsuccessful(string email)
        {
            RestRequest req = new RestRequest("/api/register", Method.Post);
            req.AddHeader("Accept", "application/json");
            req.AddParameter("email", email);
            var responseTask = Client.ExecuteAsync(req);
            var result = responseTask.Result;
            return result;
        }

        public RestResponse SuccessfulLogin(string email, string password)
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