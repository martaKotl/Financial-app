using DataAccessLayer.DataAccessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer.DataTransferObject;

namespace Finanse_Domowe
{
    public partial class FrmBankStatement : Form
    {
        public FrmBankStatement()
        {
            InitializeComponent();
        }

        public bool isBankStatementNew = false;
        BankStatementDAO bankStatement = new BankStatementDAO();

        BankStatementDetailsDTO selectedBankStatement = new BankStatementDetailsDTO();

        private void FrmBankStatement_Load(object sender, EventArgs e)
        {
            dataGridViewBankStatement.AllowUserToAddRows = false;
            if (isBankStatementNew)
                bankStatement.SaveDataToBankStatementDatabase();

            FillAllData();
        }

        private void FillAllData()
        {
            DataView dv = BankStatementDAO.DisplayBankStatementAndTransactionsInDataGridView();

            dataGridViewBankStatement.DataSource = dv;
            dataGridViewBankStatement.Columns[0].Visible = false;
            dataGridViewBankStatement.Columns[1].HeaderText = "Data transakcji";
            dataGridViewBankStatement.Columns[2].Visible = false;
            dataGridViewBankStatement.Columns[3].HeaderText = "Nazwa konta";
            dataGridViewBankStatement.Columns[4].HeaderText = "Kwota";
            dataGridViewBankStatement.Columns[5].HeaderText = "Opis";
            dataGridViewBankStatement.Columns[6].Visible = false;
            dataGridViewBankStatement.Columns[7].HeaderText = "Cel wydatku";
            dataGridViewBankStatement.Columns[8].Visible = false;
            dataGridViewBankStatement.Columns[9].HeaderText = "Źródło przychodu";
            dataGridViewBankStatement.Columns[10].HeaderText = "Flaga";

            RowsColor();
        }

        private void RowsColor()
        {
            for (int i = 0; i < dataGridViewBankStatement.Rows.Count - 1; i++)
            {
                string val = dataGridViewBankStatement.Rows[i].Cells[10].Value.ToString();
                if (val == "t")
                    dataGridViewBankStatement.Rows[i].DefaultCellStyle.BackColor = Color.SlateGray;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BankStatementDTO bankStatement = new BankStatementDTO();
            bankStatement = BankStatementDAO.GetAll();
            bool flag = false;
            foreach (var item in bankStatement.BankStatementDetailsDTOs)
            {
                if (item.RevenueSourcesId == null && item.PurposeOfExpenseId == null)
                {
                    MessageBox.Show("Dodaj kategorię do transakcji z dnia " + item.DateOfTransaction.ToString("dd.MM.yyyy"));
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                BankStatementDAO.AddBankStatementToTransaction();
                BankStatementDAO.DeleteAllRecordFromBankStatement();
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BankStatementDAO.DeleteBankStatement(selectedBankStatement.BankStatementId);
            FillAllData();
        }

        private void dataGridViewBankStatement_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectedBankStatement.BankStatementId = Convert.ToInt32(dataGridViewBankStatement.Rows[e.RowIndex].Cells[0].Value);
            selectedBankStatement.DateOfTransaction = Convert.ToDateTime(dataGridViewBankStatement.Rows[e.RowIndex].Cells[1].Value);
            selectedBankStatement.BankId = Convert.ToInt32(dataGridViewBankStatement.Rows[e.RowIndex].Cells[2].Value);
            selectedBankStatement.BankName = dataGridViewBankStatement.Rows[e.RowIndex].Cells[3].Value.ToString();
            selectedBankStatement.Amount = Convert.ToDouble(dataGridViewBankStatement.Rows[e.RowIndex].Cells[4].Value);
            selectedBankStatement.Description = dataGridViewBankStatement.Rows[e.RowIndex].Cells[5].Value.ToString();
            selectedBankStatement.Flag = dataGridViewBankStatement.Rows[e.RowIndex].Cells[10].Value.ToString();
            if (dataGridViewBankStatement.Rows[e.RowIndex].Cells[6].Value != DBNull.Value)
            {
                selectedBankStatement.PurposeOfExpenseId = Convert.ToInt32(dataGridViewBankStatement.Rows[e.RowIndex].Cells[6].Value);
                selectedBankStatement.PurposeOfExpenseName = dataGridViewBankStatement.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            else if (dataGridViewBankStatement.Rows[e.RowIndex].Cells[8].Value != DBNull.Value)
            {
                selectedBankStatement.RevenueSourcesId = Convert.ToInt32(dataGridViewBankStatement.Rows[e.RowIndex].Cells[8].Value);
                selectedBankStatement.RevenueSourcesName = dataGridViewBankStatement.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
            else 
            {
                selectedBankStatement.PurposeOfExpenseId = null;
                selectedBankStatement.PurposeOfExpenseName = null;
                selectedBankStatement.RevenueSourcesId = null;
                selectedBankStatement.RevenueSourcesName = null;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedBankStatement.BankStatementId == 0)
                MessageBox.Show("Wybierz wyciąg z listy");
            else if (selectedBankStatement.Flag == "t")
                MessageBox.Show("Nie możesz edytować transakcji.\nJeśli chcesz to zrobić wejdz w Historie transakcji");
            else
            {
                FrmTransaction frm = new FrmTransaction();
                frm.bankStatementIsUpdate = true;
                frm.bankStatementDetails = selectedBankStatement;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                FillAllData();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
