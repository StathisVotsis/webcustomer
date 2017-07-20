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
            RuleFor(customer => customer.FirstName).NotEmpty();
            RuleFor(customer => customer.LastName).NotEmpty();
            RuleFor(customer => customer.Email).NotEmpty();

        }

    }
}