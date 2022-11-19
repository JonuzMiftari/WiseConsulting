using NUnit.Framework;

using static WiseConsulting.Application.IntegrationTests.Testing;

namespace WiseConsulting.Application.IntegrationTests;
[TestFixture]
public abstract class BaseTestFixture
{
    [SetUp]
    public async Task TestSetUp()
    {
        await ResetState();
    }
}
