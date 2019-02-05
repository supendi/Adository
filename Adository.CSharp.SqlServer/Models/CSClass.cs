using System.Collections.Generic;

namespace Adository.CSharp.SqlServer.Models
{
    public class CSClass : CSObject
    {
        public List<string> Statements { get; set; }
        public List<CSField> Fields { get; set; }
        public List<CSProperty> Properties { get; set; }
        public List<CSClassConstructor> Constructors { get; set; }
        public List<CSMethod> Methods { get; set; }
        public string InheritsFrom { get; set; }

        public CSClass(string name, CSClassModifier modifier = CSClassModifier.Public) : base(name, modifier)
        {
            Fields = new List<CSField>();
            Properties = new List<CSProperty>();
            Methods = new List<CSMethod>();
            Constructors = new List<CSClassConstructor>();
            Statements = new List<string>();
        }

        public override string ToString()
        {
            string classHeader = (string.IsNullOrEmpty(InheritsFrom)) ? $"{Modifier} class {Name}" : $"{Modifier} class {Name} : {InheritsFrom}"; //public class Brand
            var classBlock = new CSBlock(classHeader);

            //Generate field
            foreach (var statement in Statements)
            {
                classBlock.Statements.Add(statement);
            }

            //Generate field
            foreach (var field in Fields)
            {
                classBlock.Statements.Add(field.ToString());
            }

            //Generate properties
            foreach (var prop in Properties)
            {
                classBlock.Statements.Add(prop.ToString());
            }

            //Generate generate Constructor
            foreach (var ctor in Constructors)
            {
                ctor.Name = this.Name;
                classBlock.Statements.Add(ctor.ToString());
            }

            //Generate methods
            foreach (var method in Methods)
            {
                classBlock.Statements.Add(method.ToString());
            }

            return $"{classBlock.ToString()}";
        }
    }

    public class CSClassConstructor : TextBase
    {
        public string Name { get; set; }
        public List<CSArgument> Args { get; set; }
        public List<string> Statements { get; set; }
        public string baseClassConstructorParameter { get; set; }

        public CSClassConstructor(string baseClassConstructorParameter = "")
        {
            Args = new List<CSArgument>();
            Statements = new List<string>();
            this.baseClassConstructorParameter = baseClassConstructorParameter;
        }

        private string CreateArgs()
        {
            var args = string.Empty;

            foreach (var arg in Args)
            {
                args += $"{arg.Type} {arg.Name}, ";
            }
            args = (Args.Count == 0) ? "" : args.Substring(0, args.Length - 2);


            args = $"({args})";

            return args;
        }

        public override string ToString()
        {
            var header = $"public {Name}{CreateArgs()}";
            if (!string.IsNullOrEmpty(baseClassConstructorParameter))
            {
                header += $" : base({baseClassConstructorParameter})";
            }
            var ctorBlock = new CSBlock(header);
            //ctorBlock.MultiplyIndent = 1;

            foreach (var code in Statements)
            {
                ctorBlock.Statements.Add(code);
            }

            return ctorBlock.ToString();
        }
    }
}
