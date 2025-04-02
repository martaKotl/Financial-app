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
using DataAccessLayer.DataAccessObject;

namespace Finanse_Domowe
{
    public partial class FrmTransaction : Form
    {
        public FrmTransaction()
        {
            InitializeComponent();
        }

        TransactionDTO transactionDTO = new TransactionDTO();
        public bool transactionIsUpdate = false;
        public TransactionDetailsDTO transactionDetails = new TransactionDetailsDTO();

        BankStatementDTO bankStatementDTO = new BankStatementDTO();
        public bool bankStatementIsUpdate = false;
        public BankStatementDetailsDTO bankStatementDetails = new BankStatementDetailsDTO();

        private List<BankDTO> allBanks = BankDAO.GetBanks();
        private List<RevenueSourceDTO> allRevenueSources = RevenueSourceDAO.GetRevenueSources();
        private List<PurposeOfExpenseDTO> allPurposeOfExpenses = PurposeOfExpenseDAO.GetPurposeOfExpense();

        private bool checkGivenInformationAgain = false;

        private void FillUpCategory()
        {

            if (Convert.ToDouble(txtAmount.Text) >= 0)
            {
                lbRevenueSource.Visible = true;
                lbPurposeOfExpanse.Visible = false;

                if (bankStatementIsUpdate)
                {
                    cmbCategory.DataSource = allRevenueSources;
                    cmbCategory.DisplayMember = "NAME";
                    cmbCategory.ValueMember = "ID";
                    cmbCategory.SelectedIndex = -1;
                }
                else
                {
                    cmbCategory.DataSource = allRevenueSources;
                    cmbCategory.DisplayMember = "NAME";
                    cmbCategory.ValueMember = "ID";
                    cmbCategory.SelectedIndex = -1;
                }

            }
            else
            {
                lbPurposeOfExpanse.Visible = true;
                lbRevenueSource.Visible = false;

                if (bankStatementIsUpdate)
                {
                    cmbCategory.DataSource = allPurposeOfExpenses;
                    cmbCategory.DisplayMember = "NAME";
                    cmbCategory.ValueMember = "ID";
                    cmbCategory.SelectedIndex = -1;
                }
                else
                {
                    cmbCategory.DataSource = allPurposeOfExpenses;
                    cmbCategory.DisplayMember = "NAME";
                    cmbCategory.ValueMember = "ID";
                    cmbCategory.SelectedIndex = -1;

                }
            }

        }

