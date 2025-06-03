
using OpenQA.Selenium;

namespace WebNUnitTestPractice.Pages
{
    public class MainPage
    {
        private readonly IWebDriver driver;
        private readonly By UsernameLocator = By.Id("user-name");
        private readonly By PasswordLocator = By.Id("password");
        private readonly By LoginButtonLocator = By.Id("login-button");
        private readonly By ErrorMessageLocator = By.CssSelector("h3[data-test='error']");

        public MainPage (IWebDriver driver)
        {
            this.driver = driver;
        }

        public MainPage EnterUsername(string username)
        {
            driver.FindElement(UsernameLocator).SendKeys(username);
            return this;
        }

        public MainPage EnterPassword(string password)
        {
            driver.FindElement(PasswordLocator).SendKeys(password);
            return this;
        }

        public MainPage ClickLoginButton()
        {
            driver.FindElement(LoginButtonLocator).Submit();
            return this;
        }

        public void ErrorMessageIsShown(string expectedErrorMessage)
        {
            Assert.That(driver.FindElement(ErrorMessageLocator).Text, Is.EqualTo(expectedErrorMessage));
        }

        public InventoryPage ClickLoginButtonAndRedirectedSuccessfully()
        {
            driver.FindElement(LoginButtonLocator).Submit();
            return new InventoryPage(driver);
        }

    }
}
