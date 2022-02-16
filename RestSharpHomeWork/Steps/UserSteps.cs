using System;
using System.Linq;
using AutomationUtils.Extensions;
using AutomationUtils.Utils;
using Newtonsoft.Json;
using OpenQA.Selenium.DevTools;
using RestSharpHomeWork.Appis;
using RestSharpHomeWork.DTO;
using RestSharpHomeWork.Utils;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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
            var response = client.regresApi.InitApiMethods<UserApi>().CreateUser(name, job).Content;
            JsonConvert.DeserializeObject<CreateUserDTO>(response).CopyPropertiesTo(createUserDto);
        }

        [When(@"User changes the job field value '(.*)'")]
        public void WhenUserChangesTheJobFieldValue(string job)
        {
            var response = client.regresApi.InitApiMethods<UserApi>().FieldJobChangeUser(job).Content;
            JsonConvert.DeserializeObject<CreateUserDTO>(response).CopyPropertiesTo(createUserDto);
        }

        [When(@"User delete field name '(.*)' value")]
        public void WhenUserDeleteFieldNameValue(string nameUser)
        {
            var response = client.regresApi.InitApiMethods<UserApi>().DeleteUser(nameUser).Content;
            JsonConvert.DeserializeObject<CreateUserDTO>(response).CopyPropertiesTo(createUserDto);
        }

        [When(@"User new register with email '(.*)' and password '(.*)'")]
        public void WhenUserNewRegisterWithEmail(string email, string password)
        {
            var response = client.regresApi.InitApiMethods<UserApi>().RegisterUser(email, password).Content;
            JsonConvert.DeserializeObject<RegisterUserDTO>(response).CopyPropertiesTo(registerUserDto);
        }

        [When(@"User enter wrong email '(.*)'")]
        public void WhenUserEnterWrongEmail(string email)
        {
            var response = client.regresApi.InitApiMethods<UserApi>().RegisterUnsuccessful(email).Content;
            JsonConvert.DeserializeObject<RegisterUserDTO>(response).CopyPropertiesTo(registerUserDto);
        }

        [When(@"User get request for single user")]
        public void WhenUserGetRequestForSingleUser()
        {
            var response = client.regresApi.InitApiMethods<UserApi>().GetSingleUser().Content;
            JsonConvert.DeserializeObject<SingleUserDTO>(response).CopyPropertiesTo(singleUserDto);
        }

        [When(@"User enter incorrect email '(.*)' field for login")]
        public void WhenUserEnterWrongValueInEmailField(string wrongEmail)
        {
            var response = client.regresApi.InitApiMethods<UserApi>().UnsuccessfulLogin(wrongEmail).Content;
            JsonConvert.DeserializeObject<RegisterUserDTO>(response).CopyPropertiesTo(registerUserDto);
        }

        [When(@"User enter correct email '(.*)' and password '(.*)' for login")]
        public void WhenUserEnterCorrectEmail(string email, string password)
        {
            var response = client.regresApi.InitApiMethods<UserApi>().SuccessfulLogin(email, password).Content;
            JsonConvert.DeserializeObject<RegisterUserDTO>(response).CopyPropertiesTo(registerUserDto);
        }


        [When(@"Test step for work with tables")]
        public void WhenTestStepForWorkWithTables(Table table)
        {
            var imports = table.CreateSet<DataImportDTO>();

            if (imports == null || !imports.Any())
            {
                throw new Exception("Data imports table is not set");
            }

            foreach (var import in imports)
            {
                var a =  client.regresApi.InitApiMethods<UserApi>().CreateUser(import.Zlp, import.NotZlp).Content;
                JsonConvert.DeserializeObject<CreateUserDTO>(a).CopyPropertiesTo(createUserDto);
            }

            Verify.AreEqual("contentForZlpColumn", createUserDto.Name, "");
            /*var t1 = table.Header;
            var t2 = table.Rows[0];
            var t3 = t2["zlp"];
            var t4 = table.CreateInstance<ListOfUsersDTO>();*/
        }
        
        [Then(@"Verify that number users")]
        public void ThenVerifyThat()
        {
            Verify.AreEqual(listOfUsers.PerPage, listOfUsers.Data.Count, "Number of users on the page does not math the actual");
        }

        [Then(@"Verify that name user equal")]
        public void ThenVerifyThatNameUserEqual()
        {
            Verify.AreEqual("morpheus", createUserDto.Name, "Expected name is not equal with user name");
        }

        [Then(@"Verify that field value has been change")]
        public void ThenVerifyThatFieldValueHasBeenChange()
        {
            Verify.AreEqual("Senior Junior Automation DevOps", createUserDto.Job, "Expected job is not equal with job user");
        }

        [Then(@"Verify that value in field was removed")]
        public void ThenVerifyThatValueInFieldWasRemoved()
        {
            Verify.AreEqual(string.Empty, createUserDto.Name, "Value in field is not removed");
        }

        [Then(@"Verify that new user registered")]
        public void ThenVerifyThatNewUserRegistered()
        {
            Verify.AreEqual(4, registerUserDto.Id, "User id not received or incorrect");
        }

        [Then(@"Verify that user take a error")]
        public void ThenVerifyThatUserTakeAError()
        {
            Verify.AreEqual("Missing password", registerUserDto.Error, "Error is incorrect or user entered correct email");
        }

        [Then(@"Verify that user get correct info")]
        public void ThenVerifyThatUserGetCorrectInfo()
        {
            Verify.AreEqual("janet.weaver@reqres.in", singleUserDto.Data.Email, "Expected login is not equal with login user");
        }

        [Then(@"Verify that user get error")]
        public void ThenVerifyThatUserGetError()
        {
            Verify.AreEqual("Missing password", registerUserDto.Error, "Error is incorrect or user entered correct login");
        }

        [Then(@"Verify that get a token for success registration")]
        public void ThenVerifyThatGetATokenForSuccessRegistration()
        {
            Verify.AreEqual("QpwL5tke4Pnpja7X4", registerUserDto.Token, "User token not received or incorrect");
        }
    }
}
