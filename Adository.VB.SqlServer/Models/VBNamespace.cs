using System.Collections.Generic;

namespace Adository.VB.SqlServer.Models
{
    public class VBNamespace : TextBase
    {
        public bool PutIncludeNamespaceOutside;
        public string Name { get; set; }

        public List<string> IncludeNamespaces { get; set; }
        public List<VBClass> Classes { get; set; }

        public VBNamespace(string name, bool includeStandardNamespaces = true, bool putIncludeNamespaceOutside = true)
        {
            Name = name;
            Classes = new List<VBClass>();
            IncludeNamespaces = new List<string>();
            this.PutIncludeNamespaceOutside = putIncludeNamespaceOutside;

            if (includeStandardNamespaces)
            {
                IncludeNamespaces.Add("Imports System");
                IncludeNamespaces.Add("Imports System.Collections.Generic");
                IncludeNamespaces.Add("Imports System.Linq");
                IncludeNamespaces.Add("Imports System.Text");
                IncludeNamespaces.Add("Imports System.Threading.Tasks");
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

            var nsBlock = new VBBlock(VBBlockStatement.Namespace, $"Namespace {Name}");
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
