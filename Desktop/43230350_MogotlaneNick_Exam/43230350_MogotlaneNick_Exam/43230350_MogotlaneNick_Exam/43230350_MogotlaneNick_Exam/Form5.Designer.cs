
namespace _43230350_MogotlaneNick_Exam
{
    partial class Form5
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
            this.txtEventID = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.linkLabelBack = new System.Windows.Forms.LinkLabel();
            this.linkLabelInstruction = new System.Windows.Forms.LinkLabel();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cancel Event";
            // 
            // txtEventID
            // 
            this.txtEventID.Location = new System.Drawing.Point(35, 71);
            this.txtEventID.Name = "txtEventID";
            this.txtEventID.Size = new System.Drawing.Size(100, 20);
            this.txtEventID.TabIndex = 1;
            this.txtEventID.TextChanged += new System.EventHandler(this.txtEventID_TextChanged);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(200, 60);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(111, 40);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // linkLabelBack
            // 
            this.linkLabelBack.AutoSize = true;
            this.linkLabelBack.Location = new System.Drawing.Point(43, 114);
            this.linkLabelBack.Name = "linkLabelBack";
            this.linkLabelBack.Size = new System.Drawing.Size(32, 13);
            this.linkLabelBack.TabIndex = 3;
            this.linkLabelBack.TabStop = true;
            this.linkLabelBack.Text = "Back";
            this.linkLabelBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBack_LinkClicked);
            // 
            // linkLabelInstruction
            // 
            this.linkLabelInstruction.AutoSize = true;
            this.linkLabelInstruction.Location = new System.Drawing.Point(197, 114);
            this.linkLabelInstruction.Name = "linkLabelInstruction";
            this.linkLabelInstruction.Size = new System.Drawing.Size(73, 13);
            this.linkLabelInstruction.TabIndex = 4;
            this.linkLabelInstruction.TabStop = true;
            this.linkLabelInstruction.Text = "How to delete";
            this.linkLabelInstruction.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelInstruction_LinkClicked);
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(197, 137);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(196, 13);
            this.lblInstruction.TabIndex = 5;
            this.lblInstruction.Text = "*Enter the  event ID to cancel the event";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 194);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.linkLabelInstruction);
            this.Controls.Add(this.linkLabelBack);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtEventID);
            this.Controls.Add(this.label1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.LinkLabel linkLabelBack;
        private System.Windows.Forms.LinkLabel linkLabelInstruction;
        private System.Windows.Forms.Label lblInstruction;
        public System.Windows.Forms.TextBox txtEventID;
    }
}