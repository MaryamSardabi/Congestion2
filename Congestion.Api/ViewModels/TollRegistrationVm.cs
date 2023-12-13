using FluentValidation;

namespace Congestion.Api.ViewModels
{
    public class TollRegistrationVm
    {
        public int CityId { get; set; }
        public int CongestionId { get; set; }
        public string Tag { get; set; }
    }
    public class TollRegistrationVmValidator : AbstractValidator<TollRegistrationVm>
    {
        public TollRegistrationVmValidator()
        {
            RuleFor(p => p.CityId).NotEmpty().WithMessage("Please specify cityId.");
            RuleFor(p => p.CongestionId).NotEmpty().WithMessage("Please specify congestionId.");
            RuleFor(p => p.Tag).NotEmpty().WithMessage("The tag could not be null or empty");
        }
    }
}
