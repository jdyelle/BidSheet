namespace BidSheet.Forms
{
    partial class frmNewHandrail
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
            this.txtRuns = new System.Windows.Forms.MaskedTextBox();
            this.cmbRailType = new System.Windows.Forms.ComboBox();
            this.txtLength = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ckHighlight = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMemberDWtFt = new System.Windows.Forms.MaskedTextBox();
            this.txtMemberDSqFt = new System.Windows.Forms.MaskedTextBox();
            this.txtMemberCWtFt = new System.Windows.Forms.MaskedTextBox();
            this.txtMemberCSqFt = new System.Windows.Forms.MaskedTextBox();
            this.txtMemberBWtFt = new System.Windows.Forms.MaskedTextBox();
            this.txtMemberBSqFt = new System.Windows.Forms.MaskedTextBox();
            this.txtMemberAWtFt = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMemberASqFt = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPicketSqFt = new System.Windows.Forms.MaskedTextBox();
            this.txtPicketLength = new System.Windows.Forms.MaskedTextBox();
            this.txtPicketWtFt = new System.Windows.Forms.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.ckSloped = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBeam
            // 
            this.lblBeam.AutoSize = true;
            this.lblBeam.Location = new System.Drawing.Point(13, 13);
            this.lblBeam.Name = "lblBeam";
            this.lblBeam.Size = new System.Drawing.Size(52, 13);
            this.lblBeam.TabIndex = 0;
            this.lblBeam.Text = "Rail Type";
            // 
            // txtRuns
            // 
            this.txtRuns.Location = new System.Drawing.Point(277, 10);
            this.txtRuns.Name = "txtRuns";
            this.txtRuns.Size = new System.Drawing.Size(26, 20);
            this.txtRuns.TabIndex = 40;
            // 
            // cmbRailType
            // 
            this.cmbRailType.FormattingEnabled = true;
            this.cmbRailType.Items.AddRange(new object[] {
            "Handrail",
            "Guardrail"});
            this.cmbRailType.Location = new System.Drawing.Point(71, 10);
            this.cmbRailType.Name = "cmbRailType";
            this.cmbRailType.Size = new System.Drawing.Size(121, 21);
            this.cmbRailType.TabIndex = 20;
            this.cmbRailType.Text = "Handrail";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(205, 10);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(40, 20);
            this.txtLength.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Runs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Length (Feet)";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(147, 318);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 70;
            this.btnOk.Text = "Accept";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(228, 318);
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
            this.ckHighlight.Location = new System.Drawing.Point(37, 322);
            this.ckHighlight.Name = "ckHighlight";
            this.ckHighlight.Size = new System.Drawing.Size(109, 17);
            this.ckHighlight.TabIndex = 110;
            this.ckHighlight.Text = "Highlight in Sheet";
            this.ckHighlight.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMemberDWtFt);
            this.groupBox2.Controls.Add(this.txtMemberDSqFt);
            this.groupBox2.Controls.Add(this.txtMemberCWtFt);
            this.groupBox2.Controls.Add(this.txtMemberCSqFt);
            this.groupBox2.Controls.Add(this.txtMemberBWtFt);
            this.groupBox2.Controls.Add(this.txtMemberBSqFt);
            this.groupBox2.Controls.Add(this.txtMemberAWtFt);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtMemberASqFt);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(37, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 148);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Members";
            // 
            // txtMemberDWtFt
            // 
            this.txtMemberDWtFt.Location = new System.Drawing.Point(168, 115);
            this.txtMemberDWtFt.Name = "txtMemberDWtFt";
            this.txtMemberDWtFt.Size = new System.Drawing.Size(36, 20);
            this.txtMemberDWtFt.TabIndex = 140;
            // 
            // txtMemberDSqFt
            // 
            this.txtMemberDSqFt.Location = new System.Drawing.Point(93, 115);
            this.txtMemberDSqFt.Name = "txtMemberDSqFt";
            this.txtMemberDSqFt.Size = new System.Drawing.Size(36, 20);
            this.txtMemberDSqFt.TabIndex = 130;
            // 
            // txtMemberCWtFt
            // 
            this.txtMemberCWtFt.Location = new System.Drawing.Point(168, 89);
            this.txtMemberCWtFt.Name = "txtMemberCWtFt";
            this.txtMemberCWtFt.Size = new System.Drawing.Size(36, 20);
            this.txtMemberCWtFt.TabIndex = 120;
            // 
            // txtMemberCSqFt
            // 
            this.txtMemberCSqFt.Location = new System.Drawing.Point(93, 89);
            this.txtMemberCSqFt.Name = "txtMemberCSqFt";
            this.txtMemberCSqFt.Size = new System.Drawing.Size(36, 20);
            this.txtMemberCSqFt.TabIndex = 110;
            // 
            // txtMemberBWtFt
            // 
            this.txtMemberBWtFt.Location = new System.Drawing.Point(168, 63);
            this.txtMemberBWtFt.Name = "txtMemberBWtFt";
            this.txtMemberBWtFt.Size = new System.Drawing.Size(36, 20);
            this.txtMemberBWtFt.TabIndex = 90;
            // 
            // txtMemberBSqFt
            // 
            this.txtMemberBSqFt.Location = new System.Drawing.Point(93, 63);
            this.txtMemberBSqFt.Name = "txtMemberBSqFt";
            this.txtMemberBSqFt.Size = new System.Drawing.Size(36, 20);
            this.txtMemberBSqFt.TabIndex = 80;
            // 
            // txtMemberAWtFt
            // 
            this.txtMemberAWtFt.Location = new System.Drawing.Point(168, 37);
            this.txtMemberAWtFt.Name = "txtMemberAWtFt";
            this.txtMemberAWtFt.Size = new System.Drawing.Size(36, 20);
            this.txtMemberAWtFt.TabIndex = 70;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Member D";
            // 
            // txtMemberASqFt
            // 
            this.txtMemberASqFt.Location = new System.Drawing.Point(93, 37);
            this.txtMemberASqFt.Name = "txtMemberASqFt";
            this.txtMemberASqFt.Size = new System.Drawing.Size(36, 20);
            this.txtMemberASqFt.TabIndex = 60;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Member C";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(157, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Weight/Foot";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Member B";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(80, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Square Feet";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Member A";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPicketSqFt);
            this.groupBox1.Controls.Add(this.txtPicketLength);
            this.groupBox1.Controls.Add(this.txtPicketWtFt);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Location = new System.Drawing.Point(37, 217);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 84);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pickets";
            // 
            // txtPicketSqFt
            // 
            this.txtPicketSqFt.Location = new System.Drawing.Point(83, 36);
            this.txtPicketSqFt.Name = "txtPicketSqFt";
            this.txtPicketSqFt.Size = new System.Drawing.Size(36, 20);
            this.txtPicketSqFt.TabIndex = 50;
            // 
            // txtPicketLength
            // 
            this.txtPicketLength.Location = new System.Drawing.Point(141, 36);
            this.txtPicketLength.Name = "txtPicketLength";
            this.txtPicketLength.Size = new System.Drawing.Size(36, 20);
            this.txtPicketLength.TabIndex = 70;
            // 
            // txtPicketWtFt
            // 
            this.txtPicketWtFt.Location = new System.Drawing.Point(200, 36);
            this.txtPicketWtFt.Name = "txtPicketWtFt";
            this.txtPicketWtFt.Size = new System.Drawing.Size(36, 20);
            this.txtPicketWtFt.TabIndex = 80;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(67, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Square Feet";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(138, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Length";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(145, 59);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(28, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Feet";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(188, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Weight/Foot";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(21, 39);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(27, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Size";
            // 
            // ckSloped
            // 
            this.ckSloped.AutoSize = true;
            this.ckSloped.Location = new System.Drawing.Point(120, 37);
            this.ckSloped.Name = "ckSloped";
            this.ckSloped.Size = new System.Drawing.Size(59, 17);
            this.ckSloped.TabIndex = 25;
            this.ckSloped.Text = "Sloped";
            this.ckSloped.UseVisualStyleBackColor = true;
            // 
            // frmNewHandrail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 359);
            this.Controls.Add(this.ckSloped);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ckHighlight);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRailType);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.txtRuns);
            this.Controls.Add(this.lblBeam);
            this.Name = "frmNewHandrail";
            this.Text = "Rail Specifications";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBeam;
        private System.Windows.Forms.MaskedTextBox txtRuns;
        private System.Windows.Forms.ComboBox cmbRailType;
        private System.Windows.Forms.MaskedTextBox txtLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox ckHighlight;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox txtMemberAWtFt;
        private System.Windows.Forms.MaskedTextBox txtMemberASqFt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txtPicketSqFt;
        private System.Windows.Forms.MaskedTextBox txtPicketLength;
        private System.Windows.Forms.MaskedTextBox txtPicketWtFt;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.MaskedTextBox txtMemberDWtFt;
        private System.Windows.Forms.MaskedTextBox txtMemberDSqFt;
        private System.Windows.Forms.MaskedTextBox txtMemberCWtFt;
        private System.Windows.Forms.MaskedTextBox txtMemberCSqFt;
        private System.Windows.Forms.MaskedTextBox txtMemberBWtFt;
        private System.Windows.Forms.MaskedTextBox txtMemberBSqFt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckSloped;
    }
}