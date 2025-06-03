using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebNUnitTestPractice.Pages;

namespace WebNUnitTestPractice
{
    public class InventoryPageTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            this.driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void TestProductImagesAreUnique()
        {
            new MainPage(this.driver)
                .EnterUsername("standard_user") //would fail for problem_user
                .EnterPassword("secret_sauce")
                .ClickLoginButtonAndTakenToProductList()
                .EachProductHasDedicatedImageSource();
        }

        [Test]
        public void TestProductTitleAreNotRightAligned()
        {
            new MainPage(this.driver)
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