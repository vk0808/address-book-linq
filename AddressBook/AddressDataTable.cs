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
    }
}
