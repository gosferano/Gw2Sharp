using System;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Exceptions
{
    /// <summary>
    /// A web API specific exception that's used when a request fails due to providing a page that's out of range.
    /// </summary>
    /// <seealso cref="BadRequestException" />
    public class PageOutOfRangeException : BadRequestException
    {
        /// <summary>
        /// Creates a new <see cref="PageOutOfRangeException"/>.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="response"/> is <c>null</c>.</exception>
        public PageOutOfRangeException(IWebApiRequest request, IWebApiResponse<ErrorObject> response) :
            base(request, response, BadRequestError.PageOutOfRange) { }
    }
}
