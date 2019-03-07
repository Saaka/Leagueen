using FluentValidation;
using Leagueen.Application.Users.Repositories;
using Leagueen.Domain.Constants;
using Leagueen.Domain.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Commands.RegisterUserWithCredentials
{
    public class RegisterUserWithCredentialsCommandValidator : AbstractValidator<RegisterUserWithCredentialsCommand>
    {
        private readonly IUsersRepository usersRepository;

        public RegisterUserWithCredentialsCommandValidator(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;

            RuleFor(x => x.DisplayName)
                .Length(UserConstants.MinDisplayNameLength, UserConstants.MaxDisplayNameLength)
                .NotEmpty();
            RuleFor(x => x.Password)
                .Length(UserConstants.MinPasswordLength, UserConstants.MaxPasswordLength)
                .NotEmpty();
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Length(UserConstants.MinEmailLength, UserConstants.MaxPasswordLength);

            RuleFor(x => x.Email)
                .MustAsync(HaveUniqueEmail)
                .WithMessage(ExceptionCode.UserEmailNotUnique.ToString());
        }
        
        private async Task<bool> HaveUniqueEmail(string email, CancellationToken cancellationToken) => !(await usersRepository.IsEmailRegistered(email));
    }
}
