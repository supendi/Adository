using System;
using System.Windows.Forms;

namespace Adository
{
    public partial class LauncherForm : Form
    {
        Language SelectedLanguage
        {
            get
            {
                return (csRadio.Checked == true) ? Language.CS : Language.VB;
            }
        }
        public LauncherForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            switch (SelectedLanguage)
            {
                case Language.CS:
                    new CSharp.UI.Main.MainForm().Show();
                    break;
                case Language.VB:
                    new VB.UI.Main.MainForm().Show();
                    break;
                default:
                    break;
            }
        }
    }

    enum Language
    {
        CS,
        VB
    }
}
