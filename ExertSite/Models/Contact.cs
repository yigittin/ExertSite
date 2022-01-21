using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExertSite.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactText { get; set; }

        public string AddressText { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string ContactSmallText { get; set; }
    }
}
