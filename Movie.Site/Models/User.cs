using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Site.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        //[DisplayName("Mail Adresi")]
        public string UserMail { get; set; }

        [StringLength(20)]
        //[DisplayName("Sifre")]
        public string UserPassword { get; set; }
    }
}
