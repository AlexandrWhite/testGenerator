using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace testGenerator.LinearGenerator.Validaton
{
    class ModGreatAndEqual2Rule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ulong mod;
            try
            {

                mod = Convert.ToUInt64(value);
            }
            catch
            {              
                return new ValidationResult(false, "Некорректный ввод");
            }

            if (mod >= 2)
            {                
                return new ValidationResult(true, null);
            }
            
            return new ValidationResult(false, "Введённое значение должно быть больше или равно 2");
        }
    }
}
