using System.Collections.Generic;

namespace Adository.CSharp.SqlServer.Models
{
    public class CSNamespace : TextBase
    {
        public bool PutIncludeNamespaceOutside;
        public string Name { get; set; }

        public List<string> IncludeNamespaces { get; set; }
        public List<CSClass> Classes { get; set; }

        public CSNamespace(string name, bool includeStandardNamespaces = true, bool putIncludeNamespaceOutside = true)
        {
            Name = name;
            Classes = new List<CSClass>();
            IncludeNamespaces = new List<string>();
            this.PutIncludeNamespaceOutside = putIncludeNamespaceOutside;

            if (includeStandardNamespaces)
            {
                IncludeNamespaces.Add("using System;");
                IncludeNamespaces.Add("using System.Collections.Generic;");
                IncludeNamespaces.Add("using System.Linq;");
                IncludeNamespaces.Add("using System.Text;");
                IncludeNamespaces.Add("using System.Threading.Tasks;");
            }
        }

        public override string ToString()
        {
            var includedNamespaces = string.Empty;
            var nsBody = string.Empty;

            foreach (var includeNs in IncludeNamespaces)
            {
                includedNamespaces += includeNs + NewLine;
            }

            includedNamespaces += NewLine;

            var nsBlock = new CSBlock($"namespace {Name}");
            if (!PutIncludeNamespaceOutside)
            {
                nsBlock.Statements.Add(includedNamespaces);
            }

            foreach (var cls in Classes)
            {
                nsBlock.Statements.Add(cls.ToString());
            }
            var finalSource = nsBlock.ToString();
            if (PutIncludeNamespaceOutside)
            {
                finalSource = includedNamespaces + finalSource;
            }

            return finalSource;
        }
    }
}
