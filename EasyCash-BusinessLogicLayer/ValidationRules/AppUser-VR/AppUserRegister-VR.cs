using System;
using FluentValidation;
using EasyCash_DtoLayer.Dtos.AppUserDtos;

namespace EasyCash_BusinessLogicLayer.ValidationRules.AppUserVR
{
	public class AppUserRegister_VR : AbstractValidator<AppUserRegisterDto>
	{
		public AppUserRegister_VR()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
			RuleFor(x => x.Name).MaximumLength(30).WithMessage("Maksimum 30 karakter olabilir");
			RuleFor(x => x.Name).MinimumLength(2).WithMessage("Minimum 2 karakter olabilir");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("Maksimum 30 karakter olabilir");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Minimum 2 karakter olabilir");

            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez");
            RuleFor(x => x.Username).MaximumLength(30).WithMessage("Maksimum 30 karakter olabilir");
            RuleFor(x => x.Username).MinimumLength(2).WithMessage("Minimum 2 karakter olabilir");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail giriniz");

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrar alanı boş geçilemez");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Şifreler eşleşmiyor");
        }
	}
}

