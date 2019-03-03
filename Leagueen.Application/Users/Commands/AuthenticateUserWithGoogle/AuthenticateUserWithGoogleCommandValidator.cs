using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leagueen.Application.Users.Commands.AuthenticateUserWithGoogle
{
    public class AuthenticateUserWithGoogleCommandValidator : AbstractValidator<AuthenticateUserWithGoogleCommand>
    {
        public AuthenticateUserWithGoogleCommandValidator()
        {
        }
    }
}
