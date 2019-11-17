using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBusinessLayer
{
    public enum EnumRoles
    {
        [Description("visitor")]
        visitor,
        [Description("registered")]
        registered,
        [Description("helper")]
        helper,
        [Description("admin")]
        admin
    }
}
