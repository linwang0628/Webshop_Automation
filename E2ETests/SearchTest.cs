using NUnit.Framework;
using Webshop_Automation.TestSetup;

namespace Webshop_Automation.E2ETests
{
    public class SearchTest : BaseTest
    {
        //essential dropdown web element ids
        readonly string _categoryDropdownId = "Cid";
        readonly string _manufacutreDropdownId = "Mid";

        //click advanced search checkbox
        public void CheckAdvancedSearch()
        {
            ClickElementbyID("As");
        }

        //click auto search sub category checkbox
        public void CheckAudoSearchSubCategory()
        {
            ClickElementbyID("Isc");
        }

        //click search product description checkbox
        public void CheckSearchProductDescriptions()
        {
            ClickElementbyID("Sid");
        }

        //click search button in the search bar
        public void SearchinSearchBar(string text)
        {
            EnterTextbyID("small-searchterms", text);
            ClickSearchbuttoninSearchBar();
        }

        //enter search text in the search Textbox
        public void SearchinSearchTextbox(string text)
        {
            EnterTextbyID("Q", text);
            ClickSearchbuttoninAdvancedSearch();
        }

        //click search button in the search bar
        public void ClickSearchbuttoninSearchBar()
        {
            ClickElementbyXpath($"//div[@class='search-box']//input[@type='submit']");
        }

        //Click search button in the advanced search
        public void ClickSearchbuttoninAdvancedSearch()
        {
            ClickElementbyXpath($"//div[@class='search-input']//input[@type='submit']");
        }

        //using search bar to top right to search item
        [TestCase(TestName = "Search item using search bar")]
        public void SearchItemUsingSearchBarTest()
        {
            OpenHomePage();
            SearchinSearchBar("empty");
            Assert.AreEqual(true, findTitleText("strong", "No products were found that matched your criteria."));
            SearchinSearchBar("a");
            Assert.AreEqual(true, findTitleText("strong", "Search term minimum length is 3 characters"));
            SearchinSearchBar("");
            DismissAlertWarning();
            SearchinSearchBar("TCP Coaching day");
            Assert.AreEqual(true, findTitleText("a", "TCP Coaching day"));
        }

        //using the advanced search function to search item
        [TestCase(TestName = "Search item using advanced search function")]
        public void SearchItemUsingSearchBarTestExist()
        {
            OpenHomePage();
            SearchinSearchBar("TCP Coaching day");
            CheckAdvancedSearch();
            SelectItemFromDropdown(_categoryDropdownId, "Computers");//test sub category function
            ClickSearchbuttoninAdvancedSearch();
            Assert.AreEqual(true, findTitleText("strong", "No products were found that matched your criteria."));
            SelectItemFromDropdown(_categoryDropdownId, "Computers >> Accessories");//test sub category where the item is in
            ClickSearchbuttoninAdvancedSearch();
            Assert.AreEqual(true, findTitleText("a", "TCP Coaching day"));
            CheckAudoSearchSubCategory();//test the sub category where the item is included
            SelectItemFromDropdown(_categoryDropdownId, "Computers");
            ClickSearchbuttoninAdvancedSearch();
            Assert.AreEqual(true, findTitleText("a", "TCP Coaching day"));
            SelectItemFromDropdown(_manufacutreDropdownId, "Tricentis");//test the manufacture function
            ClickSearchbuttoninAdvancedSearch();
            Assert.AreEqual(true, findTitleText("strong", "No products were found that matched your criteria."));
            SelectItemFromDropdown(_manufacutreDropdownId, "All");//change back to all manufacutres so the item will be shown
            EnterTextbyID("Pf", "1200");//test the price range function
            ClickSearchbuttoninAdvancedSearch();
            Assert.AreEqual(true, findTitleText("strong", "No products were found that matched your criteria."));
            EnterTextbyID("Pf", "20");
            EnterTextbyID("Pt", "999");
            ClickSearchbuttoninAdvancedSearch();
            Assert.AreEqual(true, findTitleText("strong", "No products were found that matched your criteria."));
            EnterTextbyID("Pt", "1200");
            ClickSearchbuttoninAdvancedSearch();
            Assert.AreEqual(true, findTitleText("a", "TCP Coaching day"));
            SearchinSearchTextbox("added to TCP Instructor Led 4 days training");//test the search by description function
            Assert.AreEqual(true, findTitleText("strong", "No products were found that matched your criteria."));
            CheckSearchProductDescriptions();
            ClickSearchbuttoninAdvancedSearch();
            Assert.AreEqual(true, findTitleText("a", "TCP Coaching day"));
            ClickItem("TCP Coaching day");//test the actual navigation to item list page after search completed
            Assert.AreEqual(true, findTitleText("h1", "TCP Coaching day"));
        }


    }
}
