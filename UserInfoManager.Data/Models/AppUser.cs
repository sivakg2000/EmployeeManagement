using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInfoManager.Data.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(26)]
        public string Name { get; set; }

        [Required]
        [StringLength(26)]
        public string Surname { get; set; }

        //[Required]


        [Required]
        public string Email { get; set; }

    }
}
