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
    public partial class frmNewEdgeAngle : Form
    {
        Common.ExceptionHandler ExHandler;
        Common.ChildFormClosed ChildClosed;

        internal Components.EdgeAngleInfo _EdgeAngle;

        internal frmNewEdgeAngle(Common.ExceptionHandler ExceptionTarget, Common.ChildFormClosed FormClosed, Components.EdgeAngleInfo EdgeAngle)
        {
            InitializeComponent();
            this.ExHandler = ExceptionTarget;
            this.ChildClosed = FormClosed;
            this._EdgeAngle = EdgeAngle;

            //All of this block is just to get the lookup codes from the database for the dropdown.
                Common.dbConnection.Open();
                List<string> _DropdownOptions = new List<string>();
                SQLiteCommand command = new SQLiteCommand("select lookup from SteelLookup");
                command.Connection = Common.dbConnection;
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    _DropdownOptions.Add(reader.GetString(0));
                }
                Common.dbConnection.Close();
                cmbBeamType.DataSource = _DropdownOptions;
                cmbBeamType.Text = "L20203";
            
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _EdgeAngle.Qty = Int32.Parse(txtQty.Text);
            _EdgeAngle.Size = cmbBeamType.Text;
            _EdgeAngle.LengthFt = Int32.Parse(txtLenghtFt.Text);
            _EdgeAngle.LengthIn = Int32.Parse(txtLengthIn.Text);

            if (rbMatFull.Checked)      { _EdgeAngle.MatlHandling = Components.Enums.HandlingModifier.Full; }
            if (rbMatHalf.Checked)      { _EdgeAngle.MatlHandling = Components.Enums.HandlingModifier.Half; }
            if (rbMatQuarter.Checked)   { _EdgeAngle.MatlHandling = Components.Enums.HandlingModifier.Quarter; }
            if (rbMatNone.Checked)      { _EdgeAngle.MatlHandling = Components.Enums.HandlingModifier.None; }

            if (rbBoltStd.Checked)      { _EdgeAngle.BoltType = Components.Enums.BoltTypes.Standard; }
            if (rbBoltStud.Checked)     { _EdgeAngle.BoltType = Components.Enums.BoltTypes.Stud; }
            if (rbBoltChem.Checked)     { _EdgeAngle.BoltType = Components.Enums.BoltTypes.Chem; }
            if (rbBoltAnchor.Checked)   { _EdgeAngle.BoltType = Components.Enums.BoltTypes.Anchor; }

            if (ckHighlight.Checked) { _EdgeAngle.Highlight = true; }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbExtraType.Text == "Per Foot")
            {
                label8.Text = "Inches (ctc)";
                label13.Text = "Inches (ctc)";
                label6.Text = "Inches per Ft";
                _EdgeAngle.Extras.Total = false;
            }
            if (cmbExtraType.Text == "Total")
            {
                label8.Text = "Qty";
                label13.Text = "Qty";
                label6.Text = "Weld Total";
                _EdgeAngle.Extras.Total = true;
            }
        }

    }
}
