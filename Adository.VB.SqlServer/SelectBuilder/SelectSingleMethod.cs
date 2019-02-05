using Adository.VB.SqlServer.Models;
using System.Data;

namespace Adository.VB.SqlServer.SelectBuilder
{
    public class SelectSingleMethod : VBMethod
    {
        public SelectSingleMethod(DataTable datatable, string name) : base($"{datatable.TableName}", name, MethodType.Function, VBMemberModifier.PublicOverridable)
        {
        }
    }
}
