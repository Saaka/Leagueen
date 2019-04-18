using System.Threading.Tasks;
using FluentValidation;
using Leagueen.Application.Users.Repositories;
using Leagueen.Domain.Enums;

namespace Leagueen.Application.Users.Commands.UpdateUserDisplayName
{
    public class UpdateUserDisplayNameCommandValidator : AbstractValidator<UpdateUserDisplayNameCommand>
    {
        private readonly IUsersRepository usersRepository;

        public UpdateUserDisplayNameCommandValidator(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;

            RuleFor(x => x.UserId)
                .NotEmpty();
            RuleFor(x => x.DisplayName)
                .NotEmpty();
            RuleFor(x => x)
                .MustAsync((command, cancellationToken) => HaveUniqueValue(command))
                .WithMessage(ExceptionCode.UserDisplayNameNotUnique.ToString());
        }

        private async Task<bool> HaveUniqueValue(UpdateUserDisplayNameCommand command) =>
            !(await usersRepository.IsDisplayNameInUse(command.UserId, command.DisplayName));
    }
}
