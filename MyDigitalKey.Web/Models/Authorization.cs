using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDigitalKey.Web.Models
{
    public class Authorization
    {
        public Guid ID { get; set; }
        public Guid DigitalKeyID { get; set; }
        public DigitalKey DigitalKey { get; set; }
        public Guid LockID { get; set; }
        public Lock Lock { get; set; }
        public bool CanOpen { get; set; }
    }
}
