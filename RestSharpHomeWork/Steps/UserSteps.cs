using AutomationUtils.Extensions;
using AutomationUtils.Utils;
using Newtonsoft.Json;
using RestSharpHomeWork.Appis;
using RestSharpHomeWork.DTO;
using RestSharpHomeWork.RunTimeVariables;
using RestSharpHomeWork.Utils;
using TechTalk.SpecFlow;

namespace RestSharpHomeWork.Steps
{
    [Binding]
    public class UserSteps : SpecFlowContext
    {
        private readonly RestWebClient client;
        private readonly ListOfUsersDTO listOfUsers;
        private readonly CreateUserDTO createUserDto;
        private readonly RegisterUserDTO registerUserDto;
        private readonly SingleUserDTO singleUserDto;
        private ResponseVariables responseVariables = new ResponseVariables();

        public UserSteps(RestWebClient _client, ListOfUsersDTO _listOfUsers, CreateUserDTO _createUserDto, RegisterUserDTO _registerUserDto, SingleUserDTO _singleUserDto)
        {
            client = _client;
            listOfUsers = _listOfUsers;
            createUserDto = _createUserDto;
            registerUserDto = _registerUserDto;
            singleUserDto = _singleUserDto;
        }

        [When(@"User makes GET user info request")]
        public void WhenUserMakesGetUserInfoRequest()
        {
            var response = client.regresApi.InitApiMethods<UserApi>().GetUserInfo().Content;
            var responseFromGetUsers = JsonConvert.DeserializeObject<ListOfUsersDTO>(response);
            responseFromGetUsers.CopyPropertiesTo(listOfUsers);
        }

        [When(@"User create new user with name '(.*)' and job '(.*)'")]
        public void WhenUserCreateNewUserWithNameAndJob(string name, string job)
        {
            var response = client.regresApi.InitApiMethods<UserApi>().CreateUserPost(name, job).Content;
            JsonConvert.DeserializeObject<CreateUserDTO>(response).CopyPropertiesTo(createUserDto);
        }

        [When(@"User changes the job field value to '(.*)'")]
        public void WhenUserChangesTheJobFieldValueTo(string job)
        {
            var response = client.regresApi.InitApiMethods<UserApi>().FieldJobChangeUserPut(job).Content;
            JsonConvert.DeserializeObject<CreateUserDTO>(response).CopyPropertiesTo(createUserDto);
        }

        [When(@"User makes get request to get user with '(.*)' id")]
        public void WhenUserMakesGetRequestToGetUserWithId(int userId)
        {
            var response = client.regresApi.InitApiMethods<UserApi>().GetSingleUser(userId).Content;
            JsonConvert.DeserializeObject<SingleUserDTO>(response).CopyPropertiesTo(singleUserDto);
        }

        [When(@"User delete name field with value '(.*)' for user with '(.*)' id")]
        public void WhenUserDeleteNameFieldWithValueForUserWithId(string nameUser, int userId)
        {
            responseVariables.Value = client.regresApi.InitApiMethods<UserApi>().DeleteLastNameField(nameUser, userId);
        }

        [When(@"Register new user with email '(.*)' and password '(.*)'")]
        public void WhenRegisterNewUserWithEmailAndPassword(string email, string password)
        {
            var response = client.regresApi.InitApiMethods<UserApi>().PostUserRegistration(email, password).Content;
            JsonConvert.DeserializeObject<RegisterUserDTO>(response).CopyPropertiesTo(registerUserDto);
        }

        [When(@"User enter email '(.*)' and password '(.*)' for login")]
        public void WhenUserEnterEmailAndPasswordForLogin(string email, string password)
        {
            var response = client.regresApi.InitApiMethods<UserApi>().PostLogin(email, password).Content;
            JsonConvert.DeserializeObject<RegisterUserDTO>(response).CopyPropertiesTo(registerUserDto);
        }

        [Then(@"Verify that count of users on the page equals to 'per page' value")]
        public void ThenVerifyThatCountOfUsersOnThePageEqualsToPerPageValue()
        {
            Verify.AreEqual(listOfUsers.PerPage, listOfUsers.Data.Count, "Number of users on the page does not math the actual");
        }

        [Then(@"Verify that new crated user name equals to '(.*)'")]
        public void ThenVerifyThatNewCreateduserNameEqualTo(string nameUser)
        {
            Verify.AreEqual(nameUser, createUserDto.Name, "Expected name is not equal with user name");
        }

        [Then(@"Verify that field value has been change on '(.*)'")]
        public void ThenVerifyThatFieldValueHasBeenChange(string jobValue)
        {
            Verify.AreEqual(jobValue, createUserDto.Job, "Expected job is not equal with job user");
        }

        [Then(@"Verify that value in name field was removed")]
        public void ThenVerifyThatValueInNameFieldWasRemoved()
        {
            Verify.AreEqual("NoContent", responseVariables.Value.StatusCode.ToString(), "Status code is incorrect");
        }

        [Then(@"Verify that new user was registered and got Id '(.*)'")]
        public void ThenVerifyThatNewUserWasRegisteredAndGotId(string id)
        {
            Verify.AreEqual(id, registerUserDto.Id, "User id not received or incorrect");
        }

        [Then(@"Verify that user get correct email '(.*)'")]
        public void ThenVerifyThatUserGetCorrectEmail(string email)
        {
            Verify.AreEqual(email, singleUserDto.Datas.Email, "Expected login is not equal with login user");
        }

        [Then(@"Verify that user get a token '(.*)' after successful registration")]
        public void ThenVerifyThatGetATokenForSuccessRegistration(string token)
        {
            Verify.AreEqual(token, registerUserDto.Token, "User token not received or incorrect");
        }
    }
}
