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

        public static Column<int> ID             = new Column<int>("ID", Properties.Resources.T_ID) { EnableNull = false };
        public static Column<string> Description = new Column<string>("Text", LEN.BIG_DESCRIPTION, Properties.Resources.T_Description);
        public static Column<string> Address     = new Column<string>("Address", 128);
        public static Column<string> ZipCode     = new Column<string>("ZipCode", 5);
        public static Column<string> City        = new Column<string>("City", 35);
        public static Column<string> County      = new Column<string>("County", 2);

        public static Column<string> Phone1      = new Column<string>("Phone1", LEN.CODE);
        public static Column<string> Phone2      = new Column<string>("Phone2", LEN.CODE);
        public static Column<string> Email       = new Column<string>("Email", LEN.DESCRIPTION);

        public override IColumn[] PrimaryKey { get { return new IColumn[] { ID }; } }
        public new static IColumn ForeignKey = ID;

        public CustomerTable()
        {
            VisibleInRadar(new IColumn[] { ID, Description });
            Tablename = Name;
        }
    }
}
