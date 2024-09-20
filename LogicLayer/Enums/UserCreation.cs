using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Enums
{
    public enum UserCreation
    {
        SUCCESS,
        INVALID_EMAIL,
        INVALID_PASSWORD,
        MISSING_FIELDS,
        EMAIL_ALREADY_EXISTS

    }
}
