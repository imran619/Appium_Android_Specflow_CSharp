Feature: EriBankLogin

@mytag
@mytag
Scenario: EriBank Login
Given I launch the EriBank app
When I enter the username 
And I enter the password
And click on login button
Then I am logged into the EriBank app successfully