using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExertSite.Models
{
    public class Container
    {
        public IEnumerable<ExertSite.Models.Slider> Sliders { get; set; }
        public IEnumerable<ExertSite.Models.Portfolio> Portfolios { get; set; }

        public IEnumerable<ExertSite.Models.Project> Projects { get; set; }

        public IEnumerable<ExertSite.Models.Service> Services { get; set; }
        public IEnumerable<ExertSite.Models.GrowText> GrowTexts { get; set; }

        public IEnumerable<ExertSite.Models.Clients> Clients { get; set; }

        public IEnumerable<ExertSite.Models.Member> Members { get; set; }

        public IEnumerable<ExertSite.Models.SiteOperations> SiteOperations { get; set; }

    }
}
