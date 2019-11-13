using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DiabetesProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Last name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "First name")]
        [Required]
        public string FirstName { get; set; }
        public virtual ICollection<A1C> A1C { get; set; }
        public virtual ICollection<BloodPressure> BloodPressures { get; set; }
        public virtual ICollection<BloodSugar> BloodSugars { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<DiabetesProject.Models.A1C> A1C { get; set; }

        //public System.Data.Entity.DbSet<DiabetesProject.Models.ApplicationUser> ApplicationUsers { get; set; }

        public System.Data.Entity.DbSet<DiabetesProject.Models.BloodPressure> BloodPressures { get; set; }

        public System.Data.Entity.DbSet<DiabetesProject.Models.BloodSugar> BloodSugars { get; set; }

    }
    //public class DiabetesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    //{
    //    protected override void Seed(ApplicationDbContext context)
    //    {
    //        base.Seed(context);
    //        var a1c = new List<A1C>
    //        {
    //            //int a1cID, string userID, double sugarConcentration, DateTime date, ApplicationUser user
    //            new A1C{A1cID=1,UserID="",SugarConcentration=8.4,Date=System.DateTime.Parse("20018-09-01"),  },
    //            new A1C{A1cID=1,UserID="",SugarConcentration=8.2,Date=System.DateTime.Parse("20018-09-01"),},
    //            new A1C{A1cID=1,UserID="",SugarConcentration=8.4,Date=System.DateTime.Parse("20018-09-01"),}
    //        };

    //        a1c.ForEach(e => context.A1C.Add(e));
    //        context.SaveChanges();
    //    }
    //}
}