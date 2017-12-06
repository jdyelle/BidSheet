using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BidSheet.Forms
{
    public partial class frmExtras : Form
    {
        internal Components.Extras Values;
        public frmExtras()
        {
            InitializeComponent();
            cmbExtraType.Text = "Per Foot";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbExtraType.Text == "Per Foot")
            {
                label8.Text = "Inches (ctc)";
                label13.Text = "Inches (ctc)";
                label6.Text = "Inches per Ft";
                Values.Total = false;
            }
            if (cmbExtraType.Text == "Total")
            {
                label8.Text = "Qty";
                label13.Text = "Qty";
                label6.Text = "Weld Total";
                Values.Total = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHoles.Text != "") { Values.Holes = Double.Parse(txtHoles.Text); }
                if (txtBolts.Text != "") { Values.Bolts = Int32.Parse(txtBolts.Text); }
                if (txtWeld.Text != "") { Values.Welds = Double.Parse(txtWeld.Text); }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Something doesn't make sense, try again.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Hide();
        }
    }
}
