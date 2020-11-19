﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_SIMS_PROJEKAT.Validations
{
    class PhoneNumberRule : ValidationRule
    {
        public Regex rgx = new Regex(@"^([0-9]|/|-)+$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;
            if (rgx.IsMatch(charString))
                return new ValidationResult(true, null);

            return new ValidationResult(false, $"Use just numbers, - and /");
        }
    }
}
