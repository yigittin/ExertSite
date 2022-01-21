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

    }
}
