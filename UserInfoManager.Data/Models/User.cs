using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UserInfoManager.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(26)]
        public string Name { get; set; }

        [Required]
        [StringLength(26)]
        public string Surname { get; set; }

        [Required]
        public CountryType Country{ get; set; }

        [Required]
        [Index(IsUnique = true)]
        [Display(Name="Phone Number #1")]
        [StringLength(15)]
        public string PhoneHome { get; set; }

        //[Index(IsUnique = true)]
        [Display(Name="Phone Number #2")]
        [StringLength(15)]
        public string PhoneMobile { get; set; }

        [Display(Name="Company")]
        [StringLength(26)]
        public string CompanyName { get; set; }

        [StringLength(20)]
        public string Occupation { get; set; }

        [Display(Name="Tax Id")]
        public string Afm { get; set; }

        [Display(Name="Tax Office")]
        public long TaxOfficeId { get; set; }

        public string Address { get; set; }
    }
}
