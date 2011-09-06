using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Candidate.Infrustructure.Filters;
using Candidate.Core.Services;
using System.Web.Mvc;
using Moq;
using System.Dynamic;

namespace Candidate.Tests.Filters {
    [TestFixture]
    public class AddViewNameAndHashAttributeTests {

        [SetUp]
        public void Setup() {
            Filter = new AddViewNameAndHashAttribute();
            HashService = new HashService();
            Filter.HashServices = HashService;

            FilterContext = new ActionExecutingContext();
            FilterContext.ActionParameters = new Dictionary<string, object> { 
                { "jobName", "myCurrentJob" }
            };

            FilterContext.Controller = new Mock<ControllerBase>().Object;
        }

        [Test]
        public void Filter_Adds_ViewName_Into_Bag() {
            // act
            Filter.OnActionExecuting(FilterContext);

            // assert 
            Assert.That(FilterContext.Controller.ViewBag.JobName, Is.EqualTo("myCurrentJob"));
        }

        [Test]
        public void Filter_Adds_ViewName_Hash_Into_Bag() {
            // act
            Filter.OnActionExecuting(FilterContext);

            // assert 
            var expected = HashService.CreateMD5Hash("myCurrentJob");
            Assert.That(FilterContext.Controller.ViewBag.JobNameHash, Is.EqualTo(expected));
        }

        protected AddViewNameAndHashAttribute Filter { get; set; }

        protected ActionExecutingContext FilterContext { get; set; }

        protected HashService HashService { get; set; }
    }
}
