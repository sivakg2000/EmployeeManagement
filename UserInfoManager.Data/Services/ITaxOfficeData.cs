using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInfoManager.Data.Models;

namespace UserInfoManager.Data.Services
{
    public interface ITaxOfficeData
    {
        TaxOffice GetTaxOfficeData(int id);
        IEnumerable<TaxOffice> GetAllTaxOffices();
        void AddTaxOffice(TaxOffice taxOffice);
        void UpdateTaxOffice(TaxOffice taxOffice);
        void DeleteTaxOffice(int id);
    }
}
