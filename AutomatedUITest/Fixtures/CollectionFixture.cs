using Xunit;

namespace AutomatedUITest.Fixtures
{
    [CollectionDefinition("Driver")]
    public class CollectionFixture : ICollectionFixture<EnvironmentFixture>
    {
    }
}
