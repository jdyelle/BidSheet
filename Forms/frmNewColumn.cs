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
    public partial class frmNewColumn : Form
    {
        Common.ExceptionHandler ExHandler;
        Common.ChildFormClosed ChildClosed;

        internal Components.ColumnInfo _Column;

        internal frmNewColumn(Common.ExceptionHandler ExceptionTarget, Common.ChildFormClosed FormClosed, Components.ColumnInfo Column)
        {
            InitializeComponent();
            this.ExHandler = ExceptionTarget;
            this.ChildClosed = FormClosed;
            this._Column = Column;

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
                cmbBeamType.Text = "W813";
            
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _Column.Qty = Int32.Parse(txtQty.Text);
            _Column.Size = cmbBeamType.Text;
            _Column.LengthFt = Int32.Parse(txtLenghtFt.Text);
            _Column.LengthIn = Int32.Parse(txtLengthIn.Text);

            _Column.CapPlate.Thickness = Double.Parse(txtCapThickness.Text);
            _Column.CapPlate.Width = Double.Parse(txtCapWidth.Text);
            _Column.CapPlate.Length = Double.Parse(txtCapLength.Text);
            _Column.CapPlate.Studs = Int32.Parse(txtCapHoles.Text);

            _Column.BasePlate.Thickness = Double.Parse(txtBaseThickness.Text);
            _Column.BasePlate.Width = Double.Parse(txtBaseWidth.Text);
            _Column.BasePlate.Length = Double.Parse(txtBaseLength.Text);
            _Column.BasePlate.Studs = Int32.Parse(txtBaseHoles.Text);

            if (rbMatFull.Checked)      { _Column.MatlHandling = Components.Enums.HandlingModifier.Full; }
            if (rbMatHalf.Checked)      { _Column.MatlHandling = Components.Enums.HandlingModifier.Half; }
            if (rbMatQuarter.Checked)   { _Column.MatlHandling = Components.Enums.HandlingModifier.Quarter; }
            if (rbMatNone.Checked)      { _Column.MatlHandling = Components.Enums.HandlingModifier.None; }

            if (rbBoltStd.Checked)      { _Column.BoltType = Components.Enums.BoltTypes.Standard; }
            if (rbBoltStud.Checked)     { _Column.BoltType = Components.Enums.BoltTypes.Stud; }
            if (rbBoltChem.Checked)     { _Column.BoltType = Components.Enums.BoltTypes.Chem; }
            if (rbBoltAnchor.Checked)   { _Column.BoltType = Components.Enums.BoltTypes.Anchor; }

            if (ckHighlight.Checked) { _Column.Highlight = true; }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

    }
}
