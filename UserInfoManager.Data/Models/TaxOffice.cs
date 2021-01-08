using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UserInfoManager.Data.Models
{
    public class TaxOffice
    {
        [Key]
        public int Id { set; get; }

        [Display(Name ="Tax Office Name")]
        public string Description { set; get; }
    }
}
