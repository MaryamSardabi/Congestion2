using FluentValidation;

namespace Congestion.Api.ViewModels
{
    public class CarVm
    {
        public string  Tag{ get; set; }

        public int CarTypeId{ get; set; }
    }
    public class CarVmValidator : AbstractValidator<CarVm>
    {
        public CarVmValidator()
        {
            RuleFor(p => p.CarTypeId).NotEmpty().WithMessage("Please specify carType.");
            RuleFor(p => p.Tag).NotEmpty().WithMessage("The tag could not be null or empty");            
        }
    }
}
