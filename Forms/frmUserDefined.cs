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
    public partial class frmUserDefined : Form
    {
        internal Components.UserDefined Values;
        public frmUserDefined()
        {
            InitializeComponent();
        }

        //I'm only going to hide the form rather than dispose since they may want to re-check it.
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Values.Checked = true;
                Values.Name = txtWeight.Text;
                if (txtWeight.Text != "") { Values.TotalWeight = Double.Parse(txtWeight.Text); }
                if (txtShopHours.Text != "") { Values.ShopHours = Double.Parse(txtShopHours.Text); }
                if (txtBolts.Text != "") { Values.Bolts = Int32.Parse(txtBolts.Text); }
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
