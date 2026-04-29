using NUnit.Framework;

namespace PinterestTests
{
    public class LikeTests : TestBase
    {
        private AccountData user = new AccountData("example@mail.ru", "password");

        [Test]
        public void LikePin_ShouldWork()
        {
            app.Navigation.OpenHomePage();
            app.Auth.AcceptCookies();
            app.Auth.ClickLoginButton();
            app.Auth.Login(user);

            Assert.That(app.Auth.IsLoggedIn(), Is.True);

            app.Like.OpenFirstPin();
            app.Like.LikePin();

            Assert.That(app.Like.IsPinLiked(), Is.True);
        }
    }
}