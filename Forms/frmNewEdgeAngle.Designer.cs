namespace BidSheet.Forms
{
    partial class frmNewEdgeAngle
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
            this.txtQty = new System.Windows.Forms.MaskedTextBox();
            this.cmbBeamType = new System.Windows.Forms.ComboBox();
            this.txtLenghtFt = new System.Windows.Forms.MaskedTextBox();
            this.txtLengthIn = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbMatNone = new System.Windows.Forms.RadioButton();
            this.rbMatQuarter = new System.Windows.Forms.RadioButton();
            this.rbMatHalf = new System.Windows.Forms.RadioButton();
            this.rbMatFull = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbBoltAnchor = new System.Windows.Forms.RadioButton();
            this.rbBoltChem = new System.Windows.Forms.RadioButton();
            this.rbBoltStud = new System.Windows.Forms.RadioButton();
            this.rbBoltStd = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ckHighlight = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbExtraType = new System.Windows.Forms.ComboBox();
            this.txtWeld = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBolts = new System.Windows.Forms.MaskedTextBox();
            this.txtHoles = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBeam
            // 
            this.lblBeam.AutoSize = true;
            this.lblBeam.Location = new System.Drawing.Point(13, 13);
            this.lblBeam.Name = "lblBeam";
            this.lblBeam.Size = new System.Drawing.Size(34, 13);
            this.lblBeam.TabIndex = 0;
            this.lblBeam.Text = "Angle";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(53, 10);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(26, 20);
            this.txtQty.TabIndex = 10;
            // 
            // cmbBeamType
            // 
            this.cmbBeamType.FormattingEnabled = true;
            this.cmbBeamType.Location = new System.Drawing.Point(98, 9);
            this.cmbBeamType.Name = "cmbBeamType";
            this.cmbBeamType.Size = new System.Drawing.Size(121, 21);
            this.cmbBeamType.TabIndex = 20;
            this.cmbBeamType.Text = "W813";
            // 
            // txtLenghtFt
            // 
            this.txtLenghtFt.Location = new System.Drawing.Point(240, 10);
            this.txtLenghtFt.Name = "txtLenghtFt";
            this.txtLenghtFt.Size = new System.Drawing.Size(26, 20);
            this.txtLenghtFt.TabIndex = 30;
            // 
            // txtLengthIn
            // 
            this.txtLengthIn.Location = new System.Drawing.Point(272, 10);
            this.txtLengthIn.Name = "txtLengthIn";
            this.txtLengthIn.Size = new System.Drawing.Size(26, 20);
            this.txtLengthIn.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Qty";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Beam Size / Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ft";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "In";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbMatNone);
            this.groupBox4.Controls.Add(this.rbMatQuarter);
            this.groupBox4.Controls.Add(this.rbMatHalf);
            this.groupBox4.Controls.Add(this.rbMatFull);
            this.groupBox4.Location = new System.Drawing.Point(313, 147);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(89, 114);
            this.groupBox4.TabIndex = 100;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mat\'l Handling";
            // 
            // rbMatNone
            // 
            this.rbMatNone.AutoSize = true;
            this.rbMatNone.Location = new System.Drawing.Point(6, 88);
            this.rbMatNone.Name = "rbMatNone";
            this.rbMatNone.Size = new System.Drawing.Size(31, 17);
            this.rbMatNone.TabIndex = 310;
            this.rbMatNone.Text = "0";
            this.rbMatNone.UseVisualStyleBackColor = true;
            // 
            // rbMatQuarter
            // 
            this.rbMatQuarter.AutoSize = true;
            this.rbMatQuarter.Location = new System.Drawing.Point(6, 65);
            this.rbMatQuarter.Name = "rbMatQuarter";
            this.rbMatQuarter.Size = new System.Drawing.Size(42, 17);
            this.rbMatQuarter.TabIndex = 300;
            this.rbMatQuarter.Text = "1/4";
            this.rbMatQuarter.UseVisualStyleBackColor = true;
            // 
            // rbMatHalf
            // 
            this.rbMatHalf.AutoSize = true;
            this.rbMatHalf.Location = new System.Drawing.Point(6, 42);
            this.rbMatHalf.Name = "rbMatHalf";
            this.rbMatHalf.Size = new System.Drawing.Size(42, 17);
            this.rbMatHalf.TabIndex = 290;
            this.rbMatHalf.Text = "1/2";
            this.rbMatHalf.UseVisualStyleBackColor = true;
            // 
            // rbMatFull
            // 
            this.rbMatFull.AutoSize = true;
            this.rbMatFull.Checked = true;
            this.rbMatFull.Location = new System.Drawing.Point(6, 19);
            this.rbMatFull.Name = "rbMatFull";
            this.rbMatFull.Size = new System.Drawing.Size(31, 17);
            this.rbMatFull.TabIndex = 280;
            this.rbMatFull.TabStop = true;
            this.rbMatFull.Text = "1";
            this.rbMatFull.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbBoltAnchor);
            this.groupBox5.Controls.Add(this.rbBoltChem);
            this.groupBox5.Controls.Add(this.rbBoltStud);
            this.groupBox5.Controls.Add(this.rbBoltStd);
            this.groupBox5.Location = new System.Drawing.Point(313, 9);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(89, 132);
            this.groupBox5.TabIndex = 90;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Bolt Type";
            // 
            // rbBoltAnchor
            // 
            this.rbBoltAnchor.AutoSize = true;
            this.rbBoltAnchor.Location = new System.Drawing.Point(6, 88);
            this.rbBoltAnchor.Name = "rbBoltAnchor";
            this.rbBoltAnchor.Size = new System.Drawing.Size(59, 17);
            this.rbBoltAnchor.TabIndex = 350;
            this.rbBoltAnchor.Text = "Anchor";
            this.rbBoltAnchor.UseVisualStyleBackColor = true;
            // 
            // rbBoltChem
            // 
            this.rbBoltChem.AutoSize = true;
            this.rbBoltChem.Location = new System.Drawing.Point(6, 65);
            this.rbBoltChem.Name = "rbBoltChem";
            this.rbBoltChem.Size = new System.Drawing.Size(52, 17);
            this.rbBoltChem.TabIndex = 340;
            this.rbBoltChem.Text = "Chem";
            this.rbBoltChem.UseVisualStyleBackColor = true;
            // 
            // rbBoltStud
            // 
            this.rbBoltStud.AutoSize = true;
            this.rbBoltStud.Location = new System.Drawing.Point(6, 42);
            this.rbBoltStud.Name = "rbBoltStud";
            this.rbBoltStud.Size = new System.Drawing.Size(47, 17);
            this.rbBoltStud.TabIndex = 330;
            this.rbBoltStud.Text = "Stud";
            this.rbBoltStud.UseVisualStyleBackColor = true;
            // 
            // rbBoltStd
            // 
            this.rbBoltStd.AutoSize = true;
            this.rbBoltStd.Checked = true;
            this.rbBoltStd.Location = new System.Drawing.Point(6, 19);
            this.rbBoltStd.Name = "rbBoltStd";
            this.rbBoltStd.Size = new System.Drawing.Size(65, 17);
            this.rbBoltStd.TabIndex = 320;
            this.rbBoltStd.TabStop = true;
            this.rbBoltStd.Text = "Std Bold";
            this.rbBoltStd.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(223, 182);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 70;
            this.btnOk.Text = "Accept";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(223, 211);
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
            this.ckHighlight.Location = new System.Drawing.Point(43, 188);
            this.ckHighlight.Name = "ckHighlight";
            this.ckHighlight.Size = new System.Drawing.Size(109, 17);
            this.ckHighlight.TabIndex = 110;
            this.ckHighlight.Text = "Highlight in Sheet";
            this.ckHighlight.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbExtraType);
            this.groupBox2.Controls.Add(this.txtWeld);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtBolts);
            this.groupBox2.Controls.Add(this.txtHoles);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(28, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 114);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Extras";
            // 
            // cmbExtraType
            // 
            this.cmbExtraType.FormattingEnabled = true;
            this.cmbExtraType.Items.AddRange(new object[] {
            "Per Foot",
            "Total"});
            this.cmbExtraType.Location = new System.Drawing.Point(7, 21);
            this.cmbExtraType.Name = "cmbExtraType";
            this.cmbExtraType.Size = new System.Drawing.Size(137, 21);
            this.cmbExtraType.TabIndex = 10;
            this.cmbExtraType.Text = "Total";
            // 
            // txtWeld
            // 
            this.txtWeld.Location = new System.Drawing.Point(186, 67);
            this.txtWeld.Name = "txtWeld";
            this.txtWeld.Size = new System.Drawing.Size(36, 20);
            this.txtWeld.TabIndex = 80;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(187, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Weld";
            // 
            // txtBolts
            // 
            this.txtBolts.Location = new System.Drawing.Point(108, 67);
            this.txtBolts.Name = "txtBolts";
            this.txtBolts.Size = new System.Drawing.Size(36, 20);
            this.txtBolts.TabIndex = 70;
            // 
            // txtHoles
            // 
            this.txtHoles.Location = new System.Drawing.Point(23, 67);
            this.txtHoles.Name = "txtHoles";
            this.txtHoles.Size = new System.Drawing.Size(36, 20);
            this.txtHoles.TabIndex = 60;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Inches per Ft";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(96, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Inches (ctc)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(109, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Bolts";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Inches (ctc)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Holes";
            // 
            // frmNewEdgeAngle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 269);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ckHighlight);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBeamType);
            this.Controls.Add(this.txtLengthIn);
            this.Controls.Add(this.txtLenghtFt);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.lblBeam);
            this.Name = "frmNewEdgeAngle";
            this.Text = "Angle Specifications";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBeam;
        private System.Windows.Forms.MaskedTextBox txtQty;
        private System.Windows.Forms.ComboBox cmbBeamType;
        private System.Windows.Forms.MaskedTextBox txtLenghtFt;
        private System.Windows.Forms.MaskedTextBox txtLengthIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbMatNone;
        private System.Windows.Forms.RadioButton rbMatQuarter;
        private System.Windows.Forms.RadioButton rbMatHalf;
        private System.Windows.Forms.RadioButton rbMatFull;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbBoltAnchor;
        private System.Windows.Forms.RadioButton rbBoltChem;
        private System.Windows.Forms.RadioButton rbBoltStud;
        private System.Windows.Forms.RadioButton rbBoltStd;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox ckHighlight;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbExtraType;
        private System.Windows.Forms.MaskedTextBox txtWeld;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox txtBolts;
        private System.Windows.Forms.MaskedTextBox txtHoles;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}