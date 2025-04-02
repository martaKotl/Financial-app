using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer.DataAccessObject;
using DataAccessLayer;

namespace Finanse_Domowe
{
    public partial class FrmUploadFile : Form
    {
        public FrmUploadFile()
        {
            InitializeComponent();
        }

        public int bankStatementIdBank = -1;
        public string bankStatementFilePath = string.Empty;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        UploadFileDAO fileDAO = new UploadFileDAO();

        private void btnSave_Click(object sender, EventArgs e)
        {
            bankStatementIdBank = cmbBankName.SelectedIndex + 1;

            if (bankStatementFilePath == "")
            {
                DialogResult result = MessageBox.Show("Nie wybrales pliku do wczytania. Czy chcesz kontynuować?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    FrmBankStatement frm = new FrmBankStatement();
                    this.Close();
                    //frm.MdiParent = FrmMain.ActiveForm;
                    frm.ShowDialog();
                }
            }

            else
            {
                if (bankStatementIdBank == -1)
                    MessageBox.Show("Musisz wybrac konto bankowe");
                else
                {
                    fileDAO.CreateFile(bankStatementFilePath, bankStatementIdBank);
                    FrmBankStatement frm = new FrmBankStatement();
                    frm.isBankStatementNew = true;
                    this.Close();
                    //frm.MdiParent = FrmMain.ActiveForm;
                    frm.ShowDialog();
                }
            }
        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bankStatementFilePath = openFileDialog.FileName;
            }
        }

        private void FrmUploadFile_Load(object sender, EventArgs e)
        {
            cmbBankName.DataSource = BankDAO.GetBanks();
            cmbBankName.DisplayMember = "Name";
            cmbBankName.ValueMember = "ID";
            cmbBankName.SelectedIndex = -1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
