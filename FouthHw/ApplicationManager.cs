using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PinterestTests
{
    public class ApplicationManager
    {
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private IWebDriver driver;

        private NavigationHelper navigation;
        private LoginHelper auth;
        private PinHelper pin;
        private LikeHelper like;

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            navigation = new NavigationHelper(this);
            auth = new LoginHelper(this);
            pin = new PinHelper(this);
            like = new LikeHelper(this);
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigation.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver => driver;
        public NavigationHelper Navigation => navigation;
        public LoginHelper Auth => auth;
        public PinHelper Pin => pin;
        public LikeHelper Like => like;

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch { }
        }
    }
}