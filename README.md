# WebNUnitTestPractice

Automated UI tests using **Selenium WebDriver** and **NUnit** in **C#**, built around scenarios from [saucedemo.com](https://www.saucedemo.com/).  
A personal refresher project for hands-on testing practice.  
Project is incrementally updated. 

## Project Structure
<pre><code>WebNUnitTestPractice/
├── Tests/
│   ├── LoginTests.cs
│   ├── InventoryPageTests.cs
├── Pages/
│   ├── InventoryPage.cs
│   ├── MainPage.cs
├── WebNUnitTestPractice.sln
└── README.md</code></pre>

## Prerequisites
Visual Studio 2022  
.net 8.0

## Running Tests
You can run the tests using the Test Explorer in Visual Studio.

## Test Scenarios
**LoginTests.cs**: Validates login scenarios.  
**InventoryPageTests.cs**: Validates the page after login, including visual check.
