using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finanse_Domowe
{
    public partial class FrmTransactionHistoryTimePicker : Form
    {
        public FrmTransactionHistoryTimePicker()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value >= dtpTo.Value)
                MessageBox.Show("Podany przedział czasowy nie istnieje");
            else
            {
                FrmTransactionHistory frm = new FrmTransactionHistory();
                frm.transactionDateFrom = dtpFrom.Value;
                frm.transactionDateTo = dtpTo.Value;
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTransactionHistoryTimePicker_Load(object sender, EventArgs e)
        {
            dtpFrom.CustomFormat = "MMMM yyyy";
            dtpTo.CustomFormat = "MMMM yyyy";
            dtpTo.Value = DateTime.Today;
        }
    }
}
