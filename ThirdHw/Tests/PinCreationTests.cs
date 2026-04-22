using NUnit.Framework;

namespace PinterestTests
{
    public class PinCreationTests : TestBase
    {
        private AccountData user = new AccountData("example@mail.ru", "password");

        [Test]
        public void CreatePin_ValidData_ShouldCreatePin()
        {
            var pin = new PinData(
                "Test pin from autotest",
                "Description from autotest",
                @"C:\test.jpg"
            );

            app.Navigation.OpenHomePage();
            app.Auth.AcceptCookies();
            app.Auth.ClickLoginButton();
            app.Auth.Login(user);

            Assert.That(app.Auth.IsLoggedIn(), Is.True);

            app.Navigation.OpenPinCreationPage();
            app.Pin.CreatePin(pin);

            Assert.That(app.Pin.IsPinCreated(), Is.True);
        }
    }
}