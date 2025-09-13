using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace HttpAPI.Bootstrapper
{
	public sealed class ExceptionHandler : IExceptionHandler
	{
		private readonly ILogger<ExceptionHandler> _logger;

		public ExceptionHandler(ILogger<ExceptionHandler> logger)
		{
			_logger = logger;
		}

		public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
		{
			var exception = context.Exception;
			var ex = exception.Demystify();
			_logger.LogError(ex, "An error ocurred: {Message}", ex.Message);
			httpContext.Response.ContentType = "application/json";
			httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			var result = Result.Error(exception.ToStringDemystified());
			await httpContext.Response.WriteAsJsonAsync(result, cancellationToken);
			return true;
		}
	}
}