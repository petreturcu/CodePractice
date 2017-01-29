namespace ManualProviderTests
{
    using FluentAssertions;

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
            IEmailProvider concreteEmail = Providers.GetProvider<IEmailProvider>();
            IDataProvider concreteData = Providers.GetProvider<IDataProvider>();
            IUserProvider concreteUser = Providers.GetProvider<IUserProvider>();

            // Assert
            concreteEmail.Should().BeOfType<SmptEmailProvider>();
            concreteData.Should().BeOfType<SqlServerDataProvider>();
            concreteUser.Should().BeOfType<SqlServerUserProvider>();
        }
    }
}