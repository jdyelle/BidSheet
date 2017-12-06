namespace BidSheet.Forms
{
    partial class frmUserWorksheet
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
            this.lblProjectName = new System.Windows.Forms.Label();
            this.btnProjectDetails = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLaborTimes = new System.Windows.Forms.Button();
            this.cmbTypeSelect = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnSpreadsheet = new System.Windows.Forms.Button();
            this.btnLoadProject = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(13, 13);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(16, 13);
            this.lblProjectName.TabIndex = 0;
            this.lblProjectName.Text = "...";
            // 
            // btnProjectDetails
            // 
            this.btnProjectDetails.Location = new System.Drawing.Point(591, 12);
            this.btnProjectDetails.Name = "btnProjectDetails";
            this.btnProjectDetails.Size = new System.Drawing.Size(81, 23);
            this.btnProjectDetails.TabIndex = 105;
            this.btnProjectDetails.Text = "New Estimate";
            this.btnProjectDetails.UseVisualStyleBackColor = true;
            this.btnProjectDetails.Click += new System.EventHandler(this.btnProjectDetails_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblError.Location = new System.Drawing.Point(16, 60);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(34, 13);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "Error";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(770, 526);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnLaborTimes
            // 
            this.btnLaborTimes.Location = new System.Drawing.Point(678, 12);
            this.btnLaborTimes.Name = "btnLaborTimes";
            this.btnLaborTimes.Size = new System.Drawing.Size(108, 23);
            this.btnLaborTimes.TabIndex = 110;
            this.btnLaborTimes.Text = "Adjust Labor Times";
            this.btnLaborTimes.UseVisualStyleBackColor = true;
            this.btnLaborTimes.Click += new System.EventHandler(this.btnLaborTimes_Click);
            // 
            // cmbTypeSelect
            // 
            this.cmbTypeSelect.FormattingEnabled = true;
            this.cmbTypeSelect.Items.AddRange(new object[] {
            "Beam",
            "Column",
            "Handrail",
            "Stairs",
            "Edge Angle"});
            this.cmbTypeSelect.Location = new System.Drawing.Point(16, 29);
            this.cmbTypeSelect.Name = "cmbTypeSelect";
            this.cmbTypeSelect.Size = new System.Drawing.Size(121, 21);
            this.cmbTypeSelect.TabIndex = 10;
            this.cmbTypeSelect.Text = "Beam";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(143, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(540, 47);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(120, 23);
            this.btnDeleteSelected.TabIndex = 50;
            this.btnDeleteSelected.Text = "Delete Selected";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnSpreadsheet
            // 
            this.btnSpreadsheet.Location = new System.Drawing.Point(666, 47);
            this.btnSpreadsheet.Name = "btnSpreadsheet";
            this.btnSpreadsheet.Size = new System.Drawing.Size(120, 23);
            this.btnSpreadsheet.TabIndex = 50;
            this.btnSpreadsheet.Text = "Push to Spreadsheet";
            this.btnSpreadsheet.UseVisualStyleBackColor = true;
            this.btnSpreadsheet.Click += new System.EventHandler(this.btnSpreadsheet_Click);
            // 
            // btnLoadProject
            // 
            this.btnLoadProject.Location = new System.Drawing.Point(502, 12);
            this.btnLoadProject.Name = "btnLoadProject";
            this.btnLoadProject.Size = new System.Drawing.Size(83, 23);
            this.btnLoadProject.TabIndex = 100;
            this.btnLoadProject.Text = "Load Project";
            this.btnLoadProject.UseVisualStyleBackColor = true;
            this.btnLoadProject.Click += new System.EventHandler(this.btnLoadProject_Click);
            // 
            // frmUserWorksheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 614);
            this.Controls.Add(this.btnSpreadsheet);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbTypeSelect);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnLaborTimes);
            this.Controls.Add(this.btnLoadProject);
            this.Controls.Add(this.btnProjectDetails);
            this.Controls.Add(this.lblProjectName);
            this.Name = "frmUserWorksheet";
            this.Text = "BidSheet 2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUserWorksheet_FormClosing);
            this.Resize += new System.EventHandler(this.frmUserWorksheet_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Button btnProjectDetails;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLaborTimes;
        private System.Windows.Forms.ComboBox cmbTypeSelect;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnSpreadsheet;
        private System.Windows.Forms.Button btnLoadProject;
    }
}