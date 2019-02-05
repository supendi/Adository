namespace Adository.CSharp.SqlServer.Models
{
    /// <summary>
    /// Represent argument: 'string name', 'int number'
    /// </summary>
    public class CSArgument
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public CSArgument(string type, string name)
        {
            Type = type;
            Name = name;
        }

        public override string ToString()
        {
            return this.Type + " " + this.Name;
        }
    }
}
