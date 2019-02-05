using Adository.Common;
using System.Collections.Generic;
using System.IO;

namespace Adository.CSharp.SqlServer.Models
{
    public class CSDocument : TextBase, IDocument
    {
        public List<CSNamespace> Namespaces { get; set; }
        public string Name { get; set; }
        public string ProjectName { get; set; }

        public CSDocument(string name, string projectName)
        {
            Namespaces = new List<CSNamespace>();
            Name = name;
            ProjectName = projectName;
        }

        public virtual void SetupProjectFile()
        {
        }

        public override string ToString()
        {
            return Build();
        }

        private string Build()
        {
            var nsBody = string.Empty;
            SetupUsingNamespacePlacement();

            foreach (var ns in Namespaces)
            {
                nsBody += $"{ns.ToString()}{NewLine}";
            }

            nsBody = nsBody.Length > 0 ? nsBody.Substring(0, nsBody.Length - 1) : string.Empty;

            return $"{nsBody}";
        }

        //Kalau namespace block lebih dari 1 dalam suatu dokumen, using namespace harus dimasukin kedalam block ns. Kalau ga, error
        private void SetupUsingNamespacePlacement()
        {
            if (Namespaces.Count > 1)
                foreach (var ns in Namespaces)
                {
                    ns.PutIncludeNamespaceOutside = false;
                }
        }

        public void Save(string fileName)
        {
            //string fileName = $@"{folderName}\{FileName}.cs";
            SetupProjectFile();
            File.WriteAllText(fileName, ToString());
        }
    }
}
