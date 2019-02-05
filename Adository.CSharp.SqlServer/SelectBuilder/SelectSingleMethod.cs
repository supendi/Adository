using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.SelectBuilder
{
    public class SelectSingleMethod : CSMethod
    {
        public SelectSingleMethod(DataTable datatable, string name) : base($"{datatable.TableName}", name, CSMemberModifier.PublicVirtual)
        {
        }
    }
}
