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
    public partial class frmBearingPlate : Form
    {
        internal Components.BearingPlate Values;
        public frmBearingPlate()
        {
            InitializeComponent();
        }

        //I'm only going to hide the form rather than dispose since they may want to re-check it.
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Values.Checked = true;
                if (txtStuds.Text != "") { Values.Studs = Int32.Parse(txtStuds.Text); }
                if (txtThickness.Text != "") { Values.Thickness = Double.Parse(txtThickness.Text); }
                if (txtWidth.Text != "") { Values.Width = Double.Parse(txtWidth.Text); }
                if (txtLength.Text != "") { Values.Length = Double.Parse(txtLength.Text); }
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
            Values.Checked = false;
            this.Hide();
        }
    }
}
