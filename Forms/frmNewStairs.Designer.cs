namespace BidSheet.Forms
{
    partial class frmNewStairs
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
            this.lblBeam = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ckHighlight = new System.Windows.Forms.CheckBox();
            this.txtFlights = new System.Windows.Forms.MaskedTextBox();
            this.txtTreads = new System.Windows.Forms.MaskedTextBox();
            this.txtStringerWt = new System.Windows.Forms.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.ckGrating = new System.Windows.Forms.CheckBox();
            this.ckPan = new System.Windows.Forms.CheckBox();
            this.ckBolted = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblBeam
            // 
            this.lblBeam.AutoSize = true;
            this.lblBeam.Location = new System.Drawing.Point(12, 13);
            this.lblBeam.Name = "lblBeam";
            this.lblBeam.Size = new System.Drawing.Size(33, 13);
            this.lblBeam.TabIndex = 0;
            this.lblBeam.Text = "Stairs";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(140, 116);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 70;
            this.btnOk.Text = "Accept";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(221, 116);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 80;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ckHighlight
            // 
            this.ckHighlight.AutoSize = true;
            this.ckHighlight.Location = new System.Drawing.Point(30, 120);
            this.ckHighlight.Name = "ckHighlight";
            this.ckHighlight.Size = new System.Drawing.Size(109, 17);
            this.ckHighlight.TabIndex = 110;
            this.ckHighlight.Text = "Highlight in Sheet";
            this.ckHighlight.UseVisualStyleBackColor = true;
            // 
            // txtFlights
            // 
            this.txtFlights.Location = new System.Drawing.Point(85, 10);
            this.txtFlights.Name = "txtFlights";
            this.txtFlights.Size = new System.Drawing.Size(36, 20);
            this.txtFlights.TabIndex = 10;
            // 
            // txtTreads
            // 
            this.txtTreads.Location = new System.Drawing.Point(147, 10);
            this.txtTreads.Name = "txtTreads";
            this.txtTreads.Size = new System.Drawing.Size(36, 20);
            this.txtTreads.TabIndex = 20;
            // 
            // txtStringerWt
            // 
            this.txtStringerWt.Location = new System.Drawing.Point(205, 10);
            this.txtStringerWt.Name = "txtStringerWt";
            this.txtStringerWt.Size = new System.Drawing.Size(36, 20);
            this.txtStringerWt.TabIndex = 30;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(84, 36);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Flights";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(144, 36);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Treads";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(202, 36);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Stringer Weight";
            // 
            // ckGrating
            // 
            this.ckGrating.AutoSize = true;
            this.ckGrating.Location = new System.Drawing.Point(70, 63);
            this.ckGrating.Name = "ckGrating";
            this.ckGrating.Size = new System.Drawing.Size(60, 17);
            this.ckGrating.TabIndex = 40;
            this.ckGrating.Text = "Grating";
            this.ckGrating.UseVisualStyleBackColor = true;
            // 
            // ckPan
            // 
            this.ckPan.AutoSize = true;
            this.ckPan.Location = new System.Drawing.Point(147, 63);
            this.ckPan.Name = "ckPan";
            this.ckPan.Size = new System.Drawing.Size(45, 17);
            this.ckPan.TabIndex = 50;
            this.ckPan.Text = "Pan";
            this.ckPan.UseVisualStyleBackColor = true;
            // 
            // ckBolted
            // 
            this.ckBolted.AutoSize = true;
            this.ckBolted.Location = new System.Drawing.Point(205, 63);
            this.ckBolted.Name = "ckBolted";
            this.ckBolted.Size = new System.Drawing.Size(56, 17);
            this.ckBolted.TabIndex = 60;
            this.ckBolted.Text = "Bolted";
            this.ckBolted.UseVisualStyleBackColor = true;
            // 
            // frmNewStairs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 159);
            this.Controls.Add(this.ckBolted);
            this.Controls.Add(this.ckPan);
            this.Controls.Add(this.ckGrating);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtFlights);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtTreads);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtStringerWt);
            this.Controls.Add(this.ckHighlight);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblBeam);
            this.Name = "frmNewStairs";
            this.Text = "Rail Specifications";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBeam;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox ckHighlight;
        private System.Windows.Forms.MaskedTextBox txtFlights;
        private System.Windows.Forms.MaskedTextBox txtTreads;
        private System.Windows.Forms.MaskedTextBox txtStringerWt;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox ckGrating;
        private System.Windows.Forms.CheckBox ckPan;
        private System.Windows.Forms.CheckBox ckBolted;
    }
}