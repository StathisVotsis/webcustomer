using FluentValidation;
using Stathis.Data;
using System;
using System.Collections.Generic;

namespace webcustomer.Validation
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        private static Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();

        static ValidatorFactory()
        {
            validators.Add(typeof(IValidator<Customer>), new CustomerViewModelValidator());
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator;
            if (validators.TryGetValue(validatorType, out validator))
            {
                return validator;
            }
            return validator;
        }
    }
}