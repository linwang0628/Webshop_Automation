using NUnit.Framework;
using Webshop_Automation.TestSetup;

namespace Webshop_Automation.E2ETests
{
    public class SearchTest : BaseTest
    {
        //essential element id for search function
        readonly string _checkboxIdForAdvancedSearch = "As";
        readonly string _checkboxIdForAutoSearchSubCategory = "Isc";
        readonly string _checkboxIdForSearchProductDescriptions = "Sid";
        readonly string _searchBarId = "small-searchterms";
        readonly string _searchTextboxId = "Q";

        //search function actions
        public void CheckAdvancedSearch()
        {
            ClickCheckboxbyID(_checkboxIdForAdvancedSearch);
        }

        public void CheckAudoSearchSubCategory()
        {
            ClickCheckboxbyID(_checkboxIdForAutoSearchSubCategory);
        }

        public void CheckSearchProductDescriptions()
        {
            ClickCheckboxbyID(_checkboxIdForSearchProductDescriptions);
        }

        public void SearchinSearchBar(string text)
        {
            EnterTextbyID(_searchBarId, text);
        }

        public void SearchinSearchTextbox(string text)
        {
            EnterTextbyID(_searchTextboxId, text);
        }

        public void ClickSearchbuttoninSearchBar()
        {
            ClickElementbyXpath($"//div[@class='search-box']//input[@type='submit']");
        }

        public void ClickSearchbuttoninAdvancedSearch()
        {
            ClickElementbyXpath($"//div[@class='search-input']//input[@type='submit']");
        }

        [TestCase(TestName = "Search item using search bar with wrong item name")]
        public void SearchItemUsingSearchBarTest()
        {
            OpenHomePage();
            SearchinSearchBar("empty");
            ClickSearchbuttoninSearchBar();
            Assert.AreEqual(true, findTitleText("strong", "No products were found that matched your criteria."));
        }

    }
}
