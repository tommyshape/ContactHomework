using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    internal class Application
    {
        private readonly List<Contact> _contacts = new();

        

        public void AddPerson(int index = -1)
        {
            if (index == -1)
            {
                Console.WriteLine("New contact will be added\n Please fill the form");
            }

            Console.WriteLine("Enter name : ");
            var name = Console.ReadLine();

            Console.WriteLine("Enter surname : ");
            var surname = Console.ReadLine();

            Console.WriteLine("Enter email : ");
            var email = Console.ReadLine();

            Console.WriteLine("Enter birth date as dd-MM-yyyy : ");
            var dateOfBirth =
                Convert.ToDateTime(DateTime.ParseExact(Console.ReadLine()!, "dd-MM-yyyy",
                    CultureInfo.InvariantCulture));

            Console.WriteLine("Enter telephone number : ");
            var telephoneNumber = Convert.ToInt64(Console.ReadLine());

            var contact = new Contact(name, surname, email, dateOfBirth, telephoneNumber);

            if (index == -1)
            {
                _contacts.Add(contact);
                Console.WriteLine("Contact added successfully !");
            }
            else
            {
                _contacts[index] = contact;
                Console.WriteLine("Contact edited successfully !");
            }
        }

        public void PrintAllContacts()
        {
            Console.WriteLine("Printing  all contacts -> -> -> ");
            for (var i = 0; i < _contacts.Count; i++)
            {
                Console.Write($"{i + 1}-)");
                _contacts[i].toText();
            }
        }

        public void CheckBirthday()
        {
            foreach (var contact in _contacts)
            {
                if (dateWithin(contact.DateOfBirth))
                {
                    contact.toText();
                }
            }
        }
        public Application()
        {
            var contact1 = new Contact("Person_1_Info", "Person_1_Info", "Person_1_Info",
                DateTime.ParseExact("01-01-1000", "dd-MM-yyyy", CultureInfo.InvariantCulture), 1);
            var contact2 = new Contact("Person_2_Info", "Person_2_Info", "Person_2_Info",
                DateTime.ParseExact("01-01-1000", "dd-MM-yyyy", CultureInfo.InvariantCulture), 2);
            var contact3 = new Contact("Person_3_Info", "Person_3_Info", "Person_3_Info",
                DateTime.ParseExact("01-01-1000", "dd-MM-yyyy", CultureInfo.InvariantCulture), 3);
            var contact4 = new Contact("Person_4_Info", "Person_4_Info", "Person_4_Info",
                DateTime.ParseExact("01-01-1000", "dd-MM-yyyy", CultureInfo.InvariantCulture), 4);
            var contact5 = new Contact("Person_5_Info", "Person_5_Info", "Person_5_Info",
                DateTime.ParseExact("01-01-1000", "dd-MM-yyyy", CultureInfo.InvariantCulture), 5);
            var contact6 = new Contact("Person_6_Info", "Person_6_Info", "Person_6_Info",
                DateTime.ParseExact("01-01-1000", "dd-MM-yyyy", CultureInfo.InvariantCulture), 6);

            _contacts.Add(contact1);
            _contacts.Add(contact2);
            _contacts.Add(contact3);
            _contacts.Add(contact4);
            _contacts.Add(contact5);
            _contacts.Add(contact6);
        }

        private static bool dateWithin(DateTime contactDate)
        {
            var startDateOfWeek = DateTime.Now.Date;
            var missingYears = startDateOfWeek.Year - contactDate.Year;
            var checkDate = contactDate.AddYears(missingYears);

            while (startDateOfWeek.DayOfWeek != DayOfWeek.Monday)
            {
                startDateOfWeek = startDateOfWeek.AddDays(-1d);
            }

            var toDate = startDateOfWeek.AddDays(6d);

            return checkDate >= startDateOfWeek && checkDate <= toDate;
        }

        public void EditPerson()
        {
            var selection = -1;
            var hasError = false;
            PrintAllContacts();
            Console.Write("Please select the contact you want to edit :");
            
            selection = Convert.ToInt32(Console.ReadLine()) - 1;
            if (selection >= _contacts.Count && selection != -1)
            {
                throw new IndexOutOfRangeException();
            }
            
            if (!hasError)
            {
                AddPerson(selection);
            }
        }

        public void DeletePerson()
        {
            var selection = -1;
            var isError = false;
            PrintAllContacts();
            Console.Write("Please select the contact you want to delete :");
            try
            {
                selection = Convert.ToInt32(Console.ReadLine()) - 1;
                if (selection >= _contacts.Count || selection < 0)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                isError = true;
                //throw;
            }

            if (isError) return;
            _contacts.RemoveAt(selection);
        }


        public void SearchAll()
        {
            var selection = -1;

            Console.WriteLine();
            Console.WriteLine("1-) Search by Name");
            Console.WriteLine("2-) Search by Surname");
            Console.WriteLine("3-) Search by Email");
            Console.WriteLine("4-) Search by Birth Date");
            Console.WriteLine("5-) Search by Telephone Number");
            Console.WriteLine();

            
            selection = Convert.ToInt32(Console.ReadLine());
            if (selection >= 6 || selection <= 0)
            {
                throw new Exception();
            }
            
            

            switch (selection)
            {
                case 1:
                    SearchByName();
                    break;
                case 2:
                    SearchBySurname();
                    break;
                case 3:
                    SearchByEmail();
                    break;
                case 4:
                    SearchByBirthDate();
                    break;
                case 5:
                    SearchByTelNumber();
                    break;
                default:
                    Console.WriteLine("Please select only numbers according to menu !");
                    break;
            }
        }

        private void SearchByName()
        {
            Console.WriteLine("Enter the name you want to search for: ");
            string name;
            try
            {
                name = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            foreach (var contact in _contacts.Where(contact => contact.Name == name))
            {
                contact.toText();
            }
        }

        private void SearchBySurname()
        {
            Console.WriteLine("Enter the surname you want to search for: ");
            string surname;

            try
            {
                surname = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            foreach (var contact in _contacts.Where(contact => contact.Surname == surname))
            {
                contact.toText();
            }
        }

        private void SearchByEmail()
        {
            Console.WriteLine("Enter the email you want to search for: ");
            string email;

            try
            {
                email = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("email not found" + e);
                return;
            }

            foreach (var contact in _contacts.Where(contact => contact.Email == email))
            {
                contact.toText();
            }
        }

        private void SearchByTelNumber()
        {
            Console.WriteLine("Enter the telephone number you want to search for: ");
            long number;

            try
            {
                number = Convert.ToInt64(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            foreach (var contact in _contacts.Where(contact => contact.TelephoneNumber == number))
            {
                contact.toText();
            }
        }

        private void SearchByBirthDate()
        {
            Console.WriteLine("Enter the birth date as 'dd-MM-yyyy' you want to search for: ");
            DateTime date;

            try
            {
                date = Convert.ToDateTime(DateTime.ParseExact(Console.ReadLine()!, "dd-MM-yyyy",
                    CultureInfo.InvariantCulture));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            foreach (var contact in _contacts.Where(contact => contact.DateOfBirth == date))
            {
                contact.toText();
            }
        }
    }
}
