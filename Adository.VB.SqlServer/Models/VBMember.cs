using System;

namespace Adository.VB.SqlServer.Models
{
    public class VBMember : TextBase
    {
        protected VBMemberModifier MemberModifier { get; set; }

        public string Modifier
        {
            get
            {
                switch (MemberModifier)
                {
                    case VBMemberModifier.Dim:
                        return "Public";
                    case VBMemberModifier.Private:
                        return "Private";
                    case VBMemberModifier.Protected:
                        return "Protected";
                    case VBMemberModifier.ProtectedOverridable:
                        return "Protected Overridable";
                    case VBMemberModifier.ProtectedOverrides:
                        return "Protected Overrides";
                    case VBMemberModifier.Friend:
                        return "Friend";
                    case VBMemberModifier.FriendOverridable:
                        return "Friend Virtual";
                    case VBMemberModifier.FriendOverrides:
                        return "Friend Overrides";
                    case VBMemberModifier.Public:
                        return "Public";
                    case VBMemberModifier.PublicOverridable:
                        return "Public Overridable";
                    case VBMemberModifier.PublicOverrides:
                        return "Public Overrides";
                    default:
                        throw new Exception("Undefined member modifier");
                }
            }
        }
        public string Type { get; set; }
        public string Name { get; set; }

        public VBMember(string type, string name, VBMemberModifier modifier = VBMemberModifier.Public)
        {
            this.MemberModifier = modifier;
            this.Type = type;
            this.Name = name;
        }
    }
}
