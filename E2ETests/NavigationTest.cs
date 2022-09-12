using NUnit.Framework;
using Webshop_Automation.TestSetup;

namespace Webshop_Automation.E2ETests
{
    public class NavigationTest : BaseTest
    {
        //navigate to each of the page using navigation box
        [TestCase(TestName = "Navigate using navigation box")]
        public void NavigateToAllCategoriesandSubCategoriesTest()
        {
            OpenHomePage();
            NavigateToCategory("Books");
            Assert.AreEqual(true, findTitleText("h1", "Books"));
            NavigateToCategory("Computers");
            Assert.AreEqual(true, findTitleText("h1", "Computers"));
            NavigateToCategory("Computers", "Desktops");
            Assert.AreEqual(true, findTitleText("h1", "Desktops"));
            NavigateToCategory("Computers", "Notebooks");
            Assert.AreEqual(true, findTitleText("h1", "Notebooks"));
            NavigateToCategory("Computers", "Accessories");
            Assert.AreEqual(true, findTitleText("h1", "Accessories"));
            NavigateToCategory("Electronics");
            Assert.AreEqual(true, findTitleText("h1", "Electronics"));
            NavigateToCategory("Electronics", "Camera, photo");
            Assert.AreEqual(true, findTitleText("h1", "Camera, photo"));
            NavigateToCategory("Electronics", "Cell phones");
            Assert.AreEqual(true, findTitleText("h1", "Cell phones"));
            NavigateToCategory("Apparel & Shoes");
            Assert.AreEqual(true, findTitleText("h1", "Apparel & Shoes"));
            NavigateToCategory("Digital downloads");
            Assert.AreEqual(true, findTitleText("h1", "Digital downloads"));
            NavigateToCategory("Jewelry");
            Assert.AreEqual(true, findTitleText("h1", "Jewelry"));
            NavigateToCategory("Gift Cards");
            Assert.AreEqual(true, findTitleText("h1", "Gift Cards"));
        }

        //navigate to each of the page using navigation bar
        [TestCase(TestName = "Navigate using navigation bar")]
        public void NavigateToAllCategoriesandSubCategoriesUsingNavBarTest()
        {
            OpenHomePage();
            NavigateToCategoryUsingNavBar("Books");
            Assert.AreEqual(true, findTitleText("h1", "Books"));
            NavigateToCategoryUsingNavBar("Computers");
            Assert.AreEqual(true, findTitleText("h1", "Computers"));
            NavigateToCategoryUsingNavBar("Computers", "Desktops");
            Assert.AreEqual(true, findTitleText("h1", "Desktops"));
            NavigateToCategoryUsingNavBar("Computers", "Notebooks");
            Assert.AreEqual(true, findTitleText("h1", "Notebooks"));
            NavigateToCategoryUsingNavBar("Computers", "Accessories");
            Assert.AreEqual(true, findTitleText("h1", "Accessories"));
            NavigateToCategoryUsingNavBar("Electronics");
            Assert.AreEqual(true, findTitleText("h1", "Electronics"));
            NavigateToCategoryUsingNavBar("Electronics", "Camera, photo");
            Assert.AreEqual(true, findTitleText("h1", "Camera, photo"));
            NavigateToCategoryUsingNavBar("Electronics", "Cell phones");
            Assert.AreEqual(true, findTitleText("h1", "Cell phones"));
            NavigateToCategoryUsingNavBar("Apparel & Shoes");
            Assert.AreEqual(true, findTitleText("h1", "Apparel & Shoes"));
            NavigateToCategoryUsingNavBar("Digital downloads");
            Assert.AreEqual(true, findTitleText("h1", "Digital downloads"));
            NavigateToCategoryUsingNavBar("Jewelry");
            Assert.AreEqual(true, findTitleText("h1", "Jewelry"));
            NavigateToCategoryUsingNavBar("Gift Cards");
            Assert.AreEqual(true, findTitleText("h1", "Gift Cards"));
        }

    }
}
