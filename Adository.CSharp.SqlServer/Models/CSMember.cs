using System;

namespace Adository.CSharp.SqlServer.Models
{
    public class CSMember : TextBase
    {
        protected CSMemberModifier MemberModifier { get; set; }

        public string Modifier
        {
            get
            {
                switch (MemberModifier)
                {
                    case CSMemberModifier.Private:
                        return "private";
                    case CSMemberModifier.Protected:
                        return "protected";
                    case CSMemberModifier.ProtectedVirtual:
                        return "protected virtual";
                    case CSMemberModifier.ProtectedOverride:
                        return "protected override";
                    case CSMemberModifier.Internal:
                        return "internal";
                    case CSMemberModifier.InternalVirtual:
                        return "internal virtual";
                    case CSMemberModifier.InternalOverride:
                        return "internal override";
                    case CSMemberModifier.Public:
                        return "public";
                    case CSMemberModifier.PublicVirtual:
                        return "public virtual";
                    case CSMemberModifier.PublicOverride:
                        return "public override";
                    default:
                        throw new Exception("Undefined modifier");
                }
            }
        }
        public string Type { get; set; }
        public string Name { get; set; }

        public CSMember(string type, string name, CSMemberModifier modifier = CSMemberModifier.Public)
        {
            this.MemberModifier = modifier;
            this.Type = type;
            this.Name = name;
        }
    }

    public class CSField : CSMember
    {
        public CSField(string type, string name, CSMemberModifier modifier = CSMemberModifier.Private) : base(type, name, modifier) { }

        public override string ToString()
        {
            return $"{Modifier} {Type} {Name};";
        }
    }

    public class CSProperty : CSMember
    {
        public CSProperty(string type, string name, CSMemberModifier modifier = CSMemberModifier.Public) : base(type, name, modifier) { }

        public override string ToString()
        {
            return $"{Modifier} {Type} {Name}" + " { get; set; }";
        }
    }
}
