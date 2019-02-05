using System.Collections.Generic;

namespace Adository.VB.SqlServer.Models
{
    public enum VBBlockStatement
    {
        If,
        For,
        ForEach,
        Switch,
        Using,
        Class,
        Function,
        Sub,
        Namespace
    }

    public class VBBlock : TextBase
    {
        private string braceIndent
        {
            get
            {
                if (MultiplyIndent == 0)
                    return string.Empty;
                var tab = "    ";
                for (int i = 0; i < multiplyBraceIndent; i++)
                {
                    tab += tab;
                }
                return tab;
            }
        }

        private int multiplyBraceIndent
        {
            get
            {
                if (MultiplyIndent > 0)
                    return MultiplyIndent - 1;

                return 0;
            }
        }

        public List<string> Statements { get; set; }
        public string BlockHeader { get; set; }
        protected VBBlockStatement VBBlockStatement { get; set; }
        public string EndOfBlock
        {
            get
            {
                switch (VBBlockStatement)
                {
                    case VBBlockStatement.If:
                        return "End If";
                    case VBBlockStatement.For:
                        return "Next";
                    case VBBlockStatement.ForEach:
                        return "Next";
                    case VBBlockStatement.Switch:
                        return "End Switch";
                    case VBBlockStatement.Using:
                        return "End Using";
                    case VBBlockStatement.Class:
                        return "End Class";
                    case VBBlockStatement.Function:
                        return "End Function";
                    case VBBlockStatement.Sub:
                        return "End Sub";
                    case VBBlockStatement.Namespace:
                        return "End Namespace";
                    default:
                        throw new System.Exception("Undefined");
                }
                 
            }
        }
        public VBBlock(VBBlockStatement vBBlockStatement, string blockHeader = "")
        {
            Statements = new List<string>();
            BlockHeader = blockHeader;
            VBBlockStatement = vBBlockStatement;
        }

        private string Build()
        {
            var statementResult = string.Empty;

            foreach (var statement in Statements)
            {
                var statements = statement.Split(NewLine.ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);
                foreach (var lineOfStatement in statements)
                    statementResult += $"{Indent}{lineOfStatement}{NewLine}";

            }
            statementResult = statementResult.Length > 1 ? statementResult.Substring(0, statementResult.Length - 1) : string.Empty;

            var blockHeader = (BlockHeader == string.Empty) ? string.Empty : $"{BlockHeader}";
            return $"{braceIndent}{blockHeader}{NewLine}{braceIndent}{NewLine}{statementResult}{EndOfBlock}";
        }

        public override string ToString()
        {
            return Build();
        }
    }
}
