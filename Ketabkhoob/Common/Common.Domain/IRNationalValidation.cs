﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Domain
{
    public static class IRNationalValidation
    {
        public static bool IsIdValid(this string nationalId)
        {
            var isNumber = Regex.IsMatch(nationalId, @"^\d+$");
            if (!isNumber)
                return false;

            var code = nationalId;
            if (Regex.IsMatch(code, @"/^\d{10}$/"))
                return false;

            code = ("0000" + code).Substring(code.Length + 4 - 10);

            if (Convert.ToInt32(code.Substring(3, 6), 10) == 0)
                return false;
            var lastNumber = Convert.ToInt32(code.Substring(9, 1), 10);
            var sum = 0;

            for (var i = 0; i < 9; i++)
            {
                sum += Convert.ToInt32(code.Substring(i, 1), 10) * (10 - i);
            }

            sum = sum % 11;

            return sum < 2 && lastNumber == sum || sum>=2 && lastNumber == 11-sum;
        }
    }
}