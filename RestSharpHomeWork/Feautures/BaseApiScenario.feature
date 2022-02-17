Feature: API tests with RestSharp

Scenario: GET user info
	When User makes GET user info request
	Then Verify that number users

Scenario: Create new user
	When User create new user with name 'morpheus' and job 'leader'
	Then Verify that name user 'morpheus' equal

Scenario: Field job change user
	When User changes the job field value 'Senior Junior Automation DevOps'
	Then Verify that field value has been change on 'Senior Junior Automation DevOps'

Scenario: Delete field user name
	When User delete field name 'Weaver' value
	Then Verify that value in field was removed

Scenario: Register new user
	When User new register with email 'eve.holt@reqres.in' and password 'pistol'
	Then Verify that new user registered and got my Id '4'

Scenario: Get single user
	When User get request for single user
	Then Verify that user get correct info about my email 'janet.weaver@reqres.in'

Scenario: Successful login
	When User enter correct email 'eve.holt@reqres.in' and password 'cityslicka' for login
	Then Verify that get a token 'QpwL5tke4Pnpja7X4' for success registration