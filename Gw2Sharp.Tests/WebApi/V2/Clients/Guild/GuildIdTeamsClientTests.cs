using System.Threading.Tasks;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Clients;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class GuildIdTeamsClientTests : BaseGuildSubEndpointClientTests
    {
        public GuildIdTeamsClientTests()
        {
            var connection = new Connection("12345678-1234-1234-1234-12345678901234567890-1234-1234-1234-123456789012", Locale.English, Substitute.For<IHttpClient>(), new NullCacheMethod());
            this.client = new Gw2WebApiClient(connection).V2.Guild["11111111-2222-3333-4444-555555555555"].Teams;
            this.Client = this.client;
        }

        private readonly IGuildIdTeamsClient client;

        [Theory]
        [InlineData("TestFiles.Guild.GuildIdTeams.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.client, file);
    }
}
