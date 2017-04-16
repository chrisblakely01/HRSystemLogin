using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Model.Enums
{
    public enum AuthenticationStatus
    {
        [Description("Logged In")]
        LOGGED_IN,
        [Description("User Not Found")]
        USER_NOT_FOUND,
        [Description("Incorrect Credentials")]
        INCORRECT_DETAILS,
        [Description("Account Locked")]
        LOCKED_OUT,
        [Description("Account Locked")]
        ACTIVE

    }
}