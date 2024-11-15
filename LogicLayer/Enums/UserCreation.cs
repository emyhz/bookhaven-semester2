using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Enums
{
    public enum UserCreation
    {
        EMPTY_FIELDS,
        SUCCESS,
        INVALID_EMAIL,
        PASSWORDS_DONT_MATCH,
        EMAIL_ALREADY_EXISTS

    }
}
