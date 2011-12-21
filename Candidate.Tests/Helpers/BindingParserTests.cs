using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Helpers;
using NUnit.Framework;
using SharpTestsEx;

namespace Candidate.Tests.Helpers
{
    [TestFixture]
    public class BindingParserTests
    {
        [SetUp]
        public void Setup()
        {
            Parser = new BindingParser();
        }

        [Test]
        public void parser_should_get_protocol()
        {
            // act
            var result = Parser.Parse("http:*:80:www.candidate.net");

            // assert
            result.First().Protocol.Should().Be("http");
        }

        [Test]
        public void parser_should_get_information()
        {
            // act
            var result = Parser.Parse("http:*:80:www.candidate.net");

            // assert
            result.First().Information.Should().Be("*:80:www.candidate.net");
        }

        [Test]
        public void parser_should_get_ip_address()
        {
            // act
            var result = Parser.Parse("http:*:80:www.candidate.net");

            // assert
            result.First().Ip.Should().Be("*");
        }

        [Test]
        public void parser_should_get_site_name()
        {
            // act
            var result = Parser.Parse("http:*:80:www.candidate.net");

            // assert
            result.First().SiteName.Should().Be("www.candidate.net");
        }

        [Test]
        public void parser_should_get_port()
        {
            // act
            var result = Parser.Parse("http:*:80:www.candidate.net");

            // assert
            result.First().Port.Should().Be("80");
        }

        [Test]
        public void parse_should_parse_multiple_bingings()
        {
            // act
            var result = Parser.Parse("http:*:80:www.candidate.net;http:*:80:candidate.net");

            // assert
            var x = result.Skip(1).Take(1).First();
            x.Protocol.Should().Be("http");
            x.Ip.Should().Be("*");
            x.SiteName.Should().Be("candidate.net");
            x.Port.Should().Be("80");
        }

        public BindingParser Parser { get; set; }
    }
}
