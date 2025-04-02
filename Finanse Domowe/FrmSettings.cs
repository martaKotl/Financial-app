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
using DataAccessLayer.DataTransferObject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Finanse_Domowe
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        List<BankDTO> bankList = new List<BankDTO>();
        List<RevenueSourceDTO> revenueSourceList = new List<RevenueSourceDTO>();
        List<PurposeOfExpenseDTO> purposeOfExpenseList = new List<PurposeOfExpenseDTO>();

        BankDTO currentlySelectedBank = new BankDTO();
        RevenueSourceDTO currentlySelectedRevenueSource = new RevenueSourceDTO();
        PurposeOfExpenseDTO currentlySelectedPurposeOfExpense = new PurposeOfExpenseDTO();

        private void updateCurrentBankInfo()
        {
            int rowIndex = dataGridViewBank.CurrentCell.RowIndex;
            var selectedRow = dataGridViewBank.Rows[rowIndex];
            currentlySelectedBank.Id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            currentlySelectedBank.Name = selectedRow.Cells["Name"].Value?.ToString();
        }

        private void updateCurrentRevenueSourceInfo()
        {
            int rowIndex = dataGridViewRevenueSource.CurrentCell.RowIndex;
            var selectedRow = dataGridViewRevenueSource.Rows[rowIndex];
            currentlySelectedRevenueSource.Id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            currentlySelectedRevenueSource.Name = selectedRow.Cells["Name"].Value?.ToString();
            currentlySelectedRevenueSource.IsVisible = Convert.ToBoolean(selectedRow.Cells["IsVisible"].Value);
            currentlySelectedRevenueSource.DisplayOrder = Convert.ToInt32(selectedRow.Cells["DisplayOrder"].Value);
        }

        private void updateCurrentPurposeOfExpenseInfo()
        {
            
            int rowIndex = dataGridViewPurposeOfExpense.CurrentCell.RowIndex;
            var selectedRow = dataGridViewPurposeOfExpense.Rows[rowIndex];
            currentlySelectedPurposeOfExpense.Id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            currentlySelectedPurposeOfExpense.Name = selectedRow.Cells["Name"].Value?.ToString();
            currentlySelectedPurposeOfExpense.IsVisible = Convert.ToBoolean(selectedRow.Cells["IsVisible"].Value);
            currentlySelectedPurposeOfExpense.DisplayOrder = Convert.ToInt32(selectedRow.Cells["DisplayOrder"].Value);
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            bankList = BankDAO.GetBanks();
            dataGridViewBank.DataSource = bankList;
            dataGridViewBank.Columns[0].Visible = false;

            revenueSourceList = RevenueSourceDAO.GetRevenueSources();
            dataGridViewRevenueSource.DataSource = revenueSourceList;
            dataGridViewRevenueSource.Columns[0].Visible = false;

            purposeOfExpenseList = PurposeOfExpenseDAO.GetPurposeOfExpense();
            dataGridViewPurposeOfExpense.DataSource = purposeOfExpenseList;
            dataGridViewPurposeOfExpense.Columns[0].Visible = false;
        }

        private void btnAddBank_Save_Click(object sender, EventArgs e)
        {
            if (txtAddBank_Name.Text.Trim() == "")
            {
                MessageBox.Show("Musisz podac nazwe banku");
            }
            else if (txtAddBank_AccountAmount.Text.Trim() == "")
            {
                MessageBox.Show("Musisz podac aktualny stan konta");
            }

            else
            {
                var lastBankRecord = bankList.Last();

                BankDTO bank = new BankDTO();
                bank.Id = lastBankRecord.Id + 1;
                bank.Name = txtAddBank_Name.Text;
                BankDAO.AddBank(bank);
                txtAddBank_Name.Clear();
                txtAddBank_AccountAmount.Clear();
                bankList = BankDAO.GetBanks();
                dataGridViewBank.DataSource = bankList;
            }
        }

        private void btnEditBank_Save_Click(object sender, EventArgs e)
        {
            updateCurrentBankInfo();

            if (currentlySelectedBank.Id == 0)
                MessageBox.Show("Wybierz bank którego nazwe chcesz zmienić");
            else
            {
                if (txtEditBank_NewName.Text == "")
                    MessageBox.Show("Musisz podać nową nazwe konta");
                else
                {
                    currentlySelectedBank.Name = txtEditBank_NewName.Text;
                    BankDAO.UpdateBank(currentlySelectedBank);
                    bankList = BankDAO.GetBanks();
                    dataGridViewBank.DataSource = bankList;
                    txtEditBank_NewName.Clear();
                }

            }
        }

        private void btnDeleteBank_Save_Click(object sender, EventArgs e)
        {
            updateCurrentBankInfo();

            BankDAO.DeleteBank(currentlySelectedBank.Id);

            bankList = BankDAO.GetBanks();
            dataGridViewBank.DataSource = bankList;
        }

        private void btnEditRevenueSource_Save_Click(object sender, EventArgs e)
        {
            updateCurrentRevenueSourceInfo();

            if (currentlySelectedRevenueSource.Id == 0)
                MessageBox.Show("Wybierz kategorie której nazwe chcesz zmienić");
            else
            {
                if (txtEditRevenueSource_NewName.Text == "")
                    MessageBox.Show("Musisz podać nową nazwe kategorii");
                
                currentlySelectedRevenueSource.Name = txtEditRevenueSource_NewName.Text;
                RevenueSourceDAO.UpdateRevenueSource(currentlySelectedRevenueSource);
                revenueSourceList = RevenueSourceDAO.GetRevenueSources();
                dataGridViewRevenueSource.DataSource = revenueSourceList;
                txtEditRevenueSource_NewName.Clear();
            }
        }

        private void btnDeleteRevenueSource_Save_Click(object sender, EventArgs e)
        {
            updateCurrentRevenueSourceInfo();

            RevenueSourceDAO.DeleteRevenueSource(currentlySelectedRevenueSource.Id);
            revenueSourceList = RevenueSourceDAO.GetRevenueSources();
            dataGridViewRevenueSource.DataSource = revenueSourceList;
        }

        private void btnRevenueSource_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBank_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPurposeOfExpense_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewPurposeOfExpense_Save_Click(object sender, EventArgs e)
        {
            if (txtNewPurposeOfExpense_Name.Text.Trim() == "")
            {
                MessageBox.Show("Musisz podac nazwe kategorii");
            }
            else
            {
                var lastPurposeOfExpenseRecord = purposeOfExpenseList.Last();

                PurposeOfExpenseDTO purposeOfExpense = new PurposeOfExpenseDTO();
                purposeOfExpense.Id = lastPurposeOfExpenseRecord.Id + 1;
                purposeOfExpense.Name = txtNewPurposeOfExpense_Name.Text;
                PurposeOfExpenseDAO.AddPurposeOfExpense(purposeOfExpense);
                txtNewPurposeOfExpense_Name.Clear();
                purposeOfExpenseList = PurposeOfExpenseDAO.GetPurposeOfExpense();
                dataGridViewPurposeOfExpense.DataSource = purposeOfExpenseList;
            }
        }

        private void btnNewRevenueSource_Save_Click(object sender, EventArgs e)
        {
            if (txtNewRevenueSource_Name.Text.Trim() == "")
            {
                MessageBox.Show("Musisz podac nazwe kategorii");
            }
            else
            {
                var lastRevenueSourceRecord = revenueSourceList.Last();

                RevenueSourceDTO revenueSource = new RevenueSourceDTO();
                revenueSource.Id = lastRevenueSourceRecord.Id + 1;
                revenueSource.Name = txtNewRevenueSource_Name.Text;
                RevenueSourceDAO.AddRevenueSource(revenueSource);
                txtNewRevenueSource_Name.Clear();
                revenueSourceList = RevenueSourceDAO.GetRevenueSources();
                dataGridViewRevenueSource.DataSource = revenueSourceList;
            }
        }

        private void btnEditPurposeOfExpense_Save_Click(object sender, EventArgs e)
        {
            updateCurrentPurposeOfExpenseInfo();

            if (currentlySelectedPurposeOfExpense.Id == 0)
                MessageBox.Show("Wybierz kategorie której nazwe chcesz zmienić");
            else
            {
                if (txtEditPurposeOfExpense_NewName.Text == "")
                    MessageBox.Show("Musisz podać nową nazwe kategorii");

                currentlySelectedPurposeOfExpense.Name = txtEditPurposeOfExpense_NewName.Text;
                PurposeOfExpenseDAO.UpdatePurposeOfExpense(currentlySelectedPurposeOfExpense);
                purposeOfExpenseList = PurposeOfExpenseDAO.GetPurposeOfExpense();
                dataGridViewPurposeOfExpense.DataSource = purposeOfExpenseList;
                txtEditPurposeOfExpense_NewName.Clear();
            }
        }

        private void btnDeletePurposeOfExpense_Save_Click(object sender, EventArgs e)
        {
            updateCurrentPurposeOfExpenseInfo();

            PurposeOfExpenseDAO.DeletePurposeOfExpense(currentlySelectedPurposeOfExpense.Id);
            purposeOfExpenseList = PurposeOfExpenseDAO.GetPurposeOfExpense();
            dataGridViewPurposeOfExpense.DataSource = purposeOfExpenseList;
        }
    }
}
