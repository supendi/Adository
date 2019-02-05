using System.Collections.Generic;

namespace Adository.VB.SqlServer.Models
{
    public enum MethodType
    {
        Sub,
        Function
    }

    public class VBMethod : VBMember
    {
        public List<VBArgument> MethodArgs { get; set; }
        public List<string> Statements { get; set; }
        public MethodType MethodType { get; set; }

        public VBMethod(string type, string name, MethodType methodType, VBMemberModifier modifier = VBMemberModifier.Public) : base(type, name, modifier)
        {
            MethodArgs = new List<VBArgument>();
            Statements = new List<string>();
            MethodType = methodType;
        }

        private string CreateArgs()
        {
            var args = string.Empty;

            foreach (var arg in MethodArgs)
            {
                args += $"ByVal {arg.Name} As {arg.Type}, ";
            }
            args = (MethodArgs.Count == 0) ? "" : args.Substring(0, args.Length - 2);

            args = $"({args})";

            return args;
        }

        public override string ToString()
        {
            var result = string.Empty;
            var methodHeader = string.Empty;
            if (MethodType == MethodType.Sub)
            {
                methodHeader = $"{Modifier} {MethodType.ToString()} {Name}{CreateArgs()}";
            }
            else
            {
                methodHeader = $"{Modifier} {MethodType.ToString()} {Name}{CreateArgs()} As {Type}";
            }
            var methodBlock = new VBBlock(MethodType == MethodType.Sub ? VBBlockStatement.Sub : VBBlockStatement.Function, methodHeader);

            foreach (var statement in Statements)
            {
                methodBlock.Statements.Add(statement);
            }

            return methodBlock.ToString();
        }
    }
}
