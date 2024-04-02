using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg
{
    public static class UserConstants
    {
        public static class ExceptionMessages
        {
            public static string INVALID_EMAIL => "Invalid email Address";
            public static string INVALID_PHONE_NUMBER => "Invalid Phone Number";

            public static string EMAIL_IN_USE => "Email already in use";
            public static string NUMBER_IN_USE => "Phone Number already in use";

            public static string ADDRESS_NOT_FOUND => "Address Not Found";

            public static string INVALID_ID => "The national ID is not valid";

            public static string INVALID_CHARGE_AMOUNT => $"Amount can not be less than {MINIMUM_CHARGE}";
        }
        public static string TRACKING_MESSAGE = "Your Traking code is : ";

        public static int MINIMUM_CHARGE = 500;
    }
}
