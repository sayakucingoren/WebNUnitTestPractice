using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebNUnitTestPractice.Pages;

namespace WebNUnitTestPractice
{
    public class LoginTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            this.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void TestGoodLoginDetails()
        {
            new MainPage(this.driver)
                .EnterUsername("standard_user")
                .EnterPassword("secret_sauce")
                .ClickLoginButtonAndTakenToProductList()
                .PageTitleIsShown("Products");
        }

        [Test]
        public void TestGoodLoginDetailsOnSlowPerformance()
        {
            new MainPage(this.driver)
                .EnterUsername("performance_glitch_user")
                .EnterPassword("secret_sauce")
                .ClickLoginButtonAndTakenToProductList()
                .PageTitleIsShown("Products");
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

        [Test]
        public void TestLockedOutUser()
        {
            new MainPage(this.driver)
                .EnterUsername("locked_out_user")
                .EnterPassword("secret_sauce")
                .ClickLoginButton()
                .ErrorMessageIsShown("Epic sadface: Sorry, this user has been locked out.");
        }

        [Test]
        public void TestNonExistentUser()
        {
            new MainPage(this.driver)
                .EnterUsername("x")
                .EnterPassword("x")
                .ClickLoginButton()
                .ErrorMessageIsShown("Epic sadface: Username and password do not match any user in this service");
        }

        [TearDown]
        public void Teardown()
        {
           
            driver.Dispose();
            driver.Quit();
        }

    }
}