using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
    public static class DomainConstants
    {
        public static class Exceptions
        {
            public static string INVALID_EMAIL => "Invalid email Address";
            public static string INVALID_PHONE_NUMBER => "Invalid Phone Number";

            public static string EMAIL_IN_USE => "Email already in use";
            public static string NUMBER_IN_USE => "Phone Number already in use";

            public static string ADDRESS_NOT_FOUND => "Address Not Found";

            public static string INVALID_ID => "The national ID is not valid";

            public static string PRODUCT_ALREADY_ADDED => "The product already been registered.";
            public static string PRODUCT_NOT_FOUND => "Product not found";
        }
    }
}
