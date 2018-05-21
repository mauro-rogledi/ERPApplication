using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    protected override string CreateMasterQuery(ref List<SqlProxyParameter> dParam)
    {
        var qB = new QueryBuilder();

        return qB.SelectAllFrom<CustomerTable>().
            Where(CustomerTable.ID).IsEqualTo(dParam[0]).
            Query;
    }

    protected override List<SqlProxyParameter> CreateMasterParam()
    {
        var PList = new List<SqlProxyParameter>();

        var sParam1 = new SqlProxyParameter("@p1", CustomerTable.ID) { Value = CustomerTable.ID.DefaultValue };
        PList.Add(sParam1);
        return PList;
    }

    protected override void SetParameters(ERPFramework.Controls.IRadarParameters key, DBCollection collection)
    {
        collection.Parameter[0].Value = key[0];
    }
}
    #endregion
}