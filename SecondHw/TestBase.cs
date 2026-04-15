using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PinterestTests
{
    public class TestBase : IDisposable
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        public void Dispose()
        {
            driver?.Quit();
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl("https://www.pinterest.com/");
        }

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
                    catch
                    {
                        return null;
                    }
                });

                btn?.Click();
            }
            catch (WebDriverTimeoutException) { }
        }

        public void ClickLoginButton()
        {
            var btn = wait.Until(d =>
            {
                try
                {
                    var el = d.FindElement(By.XPath("//div[text()='Войти']"));
                    return el.Displayed ? el : null;
                }
                catch
                {
                    return null;
                }
            });

            btn.Click();
        }

        public void Login(AccountData account)
        {
            var emailInput = wait.Until(d => d.FindElement(By.Name("id")));
            emailInput.SendKeys(account.Email);

            var passwordInput = wait.Until(d => d.FindElement(By.Name("password")));
            passwordInput.SendKeys(account.Password);

            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        }

        public bool IsLoggedIn()
        {
            var profileButton = wait.Until(d =>
            {
                try
                {
                    var el = d.FindElement(By.CssSelector("div[data-test-id='gestalt-avatar-svg']"));
                    return el.Displayed ? el : null;
                }
                catch
                {
                    return null;
                }
            });

            return profileButton.Displayed;
        }
    }
}