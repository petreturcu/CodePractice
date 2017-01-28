using System;

using FluentAssertions;

using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class StringInterning
    {
        [Test]
        public void StringInterning_WhenConstantLiterals_ShouldHaveSameReference()
        {
            // Arrange
            var s1 = "This is a string";
            var s2 = "This is a string";

            // Act
            var isSameReference = Object.ReferenceEquals(s1, s2);

            // Assert
            isSameReference.Should().BeTrue("because .NET string interning");
        }

        [Test]
        public void StringInterning_WhenRuntimeLiterals_ShouldHaveDifferentReference()
        {
            // Arrange
            var s1 = "This is a";
            var s2 = " string";
            var s3 = "This is a string";

            // Act
            var isSameReference = Object.ReferenceEquals(s1 + s2, s3);
            var areStringsEqual = s1 + s2 == s3;

            // Assert
            isSameReference.Should().BeFalse("because too late for .NET string interning");
            areStringsEqual.Should().BeTrue("because the strings have the same contents");
        }
    }
}