        private void FrmTransaction_Load(object sender, EventArgs e)
        {
            panelReturnAccount.Enabled = false;

            if (bankStatementIsUpdate)
            {
                bankStatementDTO = BankStatementDAO.GetAll();
                txtAmount.Text = bankStatementDetails.Amount.ToString();
                txtDescription.Text = bankStatementDetails.Description;
                cmbBank.DataSource = allBanks;
                cmbBank.DisplayMember = "NAME";
                cmbBank.ValueMember = "ID";
                cmbBank.SelectedIndex = (bankStatementDetails.BankId - 1);
                dtpDateOfTransacion.Value = bankStatementDetails.DateOfTransaction;
                if (bankStatementDetails.RevenueSourcesId == null && bankStatementDetails.PurposeOfExpenseId == null)
                    FillUpCategory();
                else 
                {
                    if (bankStatementDetails.Amount < 0)
                    {
                        cmbCategory.DataSource = allPurposeOfExpenses;
                        cmbCategory.DisplayMember = "NAME";
                        cmbCategory.ValueMember = "ID";
                        cmbCategory.SelectedIndex = (int)(bankStatementDetails.PurposeOfExpenseId) - 1;
                    }
                    else
                    {
                        cmbCategory.DataSource = allRevenueSources;
                        cmbCategory.DisplayMember = "NAME";
                        cmbCategory.ValueMember = "ID";
                        cmbCategory.SelectedIndex = (int)(bankStatementDetails.RevenueSourcesId) - 1;
                    }
                }
            }

            else
            {
                if (transactionIsUpdate)
                {
                    txtAmount.Text = transactionDetails.Amount.ToString();
                    txtDescription.Text = transactionDetails.Description;
                    cmbBank.DataSource = allBanks;
                    cmbBank.DisplayMember = "NAME";
                    cmbBank.ValueMember = "ID";
                    cmbBank.SelectedIndex = (transactionDetails.BankId - 1);
                    dtpDateOfTransacion.Value = transactionDetails.DateOfTransaction;
                    if (transactionDetails.Amount < 0)
                    {
                        cmbCategory.DataSource = allPurposeOfExpenses;
                        cmbCategory.DisplayMember = "NAME";
                        cmbCategory.ValueMember = "ID";
                        cmbCategory.SelectedIndex = (int)(transactionDetails.PurposeOfExpenseId) - 1;
                    }
                    else
                    {
                        cmbCategory.DataSource = allRevenueSources;
                        cmbCategory.DisplayMember = "NAME";
                        cmbCategory.ValueMember = "ID";
                        cmbCategory.SelectedIndex = (int)(transactionDetails.RevenueSourcesId) - 1;
                    }
                }
                else
                {
                    cmbBank.DataSource = allBanks;
                    cmbBank.DisplayMember = "NAME";
                    cmbBank.ValueMember = "ID";
                    cmbBank.SelectedIndex = -1;
                    dtpDateOfTransacion.Value = DateTime.Today;
                    cmbCategory.SelectedIndex = -1;
                }

            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (txtAmount.Text == "")
                MessageBox.Show("Musisz uzupełnić pole Kwota");

            else if (!double.TryParse(txtAmount.Text, out double result))
                MessageBox.Show("Pole Kwota może zawierać tylko cyfry");

            else
                FillUpCategory();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            while (!CheckIfInformationAreGiven()) { };

            if (checkGivenInformationAgain)
            {
                checkGivenInformationAgain = false;
            }
            else
            {
                if (bankStatementIsUpdate)
                {
                    BankStatementDetailsDTO bankStatement = new BankStatementDetailsDTO();

                    bankStatement.BankStatementId = bankStatementDetails.BankStatementId;
                    bankStatement.BankId = Convert.ToInt32(cmbBank.SelectedValue);
                    bankStatement.Amount = double.Parse(txtAmount.Text);
                    bankStatement.Description = txtDescription.Text;
                    bankStatement.DateOfTransaction = dtpDateOfTransacion.Value;

                    if (panelReturnAccount.Enabled == true)
                    {
                        BankStatementDetailsDTO returnBankStatemant = new BankStatementDetailsDTO();

                        returnBankStatemant.BankStatementId = bankStatementDetails.BankStatementId + 1;
                        returnBankStatemant.BankId = Convert.ToInt32(cmbReturnAccount.SelectedValue);
                        returnBankStatemant.Amount = -(double.Parse(txtAmount.Text));
                        returnBankStatemant.Description = txtDescription.Text + " - transakcja zwrotna";
                        returnBankStatemant.DateOfTransaction = dtpDateOfTransacion.Value;

                        BankStatementDAO.UpdateBankStatement(bankStatement);
                        BankStatementDAO.AddBankStatement(returnBankStatemant);
                    }
                    else
                    {
                        if (Convert.ToDouble(txtAmount.Text) >= 0)
                        {
                            bankStatement.RevenueSourcesId = Convert.ToInt32(cmbCategory.SelectedValue);
                            bankStatement.PurposeOfExpenseId = null;
                        }
                        else
                        {
                            bankStatement.PurposeOfExpenseId = Convert.ToInt32(cmbCategory.SelectedValue);
                            bankStatement.RevenueSourcesId = null;
                        }
                        BankStatementDAO.UpdateBankStatement(bankStatement);
                    }

                    this.Close();
                }

                else
                {
                    TransactionDetailsDTO transaction = new TransactionDetailsDTO();
                    if (transactionIsUpdate)
                    {
                        transaction.TranscationId = transactionDetails.TranscationId;
                        transaction.BankId = Convert.ToInt32(cmbBank.SelectedValue);
                        transaction.Amount = double.Parse(txtAmount.Text);
                        transaction.Description = txtDescription.Text;
                        transaction.DateOfTransaction = dtpDateOfTransacion.Value;
                        transaction.AccountBalance = 0;//TransactionBLL.CountAccountBalanceForTransaction(transaction.ID, transaction.ID_BANK, transaction.AMOUNT, transaction.DATE);

                        if (panelReturnAccount.Enabled == true)
                        {
                            TransactionDetailsDTO returnTransaction = new TransactionDetailsDTO();

                            returnTransaction.TranscationId = transactionDetails.TranscationId + 1;
                            returnTransaction.BankId = Convert.ToInt32(cmbReturnAccount.SelectedValue);
                            returnTransaction.Amount = -(double.Parse(txtAmount.Text));
                            returnTransaction.Description = txtDescription.Text + " - transakcja zwrotna";
                            returnTransaction.DateOfTransaction = dtpDateOfTransacion.Value;

                            TransactionDAO.UpdateTransaction(transaction);
                            TransactionDAO.AddTransaction(returnTransaction);
                        }
                        else
                        {
                            if (Convert.ToDouble(txtAmount.Text) >= 0)
                            {
                                transaction.RevenueSourcesId = Convert.ToInt32(cmbCategory.SelectedValue);
                                transaction.PurposeOfExpenseId = null;
                            }
                            else
                            {
                                transaction.PurposeOfExpenseId = Convert.ToInt32(cmbCategory.SelectedValue);
                                transaction.RevenueSourcesId = null;
                            }
                            TransactionDAO.UpdateTransaction(transaction);
                        }
                        //TransactionDAO.CheckIfAccountBalanceNeedToBeChangeForFollowingTransactions(transaction.TranscationId, transaction.BankId, transaction.DateOfTransaction);

                        this.Close();
                    }
                    else
                    {
                        transaction.BankId = Convert.ToInt32(cmbBank.SelectedValue);
                        transaction.Amount = double.Parse(txtAmount.Text);
                        transaction.Description = txtDescription.Text;
                        transaction.DateOfTransaction = dtpDateOfTransacion.Value;
                        transaction.AccountBalance = 0;//TransactionBLL.CountAccountBalanceForTransaction(transaction.ID, transaction.ID_BANK, transaction.AMOUNT, transaction.DATE);                       

                        if (panelReturnAccount.Enabled == true)
                        {
                            TransactionDetailsDTO returnTransaction = new TransactionDetailsDTO();

                            returnTransaction.TranscationId = transaction.TranscationId + 1;
                            returnTransaction.BankId = Convert.ToInt32(cmbReturnAccount.SelectedValue);
                            returnTransaction.Amount = -(double.Parse(txtAmount.Text));
                            returnTransaction.Description = txtDescription.Text + " - transakcja zwrotna";
                            returnTransaction.DateOfTransaction = dtpDateOfTransacion.Value;
                            returnTransaction.AccountBalance = 0;//TransactionBLL.CountAccountBalanceForTransaction(returnTransaction.ID, returnTransaction.ID_BANK, returnTransaction.AMOUNT, returnTransaction.DATE);

                            TransactionDAO.AddTransaction(transaction);
                            TransactionDAO.AddTransaction(returnTransaction);
                        }
                        else
                        {
                            if (transaction.Amount >= 0)
                                transaction.RevenueSourcesId = Convert.ToInt32(cmbCategory.SelectedValue);
                            else
                                transaction.PurposeOfExpenseId = Convert.ToInt32(cmbCategory.SelectedValue);

                            TransactionDAO.AddTransaction(transaction);
                        }

                        MessageBox.Show("Tansakcja zostala dodana");

                        cmbBank.SelectedValue = -1;
                        txtAmount.Clear();
                        cmbCategory.SelectedValue = -1;
                        txtDescription.Clear();
                        dtpDateOfTransacion.Value = DateTime.Today;
                    }

                }
            }
        }

        private bool CheckIfInformationAreGiven()
        {
            if (cmbBank.SelectedIndex == -1)
                MessageBox.Show("Nie podales konta bankowego");
            else if (txtAmount.Text.Trim() == "")
                MessageBox.Show("Nie podales kwoty");
            else if (txtDescription.Text.Trim() == "")
                MessageBox.Show("Nie podales opisu");
            //else if (dtpDataOperacji.Value==DateTime.Today)   //tak??
            else if (cmbCategory.SelectedIndex == -1 && panelReturnAccount.Enabled == false)
            {
                DialogResult result = MessageBox.Show("Nie podales rodzaju transakcji.", " Czy chcesz dodac konto korespondencyjne?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)//konto korespondencyjne
                {
                    FillUpcmbReturnAccount();
                    panelReturnAccount.Enabled = true;
                    checkGivenInformationAgain = true;
                    return true;
                }
                else
                    checkGivenInformationAgain = true;
                return true;
            }
            else
                return true;
            return false;
        }

        private void FillUpcmbReturnAccount()
        {
            if (bankStatementIsUpdate)
            {
                BankStatementDTO bankStatementDTOReturnAccount = new BankStatementDTO();
                bankStatementDTOReturnAccount = BankStatementDAO.GetAll();
                BankStatementDetailsDTO bankStatementReturnAccount = new BankStatementDetailsDTO();
                cmbReturnAccount.DataSource = bankStatementDTOReturnAccount.Banks;
                cmbReturnAccount.DisplayMember = "NAME";
                cmbReturnAccount.ValueMember = "ID";
                cmbReturnAccount.SelectedIndex = (bankStatementReturnAccount.BankId) - 1;
            }
            else
            {
                TransactionDTO transactionDTOReturnAccount = new TransactionDTO();
                transactionDTOReturnAccount = TransactionDAO.GetAll(transactionDetails.DateOfTransaction, transactionDetails.DateOfTransaction);
                TransactionDetailsDTO transactionDetailsReturnAccount = new TransactionDetailsDTO();
                cmbReturnAccount.DataSource = transactionDTOReturnAccount.Banks;
                cmbReturnAccount.DisplayMember = "NAME";
                cmbReturnAccount.ValueMember = "ID";
                cmbReturnAccount.SelectedIndex = (transactionDetailsReturnAccount.BankId) - 1;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
