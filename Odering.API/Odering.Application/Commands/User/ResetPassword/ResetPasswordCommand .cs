using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Common.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Commands.User.ResetPassword
{
    public class ResetPasswordCommand : IRequest<bool>
    {
        public string Email { get; set; } = default!;
        public string Token { get; set; } = default!;
        public string NewPassword { get; set; } = default!;
    }

    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, bool>
    {
        private readonly IIdentityService _identityService;
        private readonly ILogger<ResetPasswordCommandHandler> _logger;

        public ResetPasswordCommandHandler(
            IIdentityService identityService,
            ILogger<ResetPasswordCommandHandler> logger)
        {
            _identityService = identityService;
            _logger = logger;
        }

        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _identityService.ResetPasswordAsync(
                    request.Email, request.Token, request.NewPassword);

                if (!result)
                    _logger.LogWarning("Failed to reset password for {Email}", request.Email);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error resetting password for {Email}", request.Email);
                return false;
            }
        }
    }
}
