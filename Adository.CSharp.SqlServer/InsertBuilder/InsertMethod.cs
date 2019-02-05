using Adository.CSharp.SqlServer.Models;

namespace Adository.CSharp.SqlServer.InsertBuilder
{
    public class InsertMethod : CSMethod
    {
        public InsertMethod() : base($"void", "NewRecord", CSMemberModifier.PublicVirtual)
        {
        }
    }
}
