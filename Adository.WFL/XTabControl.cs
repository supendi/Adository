using System;
using System.Drawing;
using System.Windows.Forms;

namespace Adository.WFL
{
    public class XTabControl : TabControl
    {
        #region Fields
        private Form activeFormChild;

        private bool createLineForSelectedTab = true;

        private Color lineColorForSelectedTab = Color.Gold;

        private bool closeable = true;

        private int currentTabIndex = 0;
        #endregion

        #region Properties
        public Form ActiveForm
        {
            get
            {
                if (this.SelectedTab != null && this.SelectedTab.Controls[0] is Form)
                    return this.SelectedTab.Controls[0] as Form;
                return null;
            }
        }
        public bool Closeable
        {
            get
            {
                return closeable;
            }
            set
            {
                closeable = value;
            }
        }

        public bool CreateLineForSelectedTab
        {
            get
            {
                return createLineForSelectedTab;
            }
            set
            {
                createLineForSelectedTab = value;
            }
        }

        public Color LineColorForSelectedTab
        {
            get
            {
                return lineColorForSelectedTab;
            }
            set
            {
                lineColorForSelectedTab = value;
            }
        }
        #endregion

        #region Constructor
        public XTabControl() : base()
        {
            SetTabPadding();
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.ControlRemoved += PendTabControl_ControlRemoved;
            this.ControlAdded += PendTabControl_ControlAdded;
            this.KeyDown += PendTabControl_KeyDown;
        }

        #endregion

        #region Events 
        private void PendTabControl_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (this.SelectedTab != null) this.TabPages.Remove(this.SelectedTab);
            if (this.TabPages.Count == 0) this.Visible = false;
        }

        private void PendTabControl_ControlAdded(object sender, ControlEventArgs e)
        {
            if (!this.Visible)
                this.Visible = true;
        }

