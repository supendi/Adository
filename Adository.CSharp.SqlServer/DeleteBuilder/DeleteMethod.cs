using Adository.CSharp.SqlServer.Models;

namespace Adository.CSharp.SqlServer.DeleteBuilder
{
    public class DeleteMethod : CSMethod
    {
        public DeleteMethod(string name) : base($"void", name, CSMemberModifier.PublicVirtual)
        {
        }
    }
}
