using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPFramework.Controls;
using ERPFramework.Data;
using ERPFramework.Forms;

namespace ERPCustomer.ModuleData
{
    #region DBManagerCustomer
    internal class DBManagerCustomer : DBManager
    {
        public DBManagerCustomer(string name, IDocument document)
            : base(name, document)
        { }

        protected override string CreateMasterQuery(SqlProxyParameterCollection dParam)
        {
            var qB = new QueryBuilder();

            return qB.SelectAllFrom<CustomerTable>().
                Where(CustomerTable.ID).IsEqualTo(dParam["@p1"]).
                Query;
        }

        protected override void CreateMasterParam(SqlProxyParameterCollection parameters)
        {
            parameters.Add(
                new SqlProxyParameter("@p1", CustomerTable.ID)
                );
        }

        protected override void SetParameters(IRadarParameters key, DataAdapterProperties collection)
        {
            collection.Parameters["@p1"].Value = key[CustomerTable.ID];
        }
    }
    #endregion
}