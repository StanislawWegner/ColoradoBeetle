using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ColoradoBeetle.Application.Common.Behaviours;
public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse> {
    private readonly ILogger _logger;
    private readonly ICurrentUserService _currentUserService;
    private readonly Stopwatch _timer;

    public PerformanceBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService) {
        _logger = logger;
        _currentUserService = currentUserService;
        _timer = new Stopwatch();
    }
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next) {

        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMiliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMiliseconds > 500) {

            var userId = _currentUserService.UserId ?? string.Empty;
            var userName = _currentUserService.UserName ?? string.Empty;

            _logger.LogInformation("ColoradoBeetle Long Running Request: {@Name} " +
                "({elapsedMiliseconds} miliseconds) {@UserId} {@UserName} {@Request}"
                , typeof(TRequest).Name, elapsedMiliseconds
                , userId, userName, request);
        }

        return response;
    }
}
