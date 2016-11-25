namespace ManualProviderTests
{
    using System;
    using System.Reflection;

    using FluentAssertions;

    using Mono.CompilerServices.SymbolWriter;

    using NUnit.Framework;

    using StaticManualDI;
    using StaticManualDI.Interfaces;

    [TestFixture]
    public class ProvidersTest
    {
        [Test]
        public void Providers_WhenInterfaceSpecified_ShouldReturnDefaultConcrete()
        {
            // Arrange


            // Act
            var concreteEmail = Providers.GetProvider<IEmailProvider>();
            var concreteData = Providers.GetProvider<IDataProvider>();
            var concreteUser = Providers.GetProvider<IUserProvider>();

            // Assert
            concreteEmail.Should().BeOfType<SmptEmailProvider>();
            concreteData.Should().BeOfType<SqlServerDataProvider>();
            concreteUser.Should().BeOfType<SqlServerUserProvider>();
        }
    }
}