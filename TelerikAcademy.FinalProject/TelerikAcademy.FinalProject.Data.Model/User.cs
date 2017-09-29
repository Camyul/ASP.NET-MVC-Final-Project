using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.FinalProject.Data.Model.Contracts;

namespace TelerikAcademy.FinalProject.Data.Model
{
    public class User : IdentityUser, IAuditable, IDeletable
    {
        //private ICollection<Order> orders;
        //private ICollection<ContactInfo> contactInfos;

        //public User()
        //{
            //this.orders = new HashSet<Order>();
            //this.contactInfos = new HashSet<ContactInfo>();
        //}

        public DateTime? CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        //public virtual ICollection<Order> Orders
        //{
        //    get
        //    {
        //        return this.orders;
        //    }

        //    set
        //    {
        //        this.orders = value;
        //    }
        //}

        //public virtual ICollection<ContactInfo> ContactInfos
        //{
        //    get
        //    {
        //        return this.contactInfos;
        //    }

        //    set
        //    {
        //        this.contactInfos = value;
        //    }
        //}

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
