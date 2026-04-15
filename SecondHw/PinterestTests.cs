using NUnit.Framework;

namespace PinterestTests
{
     public class PinterestTests : TestBase
    {
        private AccountData user = new AccountData("example@mail.ru", "password");

        [Test]
        public void Pinterest_Login_Test()
        {
            OpenHomePage();
            AcceptCookies();
            ClickLoginButton();
            Login(user);

            Assert.That(IsLoggedIn(), Is.True);
        }

        [Test]
        public void Pinterest_Create_Pin_Test()
        {
            var pin = new PinData(
                "Test pin from autotest",
                "Description from autotest",
                @"C:\test.jpg"
            );

            OpenHomePage();
            AcceptCookies();
            ClickLoginButton();
            Login(user);

            Assert.That(IsLoggedIn(), Is.True);

            OpenPinCreationPage();
            CreatePin(pin);

            Assert.That(IsPinCreated(), Is.True);
        }
    }
}