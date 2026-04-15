using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PinterestTests
{
    public class LoginTests : IDisposable
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void TheUntitledTest()
        {
            driver.Navigate().GoToUrl("https://www.pinterest.com/");
            
            // Принимаем cookies
            try { driver.FindElement(By.XPath("//div[text()='Принять все']")).Click(); } catch { }
            
            // Клик по кнопке "Войти
            driver.FindElement(By.XPath("//div[text()='Войти']")).Click();
            
            // Ждём появления формы и вводим email
            wait.Until(d => d.FindElement(By.CssSelector("input[type='email']")));
            driver.FindElement(By.CssSelector("input[type='email']")).Clear();
            driver.FindElement(By.CssSelector("input[type='email']")).SendKeys("example@mail.ru");
            
            // Вводим пароль
            driver.FindElement(By.CssSelector("input[type='password']")).Clear();
            driver.FindElement(By.CssSelector("input[type='password']")).SendKeys("test");
            
            // Отправка формы
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            
            // Проверка успешного входа - ждём появления аватарки
            var profileButton = wait.Until(d => d.FindElement(By.CssSelector("div[data-test-id='gestalt-avatar-svg']")));
            
            // Проверка, что кнопка профиля видна
            Assert.That(profileButton.Displayed, Is.True);
        }

        public void Dispose()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}