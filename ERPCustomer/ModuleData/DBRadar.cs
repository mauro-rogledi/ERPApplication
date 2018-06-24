using ERPFramework.Controls;
using ERPFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPCustomer.ModuleData
{
    public class RadarCustomerParam : RadarParameters
    {
        public RadarCustomerParam(int id)
        {
            Add(CustomerTable.ID, id);
        }
    }

    #region RadarCodes

    public class RadarCustomer : RadarForm
    {
        private QueryBuilder qb = new QueryBuilder();

        public RadarCustomer()
            : base()
        {
            rdrCodeColumn = EF_Codes.CodeType;
            rdrDescColumn = EF_Codes.Description;
            //rdrNameSpace = new NameSpace("Plumber.Plumber.ApplicationFramework.CounterManager.codesForm");
        }

        protected override void PrepareFindParameters()
        {
            rdrParameters.Add(
                new SqlProxyParameter("@p1", CustomerTable.ID)
                );
        }

        protected override bool DefineFindQuery(SqlProxyCommand sqlCmd)
        {
            qb.Clear();
            sqlCmd.CommandText = qb
                .SelectAllFrom<CustomerTable>()
                .Where(CustomerTable.ID).IsEqualTo(rdrParameters["@p1"])
                .Query;

            return true;
        }

        protected override void PrepareFindQuery(IRadarParameters parameter)
        {
        }

        protected override void OnFound(SqlProxyDataReader sqlReader)
        {
            Description = sqlReader.GetValue<string>(CustomerTable.Description);
        }

        protected override string DefineBrowseQuery(SqlProxyCommand sqlCmd, string findQuery)
        {
            qb.Clear();
            qb.SelectAllFrom<CustomerTable>().
                AddFilter(findQuery);

            return qb.Query;
        }

        protected override void PrepareBrowseQuery()
        {
        }

        public override IRadarParameters GetRadarParameters(string text)
        {
            return new RadarCustomerParam(int.Parse(text));
        }

        protected override IRadarParameters PrepareRadarParameters(DataGridViewRow row)
        {
            return new RadarCustomerParam(row.GetValue<int>(CustomerTable.ID));
        }

        public override string GetCodeFromParameters(IRadarParameters param)
        {
            return param.GetValue<string>(CustomerTable.ID);
        }
    }

    #endregion
}
