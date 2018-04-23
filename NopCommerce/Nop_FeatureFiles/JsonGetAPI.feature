Feature: JsonGetAPI

@mytag
Scenario: GetDataFromAPI
	Given I have The API URL
	When I do a GET call to the API
	Then I could get the json data from the API