Feature: EriBankAppFeature

@mytag
@mytag
Scenario: EriBankAppTest
Given I have launched the Eribank mobile app
When I logged into the EriBank mobile app with valid username and password
Then I view the balance
When I click on the Make Payment button for payment
Then I am navigated to the Make Payment screen
When I enter all the details for payment and click on Send Payment button
Then I am navigated to the balance screen
When I click on the Logout button on app
Then I am navigated back to the login screen