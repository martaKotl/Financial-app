namespace Finanse_Domowe
{
    partial class FrmTransaction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lbRevenueSource = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelReturnAccount = new System.Windows.Forms.Panel();
            this.cmbReturnAccount = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpDateOfTransacion = new System.Windows.Forms.DateTimePicker();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbPurposeOfExpanse = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelReturnAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCategory
            // 
            this.cmbCategory.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(355, 298);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(286, 30);
            this.cmbCategory.TabIndex = 40;
            // 
            // lbRevenueSource
            // 
            this.lbRevenueSource.AutoSize = true;
            this.lbRevenueSource.BackColor = System.Drawing.Color.FloralWhite;
            this.lbRevenueSource.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbRevenueSource.Location = new System.Drawing.Point(86, 301);
            this.lbRevenueSource.Name = "lbRevenueSource";
            this.lbRevenueSource.Size = new System.Drawing.Size(127, 22);
            this.lbRevenueSource.TabIndex = 44;
            this.lbRevenueSource.Text = "Źródło przychodu";
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = true;
            this.btnExit.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnExit.Location = new System.Drawing.Point(501, 446);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(161, 63);
            this.btnExit.TabIndex = 43;
            this.btnExit.Text = "Anuluj";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelReturnAccount
            // 
            this.panelReturnAccount.BackColor = System.Drawing.Color.FloralWhite;
            this.panelReturnAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelReturnAccount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelReturnAccount.Controls.Add(this.cmbReturnAccount);
            this.panelReturnAccount.Controls.Add(this.label7);
            this.panelReturnAccount.Enabled = false;
            this.panelReturnAccount.Location = new System.Drawing.Point(65, 354);
            this.panelReturnAccount.Name = "panelReturnAccount";
            this.panelReturnAccount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelReturnAccount.Size = new System.Drawing.Size(597, 57);
            this.panelReturnAccount.TabIndex = 42;
            // 
            // cmbReturnAccount
            // 
            this.cmbReturnAccount.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbReturnAccount.FormattingEnabled = true;
            this.cmbReturnAccount.Location = new System.Drawing.Point(290, 8);
            this.cmbReturnAccount.Name = "cmbReturnAccount";
            this.cmbReturnAccount.Size = new System.Drawing.Size(286, 30);
            this.cmbReturnAccount.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(21, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "Konto korespondencyjne";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSave.Location = new System.Drawing.Point(280, 446);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(161, 63);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "Zapisz";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpDateOfTransacion
            // 
            this.dtpDateOfTransacion.CalendarFont = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDateOfTransacion.Location = new System.Drawing.Point(355, 112);
            this.dtpDateOfTransacion.Name = "dtpDateOfTransacion";
            this.dtpDateOfTransacion.Size = new System.Drawing.Size(286, 20);
            this.dtpDateOfTransacion.TabIndex = 37;
            // 
            // cmbBank
            // 
            this.cmbBank.BackColor = System.Drawing.SystemColors.Window;
            this.cmbBank.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(355, 51);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(286, 30);
            this.cmbBank.TabIndex = 36;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtDescription.Location = new System.Drawing.Point(355, 228);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(286, 29);
            this.txtDescription.TabIndex = 39;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtAmount.Location = new System.Drawing.Point(355, 163);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(286, 29);
            this.txtAmount.TabIndex = 38;
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FloralWhite;
            this.label5.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(86, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 22);
            this.label5.TabIndex = 35;
            this.label5.Text = "Data operacji";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FloralWhite;
            this.label4.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(86, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 22);
            this.label4.TabIndex = 34;
            this.label4.Text = "Opis";
            // 
            // lbPurposeOfExpanse
            // 
            this.lbPurposeOfExpanse.AutoSize = true;
            this.lbPurposeOfExpanse.BackColor = System.Drawing.Color.FloralWhite;
            this.lbPurposeOfExpanse.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbPurposeOfExpanse.Location = new System.Drawing.Point(86, 301);
            this.lbPurposeOfExpanse.Name = "lbPurposeOfExpanse";
            this.lbPurposeOfExpanse.Size = new System.Drawing.Size(92, 22);
            this.lbPurposeOfExpanse.TabIndex = 33;
            this.lbPurposeOfExpanse.Text = "Cel wydatku";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FloralWhite;
            this.label2.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(86, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 22);
            this.label2.TabIndex = 32;
            this.label2.Text = "Kwota";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FloralWhite;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(86, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 22);
            this.label1.TabIndex = 31;
            this.label1.Text = "Konto bankowe";
            // 
            // FrmTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(749, 569);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lbRevenueSource);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panelReturnAccount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpDateOfTransacion);
            this.Controls.Add(this.cmbBank);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbPurposeOfExpanse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transakcja";
            this.Load += new System.EventHandler(this.FrmTransaction_Load);
            this.panelReturnAccount.ResumeLayout(false);
            this.panelReturnAccount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lbRevenueSource;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelReturnAccount;
        private System.Windows.Forms.ComboBox cmbReturnAccount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpDateOfTransacion;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbPurposeOfExpanse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}