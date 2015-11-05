using System;
using System.Windows.Forms;

namespace Attribute.ChatSpeaker
{
    public partial class MainForm : Form
    {
        #region [-- CONSTRUCTORS --]

        public MainForm()
        {
            this.InitializeComponent();
        }

        #endregion


        #region [-- EVENT HANDLERS --]

        private void _exitButtonFileMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
