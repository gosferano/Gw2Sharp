using System.Threading.Tasks;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Clients;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AchievementsClientTests : BaseEndpointClientTests
    {
        public AchievementsClientTests()
        {
            var connection = new Connection(null, Locale.English, Substitute.For<IHttpClient>(), new NullCacheMethod());
            this.client = new Gw2WebApiClient(connection).V2.Achievements;
            this.Client = this.client;
        }

        private readonly IAchievementsClient client;

        [Theory]
        [InlineData("TestFiles.Achievements.Achievements.bulk.json")]
        public Task PaginatedTestAsync(string file) => this.AssertPaginatedData(this.client, file);

        [Theory]
        [InlineData("TestFiles.Achievements.Achievements.single.json")]
        public Task GetTestAsync(string file) => this.AssertGetData(this.client, file);

        [Theory]
        [InlineData("TestFiles.Achievements.Achievements.bulk.json")]
        public Task BulkTestAsync(string file) => this.AssertBulkData(this.client, file);

        [Theory]
        [InlineData("TestFiles.Achievements.Achievements.ids.json")]
        public Task IdsTestAsync(string file) => this.AssertIdsData(this.client, file);
    }
}
