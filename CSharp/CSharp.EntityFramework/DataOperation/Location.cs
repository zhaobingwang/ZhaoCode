using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperation
{
    public class Location
    {
        public Location()
        {
            Employers = new HashSet<Employer>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employer> Employers { get; set; }
    }
}
