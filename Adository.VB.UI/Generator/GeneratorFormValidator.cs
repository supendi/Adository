using Pend.WFL;

namespace Adository.VB.UI.Generator
{
    class GeneratorFormValidator
    { 
        public static bool Validate(string dbName, string projectName, string nsName, string projectFolder)
        {
            if (string.IsNullOrEmpty(dbName))
            {
                MsgBox.ShowError("Selected database is required.");
                return false;
            }
            if (string.IsNullOrEmpty(projectName))
            {
                MsgBox.ShowError("Project name is required.");
                return false;
            }
            if (string.IsNullOrEmpty(nsName))
            {
                MsgBox.ShowError("Namespace name is required.");
                return false;
            }
            if (string.IsNullOrEmpty(projectFolder))
            {
                MsgBox.ShowError("Project folder is required.");
                return false;
            }
            return true;
        }
    }
}
