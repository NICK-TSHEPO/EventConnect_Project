
namespace _43230350_MogotlaneNick_Exam
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.linkLabel_LogOut = new System.Windows.Forms.LinkLabel();
            this.lstInvoice = new System.Windows.Forms.ListBox();
            this.btnUserAccount = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(122, 300);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(155, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnInvoice
            // 
            this.btnInvoice.Location = new System.Drawing.Point(25, 336);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(95, 23);
            this.btnInvoice.TabIndex = 2;
            this.btnInvoice.Text = "Request Invoice";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // linkLabel_LogOut
            // 
            this.linkLabel_LogOut.AutoSize = true;
            this.linkLabel_LogOut.Location = new System.Drawing.Point(26, 378);
            this.linkLabel_LogOut.Name = "linkLabel_LogOut";
            this.linkLabel_LogOut.Size = new System.Drawing.Size(42, 13);
            this.linkLabel_LogOut.TabIndex = 3;
            this.linkLabel_LogOut.TabStop = true;
            this.linkLabel_LogOut.Text = "LogOut";
            this.linkLabel_LogOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LogOut_LinkClicked);
            // 
            // lstInvoice
            // 
            this.lstInvoice.FormattingEnabled = true;
            this.lstInvoice.Location = new System.Drawing.Point(316, 300);
            this.lstInvoice.Name = "lstInvoice";
            this.lstInvoice.Size = new System.Drawing.Size(472, 121);
            this.lstInvoice.TabIndex = 4;
            // 
            // btnUserAccount
            // 
            this.btnUserAccount.Location = new System.Drawing.Point(170, 378);
            this.btnUserAccount.Name = "btnUserAccount";
            this.btnUserAccount.Size = new System.Drawing.Size(107, 23);
            this.btnUserAccount.TabIndex = 5;
            this.btnUserAccount.Text = "Update Profile";
            this.btnUserAccount.UseVisualStyleBackColor = true;
            this.btnUserAccount.Click += new System.EventHandler(this.btnUserAccount_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(170, 336);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(107, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvEvents
            // 
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Location = new System.Drawing.Point(25, 10);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.Size = new System.Drawing.Size(763, 278);
            this.dgvEvents.TabIndex = 7;
            this.dgvEvents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvents_CellContentClick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvEvents);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnUserAccount);
            this.Controls.Add(this.lstInvoice);
            this.Controls.Add(this.linkLabel_LogOut);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "EventConnect";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.LinkLabel linkLabel_LogOut;
        private System.Windows.Forms.ListBox lstInvoice;
        private System.Windows.Forms.Button btnUserAccount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvEvents;
    }
}