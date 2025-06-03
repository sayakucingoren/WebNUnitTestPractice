
using OpenQA.Selenium;

namespace WebNUnitTestPractice.Pages
{
    public class InventoryPage
    {
        private readonly IWebDriver driver;

        public InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
