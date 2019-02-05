namespace Adository.VB.SqlServer.Models
{
    public class VBArgument
    {
        public string Type { get; set; }
        public string Name { get; set; }
        protected string OptionalValue { get; set; }

        public VBArgument(string type, string name, string optionalValue = "")
        {
            Type = type;
            Name = name;
            OptionalValue = optionalValue;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(OptionalValue))
                return $"Optional ByVal {this.Name} As {this.Type} = {OptionalValue}";
            return $"ByVal {this.Name} As {this.Type}";
        }
    }
}
