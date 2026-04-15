using NUnit.Framework;

namespace PinterestTests
{
    public class LoginTests : TestBase
    {
        [Test]
        public void Pinterest_Login_Test()
        {
            AccountData user = new AccountData("", "");

            OpenHomePage();
            AcceptCookies();
            ClickLoginButton();
            Login(user);

            Assert.That(IsLoggedIn(), Is.True);
        }
    }
}