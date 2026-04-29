using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PinterestTests
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager manager) : base(manager) { }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl("https://www.pinterest.com/");
        }

        public void OpenPinCreationPage()
        {
            driver.Navigate().GoToUrl("https://se.pinterest.com/pin-creation-tool/");
        }
    }
}
