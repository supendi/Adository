using System;

namespace Adository.VB.SqlServer.Models
{
    public class TextBase
    {
        public string NewLine
        {
            get
            {
                return Environment.NewLine;
            }
        }

        public int MultiplyIndent { get; set; }

        public string Indent
        {
            get
            {
                var tab = "    ";
                for (int i = 0; i < MultiplyIndent; i++)
                {
                    tab += tab;
                }
                return tab;
            }
        }

        public string Quotes
        {
            get
            {
                return @"""";
            }
        }

        public TextBase()
        {
            MultiplyIndent = 0;
        }

        public string GetSourceCode()
        {
            return ToString();
        }
    }
}