        private void PendTabControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.SelectedTab != null)
                if (e.KeyCode == Keys.W && e.Control)
                    this.TabPages.Remove(this.SelectedTab);
        }
        #endregion

        #region Methods : Override
        /// <summary>
        /// Resize form child
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (this.TabPages.Count > 0)
            {

            }
            RefreshFormSize();
        }

        /// <summary>
        /// Resize form child
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);

            if (this.TabPages.Count == 0)
            {
                //this.Visible = false;
                // throw new NotImplementedException("Coba ente nilai sekarang cocok ga di visible false kalau tabnya kosong.");
            }
            RefreshFormSize();
            if (this.SelectedTab != null && this.SelectedTab.Controls.Count > 0)
            {
                //activeFormChild = this.SelectedTab.Controls[0] as Form;
                this.SelectedTab.Controls[0].Select();
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            #region Handling Tab Text Refresh
            foreach (Control ctl in this.SelectedTab.Controls)
            {
                if (ctl is Form)
                {
                    this.SelectedTab.Text = ctl.Text;
                    break;
                }
            }
            #endregion
        }

        /// <summary>
        /// Draw tab text, button close.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {

            base.OnDrawItem(e);

            DrawSelectedTabHeaderBg(e);

            DrawTabTitleText(this, e);

            DrawTabCloseButton(e);
            e.DrawFocusRectangle();
            DrawLineForSelectedTab(e);

        }

        /// <summary>
        /// Close tab on mouse up
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            CloseTab(this, e);
            base.OnMouseUp(e);
        }

        #endregion

        #region Methods : Custom
        /// <summary>
        /// Fitur baru untuk open form ke dalam tab control, form akan dibuka didalam tabpage
        /// </summary>
        /// <param name="frm">Form yang akan dibuka</param>
        /// <param name="alwaysInNewTab">Jika true, maka form akan dibuka di new tab meskipun sudah ada form yang sama yang telah dibuka, jika false maka jika ada form yang sudah dibuka maka akan select tabpagenya saja</param>
        public void OpenForm(Form frm, bool alwaysInNewTab)
        {
            this.Visible = true;
            if (!alwaysInNewTab)
            {
                if (this.TabPages.Count > 0)
                {
                    foreach (TabPage tabs in this.TabPages)
                    {
                        foreach (Control ctl in tabs.Controls)
                        {
                            if (ctl is Form)
                            {
                                if (ctl.GetType() == frm.GetType())
                                {
                                    this.SelectedTab = tabs;
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Minimized;
            frm.WindowState = FormWindowState.Maximized;

            TabPage tab = new TabPage(frm.Text);
            tab.Controls.Add(frm);
            this.TabPages.Add(tab);
            frm.Show();
            this.SelectedTab = tab;
            RefreshFormSize();
        }

        /// <summary>
        /// Fitur baru untuk open form ke dalam tab control, form akan dibuka didalam tabpage
        /// </summary>
        /// <param name="frm">Form yang akan dibuka</param>
        /// <param name="alwaysInNewTab">Jika true, maka form akan dibuka di new tab meskipun sudah ada form yang sama yang telah dibuka, jika false maka jika ada form yang sudah dibuka maka akan select tabpagenya saja</param>
        public void OpenFormInSelectedTab(Form frm)
        {
            if (this.SelectedTab == null) return;

            this.Visible = true;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Minimized;
            frm.WindowState = FormWindowState.Maximized;

            TabPage tab = this.SelectedTab;
            tab.Text = frm.Text;
            tab.Controls.Add(frm);
            frm.Show();
            this.SelectedTab = tab;
            RefreshFormSize();
        }

        /// <summary>
        /// Kadang kadang form yang ada sebagai control di tabpage, tidak terdraw dengan baik. maka di set manual
        /// </summary>
        private void RefreshFormSize()
        {
            if (this.TabPages.Count > 0)
            {
                if (this.SelectedTab == null) return;
                foreach (Control ctl in this.SelectedTab.Controls)
                {
                    if (ctl == null) continue;
                    if (ctl is Form)
                    {
                        Form childForm = (Form)ctl;
                        childForm.WindowState = FormWindowState.Normal;
                        childForm.WindowState = FormWindowState.Maximized;
                        break;
                        //childForm.Height = this.SelectedTab.Height;
                        //childForm.Width = this.SelectedTab.Width;
                        //childForm.Refresh();
                    }
                }
            }
        }

        /// <summary>
        /// Karena DrawMode = TabDrawMode.OwnerDrawFixed, maka tab text tidak akan muncul dan harus di draw manual
        /// </summary>
        /// <param name="tabControl"></param>
        /// <param name="e"></param>
        private void DrawTabTitleText(TabControl tabControl, DrawItemEventArgs e)
        {
            e.Graphics.DrawString(tabControl.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
        }

        /// <summary>
        /// Bikin button close tab yaitu 'x' pada tab page
        /// </summary>
        /// <param name="e"></param>
        private void DrawTabCloseButton(DrawItemEventArgs e)
        {
            if (Closeable)
            {
                e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
            }
        }

        private void DrawLineForSelectedTab(DrawItemEventArgs e)
        {
            if (createLineForSelectedTab && this.TabPages.Count > 0)
            {
                Rectangle r = this.GetTabRect(this.SelectedIndex);
                e.Graphics.FillRectangle(new SolidBrush(lineColorForSelectedTab), r.X + 1, r.Y, r.Width - 3, 2);
            }
        }

        private void DrawSelectedTabHeaderBg(DrawItemEventArgs e)
        {
            if (this.SelectedIndex == -1) return;

            Rectangle r = this.GetTabRect(this.SelectedIndex);
            e.Graphics.FillRectangle(Brushes.White, r);
        }

        /// <summary>
        /// Padding berfungsi memberi jarak antara tab text dengan string 'x' atau button close
        /// </summary>
        /// <param name="tabControl"></param>
        private void SetTabPadding()
        {
            this.Padding = new System.Drawing.Point(21, 3);
        }


        /// <summary>
        /// Close tab, jika mouse position berada di area string x atau button close
        /// </summary>
        /// <param name="tabControl"></param>
        /// <param name="e"></param>
        private void CloseTab(TabControl tabControl, MouseEventArgs e)
        {
            if (Closeable)
            {
                //Looping through the controls.
                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    Rectangle r = tabControl.GetTabRect(i);
                    //Getting the position of the "x" mark.
                    Rectangle closeButton = new Rectangle(r.Right - 14, r.Top + 4, 10, 10);
                    if (closeButton.Contains(e.Location))
                    {
                        foreach (Control ctl in this.SelectedTab.Controls)
                        {
                            #region PR UNTUK HANDLING KALAU FORM CLOSING E.CANCEL
                            if (ctl is Form)
                            {
                                currentTabIndex = i;

                                activeFormChild = (Form)ctl;
                                activeFormChild.FormClosed += FrmToBeClosed_FormClosed;
                                activeFormChild.Close(); //Tabpage diremove setelah form benar2 close, karena takutnya mau di handling waktu form closing
                                break;
                            }
                            #endregion

                            //ctl.Dispose();
                        }
                    }
                }
            }
        }

        private void FrmToBeClosed_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.TabPages.RemoveAt(this.SelectedIndex);//gagal close semua tab jika ada yang di cancel
            //this.TabPages.Remove(this.SelectedTab);//gagal juga close semua tab jika ada yang di cancel
            if (activeFormChild.Parent != null)
            {
                var currentTab = (TabPage)activeFormChild.Parent;

                this.TabPages.Remove(currentTab);
                if (activeFormChild != null)
                    activeFormChild.Dispose();
                if (currentTabIndex > 0)
                    this.SelectedIndex = currentTabIndex - 1;
            }
        }
        #endregion
    }
}
