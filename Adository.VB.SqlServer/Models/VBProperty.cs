namespace Adository.VB.SqlServer.Models
{
    public class VBProperty : VBMember
    {
        public VBProperty(string type, string name, VBMemberModifier modifier = VBMemberModifier.Public) : base(type, name, modifier) { }

        public override string ToString()
        {
            // Public Overridable Property Id As Integer
            return $"{Modifier} Property {Name} As {Type}";
        }
    }
}
