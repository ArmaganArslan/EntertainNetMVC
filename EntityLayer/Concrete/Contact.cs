using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int contactId { get; set; }
        [StringLength(50)]
        public string userName { get; set; }
        [StringLength(50)]
        public string userMail { get; set; }
        [StringLength(50)]
        public string subject { get; set; }

        public string message { get; set; }
    }
}
