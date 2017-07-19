using FluentValidation;
using Stathis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webcustomer.Validation
{
    public class CustomerViewModelValidator : AbstractValidator<Customer>
    {
        public CustomerViewModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("*Required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("*Required").Length(6, 10);
            RuleFor(x => x.Email).EmailAddress().WithMessage("Not Valid").NotEmpty().WithMessage("*Required");
        }
           
    }
}