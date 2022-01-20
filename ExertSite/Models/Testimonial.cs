using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExertSite.Models
{
    public class Testimonial
    {
        public int TestimonialId { get; set; }
        public string TestimonialPersonImage { get; set; }
        public string TestimonialBgImage { get; set; }
        public string TestimonialText { get; set; }
        public string TestimonialPerson { get; set; }
    }
}
