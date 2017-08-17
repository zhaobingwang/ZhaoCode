using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Util.Open
{
    public class Unclassified
    {
        /// <summary>
        /// Calculate the age
        /// </summary>
        /// <param name="birthday">Date of birth</param>
        /// <param name="now">Current Time</param>
        /// <returns></returns>
        public static int GetAge(DateTime birthday, DateTime now)
        {
            int age = now.Year - birthday.Year;
            if (birthday > now.AddYears(-age))
                age--;
            return age;
        }
    }
}
