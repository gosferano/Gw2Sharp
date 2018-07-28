using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Models;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Gw2Sharp.Tests.WebApi
{
    public class ConnectionTests
    {
        [Fact]
        public void ConstructorTest()
        {
            string key = "test key";
            Locale locale = Locale.German;
            var httpClient = Substitute.For<IHttpClient>();
            var cacheMethod = Substitute.For<ICacheMethod>();

            var connection1 = new Connection();
            var connection2 = new Connection(key);
            var connection3 = new Connection(locale);
            var connection4 = new Connection(key, locale);
            var connection5 = new Connection(key, locale, httpClient, cacheMethod);

            Assert.Null(connection1.AccessToken);
            Assert.Equal(Locale.English, connection1.Locale);
            Assert.IsType<HttpClient>(connection1.HttpClient);
            Assert.IsType<MemoryCacheMethod>(connection1.CacheMethod);

            Assert.Equal(key, connection2.AccessToken);
            Assert.Equal(Locale.English, connection2.Locale);
            Assert.IsType<HttpClient>(connection2.HttpClient);
            Assert.IsType<MemoryCacheMethod>(connection2.CacheMethod);

            Assert.Null(connection3.AccessToken);
            Assert.Equal(locale, connection3.Locale);
            Assert.IsType<HttpClient>(connection3.HttpClient);
            Assert.IsType<MemoryCacheMethod>(connection3.CacheMethod);

            Assert.Equal(key, connection4.AccessToken);
            Assert.Equal(locale, connection4.Locale);
            Assert.IsType<HttpClient>(connection4.HttpClient);
            Assert.IsType<MemoryCacheMethod>(connection4.CacheMethod);

            Assert.Equal(key, connection5.AccessToken);
            Assert.Equal(locale, connection5.Locale);
            Assert.Same(httpClient, connection5.HttpClient);
            Assert.Same(cacheMethod, connection5.CacheMethod);
        }

        [Theory]
        [InlineData("en", Locale.English)]
        [InlineData("de", Locale.German)]
        [InlineData("fr", Locale.French)]
        [InlineData("es", Locale.Spanish)]
        [InlineData("ko", Locale.Korean)]
        [InlineData("zh", Locale.Chinese)]
        public void LocaleStringTest(string expected, Locale locale)
        {
            // Maybe find a way to store strings inside enums and test that feature instead,
            // so we don't have to manually test every enum with custom string values in existence.
            var connection = new Connection(locale);
            Assert.Equal(expected, connection.LocaleString);
        }

        [Fact]
        public async Task ValidRequestTest()
        {
            var httpClient = Substitute.For<IHttpClient>();
            var httpResponse = Substitute.For<IHttpResponse>();
            httpResponse.Content.Returns("{\"testkey\":\"testvalue\"}");
            httpResponse.StatusCode.Returns(HttpStatusCode.OK);
            httpResponse.RequestHeaders.Returns(new Dictionary<string, string> { { "request", "headers" } });
            httpResponse.ResponseHeaders.Returns(new Dictionary<string, string> { { "response", "here" } });
            httpClient.Request(Arg.Any<IHttpRequest>(), CancellationToken.None).Returns(Task.FromResult(httpResponse));
            var content = new TestContentClass { Testkey = "testvalue" };

            var connection = new Connection(null, default, httpClient, new NullCacheMethod());
            var response = await connection.Request<TestContentClass>(null, CancellationToken.None);

            Assert.Equal(content.Testkey, response.Content.Testkey);
            Assert.Equal(httpResponse.StatusCode, response.StatusCode);
            Assert.Equal(httpResponse.RequestHeaders, response.RequestHeaders);
            Assert.Equal(httpResponse.ResponseHeaders, response.ResponseHeaders);
        }

        [Theory]
        [InlineData("bad request", HttpStatusCode.BadRequest, typeof(BadRequestException))]
        [InlineData("authorization failed", HttpStatusCode.Forbidden, typeof(AuthorizationRequiredException))]
        [InlineData("invalid key", HttpStatusCode.Forbidden, typeof(InvalidAccessTokenException))]
        [InlineData("requires scope inventories", HttpStatusCode.Forbidden, typeof(MissingScopesException))]
        [InlineData("membership required", HttpStatusCode.Forbidden, typeof(MembershipRequiredException))]
        [InlineData("access restricted to guild leaders", HttpStatusCode.Forbidden, typeof(RestrictedToGuildLeadersException))]
        [InlineData("not found", HttpStatusCode.NotFound, typeof(NotFoundException))]
        [InlineData("server error", HttpStatusCode.InternalServerError, typeof(ServerErrorException))]
        [InlineData("service unavailable", HttpStatusCode.ServiceUnavailable, typeof(ServiceUnavailableException))]
        public async Task ExceptionRequestTest(string errorText, HttpStatusCode statusCode, Type exceptionType)
        {
            var httpClient = Substitute.For<IHttpClient>();
            var httpResponse = Substitute.For<IHttpResponse>();
            httpResponse.Content.Returns($"{{\"text\":\"{errorText}\"}}");
            httpResponse.StatusCode.Returns(statusCode);
            httpClient.Request(Arg.Any<IHttpRequest>(), CancellationToken.None).Throws(_ => new UnexpectedStatusException(null, httpResponse));

            var connection = new Connection(null, default, httpClient, new NullCacheMethod());
            var exception = await Assert.ThrowsAsync(exceptionType, () => connection.Request<TestContentClass>(null, CancellationToken.None)) as UnexpectedStatusException<ErrorObject>;
            Assert.Equal(errorText, exception.Response.Content.Text);
        }

        [Fact]
        public async Task UnexpectedStatusExceptionRequestTest()
        {
            var message = "{\"error\":\"Some nice error message\"}";
            var httpClient = Substitute.For<IHttpClient>();
            var httpResponse = Substitute.For<IHttpResponse>();
            httpResponse.Content.Returns(message);
            httpResponse.StatusCode.Returns((HttpStatusCode)499);
            httpClient.Request(Arg.Any<IHttpRequest>(), CancellationToken.None).Throws(_ => new UnexpectedStatusException(null, httpResponse));

            var connection = new Connection(null, default, httpClient, new NullCacheMethod());
            var exception = await Assert.ThrowsAsync<UnexpectedStatusException>(() => connection.Request<TestContentClass>(null, CancellationToken.None));
            Assert.Equal(message, exception.Response.Content);
        }

        public class TestContentClass
        {
            public string Testkey { get; set; }
        }
    }
}
