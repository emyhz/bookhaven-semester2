using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.RegularExpressions
{
    public class RegexManager
    {
        public static string EMAIL_REGEX = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public static string PASSWORD_REGEX = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
        public static string NAME_REGEX = @"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$";
        public static string PHONE_REGEX = @"^(\d{3}-\d{3}-\d{4})$";
        public static string DATE_REGEX = @"^(\d{4}-\d{2}-\d{2})$";
        public static string ZIPCODE_REGEX = @"^(\d{5})$";
        public static string STATE_REGEX = @"^([A-Z]{2})$";
        public static string CITY_REGEX = @"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$";
        public static string ADDRESS_REGEX = @"^[a-zA-Z0-9]+(([',. -][a-zA-Z0-9 ])?[a-zA-Z0-9]*)*$";
        public static string CREDIT_CARD_REGEX = @"^(\d{16})$";
        public static string CVV_REGEX = @"^(\d{3})$";
        public static string EXPIRATION_DATE_REGEX = @"^(\d{2}/\d{2})$";
        public static string PRICE_REGEX = @"^(\d{1,5}.\d{2})$";
        public static string QUANTITY_REGEX = @"^(\d{1,3})$";
    }
}
