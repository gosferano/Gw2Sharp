using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account mounts types endpoint.
    /// </summary>
    [EndpointPath("account/mounts/types")]
    [EndpointSchemaVersion("2019-02-21T00:00:00.000Z")]
    public class AccountMountsTypesClient : BaseEndpointBlobClient<IApiV2ObjectList<string>>, IAccountMountsTypesClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountMountsTypesClient"/> that is used for the API v2 account mounts types endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountMountsTypesClient(IConnection connection) :
            base(connection)
        { }
    }
}
