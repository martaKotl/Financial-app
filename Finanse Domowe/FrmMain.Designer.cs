namespace Finanse_Domowe
{
    partial class FrmMain
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnBankStatement = new System.Windows.Forms.Button();
            this.btnNewTransaction = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.wczytanieWyciąguToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nowaTransakcjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historiaTransakcjiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijOknaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTransactionHistory = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnExit.Location = new System.Drawing.Point(413, 189);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 49);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Zamknij";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSettings.Location = new System.Drawing.Point(97, 178);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(113, 72);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "Ustawienia";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnBankStatement
            // 
            this.btnBankStatement.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBankStatement.Location = new System.Drawing.Point(97, 71);
            this.btnBankStatement.Margin = new System.Windows.Forms.Padding(2);
            this.btnBankStatement.Name = "btnBankStatement";
            this.btnBankStatement.Size = new System.Drawing.Size(113, 72);
            this.btnBankStatement.TabIndex = 1;
            this.btnBankStatement.Text = "Wczytanie wyciągu";
            this.btnBankStatement.UseVisualStyleBackColor = true;
            this.btnBankStatement.Click += new System.EventHandler(this.btnBankStatement_Click);
            // 
            // btnNewTransaction
            // 
            this.btnNewTransaction.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNewTransaction.Location = new System.Drawing.Point(247, 71);
            this.btnNewTransaction.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewTransaction.Name = "btnNewTransaction";
            this.btnNewTransaction.Size = new System.Drawing.Size(109, 72);
            this.btnNewTransaction.TabIndex = 2;
            this.btnNewTransaction.Text = "Nowa Transakcja";
            this.btnNewTransaction.UseVisualStyleBackColor = true;
            this.btnNewTransaction.Click += new System.EventHandler(this.btnNewTransaction_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wczytanieWyciąguToolStripMenuItem,
            this.nowaTransakcjaToolStripMenuItem,
            this.historiaTransakcjiToolStripMenuItem,
            this.ustawieniaToolStripMenuItem,
            this.zamknijOknaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(610, 25);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // wczytanieWyciąguToolStripMenuItem
            // 
            this.wczytanieWyciąguToolStripMenuItem.Font = new System.Drawing.Font("Sylfaen", 11F);
            this.wczytanieWyciąguToolStripMenuItem.Name = "wczytanieWyciąguToolStripMenuItem";
            this.wczytanieWyciąguToolStripMenuItem.Size = new System.Drawing.Size(143, 23);
            this.wczytanieWyciąguToolStripMenuItem.Text = "Wczytanie wyciągu";
            // 
            // nowaTransakcjaToolStripMenuItem
            // 
            this.nowaTransakcjaToolStripMenuItem.Font = new System.Drawing.Font("Sylfaen", 11F);
            this.nowaTransakcjaToolStripMenuItem.Name = "nowaTransakcjaToolStripMenuItem";
            this.nowaTransakcjaToolStripMenuItem.Size = new System.Drawing.Size(126, 23);
            this.nowaTransakcjaToolStripMenuItem.Text = "Nowa transakcja";
            // 
            // historiaTransakcjiToolStripMenuItem
            // 
            this.historiaTransakcjiToolStripMenuItem.Font = new System.Drawing.Font("Sylfaen", 11F);
            this.historiaTransakcjiToolStripMenuItem.Name = "historiaTransakcjiToolStripMenuItem";
            this.historiaTransakcjiToolStripMenuItem.Size = new System.Drawing.Size(132, 23);
            this.historiaTransakcjiToolStripMenuItem.Text = "Historia transakcji";
            // 
            // ustawieniaToolStripMenuItem
            // 
            this.ustawieniaToolStripMenuItem.Font = new System.Drawing.Font("Sylfaen", 11F);
            this.ustawieniaToolStripMenuItem.Name = "ustawieniaToolStripMenuItem";
            this.ustawieniaToolStripMenuItem.Size = new System.Drawing.Size(89, 23);
            this.ustawieniaToolStripMenuItem.Text = "Ustawienia";
            // 
            // zamknijOknaToolStripMenuItem
            // 
            this.zamknijOknaToolStripMenuItem.Font = new System.Drawing.Font("Sylfaen", 11F);
            this.zamknijOknaToolStripMenuItem.Name = "zamknijOknaToolStripMenuItem";
            this.zamknijOknaToolStripMenuItem.Size = new System.Drawing.Size(105, 23);
            this.zamknijOknaToolStripMenuItem.Text = "Zamknij okna";
            // 
            // btnTransactionHistory
            // 
            this.btnTransactionHistory.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTransactionHistory.Location = new System.Drawing.Point(403, 71);
            this.btnTransactionHistory.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransactionHistory.Name = "btnTransactionHistory";
            this.btnTransactionHistory.Size = new System.Drawing.Size(113, 72);
            this.btnTransactionHistory.TabIndex = 3;
            this.btnTransactionHistory.Text = "Historia Transakcji";
            this.btnTransactionHistory.UseVisualStyleBackColor = true;
            this.btnTransactionHistory.Click += new System.EventHandler(this.btnTransactionHistory_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(610, 288);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnBankStatement);
            this.Controls.Add(this.btnNewTransaction);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnTransactionHistory);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finanse Domowe";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnBankStatement;
        private System.Windows.Forms.Button btnNewTransaction;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem wczytanieWyciąguToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nowaTransakcjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historiaTransakcjiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijOknaToolStripMenuItem;
        private System.Windows.Forms.Button btnTransactionHistory;
    }
}