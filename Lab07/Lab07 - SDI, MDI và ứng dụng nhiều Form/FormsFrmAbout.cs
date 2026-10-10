using System;
using System.Windows.Forms;

namespace ShopManagerMini.Forms
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }
    }
}