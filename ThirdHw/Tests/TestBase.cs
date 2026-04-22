using NUnit.Framework;

namespace PinterestTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        protected AccountData DefaultUser = new AccountData("example@mail.ru", "password");

        [SetUp]
        public void SetUp()
        {
            app = new ApplicationManager();
        }

        [TearDown]
        public void TearDown()
        {
            app.Stop();
        }
    }
}