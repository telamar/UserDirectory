using FluentValidation;

namespace UserDirectory.Application.UserIdentities.Queries.UserIdentityExists
{
    public class UserIdentityExistsQueryValidator : AbstractValidator<UserIdentityExistsQuery>
    {
        public UserIdentityExistsQueryValidator()
        {
            RuleFor(query => query.UserIdentityId).NotEmpty().GreaterThan(0);
        }
    }
}