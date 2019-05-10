using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace UserDirectory.Application.Infrastructure
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            IReadOnlyCollection<ValidationFailure> validationErrors = ValidateRequest(request);

            if (validationErrors.Count != 0)
            {
                throw new ValidationException(validationErrors);
            }

            return next();
        }

        private IReadOnlyCollection<ValidationFailure> ValidateRequest(TRequest request)
        {
            var context = new ValidationContext(request);

            return validators
                .Select(validator => validator.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();
        }
    }
}