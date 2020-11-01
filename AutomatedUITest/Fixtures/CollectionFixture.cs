using AutomatedUITest.Fixtures;
using Xunit;

namespace iClipsTest.Fixtures
{
    [CollectionDefinition("Driver")]
    public class CollectionFixture : ICollectionFixture<EnvironmentFixture>
    {
    }
}
