using Heikal.Lubricant.Core.Entities;
using Heikal.Lubricant.Core.Enums;
using Heikal.Lubricant.Infrastructure.Data;
using System.Linq;

namespace Heikal.Lubricant.Infrastructure.Seeds
{
    public class UserSeed
    {
        public static void UsersData(LubricantContext context)
        {
            var adminRole = context.Roles.FirstOrDefault(r => r.RoleName == Roles.Admin.ToString());
            if (context.Users.SingleOrDefault(role => role.UserName == "admin") == null)
                context.Users.Add(new User { UserName = "admin" , Password = "admin", RoleId = adminRole.Id });

            var staffRole = context.Roles.FirstOrDefault(r => r.RoleName == Roles.Staff.ToString());
            if (context.Users.SingleOrDefault(role => role.UserName == "staff") == null)
                context.Users.Add(new User { UserName = "staff", Password = "staff", RoleId = staffRole.Id });

            var userRole = context.Roles.FirstOrDefault(r => r.RoleName == Roles.User.ToString());
            if (context.Users.SingleOrDefault(role => role.UserName == "user") == null)
                context.Users.Add(new User { UserName = "user", Password = "user", RoleId = userRole.Id });
        }
    }
}
