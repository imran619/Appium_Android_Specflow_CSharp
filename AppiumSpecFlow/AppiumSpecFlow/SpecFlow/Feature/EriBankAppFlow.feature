Feature: EriBankAppFlow

@mytag
@mytag
Scenario: EriBankAppTest
Given I have launched the Eribank app
When I logged into the EriBank app with valid username and password
Then I view the balance
When I click on the Make Payment button
Then I am navigated to the Make Payment screen
When I enter all the details and click on Send Payment button
Then I am navigated to the balance screen
When I click on the Logout button
Then I am navigated to the login screen
   
