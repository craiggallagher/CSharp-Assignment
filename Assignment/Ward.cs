using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
   public class Ward
    {
        public string Name { get; set; }// name
        public List<Patient> listPatient { get; set; }// the list
        public int Limit { get; set; }// limit

        public Ward()
        {

        }

        public Ward(string n, int l)
        {
            Name = n;
            Limit = l;
        }

        public override string ToString()
        {
            return string.Format("{0} (Limit:{1})", Name, Limit);// output
        }


    }
}
