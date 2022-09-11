using NUnit.Framework;
using Webshop_Automation.TestSetup;


namespace Webshop_Automation.E2ETests
{
    public class ShoppingCartTest : BaseTest
    {
        //add to shopping cart button
        public void AddItemToShoppingCart()
        {
            ClickElementbyXpath("//input[@class='button-1 add-to-cart-button']");
        }

        //click shopping cart button on top right of the page
        public void ClickShoppingCartButton()
        {
            ClickElementbyXpath("//a[@class='ico-cart']");
        }

        //click remove item
        public void ClickRemovebyItemName(string itemName)
        {
            ClickElementbyXpath($"//tr//a[contains(text(),'{itemName}')]/../..//input[@name='removefromcart']");
            ClickUpdateShoppingCartButton();
        }

        //update item quantity
        public void UpdateQuantityforItem(string itemName, int quantity)
        {
            EnterTextbyXpath($"//tr//a[contains(text(),'{itemName}')]/../..//input[@class]", quantity.ToString());
            ClickUpdateShoppingCartButton();
        }

        //click update shopping cart button
        public void ClickUpdateShoppingCartButton()
        {
            ClickElementbyXpath("//input[@name='updatecart']");
        }

        //Shopping cart test
        [TestCase(TestName = "Shopping cart test")]
        public void SearchItemUsingSearchBarTest()
        {
            OpenHomePage();
            navigateToCategory("Computers", "Desktops");
            ClickItem("Build your own cheap computer");//test add item to shopping cart
            AddItemToShoppingCart();
            VerifyShoppingCartCount(1);//verify item added
            navigateToCategory("Computers", "Accessories");
            ClickItem("TCP Coaching day");//test add item with other requirements, should have warning and not added to cart
            AddItemToShoppingCart();
            waitForDelay(500);
            findTitleText("p", "This product requires the following product is added to the cart: TCP Instructor Led Training");
            VerifyShoppingCartCount(1);//verify item not added
            navigateToCategory("Computers", "Accessories");
            ClickItem("TCP Instructor Led Training");
            AddItemToShoppingCart();
            VerifyShoppingCartCount(2);//verify item added
            navigateToCategory("Computers", "Accessories");
            ClickItem("TCP Coaching day");
            AddItemToShoppingCart();
            VerifyShoppingCartCount(3);//verify item added
            ClickShoppingCartButton();//Test shopping cart function
            UpdateQuantityforItem("TCP Coaching day", 5);//update item count
            VerifyItemTotalPrice("TCP Coaching day", "5000.00");
            ClickRemovebyItemName("TCP Instructor Led Training");//remove item and check warning message
            Assert.AreEqual(false, findTitleText("a", "TCP Instructor Led Training"));
            Assert.AreEqual(true, findTitleText("li", "This product requires the following product is added to the cart: TCP Instructor Led Training"));

        }

    }
}
