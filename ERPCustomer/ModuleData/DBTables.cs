using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPFramework.Data;

namespace ERPCustomer.ModuleData
{
    public class CustomerTable : Table
    {
        public static string Name = "APP_Customer";

        public static Column<CustomerTable, int> ID = new Column<CustomerTable, int>("ID", Properties.Resources.T_ID) { EnableNull = false };
        public static Column<CustomerTable, string> Description = new Column<CustomerTable, string>("Text", LEN.BIG_DESCRIPTION, Properties.Resources.T_Description);
        public static Column<CustomerTable, string> Address = new Column<CustomerTable, string>("Address", 128);
        public static Column<CustomerTable, string> ZipCode = new Column<CustomerTable, string>("ZipCode", 5);
        public static Column<CustomerTable, string> City = new Column<CustomerTable, string>("City", 35);
        public static Column<CustomerTable, string> County = new Column<CustomerTable, string>("County", 2);

        public static Column<CustomerTable, string> Phone1 = new Column<CustomerTable, string>("Phone1", LEN.CODE);
        public static Column<CustomerTable, string> Phone2 = new Column<CustomerTable, string>("Phone2", LEN.CODE);
        public static Column<CustomerTable, string> Email = new Column<CustomerTable, string>("Email", LEN.DESCRIPTION);

        public override IColumn[] PrimaryKey { get { return new IColumn[] { ID }; } }
        public new static IColumn ForeignKey = ID;

        public CustomerTable()
        {
            VisibleInRadar(new IColumn[] { ID, Description });
            Tablename = Name;
        }
    }
}
