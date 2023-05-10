using EasyCash.Dtos.Dtos.AppUserDtos;
using FluentValidation;

namespace EasyCash.Business.ValidationRules.AppUserValidations
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(i => i.Name)
                .NotEmpty().WithName("Adınız").WithMessage("{PropertyName} Alanı Boş Geçilmemelidir!")
                .MinimumLength(2).WithName("Adınız").WithMessage("{PropertyName} Alanı En Az 2 Karakter Olmalıdır!")
                .MaximumLength(40).WithName("Adınız").WithMessage("{PropertyName} Alanı En Çok 40 Karakter Olabilir!");

            RuleFor(i => i.SurName)
                .NotEmpty().WithName("Soyadınız").WithMessage("{PropertyName} Alanı Boş Geçilmemelidir!")
                .MinimumLength(2).WithName("Soyadınız").WithMessage("{PropertyName} Alanı En Az 2 Karakter Olmalıdır!")
                .MaximumLength(40).WithName("Soyadınız").WithMessage("{PropertyName} Alanı En Çok 40 Karakter Olabilir!");

            RuleFor(i => i.Email)
                .NotEmpty().WithName("Eposta Adresi").WithMessage("{PropertyName} Alanı Boş Geçilemez!")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithName("Eposta Adresi").WithMessage("{PropertyName} Geçerli Eposta Adresi Olmalıdır!");

            RuleFor(i => i.UserName)
                .NotEmpty().WithName("Kullanıcı Adı").WithMessage("{PropertyName} Alanı Boş Geçilmemelidir!")
                .MinimumLength(5).WithName("Kullanıcı Adı").WithMessage("{PropertyName} Alanı En Az 5 Karakter Olmalıdır!")
                .MaximumLength(25).WithName("Kullanıcı Adı").WithMessage("{PropertyName} Alanı En Çok 25 Karakter Olabilir!");

            RuleFor(i => i.Password)
                .NotEmpty().WithName("Parola").WithMessage("{PropertyName} Alanı Boş Geçilmemelidir!")
                .MinimumLength(6).WithName("Parola").WithMessage("{PropertyName} En Az 6 Karakter Olmalıdır!")
                .Matches("[A-Z]").WithName("Prola").WithMessage("{PropertyName} En Az Bir Adet Büyük Harf İçermelidir!")
                .Matches("[a-z]").WithName("Prola").WithMessage("{PropertyName} En Az Bir Adet Küçük Harf İçermelidir!")
                .Matches("[0-9]").WithName("Prola").WithMessage("{PropertyName} En Az Bir Adet Sayı İçermelidir!")
                .Matches("[^a-zA-Z0-9]").WithName("Prola").WithMessage("Şifreniz En Az Bir Adet Özel Karakter İçermelidir!");

            RuleFor(i => i.ConfirmPassword)
                .NotEmpty().WithName("Parola Tekrarı").WithMessage("{PropertyName} Alanı Boş Geçilmemelidir!")
                .Equal(w => w.Password).WithName("Parola Tekrarı").WithMessage("{PropertyName} Parolayla Eşleşmiyor! ")
                .MinimumLength(6).WithName("Parola Tekrarı").WithMessage("{PropertyName} En Az 6 Karakter Olmalıdır!")
                .Matches("[A-Z]").WithName("Parola Tekrarı").WithMessage("{PropertyName} En Az Bir Adet Büyük Harf İçermelidir!")
                .Matches("[a-z]").WithName("Parola Tekrarı").WithMessage("{PropertyName} En Az Bir Adet Küçük Harf İçermelidir!")
                .Matches("[0-9]").WithName("Parola Tekrarı").WithMessage("{PropertyName} En Az Bir Adet Sayı İçermelidir!")
                .Matches("[^a-zA-Z0-9]").WithName("Parola Tekrarı").WithMessage("Şifreniz En Az Bir Adet Özel Karakter İçermelidir!");
        }
    }
}
