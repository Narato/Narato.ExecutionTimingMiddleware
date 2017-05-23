using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Narato.ExecutionTimingMiddleware.Middleware;
using Xunit;

namespace Narato.ExecutionTimingMiddleware.Test.Middleware
{
    public class ExecutionTimingMiddlewareTest
    {
        [Fact]
        public async void TestTimingHeaderIsSet()
        {
            // Arrange
            var builder = new WebHostBuilder()
                .Configure(app =>
                {
                    app.UseExecutionTiming();
                });

            var server =  new TestServer(builder);

            // Act
            var responseMessage = await server.CreateClient().GetAsync("/");

            // Assert
            Assert.True(responseMessage.Headers.Contains(AddExecutionTimingMiddleware.EXECUTION_TIMING_HEADER_NAME));
        }
    }
}
