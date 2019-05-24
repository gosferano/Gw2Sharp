using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account mapchests endpoint.
    /// </summary>
    [EndpointPath("account/mapchests")]
    [EndpointSchemaVersion("2019-02-21T00:00:00.000Z")]
    public class AccountMapChestsClient : BaseEndpointBlobClient<IApiV2ObjectList<string>>, IAccountMapChestsClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountMapChestsClient"/> that is used for the API v2 account mapchests endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountMapChestsClient(IConnection connection) :
            base(connection)
        { }
    }
}
