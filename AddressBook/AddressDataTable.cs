using System;
using System.Collections.Generic;
using System.Data;
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

            // uc-3
            table.Rows.Add("Rahul ", "Gowda", "2nd cross Ramnagar Nagar", "Mysore", "Karnataka", "580082", "8123351458", "rahul@gmail.com");
            table.Rows.Add("Ravi ", "Kumar", "3nd cross", "Bangalore", "Karnataka", "800078", "934747358", "ravi@gmail.com");
            table.Rows.Add("Asha", "Kumari", "4nd cross Indira Nagar", "Bangalore", "Karnataka", "580003", "1234567896", "asha@gmail.com");
            table.Rows.Add("Porvi", "Shetty", "2nd cross", "Mandya", "Karnataka", "560078", "0987654321", "porvi@gmail.com");
            table.Rows.Add("Raja", "M", "2nd cross Rajaji Nagar", "Gadag", "Karnataka", "570006", "0987654321", "raja@gmail.com");

            return table;
        }

        // uc-4
        public void DisplayContacts(EnumerableRowCollection<DataRow> recordedData)
        {
            Console.WriteLine($"{new string('-', 139)}");
            Console.WriteLine($"|{"FirstName",15} | {"LastName",10} | {"Address",20} | {"City",10} | {"State",10} | {"Zip",20} | {"PhoneNumber",15} | {"Email",15} |");
            Console.WriteLine($"{new string('-', 139)}");
            foreach (var list in recordedData)
            {
                Console.WriteLine($"|{list.Field<string>("FirstName"),10} | {list.Field<string>("LastName"),10} | {list.Field<string>("Address"),20} | {list.Field<string>("City"),10} | {list.Field<string>("State"),10} | {list.Field<string>("Zip"),10} | {list.Field<string>("PhoneNumber"),15} | {list.Field<string>("Email"),15} |");
            }
            Console.WriteLine($"{new string('-', 139)}\n");
        }

        public void EditContact(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("FirstName") == "Rahul ");
            foreach (var contact in contacts)
            {
                contact.SetField("LastName", "Das");
                contact.SetField("City", "Mumbai");
                contact.SetField("State", "Maharashtra");
                contact.SetField("Zip", "43254");
            }

            Console.WriteLine("The Contact is updated succesfully\n");
            DisplayContacts(contacts);
        }
    }
}
