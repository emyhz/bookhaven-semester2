using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Enums
{
    public enum OrderCreation
    {
        SUCCESS,
        INVALID_ZIPCODE,
        INVALID_CVV,
        INVALID_EXPIRATION,
        INVALID_CARD_NUMBER
    }
}
