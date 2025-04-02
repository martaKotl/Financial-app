using DataAccessLayer.DataTransferObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using DataAccessLayer.DataAccessObject;

namespace Finanse_Domowe
{
    public partial class FrmTransactionHistory : Form
    {
        public FrmTransactionHistory()
        {
            InitializeComponent();
        }

        TransactionDTO transactionDTO = new TransactionDTO();
        public DateTime transactionDateFrom = new DateTime();
        public DateTime transactionDateTo = new DateTime();
        List<BankDTO> bankList = BankDAO.GetBanks();
        List<RevenueSourceDTO> revenueSourceList = RevenueSourceDAO.GetRevenueSources();
        List<PurposeOfExpenseDTO> purposeOfExpenseList = PurposeOfExpenseDAO.GetPurposeOfExpense();

        TransactionDetailsDTO currentlySelectedTransaction = new TransactionDetailsDTO();

        private void updateCurrentTransactionnfo()
        {
            int rowIndex = dataGridViewTransactionHistory.CurrentCell.RowIndex;
            var selectedRow = dataGridViewTransactionHistory.Rows[rowIndex];
            currentlySelectedTransaction.TranscationId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            currentlySelectedTransaction.DateOfTransaction = Convert.ToDateTime(selectedRow.Cells["Date"].Value);
            currentlySelectedTransaction.BankId = Convert.ToInt32(selectedRow.Cells["Id_Bank"].Value);
            currentlySelectedTransaction.Amount = Convert.ToDouble(selectedRow.Cells["Amount"].Value);
            currentlySelectedTransaction.Description = selectedRow.Cells["Description"].Value?.ToString();
            if (selectedRow.Cells["Id_Revenue_Source"].Value == DBNull.Value)
                currentlySelectedTransaction.RevenueSourcesId = null;
            else
                currentlySelectedTransaction.RevenueSourcesId = Convert.ToInt32(selectedRow.Cells["Id_Revenue_Source"].Value);
            if (selectedRow.Cells["Id_Purpose_Of_Expense"].Value == DBNull.Value)
                currentlySelectedTransaction.PurposeOfExpenseId = null;
            else
                currentlySelectedTransaction.PurposeOfExpenseId = Convert.ToInt32(selectedRow.Cells["Id_Purpose_Of_Expense"].Value);
            currentlySelectedTransaction.AccountBalance = Convert.ToDouble(selectedRow.Cells["Account_Balance"].Value);
        }

        void FillAllData()
        {
            transactionDTO = TransactionDAO.GetAll(transactionDateFrom, transactionDateTo);

            cmbFiltersBankName.DataSource = bankList;
            cmbFiltersBankName.DisplayMember = "NAME";
            cmbFiltersBankName.ValueMember = "ID";
            cmbFiltersBankName.SelectedIndex = -1;
            cmbFiltersRevenurSourceName.DataSource = revenueSourceList;
            cmbFiltersRevenurSourceName.DisplayMember = "NAME";
            cmbFiltersRevenurSourceName.ValueMember = "ID";
            cmbFiltersRevenurSourceName.SelectedIndex = -1;
            cmbFiltersPurposeOfExpenseName.DataSource = purposeOfExpenseList;
            cmbFiltersPurposeOfExpenseName.DisplayMember = "NAME";
            cmbFiltersPurposeOfExpenseName.ValueMember = "ID";
            cmbFiltersPurposeOfExpenseName.SelectedIndex = -1;
            dateTimePickerFrom.Value = transactionDateFrom;
            dateTimePickerTo.Value = transactionDateTo;


            DataView dv = TransactionDAO.DisplayTransactionsInDataGridView(transactionDateFrom.ToString("yyyy.MM.dd"), transactionDateTo.ToString("yyyy.MM.dd"));

            dataGridViewTransactionHistory.DataSource = dv;
            dataGridViewTransactionHistory.Columns[0].Visible = false;
            dataGridViewTransactionHistory.Columns[1].HeaderText = "Data transakcji";
            dataGridViewTransactionHistory.Columns[2].Visible = false;
            dataGridViewTransactionHistory.Columns[3].HeaderText = "Nazwa konta";
            dataGridViewTransactionHistory.Columns[4].HeaderText = "Kwota";
            dataGridViewTransactionHistory.Columns[5].HeaderText = "Opis";
            dataGridViewTransactionHistory.Columns[6].Visible = false;
            dataGridViewTransactionHistory.Columns[7].HeaderText = "Cel wydatku";
            dataGridViewTransactionHistory.Columns[8].Visible = false;
            dataGridViewTransactionHistory.Columns[9].HeaderText = "Źródło przychody";
            dataGridViewTransactionHistory.Columns[10].HeaderText = "Stan konta";
        }

