
using OpenQA.Selenium;

namespace WebNUnitTestPractice.Pages
{
    public class MainPage
    {
        private readonly IWebDriver driver;
        private readonly By usernameLocator = By.Id("user-name");
        private readonly By passwordLocator = By.Id("password");
        private readonly By loginButtonLocator = By.Id("login-button");
        private readonly By errorMessageLocator = By.CssSelector("h3[data-test='error']");

        public MainPage (IWebDriver driver)
        {
            this.driver = driver;
        }

        public MainPage EnterUsername(string username)
        {
            driver.FindElement(usernameLocator).SendKeys(username);
            return this;
        }

        public MainPage EnterPassword(string password)
        {
            driver.FindElement(passwordLocator).SendKeys(password);
            return this;
        }

        public MainPage ClickLoginButton()
        {
            driver.FindElement(loginButtonLocator).Submit();
            return this;
        }

        public void ErrorMessageIsShown(string expectedErrorMessage)
        {
            Assert.That(driver.FindElement(errorMessageLocator).Text, Is.EqualTo(expectedErrorMessage));
        }

        public InventoryPage ClickLoginButtonAndTakenToProductList()
        {
            driver.FindElement(loginButtonLocator).Submit();
            return new InventoryPage(driver);
        }

    }
}
