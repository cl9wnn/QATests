using NUnit.Framework;

namespace PinterestTests
{
    public class LoginTests : TestBase
    {
        private AccountData user = new AccountData("example@mail.ru", "password");

        [Test]
        public void Login_ValidUser_ShouldBeLoggedIn()
        {
            app.Navigation.OpenHomePage();
            app.Auth.AcceptCookies();
            app.Auth.ClickLoginButton();
            app.Auth.Login(user);

            Assert.That(app.Auth.IsLoggedIn(), Is.True);
        }
    }
}