using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact
{
    internal class Contact
    {
        public string Name { 
            
            get; 
            
            set; 
        
        }

        public string Surname { 
            get; 

            set; 
        }

        public string Email { 
            get;
            
            set; 
        }

        public DateTime DateOfBirth { 
            get; 
            
            set; 
        }

        public long TelephoneNumber { 
            get; 

            set; 
        }

        public Contact(string _name, string _surname, string _email, 
            DateTime _dateOfBirth, long _telephoneNumber)
        {
            Name = _name;
            Surname = _surname;
            Email = _email;
            DateOfBirth = _dateOfBirth;
            TelephoneNumber = _telephoneNumber;
        }


        public void toText()
        {
            Console.WriteLine(
                $"Name: {Name}, Surname: {Surname}, Email: {Email}, Birth Date: {DateOfBirth:dd/MM/yyyy}, Number: {TelephoneNumber}");
        }
    }
}
