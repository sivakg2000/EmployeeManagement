using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserInfoManager.Data.Models;

namespace UserInfoManager.Web.ViewModels
{
    public class CreateTaxOfficeViewModel
    {
            public User User { get; set; }
            public TaxOffice TaxOffice{ get; set; } //this will create the list of resourcetypes
            public int TaxOfficeId { get; set; } //this will be used to select the id of resourceType you are selecting.

        public CreateTaxOfficeViewModel(User user, List<TaxOffice> taxOffice) //create a constructor 
        {
            this.User = user;
            //here you will set the list as a new selectList, stating where the list will come from. the Id de valuevaluefield, and the name is the valuetextfield
            this.TaxOffice = new SelectList(taxOffice, "Id", "Description");
        }

        public CreateTaxOfficeViewModel() { } //you need this second constructor

        }
    }