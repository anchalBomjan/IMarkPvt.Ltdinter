using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Common.Exceptions;
using Ordering.Application.Common.Interface;

namespace Ordering.Application.Commands.User.ForgetPassword
{
    public class ForgotPasswordCommand : IRequest<string>
    {
        public string Email { get; set; }

        public ForgotPasswordCommand(string email)
        {
            Email = email;
        }
    }

    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, string>
    {
        private readonly IIdentityService _identityService;
        private readonly ILogger<ForgotPasswordCommandHandler> _logger;

        public ForgotPasswordCommandHandler(
            IIdentityService identityService,
            ILogger<ForgotPasswordCommandHandler> logger)
        {
            _identityService = identityService;
            _logger = logger;
        }

        public async Task<string> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var token = await _identityService.GeneratePasswordResetTokenAsync(request.Email);

                // Log for dev purposes only (remove in production)
                _logger.LogInformation("Password reset token for {Email}: {Token}", request.Email, token);

                return token; // success
            }
            catch (NotFoundException)
            {
                _logger.LogWarning("Email not found: {Email}", request.Email);

                // Return empty string on purpose — avoid revealing existence of email
                return string.Empty;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating password reset token for {Email}", request.Email);

                return string.Empty;
            }
        }
    }
}
