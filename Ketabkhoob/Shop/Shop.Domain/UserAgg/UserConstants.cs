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
            public static string INVALID_CHARGE_AMOUNT => $"Amount can not be less than {MINIMUM_CHARGE}";
        }
        public static string DefaultAvatarImage = "avatar.png";
        public static string TRACKING_MESSAGE = "Your Traking code is : ";

        public static int MINIMUM_CHARGE = 500;
    }
}
