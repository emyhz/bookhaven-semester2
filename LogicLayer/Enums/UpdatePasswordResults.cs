using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Enums
{
    public enum UpdatePasswordResults
    {
        INVALID_OLD_PASSWORD,
        PASSWORDS_DONT_MATCH,
        MISSING_FIELDS,
        PASSWORD_UPDATED,
    }
}
