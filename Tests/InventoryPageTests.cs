using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebNUnitTestPractice.Pages;

namespace WebNUnitTestPractice.Tests
{
    public class InventoryPageTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void TestProductImagesAreUnique()
        {
            new MainPage(driver)
                .EnterUsername("standard_user") //would fail for problem_user
                .EnterPassword("secret_sauce")
                .ClickLoginButtonAndTakenToProductList()
                .EachProductHasDedicatedImageSource();
        }

        [Test]
        public void TestProductTitleAreNotRightAligned()
        {
            new MainPage(driver)
                .EnterUsername("standard_user") //would fail for visual_user
                .EnterPassword("secret_sauce")
                .ClickLoginButtonAndTakenToProductList()
                .ProductTitlesAreNotRightAligned();
        }


        [TearDown]
        public void Teardown()
        {
           
            driver.Dispose();
            driver.Quit();
        }

    }
}