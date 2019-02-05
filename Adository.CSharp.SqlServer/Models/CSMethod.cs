using System.Collections.Generic;

namespace Adository.CSharp.SqlServer.Models
{
    public class CSMethod : CSMember
    {
        public List<CSArgument> MethodArgs { get; set; }
        public List<string> Statements { get; set; }

        public CSMethod(string type, string name, CSMemberModifier modifier = CSMemberModifier.Public) : base(type, name, modifier)
        {
            MethodArgs = new List<CSArgument>();
            Statements = new List<string>();
        }

        private string CreateArgs()
        {
            var args = string.Empty;

            foreach (var arg in MethodArgs)
            {
                args += $"{arg.Type} {arg.Name}, ";
            }
            args = (MethodArgs.Count == 0) ? "" : args.Substring(0, args.Length - 2);


            args = $"({args})";

            return args;
        }

        public override string ToString()
        {
            var result = string.Empty;
            var methodHeader = $"{Modifier} {Type} {Name}{CreateArgs()}";
            var methodBlock = new CSBlock(methodHeader);

            foreach (var statement in Statements)
            {
                methodBlock.Statements.Add(statement);
            }

            return methodBlock.ToString();
        }
    }
}
