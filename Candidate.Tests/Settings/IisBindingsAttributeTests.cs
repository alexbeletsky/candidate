using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Settings.Validation;
using Machine.Specifications;
using NUnit.Framework;

namespace Candidate.Tests.Settings
{

    //public class when_binding_is_correct {
    //    Establish context = () => {
    //        Validator = new IisBindingsAttribute();
    //    };

    //    It should_return_true_for_correct_binding = () => Validator.IsValid("http:*:90:candidate.net").ShouldBeTrue();
    //    It should_be_false_if_protocol_missing = () => Validator.IsValid(":*:90:candidate.net").ShouldBeFalse();

    //    private static bool result;
    //    public static IisBindingsAttribute Validator { get; set; }
    //}

    //public class BingingValidatorTests {

    //    [TestCase(":*:90:candidate.net", Result=false)]
    //    [TestCase(":*:90:candidate.net", Result=true)]
    //    public bool Test(string binding) {
    //        return new IisBindingsAttribute().IsValid(binding);
    //    }
    //}

    //[TestFixture]
    //public class IisBindingsAttributeTests {
    //    [Test]
    //    public void Is_Valid_For_Correct_Simple_Input() {
    //        // arrange
    //        var validator = new IisBindingsAttribute();

    //        // act
    //        var result = validator.IsValid("http:*:90:candidate.net");

    //        // assert 
    //        Assert.That(result, Is.True);
    //    }

    //    [Test]
    //    public void Not_Valid_If_Protocol_Is_Missing() {
    //        // arrange
    //        var validator = new IisBindingsAttribute();

    //        // act
    //        var result = validator.IsValid("*:90:candidate.net");

    //        // assert 
    //        Assert.That(result, Is.False);
    //    }

    //    [Test]
    //    public void Ip_Address_Could_Be_Set_In_Usuall_Format() {
    //        // arrange
    //        var validator = new IisBindingsAttribute();

    //        // act
    //        var result = validator.IsValid("http:127.0.0.1:90:candidate.net");

    //        // assert 
    //        Assert.That(result, Is.True);
    //    }

    //    [Test]
    //    public void Ip_Address_Could_Be_Defined_As_Asterix() {
    //        // arrange
    //        var validator = new IisBindingsAttribute();

    //        // act
    //        var result = validator.IsValid("http:*:90:candidate.net");

    //        // assert 
    //        Assert.That(result, Is.True);
    //    }

    //    [Test]
    //    public void Ftp_Is_Allowed_Protocol() {
    //        // arrange
    //        var validator = new IisBindingsAttribute();

    //        // act
    //        var result = validator.IsValid("ftp:*:90:candidate.net");

    //        // assert 
    //        Assert.That(result, Is.True);
    //    }

    //    [Test]
    //    public void Port_Is_Mandatory_Field() {
    //        // arrange
    //        var validator = new IisBindingsAttribute();

    //        // act
    //        var result = validator.IsValid("http:*::can.net");

    //        // assert 
    //        Assert.That(result, Is.False);
    //    }
    //}
}
