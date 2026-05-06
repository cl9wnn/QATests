using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PinterestTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void AcceptCookies()
        {
            try
            {
                var btn = wait.Until(d =>
                {
                    try
                    {
                        var el = d.FindElement(By.XPath("//div[text()='Принять все']"));
                        return el.Displayed ? el : null;
                    }
                    catch { return null; }
                });

                btn?.Click();
            }
            catch { }
        }

        public void ClickLoginButton()
        {
            var btn = wait.Until(d => d.FindElement(By.XPath("//div[text()='Войти']")));
            btn.Click();
        }

        public void Login(AccountData account)
        {
            driver.FindElement(By.Name("id")).SendKeys(account.Email);
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        }

        public bool IsLoggedIn()
        {
            try
            {
                return driver.FindElement(By.CssSelector("div[data-test-id='gestalt-avatar-svg']")).Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}