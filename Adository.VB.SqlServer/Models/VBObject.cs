using System;

namespace Adository.VB.SqlServer.Models
{
    public class VBObject : TextBase
    {
        protected VBClassModifier ClassModifier { get; set; }

        public string Modifier
        {
            get
            {
                switch (ClassModifier)
                {
                    case VBClassModifier.Public:
                        return "Public";
                    case VBClassModifier.PublicPartial:
                        return "Partial Public";
                    case VBClassModifier.PublicNotInheritable:
                        return "Public NotInheritable";
                    case VBClassModifier.PublicMustInherit:
                        return "Public MustInherit";
                    case VBClassModifier.Friend:
                        return "Friend";
                    case VBClassModifier.FriendNotInheritable:
                        return "Friend NotInheritable";
                    case VBClassModifier.FriendMustInherit:
                        return "Friend MustInherit";
                    case VBClassModifier.Shared:
                        return "Shared";
                    default:
                        throw new Exception("Undefined class modifier");
                }
            }
        }
        public string Name { get; set; }

        public VBObject(string name, VBClassModifier modifier = VBClassModifier.Public)
        {
            this.ClassModifier = modifier;
            this.Name = name;
        }
    }
}
