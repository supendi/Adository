using Adository.VB.SqlServer.Models;
using System.Data;

namespace Adository.VB.SqlServer.SelectBuilder
{
    public class SelectMethod : VBMethod
    {
        public SelectMethod(DataTable datatable, string name) : base($"List(Of {datatable.TableName})", name, MethodType.Function, VBMemberModifier.PublicOverridable)
        {
        }
    }
}
