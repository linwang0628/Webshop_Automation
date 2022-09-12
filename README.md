
# E-Commerce Automation Testing

This project is created to test the E-Commerce website (http://demowebshop.tricentis.com/), using c#, selenium, chrome driver and NUnit testing framework. 

# High risk areas of the application
Those following areas are identified as high-risk areas of the application, which should always be checked/tested before any releases, and those areas should always meet the business requirements.

## Navigation and search function

The search and navigation function should always be functional, user should be able to navigate to each of the pages from the navigation bar, and use the search function to find the items they want. It is very important because if this function is not working, the user might not want to use the application at all.

## Shopping cart function
The shopping cart is vital to the system, user should be able to add any items (in stock) that they would like to purchase, also when the item is added, the user should be able to update the shopping cart, like change the quantities or simply remove the items. It is also vital to the application because it is the prerequisites to make a purchase.

## Account and payment function
If user decided to make a purchase, the most important function for the application would be account management and payment verification, the user should be able to register a new account/ login with existing account. Make a payment to the items they purchased and check the order status afterwards. 

## Performance
The application need to have a baseline for the performance requirements, e.g., maximum request it should be able to handle per minute during peak hours. If the performance does not meet the requirements, there is a high risk that the system will fail during the peak hours, which will result in profit loss because during these times the application generates most of the profit.

## Security and compliance
For an e-commerce website, the security and compliance should always be a high risk area and need to be checked, because the website stores sensitive information such as personal information, bank account details, shopping preference and wish lists etc.


# Testcases for high-risk areas
The following high-risk areas will be covered by the automation test suite:

* Navigation and search function
	The navigation tests include navigating to the homepage of the website and click through all the items within the navigation box, and navigation bar.

	The search function tests include using both search bar on the top right of the webpage, and the advanced search function: including category, sub category, price range and search using description keywords.

* Shopping cart function
	The shopping cart function tests include adding one item to the shopping cart, adding multiple items to the shopping cart, check if the item is associated with other items (cannot be purchased standalone), update items and remove items.

Reasons for automate those testcases:
* User will use those functions frequently
* Those areas should always work before the release and is key part of the web application
* Any issues found during those tests will be a blocker for the release
* Those testcases should be included in the ci/cd pipeline for regression testing

# How to run the test
Two ways to run the test
* Run the test project directly from Visual Studio:
1. Load the project and build it
2. From the test explorer (Test -> Test Explorer), find the TestProject Webshop_Automation
3. Select any tests that intended to run or select all testcases, make sure the Chrome browser version is up to date (105.0.5195.102)
4. Right click the tests and run
5. View test results directly from the test explorer

* Run the test project from CLI:
1. Before running the test in CLI, the project needs to be built and the dll should be generated (Webshop_Automation.dll)
2. In the CLI, switch to the Nuget package nunit.runner installation location `.nuget\packages\nunit.consolerunner\3.15.2\tools`
3. Run the command `nunit3-console.exe "%repolocation%\bin\Debug\net6.0\Webshop_Automation.dll"`
4. The default test result will be a TestResult.XML file located in the nunit package location by default, but it can be changed by adding argument `--output "location\testResultsName.xml"`
