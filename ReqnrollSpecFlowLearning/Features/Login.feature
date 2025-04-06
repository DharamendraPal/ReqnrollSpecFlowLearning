Feature: Login Feature
  In order to perform successful login
  As a User
  I have to enter correct username and password

@staging 
Scenario Outline: Successful login with valid credentials
	Given I have navigated to the login page
	When I enter valid "<username>" and "<password>"
	Then I should be redirected to the dashboard
	Then I should Select City and Country 
	| City   | Country  |
	| Bankok | Thailand |
	| Moscow | Russia   |
	
	Examples: 
		| username | password |
		| Rahul    | sadsfsf  |
		| Raman    | dddfgf   |

