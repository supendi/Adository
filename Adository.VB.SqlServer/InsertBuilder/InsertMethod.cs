using Adository.VB.SqlServer.Models;

namespace Adository.VB.SqlServer.InsertBuilder
{
    public class InsertMethod : VBMethod
    {
        public InsertMethod() : base($"", "NewRecord", MethodType.Sub, VBMemberModifier.PublicOverridable)
        {
        }
    }
}
