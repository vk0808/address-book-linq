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

            // uc-5
            addressBook.DeleteContact(dataTable);

            // uc-6
            addressBook.RetrieveByCityOrState(dataTable);

            // uc-7
            addressBook.GetSizeOfCityOrState(dataTable);

            // uc-8
            addressBook.SortContacts(dataTable);

            // uc-10
            addressBook.GetCountByType(dataTable);
        }
    }
}
