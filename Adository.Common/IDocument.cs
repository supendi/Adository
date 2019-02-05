namespace Adository.Common
{
    public interface IDocument
    {
        string Name { get; set; }
        void Save(string fileName);
        string GetSourceCode();
    }
}
