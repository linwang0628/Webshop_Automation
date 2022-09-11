using NUnit.Framework;
using Webshop_Automation.TestSetup;

namespace Webshop_Automation.E2ETests
{
    public class NavigationTest : BaseTest
    {
        //navigate to each of the page using navigation box
        [TestCase(TestName = "Navigate to all categories and sub categories")]
        public void NavigateToAllCategoriesandSubCategoriesTest()
        {
            OpenHomePage();
            navigateToCategory("Books");
            Assert.AreEqual(true, findTitleText("h1", "Books"));
            navigateToCategory("Computers");
            Assert.AreEqual(true, findTitleText("h1", "Computers"));
            navigateToCategory("Computers", "Desktops");
            Assert.AreEqual(true, findTitleText("h1", "Desktops"));
            navigateToCategory("Computers", "Notebooks");
            Assert.AreEqual(true, findTitleText("h1", "Notebooks"));
            navigateToCategory("Computers", "Accessories");
            Assert.AreEqual(true, findTitleText("h1", "Accessories"));
            navigateToCategory("Electronics");
            Assert.AreEqual(true, findTitleText("h1", "Electronics"));
            navigateToCategory("Electronics", "Camera, photo");
            Assert.AreEqual(true, findTitleText("h1", "Camera, photo"));
            navigateToCategory("Electronics", "Cell phones");
            Assert.AreEqual(true, findTitleText("h1", "Cell phones"));
            navigateToCategory("Apparel & Shoes");
            Assert.AreEqual(true, findTitleText("h1", "Apparel & Shoes"));
            navigateToCategory("Digital downloads");
            Assert.AreEqual(true, findTitleText("h1", "Digital downloads"));
            navigateToCategory("Jewelry");
            Assert.AreEqual(true, findTitleText("h1", "Jewelry"));
            navigateToCategory("Gift Cards");
            Assert.AreEqual(true, findTitleText("h1", "Gift Cards"));
        }

    }
}
