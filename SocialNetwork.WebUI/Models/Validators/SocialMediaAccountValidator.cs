using FluentValidation;
using SocialNetwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.WebUI.Models.Validators
{
    public class SocialMediaAccountValidator : AbstractValidator<SocialMediaAccount>
    {
        public SocialMediaAccountValidator()
        {
            RuleFor(x => x.Username)
                .NotNull().WithMessage("Kulanıcı Adı Boş Olamaz.")
                .NotEmpty().WithMessage("Kulanıcı Adı Boş Olamaz.")
                .MinimumLength(5).WithMessage("Min 5 karakterli olabilir.")
                .MaximumLength(30).WithMessage("Max 30 karakterli olabilir.");

            RuleFor(x => x.Token)
                .NotNull().WithMessage("Şifre Boş Olamaz.")
                .NotEmpty().WithMessage("Şifre Boş Olamaz.")
                .MinimumLength(5).WithMessage("Min 5 karakterli olabilir.")
                .MaximumLength(30).WithMessage("Max 30 karakterli olabilir.");
                //.Matches(@"^[a-zA-Z]+$").WithMessage("Sadece Harf İçerebilir.")
                //.Matches(@"^[\d]+$").WithMessage("Sadece Sayı İçerebilir.")
                //.Must(RepublicOfTurkeyIdentityNumberValidator).WithMessage("Gerçek Tc Kimlik No Giriniz.");

            RuleFor(x => x.SocialMediaName)
                .NotNull().WithMessage("Sosyal Medya Türü Boş Olamaz")
                .NotEmpty().WithMessage("Sosyal Medya Türü Boş Olamaz");
        }
    }
}