        private void ClearFilters()
        {
            cmbFiltersBankName.SelectedIndex = -1;
            cmbFiltersPurposeOfExpenseName.SelectedIndex = -1;
            cmbFiltersRevenurSourceName.SelectedIndex = -1;
            dateTimePickerFrom.Value = transactionDateFrom;
            dateTimePickerTo.Value = transactionDateTo;
            txtFiltersDescription.Text = null;
            Array.Clear(TransactionDAO.filters, 0, TransactionDAO.filters.Length);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            updateCurrentTransactionnfo();
            if (currentlySelectedTransaction.TranscationId == 0)
                MessageBox.Show("Wybierz transakcje którą chcesz edytować z listy ");
            else
            {
                FrmTransaction frm = new FrmTransaction();

                frm.transactionIsUpdate = true;
                frm.transactionDetails = currentlySelectedTransaction;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                FillAllData();
                ClearFilters();
            }
        }

        private void FrmTransactionHistory_Load(object sender, EventArgs e)
        {
            dataGridViewTransactionHistory.AllowUserToAddRows = false;
            FillAllData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            updateCurrentTransactionnfo();
            if (currentlySelectedTransaction.TranscationId == 0)
                MessageBox.Show("Wybierz transakcje którą chcesz usunąć z listy ");
            else
            {
                TransactionDAO.DeleteTransaction(currentlySelectedTransaction.TranscationId);
                FillAllData();
            }
        }

        private void btnFiltersSearch_Click(object sender, EventArgs e)
        {
            string[] filteredTransactions = new string[4];

            if (dateTimePickerFrom.Value != transactionDateFrom)
                transactionDateFrom = dateTimePickerFrom.Value;
            if (dateTimePickerTo.Value != transactionDateTo)
                transactionDateTo = dateTimePickerTo.Value;
            if (cmbFiltersBankName.SelectedIndex != -1)
                filteredTransactions[0] = (cmbFiltersBankName.SelectedValue).ToString();
            if (cmbFiltersRevenurSourceName.SelectedIndex != -1)
                filteredTransactions[1] = (cmbFiltersRevenurSourceName.SelectedValue).ToString();
            if (cmbFiltersPurposeOfExpenseName.SelectedIndex != -1)
                filteredTransactions[2] = (cmbFiltersPurposeOfExpenseName.SelectedValue).ToString();
            if (txtFiltersDescription.Text.Trim() != "")
                filteredTransactions[3] = txtFiltersDescription.Text;

            TransactionDAO.filters = filteredTransactions;

            DataView dv = TransactionDAO.DisplayTransactionsInDataGridView(transactionDateFrom.ToString("yyyy.MM.dd"), transactionDateTo.ToString("yyyy.MM.dd"));

            dataGridViewTransactionHistory.DataSource = dv;
            dataGridViewTransactionHistory.Columns[0].Visible = false;
            dataGridViewTransactionHistory.Columns[1].HeaderText = "Data transakcji";
            dataGridViewTransactionHistory.Columns[2].Visible = false;
            dataGridViewTransactionHistory.Columns[3].HeaderText = "Nazwa konta";
            dataGridViewTransactionHistory.Columns[4].HeaderText = "Kwota";
            dataGridViewTransactionHistory.Columns[5].HeaderText = "Opis";
            dataGridViewTransactionHistory.Columns[6].Visible = false;
            dataGridViewTransactionHistory.Columns[7].HeaderText = "Cel wydatku";
            dataGridViewTransactionHistory.Columns[8].Visible = false;
            dataGridViewTransactionHistory.Columns[9].HeaderText = "Źródło przychody";
            dataGridViewTransactionHistory.Columns[10].HeaderText = "Stan konta";
        }

        private void btnFiltersReset_Click(object sender, EventArgs e)
        {
            ClearFilters();
            FillAllData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
