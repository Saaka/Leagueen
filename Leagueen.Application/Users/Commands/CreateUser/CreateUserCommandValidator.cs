using FluentValidation;
using Leagueen.Application.Users.Repositories;
using Leagueen.Domain.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUsersRepository _usersRepository;

        public CreateUserCommandValidator(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public CreateUserCommandValidator()
        {
            RuleFor(x => x.UserGuid)
                .NotEmpty();

            RuleFor(x => x.UserGuid)
                .MustAsync(NotExist)
                .WithMessage(ExceptionCode.UserAlreadyExists.ToString());

            RuleFor(x => x.ImageUrl)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.DisplayName)
                .NotEmpty();
        }

        private async Task<bool> NotExist(Guid userGuid, CancellationToken cancellationToken)
            => !(await _usersRepository.GetUserIdByGuid(userGuid)).HasValue;
    }
}
