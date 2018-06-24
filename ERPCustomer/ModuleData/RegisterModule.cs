using ERPFramework;
using ERPFramework.Data;
using System;

namespace ERPCustomer.ModuleData
{
    internal class RegisterModule : ERPFramework.Data.RegisterModule
    {
        public override string Module()
        {
            return "ERPC";
        }

        public override int CurrentVersion()
        {
            return 1;
        }

        public override Version DllVersion
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        public override void RegisterCountersAndCodes()
        {
            //GlobalInfo.AddCounter(Counters.Descriptions.Int(), Properties.Resources.CN_Descriptions);
            GlobalInfo.AddCounter(Counters.Masters.Int(), Properties.Resources.CN_Customer);
        }

        public override void Addon(ERPFramework.Forms.IDocument frm, ERPFramework.NameSpace nameSpace)
        {
        }

        public override ERPFramework.Preferences.PreferencePanel[] RegisterPreferences()
        {
            return new ERPFramework.Preferences.PreferencePanel[]
            {
                //new MastersPreferencePanel("")
            };
        }

        protected override bool CreateDBTables()
        {
            AddTable<CustomerTable>();

            return true;
        }

        protected override bool UpdateDBTables()
        {
            if (dbVersion < 2)
            {
                if (!SqlProxyDatabaseHelper.SearchColumn(CustomerTable.Email, GlobalInfo.SqlConnection))
                {
                    SqlCreateTable.AlterTable<CustomerTable>();
                    SqlCreateTable.AddColumn(CustomerTable.Email);
                    SqlCreateTable.Alter();
                }
            }

            return true;
        }
    }
}
