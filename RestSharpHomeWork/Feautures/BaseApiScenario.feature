Feature: API tests with RestSharp

Scenario: GET user info
	When User makes GET user info request
	Then Verify that

Scenario: Create new user
	When User create new user with name 'morpheus' and job 'leader'
	Then Verify that name user equal

Scenario: Field job change user
	When User changes the job field value 'Senior Junior Automation DevOps'
	Then Verify that field value has been change

Scenario: Delete field user name
	When User delete field name 'morpheus' value
	Then Verify that value in field was removed

Scenario: Register new user
	When User new register with email 'eve.holt@reqres.in' and password 'pistol'
	Then Verify that new user registered

Scenario: Unsuccessful register
	When User enter wrong email 'sydney@fife'
	Then Verify that user take a error

Scenario: Get single user
	When User get request for single user
	Then Verify that user get correct info

Scenario: Unsuccessful login
	When User enter incorrect email 'peter@klaven' field for login
	Then Verify that user get error

Scenario: Successful login
	When User enter correct email 'eve.holt@reqres.in' and password 'cityslicka' for login
	Then Verify that get a token for success registration

Scenario: WorkWithTablesTest
	When Test step for work with tables
		| zlp                 | notZlp                 | somethingElse        |
		| contentForZlpColumn | contentForNotZlpColumn | somethingElseContent |