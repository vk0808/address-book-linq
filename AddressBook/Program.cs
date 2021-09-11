using System;
using System.Data;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Address Book Program\n");

            // uc-1
            AddressDataTable addressBook = new AddressDataTable();
            DataTable dataTable = addressBook.AddressBookDataTable();

            // uc-4
            addressBook.EditContact(dataTable);
        }
    }
}
