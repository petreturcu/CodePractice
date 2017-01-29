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
            string s1 = "This is a string";
            string s2 = "This is a string";

            // Act
            bool isSameReference = Object.ReferenceEquals(s1, s2);

            // Assert
            isSameReference.Should().BeTrue("because .NET string interning");
        }

        [Test]
        public void StringInterning_WhenRuntimeLiterals_ShouldHaveDifferentReference()
        {
            // Arrange
            string s1 = "This is a";
            string s2 = " string";
            string s3 = "This is a string";

            // Act
            bool isSameReference = Object.ReferenceEquals(s1 + s2, s3);
            bool areStringsEqual = s1 + s2 == s3;

            // Assert
            isSameReference.Should().BeFalse("because too late for .NET string interning");
            areStringsEqual.Should().BeTrue("because the strings have the same contents");
        }
    }
}