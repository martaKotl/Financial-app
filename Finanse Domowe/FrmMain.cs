using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finanse_Domowe
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
        }

        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            FrmTransaction frm = new FrmTransaction();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnTransactionHistory_Click(object sender, EventArgs e)
        {
            FrmTransactionHistoryTimePicker frm = new FrmTransactionHistoryTimePicker();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz zamknąć program?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                this.Close();
        }

        private void btnBankStatement_Click(object sender, EventArgs e)
        {
            FrmUploadFile frm = new FrmUploadFile();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }
    }
}
