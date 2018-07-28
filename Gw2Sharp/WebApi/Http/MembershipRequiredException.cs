using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A web API specific exception that's used when a request fails to authorize due to the owner of the API key not being a member of the guild (code 403).
    /// </summary>
    /// <seealso cref="UnexpectedStatusException{Error}" />
    public class MembershipRequiredException : AuthorizationRequiredException
    {
        /// <summary>
        /// Creates a new <see cref="MembershipRequiredException"/>.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        public MembershipRequiredException(IHttpRequest request, IHttpResponse<ErrorObject> response) : base(request, response, AuthorizationError.MembershipRequired) { }
    }
}
