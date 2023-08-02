using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.writerName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz!");
            RuleFor(x => x.writerSurName).NotEmpty().WithMessage("Yazar Soyadını Boş Geçemezsiniz!");
            RuleFor(x => x.writerAbout).NotEmpty().WithMessage("Hakkımda Kısmını Boş Geçemezsiniz!");
            RuleFor(x => x.writerMail).NotEmpty().WithMessage("Yazar Mailini Boş Geçemezsiniz!");
            RuleFor(x => x.writerPassword).NotEmpty().WithMessage("Yazar Şifresini Kısmını Boş Geçemezsiniz!");
            RuleFor(x => x.writerTitle).NotEmpty().WithMessage("Yazar Ünvanını Boş Geçemezsiniz!");
            RuleFor(x => x.writerName).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Girişi Yapın!");
            RuleFor(x => x.writerSurName).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Girişi Yapın!");
            RuleFor(x => x.writerName).MaximumLength(20).WithMessage("Lütfen 20 Karakterden Fazla Değer Girişi Yapmayın!");
            RuleFor(x => x.writerSurName).MaximumLength(20).WithMessage("Lütfen 20 Karakterden Fazla Değer Girişi Yapmayın!");
        }
    }
}
