using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExertSite.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string ProjectImage { get; set; }

        public string ProjectName { get; set; }

        public string ProjectText { get; set; }

        public Service Service { get; set; }

        public int ServiceId { get; set; }
    }
}
