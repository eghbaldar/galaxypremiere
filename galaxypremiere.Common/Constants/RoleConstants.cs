using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Common.Constants
{
    public abstract class RoleConstants
    {
        public const string King = "King"; // the highest role (CEO & its agent)
        public const string SuperAdmin = "SuperAdmin"; // the CEO's agent or other higher-ups
        public const string Admin = "Admin"; // website managers
        public const string Client = "Client"; // who are registered
        public const string User = "User"; // who are not registered yet!
    }
}
