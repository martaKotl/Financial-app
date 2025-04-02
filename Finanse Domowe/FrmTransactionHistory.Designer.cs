namespace Finanse_Domowe
{
    partial class FrmTransactionHistory
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
            this.panelEdycji = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.cmbFiltersRevenurSourceName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFiltersDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFiltersReset = new System.Windows.Forms.Button();
            this.btnFiltersSearch = new System.Windows.Forms.Button();
            this.cmbFiltersPurposeOfExpenseName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbFiltersBankName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.panelSearchFilters = new System.Windows.Forms.Panel();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTransactionHistory = new System.Windows.Forms.DataGridView();
            this.panelEdycji.SuspendLayout();
            this.panelSearchFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactionHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEdycji
            // 
            this.panelEdycji.Controls.Add(this.btnExit);
            this.panelEdycji.Controls.Add(this.btnDelete);
            this.panelEdycji.Controls.Add(this.btnEdit);
            this.panelEdycji.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEdycji.Location = new System.Drawing.Point(225, 492);
            this.panelEdycji.Margin = new System.Windows.Forms.Padding(2);
            this.panelEdycji.Name = "panelEdycji";
            this.panelEdycji.Size = new System.Drawing.Size(1102, 54);
            this.panelEdycji.TabIndex = 13;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(685, 20);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(71, 26);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Anuluj";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(371, 20);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(71, 26);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Usun";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(268, 20);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(71, 26);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edytuj";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cmbFiltersRevenurSourceName
            // 
            this.cmbFiltersRevenurSourceName.FormattingEnabled = true;
            this.cmbFiltersRevenurSourceName.Location = new System.Drawing.Point(11, 166);
            this.cmbFiltersRevenurSourceName.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFiltersRevenurSourceName.Name = "cmbFiltersRevenurSourceName";
            this.cmbFiltersRevenurSourceName.Size = new System.Drawing.Size(82, 21);
            this.cmbFiltersRevenurSourceName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Źródło przychodu";
            // 
            // txtFiltersDescription
            // 
            this.txtFiltersDescription.Location = new System.Drawing.Point(11, 280);
            this.txtFiltersDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtFiltersDescription.Name = "txtFiltersDescription";
            this.txtFiltersDescription.Size = new System.Drawing.Size(190, 20);
            this.txtFiltersDescription.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 259);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Opis";
            // 
            // btnFiltersReset
            // 
            this.btnFiltersReset.Location = new System.Drawing.Point(11, 353);
            this.btnFiltersReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnFiltersReset.Name = "btnFiltersReset";
            this.btnFiltersReset.Size = new System.Drawing.Size(120, 28);
            this.btnFiltersReset.TabIndex = 8;
            this.btnFiltersReset.Text = "Reset";
            this.btnFiltersReset.UseVisualStyleBackColor = true;
            this.btnFiltersReset.Click += new System.EventHandler(this.btnFiltersReset_Click);
            // 
            // btnFiltersSearch
            // 
            this.btnFiltersSearch.Location = new System.Drawing.Point(11, 313);
            this.btnFiltersSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnFiltersSearch.Name = "btnFiltersSearch";
            this.btnFiltersSearch.Size = new System.Drawing.Size(120, 30);
            this.btnFiltersSearch.TabIndex = 7;
            this.btnFiltersSearch.Text = "Szukaj";
            this.btnFiltersSearch.UseVisualStyleBackColor = true;
            this.btnFiltersSearch.Click += new System.EventHandler(this.btnFiltersSearch_Click);
            // 
            // cmbFiltersPurposeOfExpenseName
            // 
            this.cmbFiltersPurposeOfExpenseName.FormattingEnabled = true;
            this.cmbFiltersPurposeOfExpenseName.Location = new System.Drawing.Point(11, 224);
            this.cmbFiltersPurposeOfExpenseName.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFiltersPurposeOfExpenseName.Name = "cmbFiltersPurposeOfExpenseName";
            this.cmbFiltersPurposeOfExpenseName.Size = new System.Drawing.Size(82, 21);
            this.cmbFiltersPurposeOfExpenseName.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 198);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Cel wydatku";
            // 
            // cmbFiltersBankName
            // 
            this.cmbFiltersBankName.FormattingEnabled = true;
            this.cmbFiltersBankName.Location = new System.Drawing.Point(11, 114);
            this.cmbFiltersBankName.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFiltersBankName.Name = "cmbFiltersBankName";
            this.cmbFiltersBankName.Size = new System.Drawing.Size(82, 21);
            this.cmbFiltersBankName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 88);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Bank";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(36, 57);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(116, 20);
            this.dateTimePickerTo.TabIndex = 2;
            // 
            // panelSearchFilters
            // 
            this.panelSearchFilters.Controls.Add(this.cmbFiltersRevenurSourceName);
            this.panelSearchFilters.Controls.Add(this.label4);
            this.panelSearchFilters.Controls.Add(this.txtFiltersDescription);
            this.panelSearchFilters.Controls.Add(this.label5);
            this.panelSearchFilters.Controls.Add(this.btnFiltersReset);
            this.panelSearchFilters.Controls.Add(this.btnFiltersSearch);
            this.panelSearchFilters.Controls.Add(this.cmbFiltersPurposeOfExpenseName);
            this.panelSearchFilters.Controls.Add(this.label7);
            this.panelSearchFilters.Controls.Add(this.cmbFiltersBankName);
            this.panelSearchFilters.Controls.Add(this.label6);
            this.panelSearchFilters.Controls.Add(this.dateTimePickerTo);
            this.panelSearchFilters.Controls.Add(this.dateTimePickerFrom);
            this.panelSearchFilters.Controls.Add(this.label3);
            this.panelSearchFilters.Controls.Add(this.label2);
            this.panelSearchFilters.Controls.Add(this.label1);
            this.panelSearchFilters.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSearchFilters.Location = new System.Drawing.Point(0, 0);
            this.panelSearchFilters.Margin = new System.Windows.Forms.Padding(2);
            this.panelSearchFilters.Name = "panelSearchFilters";
            this.panelSearchFilters.Size = new System.Drawing.Size(225, 546);
            this.panelSearchFilters.TabIndex = 14;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(36, 34);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(116, 20);
            this.dateTimePickerFrom.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Do";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Od";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data";
            // 
            // dataGridViewTransactionHistory
            // 
            this.dataGridViewTransactionHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTransactionHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransactionHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTransactionHistory.Location = new System.Drawing.Point(225, 0);
            this.dataGridViewTransactionHistory.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewTransactionHistory.Name = "dataGridViewTransactionHistory";
            this.dataGridViewTransactionHistory.RowHeadersWidth = 62;
            this.dataGridViewTransactionHistory.RowTemplate.Height = 28;
            this.dataGridViewTransactionHistory.Size = new System.Drawing.Size(1102, 492);
            this.dataGridViewTransactionHistory.TabIndex = 15;
            // 
            // FrmTransactionHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 546);
            this.Controls.Add(this.dataGridViewTransactionHistory);
            this.Controls.Add(this.panelEdycji);
            this.Controls.Add(this.panelSearchFilters);
            this.Name = "FrmTransactionHistory";
            this.Text = "Historia Transakcji";
            this.Load += new System.EventHandler(this.FrmTransactionHistory_Load);
            this.panelEdycji.ResumeLayout(false);
            this.panelSearchFilters.ResumeLayout(false);
            this.panelSearchFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactionHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelEdycji;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cmbFiltersRevenurSourceName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFiltersDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFiltersReset;
        private System.Windows.Forms.Button btnFiltersSearch;
        private System.Windows.Forms.ComboBox cmbFiltersPurposeOfExpenseName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbFiltersBankName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Panel panelSearchFilters;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewTransactionHistory;
    }
}