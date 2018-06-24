using ERPCustomer.ModuleData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPCustomer.Forms
{
    public partial class customerForm : ERPFramework.Forms.DocumentForm
    {
        public customerForm()
        {
            InitializeComponent();
        }

        protected override void OnInitializeData()
        {
            dbManager = new DBManagerCustomer("userForm", this);
            dbManager.AttachRadar<RadarCustomer>();
            dbManager.AddMaster<CustomerTable>();
        }
    }
}
