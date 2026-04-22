using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PinterestTests
{
    public class ApplicationManager
    {
        private IWebDriver driver;

        private NavigationHelper navigation;
        private LoginHelper auth;
        private PinHelper pin;

        public ApplicationManager()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            navigation = new NavigationHelper(this);
            auth = new LoginHelper(this);
            pin = new PinHelper(this);
        }

        public IWebDriver Driver => driver;
        public NavigationHelper Navigation => navigation;
        public LoginHelper Auth => auth;
        public PinHelper Pin => pin;

        public void Stop()
        {
            driver.Quit();
        }
    }
}