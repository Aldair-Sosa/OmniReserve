
using MediatR;
using FluentValidation; 
using ValidationException = OmniReserve.Application.Common.Exceptions.ValidationException;


namespace OmniReserve.Application.Common.Behaviors;

public class ValidationBehavior <TRequest, TResponse> : IPipelineBehavior<TRequest , TResponse> where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _Validators; 

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _Validators = validators; 
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_Validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
             
             var validationResults = await Task.WhenAll(_Validators.Select(v => v.ValidateAsync(context, cancellationToken)));

             var failures = validationResults
             .Where(r => r.Errors.Any())
             .SelectMany(r => r.Errors)
             .ToList(); 

             if (failures.Any())
             throw new ValidationException(failures);
        }

        return await next();
    }
}