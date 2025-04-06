Feature: Login Production Feature
  In order to perform successful login on Production
  As a User
  I have to enter correct username and password
@prod
Scenario: Login to the production website
	Given user navigates to the facebook website
	When user validates the homepage title
	Then user enters valid username
	Then user enters valid password
	Then user clicks on the signin button
