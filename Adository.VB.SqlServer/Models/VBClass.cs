using System.Collections.Generic;

namespace Adository.VB.SqlServer.Models
{
    public class VBClass : VBObject
    {
        public List<string> Statements { get; set; }
        public List<VBField> Fields { get; set; }
        public List<VBProperty> Properties { get; set; }
        public List<VBClassConstructor> Constructors { get; set; }
        public List<VBMethod> Methods { get; set; }
        public string InheritsFrom { get; set; }

        public VBClass(string name, VBClassModifier modifier = VBClassModifier.Public) : base(name, modifier)
        {
            Fields = new List<VBField>();
            Properties = new List<VBProperty>();
            Methods = new List<VBMethod>();
            Constructors = new List<VBClassConstructor>();
            Statements = new List<string>();
        }

        public override string ToString()
        {
            string classHeader = (string.IsNullOrEmpty(InheritsFrom)) ? $"{Modifier} Class {Name}" : $"{Modifier} Class {Name} {NewLine} Inherits {InheritsFrom}"; //public class Brand
            var classBlock = new VBBlock(VBBlockStatement.Class, classHeader);

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

    public class VBClassConstructor : TextBase
    {
        public string Name { get; set; }
        public List<VBArgument> Args { get; set; }
        public List<string> Statements { get; set; }
        public string BaseClassConstructorParameter { get; set; }

        public VBClassConstructor(string baseClassConstructorParameter = "")
        {
            Args = new List<VBArgument>();
            Statements = new List<string>();
            this.BaseClassConstructorParameter = baseClassConstructorParameter;
        }

        private string CreateArgs()
        {
            var args = string.Empty;

            foreach (var arg in Args)
            {
                args += $"ByVal {arg.Name} As {arg.Type}, ";
            }
            args = (Args.Count == 0) ? "" : args.Substring(0, args.Length - 2);


            args = $"({args})";

            return args;
        }

        public override string ToString()
        {
            var header = $"Public Sub New{CreateArgs()}";
           
            var ctorBlock = new VBBlock(VBBlockStatement.Sub, header);
            if (!string.IsNullOrEmpty(BaseClassConstructorParameter))
            {
                ctorBlock.Statements.Add($"MyBase.New({BaseClassConstructorParameter})");
            }

            foreach (var code in Statements)
            {
                ctorBlock.Statements.Add(code);
            }

            return ctorBlock.ToString();
        }
    }
}
