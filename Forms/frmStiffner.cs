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
    public partial class frmStiffner : Form
    {
        internal Components.Stiffner Values;
        public frmStiffner()
        {            
            InitializeComponent();
        }

        //I'm only going to hide the form rather than dispose since they may want to re-check it.
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStifQty.Text != "") { Values.StiffnerQty = Double.Parse(txtStifQty.Text); }
                if (txtStifThick.Text != "") { Values.StiffnerThickness = Double.Parse(txtStifThick.Text); }
                if (txtStifWeld.Text != "") { Values.StiffnerPercentWeld = Double.Parse(txtStifWeld.Text); }
                if (txtGusQty.Text != "") { Values.GussetQty = Double.Parse(txtGusQty.Text); }
                if (txtGusThick.Text != "") { Values.GussetThickness = Double.Parse(txtGusThick.Text); }
                if (txtGusWidth.Text != "") { Values.GussetWidth = Double.Parse(txtGusWidth.Text); }
                if (txtGusLength.Text != "") { Values.GussetLength = Double.Parse(txtGusLength.Text); }
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
