using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExertSite.Models
{
    public class Member
    {
        public int MemberId { get; set; }

        public string MemberSmallText { get; set; }


        public string MemberName { get; set; }

        public string MemberRole { get; set; }

        public string MemberImage { get; set; }

        public string MemberTwitter { get; set; }
        public string MemberFacebook { get; set; }
        public string MemberLinkedin { get; set; }
    }
}
