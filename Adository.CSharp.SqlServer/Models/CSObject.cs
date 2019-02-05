using System;

namespace Adository.CSharp.SqlServer.Models
{
    public class CSObject : TextBase
    {
        protected CSClassModifier ClassModifier { get; set; }

        public string Modifier
        {
            get
            {
                switch (ClassModifier)
                {
                    case CSClassModifier.Public:
                        return "public";
                    case CSClassModifier.PublicPartial:
                        return "public partial";
                    case CSClassModifier.PublicSealed:
                        return "public sealed";
                    case CSClassModifier.PublicAbstract:
                        return "public abstract";
                    case CSClassModifier.Internal:
                        return "internal";
                    case CSClassModifier.InternalSealed:
                        return "internal sealed";
                    case CSClassModifier.InternalAbstract:
                        return "internal abstract";
                    case CSClassModifier.Static:
                        return "static";
                    default:
                        throw new Exception("Undefined modifier");
                }
            }
        }
        public string Name { get; set; }

        public CSObject(string name, CSClassModifier modifier = CSClassModifier.Public)
        {
            this.ClassModifier = modifier;
            this.Name = name;
        }
    }
}
