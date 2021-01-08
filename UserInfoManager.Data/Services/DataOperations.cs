using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInfoManager.Data.Models;

namespace UserInfoManager.Data.Services
{
    public class DataOperations : IUserData, ITaxOfficeData
    {
        private readonly UserInfoManagerDbContext db;

        public DataOperations(UserInfoManagerDbContext db)
        {
            this.db = db;
        }

        //Add Operations
        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges(); //such wow
        }

        public void AddTaxOffice(TaxOffice taxOffice)
        {
            db.TaxOffices.Add(taxOffice);
            db.SaveChanges(); //such wow again
        }

        //Delete Operations
        public void DeleteTaxOffice(int id)
        {
            var taxOffice = db.TaxOffices.Find(id);
            db.TaxOffices.Remove(taxOffice);
            db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
        }

        //GetData Operations
        public TaxOffice GetTaxOfficeData(int id)
        {
            return db.TaxOffices.FirstOrDefault(r => r.Id == id);
        }

        public User GetUserData(int id)
        {
            return db.Users.FirstOrDefault(r => r.Id == id);
        }

        //GetObjs Operations
        public IEnumerable<TaxOffice> GetAllTaxOffices()
        {
            //linq syntax
            return from r in db.TaxOffices
                   orderby r.Description
                   select r;
        }

        public IEnumerable<User> GetAllUsers()
        {
            //linq syntax
            return from r in db.Users
                   select r;
        }

        //Update Operations
        public void UpdateTaxOffice(TaxOffice taxOffice)
        {
            var entry = db.Entry(taxOffice);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var entry = db.Entry(user);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
