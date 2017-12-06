using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace BidSheet.Forms
{
    public partial class frmNewStairs : Form
    {
        Common.ExceptionHandler ExHandler;
        Common.ChildFormClosed ChildClosed;

        internal Components.StairsInfo _Stairs;

        internal frmNewStairs(Common.ExceptionHandler ExceptionTarget, Common.ChildFormClosed FormClosed, Components.StairsInfo Stairs)
        {
            InitializeComponent();
            this.ExHandler = ExceptionTarget;
            this.ChildClosed = FormClosed;
            this._Stairs = Stairs;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Int32.TryParse(txtFlights.Text, out _Stairs.Flights);
            Int32.TryParse(txtTreads.Text, out _Stairs.Treads);
            Double.TryParse(txtStringerWt.Text, out _Stairs.StringerWeight);

            _Stairs.Grating = ckGrating.Checked;
            _Stairs.Pan = ckPan.Checked;
            _Stairs.Bolted = ckBolted.Checked;

            if (ckHighlight.Checked) { _Stairs.Highlight = true; }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

    }
}
