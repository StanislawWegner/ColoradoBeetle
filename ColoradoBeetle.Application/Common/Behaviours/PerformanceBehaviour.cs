using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ColoradoBeetle.Application.Common.Behaviours;
public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse> {
    private readonly ILogger _logger;
    private readonly Stopwatch _timer;

    public PerformanceBehaviour(ILogger<TRequest> logger) {
        _logger = logger;
        _timer = new Stopwatch();
    }
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next) {

        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMiliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMiliseconds > 500) {

            _logger.LogInformation("ColoradoBeetle Long Running Request: {@Name} " +
                "({elapsedMiliseconds} miliseconds) {@Request}", typeof(TRequest).Name, elapsedMiliseconds
                , request);
        }

        return response;



    }
}
