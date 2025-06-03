using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebNUnitTestPractice.Pages;

namespace WebNUnitTestPractice
{
    public class BrowsingTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            this.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void TestEmptyUserNameAndPassword()
        {
            new MainPage(this.driver)
                .EnterUsername("")
                .EnterPassword("")
                .ClickLoginButton()
                .ErrorMessageIsShown("Epic sadface: Username is required");
        }


        [Test]
        public void TestEmptyUserName()
        {
            new MainPage(this.driver)
                .EnterUsername("")
                .EnterPassword("secret_sauce")
                .ClickLoginButton()
                .ErrorMessageIsShown("Epic sadface: Username is required");
        }

        [Test]
        public void TestEmptyPassword()
        {
            new MainPage(this.driver)
                .EnterUsername("standard_user")
                .EnterPassword("")
                .ClickLoginButton()
                .ErrorMessageIsShown("Epic sadface: Password is required");
        }

        [TearDown]
        public void Teardown()
        {
           
            driver.Dispose();
            driver.Quit();
        }

    }
}