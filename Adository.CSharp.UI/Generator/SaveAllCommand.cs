using Adository.WFL;
using System;
using System.Windows.Forms;

namespace Adository.CSharp.UI.Generator
{
    public class SaveAllCommand : GeneratorCommandBase
    {
        public SaveAllCommand(GeneratorForm form) : base(form)
        {
        }

        protected override void InitEvents()
        {
            Form.OK.Click += OnClick;
        }

        private bool IsValidInput()
        {
            return GeneratorFormValidator.Validate(Form.SelectedDatabaseName, Form.ProjectName, Form.NamespaceName, Form.ProjectFolder);
        }

        private void OnClick(object sender, EventArgs e)
        {
            SaveAll();
        }

        private void SaveAll()
        {
            if (IsValidInput())
            {
                Form.Cursor = Cursors.WaitCursor;
                AdositoryGeneratorSingleton.GetInstance().SaveAll(Form.SelectedDbNode.Name, Form.ProjectFolder, Form.ProjectName, Form.NamespaceName, Form.DbContextName);
                MsgBox.ShowInfo("Files successfully generated.");
                Form.Cursor = Cursors.Default;
                Form.Close();
            }
        }
    }
}
