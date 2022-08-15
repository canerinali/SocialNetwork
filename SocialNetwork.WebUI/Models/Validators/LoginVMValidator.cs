using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.WebUI.Models.Validators
{
    public class LoginVMValidator : AbstractValidator<LoginVM>
    {
        public LoginVMValidator()
        {
            RuleFor(x => x.Mail)
              .NotNull().WithMessage("E-Mail Boş Olamaz.")
              .NotEmpty().WithMessage("E-Mail Boş Boş Olamaz.")
              .EmailAddress().WithMessage("E-Mail Formatında Olmalıdır.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Şifre Boş Olamaz.")
                .NotEmpty().WithMessage("Şifre Boş Olamaz.")
                .MinimumLength(6).WithMessage("Min 6 karakterli olabilir.");
        }
    }
}
