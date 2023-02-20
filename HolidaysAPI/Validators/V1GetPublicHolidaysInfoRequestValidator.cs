using FluentValidation;
using HolidaysAPI.Controllers;

namespace HolidaysAPI.Validators
{
    public class V1GetPublicHolidaysInfoRequestValidator : AbstractValidator<V1GetPublicHolidaysInfoRequest>
    {
        public V1GetPublicHolidaysInfoRequestValidator()
        {
            RuleFor(x => x.Year)
                .GreaterThan(0);

            RuleFor(x => x.CountryCode)
                .Must(x => string.IsNullOrEmpty(x) is false)
                .WithMessage("Код страны не должен быть пустой строкой");
        }
    }
}