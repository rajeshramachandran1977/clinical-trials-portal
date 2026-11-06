using Anju.Navigate.UI.Controllers;
using Anju.Navigate.UI.Tests.Helper;
using Anju.Navigate.Utilities.Logger;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Moq;
using NUnit.Framework;

namespace Anju.Navigate.UI.Tests
{
    [TestFixture]
    public class LoginControllerTests
    {
        private LoginController sut;
        private Mock<IAppLogger<LoginController>> mockAppLogger;
        private Mock<IStringLocalizer<LoginController>> mockStringLocalizer;

        [SetUp]
        public void Setup()
        {
            mockAppLogger = new Mock<IAppLogger<LoginController>>();
            mockStringLocalizer = new Mock<IStringLocalizer<LoginController>>();
            sut = new LoginController(mockAppLogger.Object);
        }

        [Test]
        public void Test_Login_Action_Returns_Login_View()
        {
            //Arrange
            var localizedString = new LocalizedString("UserName", "some message from login");
            mockStringLocalizer.Setup(lm => lm["UserName"]).Returns(localizedString);

            //Act
            var result = sut.Login();

            //Assert
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public void Test_ForgetPassword_Action_Returns_ForgetPassword_View()
        {
            //Act
            var result = sut.ForgotPasswordPage();

            //Assert
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public void Test_ForgotPasswordPage_Action_Returns_ForgotPasswordPage_View()
        {
            //Act
            var result = sut.ForgotPasswordPage();

            //Assert
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public void Test_Dashboard_Action_Returns_Dashboard_View()
        {
            //Act
            //var result = sut.Dashboard();

            //Assert
            //Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public void Test_ChangePasswordPartial_Action_Returns_ChangePasswordPartial_PartialView()
        {
            //Act
            var result = sut.ChangePasswordPartial();

            //Assert
            Assert.That(result, Is.TypeOf<PartialViewResult>());
        }

        [Test]
        public void Test_ResetPassword_Action_Returns_ResetPassword_PartialView()
        {
            //Arrange
            var mockHttpContext = new Mock<HttpContext>();
            var mockSession = new MockHttpSession { ["sessionname"] = "session" };
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            var controller = new LoginController(mockAppLogger.Object)
            {
                ControllerContext = { HttpContext = mockHttpContext.Object }
            };

            //Act
            // var result = controller.ResetPassword("demouser");
            var result = controller.ResetPassword();

            //Assert
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public void Test_GetAdminEmail_Returns_EmailAddress()
        {
            var result = sut.GetAdminEmail() as ObjectResult;
            var source = (result.Value as DataSourceResult).Data;
            Assert.That(((string[])source)[0], Is.Not.EqualTo(string.Empty));
        }
    }
}