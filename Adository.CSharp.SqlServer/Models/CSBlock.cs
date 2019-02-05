using System.Collections.Generic;

namespace Adository.CSharp.SqlServer.Models
{
    /// <summary>
    /// Represent block: '{ [LineOfCodes] }'
    /// </summary>
    public class CSBlock : TextBase
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

        public CSBlock(string blockHeader = "")
        {
            Statements = new List<string>();
            BlockHeader = blockHeader;
        }

        private string Build()
        {
            var statementResult = string.Empty;

            foreach (var statement in Statements)
            {
                var statements = statement.Split(NewLine.ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);
                foreach (var lineOfStatement in statements)
                {
                    statementResult += $"{Indent}{lineOfStatement}{NewLine}";
                }
            }
            statementResult = statementResult.Length > 1 ? statementResult.Substring(0, statementResult.Length - 1) : string.Empty;

            var blockHeader = (BlockHeader == string.Empty) ? string.Empty : $"{BlockHeader}";
            return $"{braceIndent}{blockHeader}{NewLine}{braceIndent}{{{NewLine}{statementResult}{braceIndent}}}";
        }

        public override string ToString()
        {
            return Build();
        }
    }
}
