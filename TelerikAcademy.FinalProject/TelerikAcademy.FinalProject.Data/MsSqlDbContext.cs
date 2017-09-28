using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.FinalProject.Data.Model;

namespace TelerikAcademy.FinalProject.Data
{
    public class MsSqlDbContext : IdentityDbContext<User>
    {
        public MsSqlDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public static MsSqlDbContext Create()
        {
            return new MsSqlDbContext();
        }
    }
}
