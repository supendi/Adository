using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.SelectBuilder
{
    public class SelectMethod : CSMethod
    {
        public SelectMethod(DataTable datatable, string name) : base($"List<{datatable.TableName}>", name, CSMemberModifier.PublicVirtual)
        {
        }
    }
}
