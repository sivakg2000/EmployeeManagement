using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInfoManager.Data.Models;

namespace UserInfoManager.Data.Services
{
    public class UserInfoManagerDbContext : DbContext // Points to Db - we can break it into smaller piecies
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TaxOffice> TaxOffices { get; set; }

        public UserInfoManagerDbContext() : base("UserInfoManagerDbContext") // Not sure what's going on here
        {

        }
    }
}
