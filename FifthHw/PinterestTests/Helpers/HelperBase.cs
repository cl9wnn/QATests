using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PinterestTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }
    }
}