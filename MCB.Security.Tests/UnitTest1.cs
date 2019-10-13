using MCB.Security.Infrastructure.TokenProviders;
using NUnit.Framework;

namespace MCB.Security.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            TokenProviderFactory factory = new TokenProviderFactory();
            var result = factory.GetTokenFactory(Infrastructure.Configuration.TokenProviderEnum.Jwt);
            Assert.Pass();
        }
    }
}