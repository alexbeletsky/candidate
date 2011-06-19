using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SharpTestsEx;
using System.Web.Mvc;
using Candidate.Controllers;
using Candidate.Models;

namespace Candidate.Tests.Controllers
{
    [TestFixture]
    public class LoginControllerTests
    {
        [Test]
        public void Index_Get_ReturnsView()
        {
            // arrange
            var controller = new LoginController();

            // act
            var result = controller.Index() as ViewResult;

            // assert
            result.Should().Not.Be.Null();
        }

        [Test]
        public void Login_Post_RedirectToDashboard()
        {
            // arrange
            var controller = new LoginController();
            var model = new LoginModel { Login = "alexander.beletsky", Password = "111111" };

            // act
            var result = controller.Login(model) as RedirectToRouteResult;

            // assert
            result.RouteValues["controller"].Should().Be("Dashboard");
            result.RouteValues["action"].Should().Be("Index");
        }

    }
}
