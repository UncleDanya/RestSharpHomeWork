Feature: API tests with RestSharp

Scenario: GET user info
	When User makes GET user info request
	Then Verify that count of users on the page equals to 'per page' value

Scenario: Create new user
	When User create new user with name 'morpheus' and job 'leader'
	Then Verify that new crated user name equals to 'morpheus'

Scenario: Field job change user
	When User changes the job field value to 'Senior Junior Automation DevOps'
	Then Verify that field value has been change on 'Senior Junior Automation DevOps'

Scenario: Delete field user name
	When User delete name field with value 'Weaver' for user with '2' id
	Then Verify that value in name field was removed

Scenario: Register new user
	When Register new user with email 'eve.holt@reqres.in' and password 'pistol'
	Then Verify that new user was registered and got Id '4'

Scenario: Get single user
	When User makes get request to get user with '2' id
	Then Verify that user get correct email 'janet.weaver@reqres.in'

Scenario: Successful login
	When User enter email 'eve.holt@reqres.in' and password 'cityslicka' for login
	Then Verify that user get a token 'QpwL5tke4Pnpja7X4' after successful registration