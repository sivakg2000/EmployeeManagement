using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using UserInfoManager.Data.Services;
using UserInfoManager.Web.Models;

[assembly: OwinStartupAttribute(typeof(UserInfoManager.Web.Startup))]

namespace UserInfoManager.Web
{
    public partial class Startup
    {
        //private readonly UserInfoManagerDbContext db;

        //public Startup(UserInfoManagerDbContext db)
        //{
        //    this.db = db;
        //}

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //CreateRolesandUsers();
        }

        //private void CreateRolesandUsers()
        //{
        //    RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
        //    UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

        //    // In Startup iam creating first Admin Role and creating a default Admin User
        //    if (!roleManager.RoleExists("Admin"))
        //    {
        //        // first we create Admin rool
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "Admin";
        //        roleManager.Create(role);

        //        //Here we create a Admin super user who will maintain the website

        //        var user = new ApplicationUser();
        //        user.UserName = "shanu";
        //        user.Email = "syedshanumcain@gmail.com";

        //        string userPWD = "A@Z200711";

        //        var chkUser = UserManager.Create(user, userPWD);

        //        //Add default User to Role Admin
        //        if (chkUser.Succeeded)
        //        {
        //            var result1 = UserManager.AddToRole(user.Id, "Admin");
        //        }
        //    }

        //    // creating Creating Manager role
        //    if (!roleManager.RoleExists("Manager"))
        //    {
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "Manager";
        //        roleManager.Create(role);
        //    }

        //    // creating Creating Employee role
        //    if (!roleManager.RoleExists("Employee"))
        //    {
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "Employee";
        //        roleManager.Create(role);
        //    }
        //}
    }
}