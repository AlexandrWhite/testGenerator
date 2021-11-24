using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace testGenerator.Validation
{
    class PositiveIntNumberRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int n;
            try
            {
                n = Convert.ToInt32(value);
            }
            catch
            {               
                return new ValidationResult(false, null);
            }

            if (n < 0) { return new ValidationResult(false,"Число не должно быть отрицательным"); }
            return new ValidationResult(true,null);
        }
    }
}
