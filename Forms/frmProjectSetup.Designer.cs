namespace BidSheet.Forms
{
    partial class frmProjectSetup
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
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.lblEstimateNum = new System.Windows.Forms.Label();
            this.txtEstimateNum = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSqFt = new System.Windows.Forms.Label();
            this.txtSqFt = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(33, 35);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(90, 32);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(304, 20);
            this.txtCustomer.TabIndex = 10;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Location = new System.Drawing.Point(13, 13);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(71, 13);
            this.lblFormTitle.TabIndex = 2;
            this.lblFormTitle.Text = "Project Setup";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(33, 61);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(40, 13);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "Project";
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(90, 58);
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(304, 20);
            this.txtProject.TabIndex = 20;
            // 
            // lblEstimateNum
            // 
            this.lblEstimateNum.AutoSize = true;
            this.lblEstimateNum.Location = new System.Drawing.Point(33, 87);
            this.lblEstimateNum.Name = "lblEstimateNum";
            this.lblEstimateNum.Size = new System.Drawing.Size(57, 13);
            this.lblEstimateNum.TabIndex = 0;
            this.lblEstimateNum.Text = "Estimate #";
            // 
            // txtEstimateNum
            // 
            this.txtEstimateNum.Location = new System.Drawing.Point(90, 84);
            this.txtEstimateNum.Name = "txtEstimateNum";
            this.txtEstimateNum.Size = new System.Drawing.Size(131, 20);
            this.txtEstimateNum.TabIndex = 30;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(232, 87);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(125, 145);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 60;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(220, 145);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 70;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSqFt
            // 
            this.lblSqFt.AutoSize = true;
            this.lblSqFt.Location = new System.Drawing.Point(147, 113);
            this.lblSqFt.Name = "lblSqFt";
            this.lblSqFt.Size = new System.Drawing.Size(53, 13);
            this.lblSqFt.TabIndex = 0;
            this.lblSqFt.Text = "Square Ft";
            // 
            // txtSqFt
            // 
            this.txtSqFt.Location = new System.Drawing.Point(220, 110);
            this.txtSqFt.Name = "txtSqFt";
            this.txtSqFt.Size = new System.Drawing.Size(105, 20);
            this.txtSqFt.TabIndex = 50;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(268, 84);
            this.txtDate.Mask = "90/90/0000";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(126, 20);
            this.txtDate.TabIndex = 40;
            // 
            // frmProjectSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 191);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.txtSqFt);
            this.Controls.Add(this.lblSqFt);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtEstimateNum);
            this.Controls.Add(this.lblEstimateNum);
            this.Controls.Add(this.txtProject);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Name = "frmProjectSetup";
            this.Text = "Project Setup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProjectSetup_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.Label lblEstimateNum;
        private System.Windows.Forms.TextBox txtEstimateNum;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSqFt;
        private System.Windows.Forms.TextBox txtSqFt;
        private System.Windows.Forms.MaskedTextBox txtDate;
    }
}

