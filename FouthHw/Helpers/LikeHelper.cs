using OpenQA.Selenium;

namespace PinterestTests
{
    public class LikeHelper : HelperBase
    {
        public LikeHelper(ApplicationManager manager) : base(manager) { }

        public void OpenFirstPin()
        {
            var pin = wait.Until(d => d.FindElement(By.CssSelector("div[data-test-id='pin']")));
            pin.Click();
        }

        public void LikePin()
        {
            var likeButton = wait.Until(d =>
                d.FindElement(By.CssSelector("button[aria-label='Like']")));
            likeButton.Click();
        }

        public bool IsPinLiked()
        {
            try
            {
                return driver.FindElement(By.CssSelector("button[aria-pressed='true']")).Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}