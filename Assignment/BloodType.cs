using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public enum BloodType
    {
        A,B,AB,O// differnt blood types
    }
    public class Patient
    {
       
        public string Name { get; set; }// name
      
        public BloodType Blood { get; set; }
        private DateTime dob;
        public DateTime DOB
        {
            get
            {
                return dob;
            }
            set
            {
                if (value <= DateTime.Now)
                
                {
                    dob= value;
                }
                
                else dob = DateTime.Now;
            }
        }

        public Patient()
        {

        }

        public Patient(string n, DateTime d, BloodType B)
        {
            Name = n;
            DOB = d;
            Blood = B;
        }
       public override string ToString()
{
 	 return String.Format("{0} ({1}) {2}", Name, (DateTime.Now - DOB).Days/365 , Blood);
}


       


    }
}
