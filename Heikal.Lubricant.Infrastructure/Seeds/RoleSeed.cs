using Heikal.Lubricant.Core.Entities;
using Heikal.Lubricant.Core.Enums;
using Heikal.Lubricant.Infrastructure.Data;
using System.Linq;

namespace Heikal.Lubricant.Infrastructure.Seeds
{
    public class RoleSeed
    {
        public static void RolesData(LubricantContext context) 
        {
            if (context.Roles.SingleOrDefault(role => role.RoleName == Roles.Admin.ToString()) == null)
                context.Roles.Add(new Role { RoleName = Roles.Admin.ToString() });

            if (context.Roles.SingleOrDefault(role => role.RoleName == Roles.Staff.ToString()) == null)
                context.Roles.Add(new Role { RoleName = Roles.Staff.ToString() });

            if (context.Roles.SingleOrDefault(role => role.RoleName == Roles.User.ToString()) == null)
                context.Roles.Add(new Role { RoleName = Roles.User.ToString() });
        }
    }
}
