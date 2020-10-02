using CatalogOfEmployees.BusinessLogic.Domain.Contracts;
using FluentValidation;

namespace CatalogOfEmployees.Validators
{
    /// <summary>
    /// </summary>
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployee>
    {
        /// <summary>
        /// </summary>
        public CreateEmployeeValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("Поле FirstName не заполнено")
                .NotEmpty().WithMessage("Поле FirstName не заполнено");


            RuleFor(x => x.LastName)
                .NotNull().WithMessage("Поле LastName не заполнено")
                .NotEmpty().WithMessage("Поле LastName не заполнено");


            RuleFor(x => x.MiddleName)
                .NotNull().WithMessage("Поле MiddleName не заполнено")
                .NotEmpty().WithMessage("Поле MiddleName не заполнено");
        }
    }

    /// <summary>
    /// </summary>
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployee>
    {
        /// <summary>
        /// </summary>
        public UpdateEmployeeValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Id).GreaterThan(x => 0).WithMessage("Поле Id не заполнено");

            RuleFor(x => x.FirstName)
                 .NotNull().WithMessage("Поле FirstName не заполнено")
                 .NotEmpty().WithMessage("Поле FirstName не заполнено");


            RuleFor(x => x.LastName)
                .NotNull().WithMessage("Поле LastName не заполнено")
                .NotEmpty().WithMessage("Поле LastName не заполнено");

            RuleFor(x => x.MiddleName)
                .NotNull().WithMessage("Поле MiddleName не заполнено")
                .NotEmpty().WithMessage("Поле MiddleName не заполнено");

        }
    }
}
