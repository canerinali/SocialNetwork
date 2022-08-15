using FluentValidation;
using SocialNetwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.WebUI.Models.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Mail)
               .NotNull().WithMessage("E-Mail Boş Olamaz.")
               .NotEmpty().WithMessage("E-Mail Boş Boş Olamaz.")
               .EmailAddress().WithMessage("E-Mail Formatında Olmalıdır.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Şifre Boş Olamaz.")
                .NotEmpty().WithMessage("Şifre Boş Olamaz.")
                .MinimumLength(6).WithMessage("Min 6 karakterli olabilir.");

            RuleFor(x => x.ConfirmPassword)
                .NotNull().WithMessage("Şifre Boş Olamaz.")
                .NotEmpty().WithMessage("Şifre Boş Olamaz.")
                .MinimumLength(6).WithMessage("Min 6 karakterli olabilir.")
                .Equal(x => x.Password).WithMessage("Şifreler Eşleşmiyor.");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("İsim Boş Olamaz.")
                .NotEmpty().WithMessage("İsim Boş Olamaz.")
                .MinimumLength(2).WithMessage("Min 2 karakterli olabilir.")
                .MaximumLength(30).WithMessage("Max 30 karakterli olabilir.");

            RuleFor(x => x.Surname)
                .NotNull().WithMessage("Soyisim Boş Olamaz.")
                .NotEmpty().WithMessage("Soyisim Boş Olamaz.")
                .MinimumLength(2).WithMessage("Min 2 karakterli olabilir.")
                .MaximumLength(30).WithMessage("Max 30 karakterli olabilir.");
        }
    }
}
