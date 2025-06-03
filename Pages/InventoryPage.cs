
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebNUnitTestPractice.Pages
{
    public class InventoryPage
    {
        private readonly IWebDriver driver;
        private readonly By titleLocator = By.ClassName("inventory_list");
        private readonly By productTitleLocator = By.ClassName("inventory_item_name");
        private readonly By imageLocator = By.CssSelector("img[class='inventory_item_img']");


        public InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void PageTitleIsShown(string expectedPageTitle)
        {
            Assert.That(driver.FindElement(titleLocator).Displayed);
        }

        public void EachProductHasDedicatedImageSource()
        {
            IList<IWebElement> images = driver.FindElements(imageLocator);
            HashSet<string> uniqueListOfImageSources = new HashSet<string>();
            foreach (var image in images)
            {
                string imageSource = image.GetAttribute("src");
                uniqueListOfImageSources.Add(imageSource);
            }
            Assert.That(uniqueListOfImageSources.Count, Is.EqualTo(images.Count));
        }

        public void ProductTitlesAreNotRightAligned()
        {
            IList<IWebElement> titles = driver.FindElements(productTitleLocator);

            var rightAlignedTitles = titles
                .Where(title => title.GetCssValue("text-align").ToLower() == "right")
                .ToList();

            Assert.IsEmpty(rightAlignedTitles,
                $"Found {rightAlignedTitles.Count} right-aligned product titles.");
        }
    }
}
