using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperation
{
    public class Employer
    {
        public Employer()
        {
            Companies = new HashSet<Company>();
        }
        public int Id { get; set; }
        public string EmployerName { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}
