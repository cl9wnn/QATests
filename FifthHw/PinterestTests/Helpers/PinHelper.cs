using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PinterestTests
{
    public class PinHelper : HelperBase
    {
        public PinHelper(ApplicationManager manager) : base(manager) { }

        public void CreatePin(PinData pin)
        {
            var upload = wait.Until(d => d.FindElement(By.CssSelector("input[type='file']")));
            upload.SendKeys(pin.ImagePath);

            var textareas = wait.Until(d =>
            {
                var els = d.FindElements(By.TagName("textarea"));
                return els.Count >= 2 ? els : null;
            });

            textareas[0].SendKeys(pin.Title);
            textareas[1].SendKeys(pin.Description);

            driver.FindElement(By.XPath("//div[text()='Опубликовать'] | //div[text()='Publish']")).Click();
        }

        public bool IsPinCreated()
        {
            try
            {
                wait.Until(d => d.FindElement(By.XPath("//*[contains(text(),'Опубликовано')]")));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}