using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.categoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz!");
            RuleFor(x => x.categoryDescription).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz!");
            RuleFor(x => x.categoryName).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Girişi Yapın!");
            RuleFor(x => x.categoryName).MaximumLength(20).WithMessage("Lütfen 20 Karakterden Fazla Değer Girişi Yapmayın!");
        }
    }
}
