using Adository.CSharp.SqlServer.Models;

namespace Adository.CSharp.SqlServer.UpdateBuilder
{
    public class UpdateMethod : CSMethod
    {
        public UpdateMethod(string name) : base($"void", name, CSMemberModifier.PublicVirtual)
        {
        }
    }
}
