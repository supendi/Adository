namespace Adository.VB.SqlServer.Models
{
    public class VBField : VBMember
    {
        public VBField(string type, string name, VBMemberModifier modifier = VBMemberModifier.Private) : base(type, name, modifier) { }

        public override string ToString()
        {
            return $"{Modifier} {Name} As {Type}";
        }
    }
}
