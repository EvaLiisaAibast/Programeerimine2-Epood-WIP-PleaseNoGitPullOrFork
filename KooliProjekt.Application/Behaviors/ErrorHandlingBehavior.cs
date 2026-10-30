using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KooliProjekt.Application.Behaviors
{
    public class ErrorHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : OperationResult, new()
    {
        private readonly ILogger<ErrorHandlingBehavior<TRequest, TResponse>> _logger;

        public ErrorHandlingBehavior(ILogger<ErrorHandlingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);

                _logger.LogError(ex, "Request {RequestName} failed", typeof(TRequest).Name);

                var response = new TResponse();

                response.AddError("Andmete töötlemine ebaõnnestus. Palun kontrolli sisestatud andmeid ja proovi uuesti.");

                return response;
            }
        }
    }
}