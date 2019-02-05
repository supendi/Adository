using Adository.VB.SqlServer.Models;

namespace Adository.VB.SqlServer.UpdateBuilder
{
    public class UpdateMethod : VBMethod
    {
        public UpdateMethod(string name) : base($"", name, MethodType.Sub, VBMemberModifier.PublicOverridable)
        {
        }
    }
}
