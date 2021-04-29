using System;

namespace Contact
{
    internal class Program
    {
        private static readonly Application App = new();
        private static bool Runon = true;

        static void Main(string[] args)
        {
            Application_Main_Program();
        }

        private static void Application_Main_Program()
        {
            while (Runon)
            {
                int cursor;

                
                Console.WriteLine("___________________________________________________");
                Console.WriteLine("Please select the operation you want to perform : ");
                Console.WriteLine();
                Console.WriteLine("1-) Add new contact");
                Console.WriteLine("2-) Print out all contacts");
                Console.WriteLine("3-) Check current week's birth dates");
                Console.WriteLine("4-) Edit contact");
                Console.WriteLine("5-) Delete contact");
                Console.WriteLine("6-) Search contacts");
                Console.WriteLine("7-) Exit program\n");
                Console.WriteLine("___________________________________________________");

                cursor = Convert.ToInt32(Console.ReadLine());

                switch (cursor)
                {
                    case 1:
                        App.AddPerson();
                        break;
                    case 2:
                        App.PrintAllContacts();
                        break;
                    case 3:
                        App.CheckBirthday();
                        break;
                    case 4:
                        App.EditPerson();
                        break;
                    case 5:
                        App.DeletePerson();
                        break;
                    case 6:
                        App.SearchAll();
                        break;
                    case 7:
                        Runon = false;
                        Console.WriteLine("Closing console ...");
                        break;

                    default:
                        Console.WriteLine("wrong number cursor");
                        break;
                }
            }
        }
    }
}
