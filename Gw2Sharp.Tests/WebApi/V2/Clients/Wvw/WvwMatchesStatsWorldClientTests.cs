using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class WvwMatchesStatsWorldClientTests : BaseWvwMatchesWorldClientTests<IWvwMatchesStatsWorldClient>
    {
        protected override IWvwMatchesStatsWorldClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Wvw.Matches.Stats.World(1001);

        [Theory]
        [InlineData("TestFiles.Wvw.WvwMatchesStats.single.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
