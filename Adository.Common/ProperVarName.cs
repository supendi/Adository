using System.Linq;

namespace Adository.Common
{
    public class ProperVarName
    {
        static string[] restrictedNames = new string[]
          {
            "abstract",
            "as",
            "base",
            "bool",
            "break",
            "byte",
            "case",
            "catch",
            "char",
            "checked",
            "class",
            "const",
            "continue",
            "decimal",
            "default",
            "delegate",
            "do",
            "double",
            "else",
            "enum",
            "event",
            "explicit",
            "extern",
            "finally",
            "fixed",
            "float",
            "for",
            "foreach",
            "goto",
            "if",
            "implicit",
            "in",
            "int",
            "interface",
            "internal",
            "is",
            "lock",
            "long",
            "namespace",
            "new",
            "null",
            "object",
            "operator",
            "out",
            "override",
            "params",
            "private",
            "protected",
            "public",
            "readonly",
            "ref",
            "return",
            "sbyte",
            "sealed",
            "short",
            "sizeof",
            "stackalloc",
            "static",
            "string",
            "struct",
            "switch",
            "this",
            "throw",
            "try",
            "typeof",
            "uint",
            "ulong",
            "unchecked",
            "unsafe",
            "ushort",
            "using",
            "using static",
            "virtual",
            "void",
            "volatile",
            "while",
            "false",
            "true",
            "end",
            "End"
          };

        public static string Get(string name, bool removeSpace = true)
        {
            if (removeSpace && name.Contains(" "))
                name = name.Replace(" ", "");

            //add underscore Prefix if name equals c# keywords
            if (restrictedNames.Contains(name))
                return $"_{name}";

            return name;
        }
    }
}
