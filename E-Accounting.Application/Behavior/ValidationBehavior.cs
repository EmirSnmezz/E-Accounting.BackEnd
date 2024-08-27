using E_Accounting.Application.Messaging;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Accounting.Application.Behavior
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> //IPipeLineBehavior İnterface'i sayesinde araya girip ilgili requestler üzerinde validasyon kontrollerimizi yapmamızı sağlamaktadır.
                                                                  where TRequest : ICommand<TResponse>, new()
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next(); // burada dedik ki eğer _validators içerisinde tanımlı bir validasyon işlemimiz yoksa await ile beraber next diyerek bizim işlemimizi devam ettirsin yani bir sonraki yapıya versim
            }

            var context = new ValidationContext<TRequest>(request); // validasyon kurallarına takılan tüm errorleri liste formatında tutuyoruz
            var errorDictionary = _validators.Select(x => x.Validate(context))
                                             .SelectMany( x=> x.Errors)
                                             .Where(x => x!= null)
                                             .GroupBy(
                                             x => x.PropertyName,
                                             x => x.ErrorMessage, (propertyName, errorMessage) => new
                                             {
                                                 Key = propertyName,
                                                 Values = errorMessage.Distinct().ToList()
                                             }).ToDictionary(x=> x.Key, x => x.Values[0]);

            if (errorDictionary.Any())
            {
                var errors = errorDictionary.Select(s => new ValidationFailure // Validation Messagelarını bir objeye atadık 
                {
                    PropertyName = s.Value,
                    ErrorCode = s.Key
                });

                throw new ValidationException(errors);
            }

            return await next();  

        }
    }
}
