using ASOFOTEC_Web.DTOs;
using FluentValidation;

namespace ASOFOTEC_Web.Validators
{
    public class UserInsertValidator: AbstractValidator<InsertUsersDto>
    {
        public UserInsertValidator()
        {
            RuleFor(C => C.Id_Card).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(A => A.Last_Name).NotEmpty();
            RuleFor(E => E.Email).NotEmpty();
            RuleFor(P => P.Phone).NotEmpty();
            RuleFor(c => c.Country).NotEmpty();
            RuleFor(B => B.Age)
                .NotNull()
                .GreaterThanOrEqualTo(18)
                .LessThanOrEqualTo(99);
        }
    }
}
