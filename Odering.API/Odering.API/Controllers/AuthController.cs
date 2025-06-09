using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Commands.Auth;
using Ordering.Application.Commands.User.ForgetPassword;
using Ordering.Application.Commands.User.ResetPassword;

namespace Ordering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;
        public AuthController( IMediator mediator)
        {
            _mediator = mediator;
            
        }
        [HttpPost("Login")]
        public  async Task<ActionResult> Login([FromBody] AuthCommand command)
        {
            return Ok(await _mediator.Send(command));

        }
        [HttpPost("forgot-password")]
        public async Task<ActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var token = await _mediator.Send(new ForgotPasswordCommand(request.Email));

            if (string.IsNullOrEmpty(token))
            {
                // Return generic OK for security
                return Ok(new { Message = "If the email exists, a reset token has been sent." });
            }

            // For dev only - return the token in response (remove in prod)
            return Ok(new { Token = token });
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordCommand request)
        {
            var success = await _mediator.Send(new ResetPasswordCommand
            {
                Email = request.Email,
                Token = request.Token,
                NewPassword = request.NewPassword
            });

            return success
                ? Ok(new { Message = "Password reset successful." })
                : BadRequest(new { Message = "Password reset failed." });
        }


    }
}
