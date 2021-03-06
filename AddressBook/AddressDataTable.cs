using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AddressBook
{
    class AddressDataTable
    {
        // uc-1
        public DataTable AddressBookDataTable()
        {
            DataTable table = new DataTable();

            // uc-2
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("City", typeof(string));
            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Zip", typeof(string));
            table.Columns.Add("PhoneNumber", typeof(string));
            table.Columns.Add("Email", typeof(string));
            // uc-9
            table.Columns.Add("BookName", typeof(string));
            table.Columns.Add("BookType", typeof(string));

            // uc-3
            table.Rows.Add("Rahul", "Gowda", "2nd cross Ramnagar Nagar", "Mysore", "Karnataka", "580082", "8123351458", "rahul@gmail.com", "Book1", "Friends");
            table.Rows.Add("Ravi", "Kumar", "3nd cross", "Bangalore", "Karnataka", "800078", "934747358", "ravi@gmail.com", "Book2", "Family");
            table.Rows.Add("Asha", "Kumari", "4nd cross Indira Nagar", "Bangalore", "Karnataka", "580003", "1234567896", "asha@gmail.com", "Book1", "Friends");
            table.Rows.Add("Porvi", "Shetty", "2nd cross", "Mandya", "Karnataka", "560078", "0987654321", "porvi@gmail.com", "Book2", "Family");
            table.Rows.Add("Raja", "M", "2nd cross Rajaji Nagar", "Gadag", "Karnataka", "570006", "0987654321", "raja@gmail.com", "Book3", "Profession");

            return table;
        }

        // uc-4
        public void DisplayContacts(EnumerableRowCollection<DataRow> recordedData)
        {
            Console.WriteLine($"{new string('-', 129)}");
            Console.WriteLine($"|{"FirstName",10} | {"LastName",10} | {"Address",25} | {"City",10} | {"State",10} | {"Zip",10} | {"PhoneNumber",15} | {"Email",15} |");
            Console.WriteLine($"{new string('-', 129)}");
            foreach (var list in recordedData)
            {
                Console.WriteLine($"|{list.Field<string>("FirstName"),10} | {list.Field<string>("LastName"),10} | {list.Field<string>("Address"),25} | {list.Field<string>("City"),10} | {list.Field<string>("State"),10} | {list.Field<string>("Zip"),10} | {list.Field<string>("PhoneNumber"),15} | {list.Field<string>("Email"),15} |");
            }
            Console.WriteLine($"{new string('-', 129)}\n");
        }

        public void DisplayContacts(List<DataRow> recordedData)
        {
            Console.WriteLine($"{new string('-', 129)}");
            Console.WriteLine($"|{"FirstName",10} | {"LastName",10} | {"Address",25} | {"City",10} | {"State",10} | {"Zip",10} | {"PhoneNumber",15} | {"Email",15} |");
            Console.WriteLine($"{new string('-', 129)}");
            foreach (var list in recordedData)
            {
                Console.WriteLine($"|{list.Field<string>("FirstName"),10} | {list.Field<string>("LastName"),10} | {list.Field<string>("Address"),25} | {list.Field<string>("City"),10} | {list.Field<string>("State"),10} | {list.Field<string>("Zip"),10} | {list.Field<string>("PhoneNumber"),15} | {list.Field<string>("Email"),15} |");
            }
            Console.WriteLine($"{new string('-', 129)}\n");
        }

        public void EditContact(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("FirstName") == "Rahul");
            foreach (var contact in contacts)
            {
                contact.SetField("LastName", "Das");
                contact.SetField("City", "Mumbai");
                contact.SetField("State", "Maharashtra");
                contact.SetField("Zip", "43254");
            }

            Console.WriteLine("\nThe Contact is updated succesfully: ");
            DisplayContacts(contacts);
        }

        // uc-5
        public void DeleteContact(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("FirstName") == "Ravi");
            foreach (var row in contacts.ToList())
            {
                row.Delete();
            }
            Console.WriteLine("\nThe Contact is deleted succesfully: ");
            DisplayContacts(table.AsEnumerable());
        }

        // uc-6
        public void RetrieveByCityOrState(DataTable table)
        {
            string cityState = "Maharashtra";
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("State") == cityState);
            Console.WriteLine($"\nThe Contacts with state = {cityState}.");
            DisplayContacts(contacts);
        }

        // uc-7
        public void GetSizeOfCityOrState(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>()
                             .GroupBy(x => x["State"].Equals("Karnataka")).Count();
            Console.WriteLine("Karnataka : {0} ", contacts);
        }

        // uc-8
        public void SortContacts(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>()
                           .OrderBy(x => x.Field<string>("FirstName"))
                           .ToList();
            Console.WriteLine("\nThe Contacts are sorted succesfully: ");
            DisplayContacts(contacts);
        }

        // uc-10
        public void GetCountByType(DataTable table)
        {
            var friendsCount = table.Rows.Cast<DataRow>()
                                         .Where(x => x["BookType"].Equals("Friends")).Count();
            var familyCount = table.Rows.Cast<DataRow>()
                             .Where(x => x["BookType"].Equals("Family")).Count();
            var ProfessionalCount = table.Rows.Cast<DataRow>()
                             .Where(x => x["BookType"].Equals("Profession")).Count();
            Console.WriteLine($"'Friends' : {friendsCount}");
            Console.WriteLine($"'Family' : {familyCount}");
            Console.WriteLine($"'Profession' : {ProfessionalCount}");
        }
    }
}
