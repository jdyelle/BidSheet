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
    public partial class frmNewBeam : Form
    {
        Common.ExceptionHandler ExHandler;
        Common.ChildFormClosed ChildClosed;

        internal Components.BeamInfo _Beam;
        private Components.Stiffner _StiffnerA;
        private Components.Stiffner _StiffnerB;
        private Components.BearingPlate _BearingPlateA;
        private Components.BearingPlate _BearingPlateB;
        private Components.UserDefined _UserDefA;
        private Components.UserDefined _UserDefB;
        private Components.Extras _Extras;
        private Forms.frmStiffner _StiffnerFormA;
        private Forms.frmStiffner _StiffnerFormB;
        private Forms.frmBearingPlate _BearingFormA;
        private Forms.frmBearingPlate _BearingFormB;
        private Forms.frmUserDefined _UserFormA;
        private Forms.frmUserDefined _UserFormB;
        private Forms.frmExtras _ExtrasForm;
                        
        internal frmNewBeam(Common.ExceptionHandler ExceptionTarget, Common.ChildFormClosed FormClosed, Components.BeamInfo Beam)
        {
            InitializeComponent();
            this.ExHandler = ExceptionTarget;
            this.ChildClosed = FormClosed;
            this._Beam = Beam;

            _StiffnerFormA = new frmStiffner();
            _StiffnerFormB = new frmStiffner();
            _BearingFormA = new frmBearingPlate();
            _BearingFormB = new frmBearingPlate();
            _UserFormA = new frmUserDefined();
            _UserFormB = new frmUserDefined();
            _ExtrasForm = new frmExtras();

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
            _Beam.Qty = Int32.Parse(txtQty.Text);
            _Beam.Size = cmbBeamType.Text;
            _Beam.LengthFt = Int32.Parse(txtLenghtFt.Text);
            _Beam.LengthIn = Int32.Parse(txtLengthIn.Text);
            _Beam.LintelType = Components.Enums.LintelTypes.None;

            if (ckAStdDblAngle.Checked)  { _Beam.EndA.StdDblAngle = true; }
            if (ckAStdSngAngle.Checked)  { _Beam.EndA.StdSngAngle = true; }
            if (ckAShearPlate.Checked)   { _Beam.EndA.ShearPlate = true; }
            if (ckACut.Checked)          { _Beam.EndA.Cut = true; }
            if (ckADoubleCope.Checked)   { _Beam.EndA.DoubleCope = true; }
            if (ckASingleCope.Checked)   { _Beam.EndA.SingleCope = true; }
            if (ckAStiffner.Checked)     { _Beam.EndA.Stiffner = _StiffnerA; }
            if (ckABearingPlate.Checked) { _Beam.EndA.BearingPlate = _BearingPlateA; }
            if (ckAUserDefined.Checked)  { _Beam.EndA.User = _UserDefA; }

            if (ckBStdDblAngle.Checked)  { _Beam.EndB.StdDblAngle = true; }
            if (ckBStdSngAngle.Checked)  { _Beam.EndB.StdSngAngle = true; }
            if (ckBShearPlate.Checked)   { _Beam.EndB.ShearPlate = true; }
            if (ckBCut.Checked)          { _Beam.EndB.Cut = true; }
            if (ckBDoubleCope.Checked)   { _Beam.EndB.DoubleCope = true; }
            if (ckBSingleCope.Checked)   { _Beam.EndB.SingleCope = true; }
            if (ckBStiffner.Checked)     { _Beam.EndB.Stiffner = _StiffnerB; }
            if (ckBBearingPlate.Checked) { _Beam.EndB.BearingPlate = _BearingPlateB; }
            if (ckBUserDefined.Checked)  { _Beam.EndB.User = _UserDefB; }

            if (ckErecGirder.Checked)    { _Beam.Erection.Girder = true; }
            if (ckErecColumn.Checked)    { _Beam.Erection.Column = true; }
            if (ckErecAngle.Checked)     { _Beam.Erection.EdgeAngle = true; }
            if (ckErecGirt.Checked)      { _Beam.Erection.Girt = true; }

            if (rbMatFull.Checked)       { _Beam.MatlHandling = Components.Enums.HandlingModifier.Full; }
            if (rbMatHalf.Checked)       { _Beam.MatlHandling = Components.Enums.HandlingModifier.Half; }
            if (rbMatQuarter.Checked)    { _Beam.MatlHandling = Components.Enums.HandlingModifier.Quarter; }
            if (rbMatNone.Checked)       { _Beam.MatlHandling = Components.Enums.HandlingModifier.None; }

            if (rbBoltStd.Checked)       { _Beam.BoltType = Components.Enums.BoltTypes.Standard; }
            if (rbBoltStud.Checked)      { _Beam.BoltType = Components.Enums.BoltTypes.Stud; }
            if (rbBoltChem.Checked)      { _Beam.BoltType = Components.Enums.BoltTypes.Chem; }
            if (rbBoltAnchor.Checked)    { _Beam.BoltType = Components.Enums.BoltTypes.Anchor; }

            if (rbLinBackBack.Checked)     { _Beam.LintelType = Components.Enums.LintelTypes.BackBack; }
            if (rbLinSingle.Checked)       { _Beam.LintelType = Components.Enums.LintelTypes.Single; }
            if (rbLinBeamPlate.Checked)    { _Beam.LintelType = Components.Enums.LintelTypes.BeamPlate; }
            if (rbLinPlainBollard.Checked) { _Beam.LintelType = Components.Enums.LintelTypes.Bollard; }
            if (rbLinBollardPlate.Checked) { _Beam.LintelType = Components.Enums.LintelTypes.PlateBollard; }

            if (ckAddExtras.Checked) { _Beam.Extras = _Extras; }
            if (ckHighlight.Checked) { _Beam.Highlight = true; }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void ckAStiffner_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAStiffner.Checked)
            {                
                DialogResult result = _StiffnerFormA.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _StiffnerA = _StiffnerFormA.Values;
                }
                if (result == DialogResult.Cancel)
                {
                    ckAStiffner.Checked = false;
                }
            }
            else
            {
                //Probably only need to set quantities to 0 because calculations.
                _StiffnerA.StiffnerQty = 0;
                _StiffnerA.StiffnerThickness = 0;
                _StiffnerA.StiffnerPercentWeld = 0;
                _StiffnerA.GussetQty = 0;
                _StiffnerA.GussetThickness = 0;
                _StiffnerA.GussetWidth = 0;
                _StiffnerA.GussetLength = 0;
                _StiffnerA.GussetWeld = 0;
            }

        }

        private void ckBStiffner_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBStiffner.Checked)
            {
                DialogResult result = _StiffnerFormB.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _StiffnerB = _StiffnerFormB.Values;
                }
                if (result == DialogResult.Cancel)
                {
                    ckBStiffner.Checked = false;
                }
            }
            else
            {
                //Probably only need to set quantities to 0 because calculations.
                _StiffnerB.StiffnerQty = 0;
                _StiffnerB.StiffnerThickness = 0;
                _StiffnerB.StiffnerPercentWeld = 0;
                _StiffnerB.GussetQty = 0;
                _StiffnerB.GussetThickness = 0;
                _StiffnerB.GussetWidth = 0;
                _StiffnerB.GussetLength = 0;
                _StiffnerB.GussetWeld = 0;
            }

        }

        private void ckABearingPlate_CheckedChanged(object sender, EventArgs e)
        {
            if (ckABearingPlate.Checked)
            {
                DialogResult result = _BearingFormA.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _BearingPlateA = _BearingFormA.Values;
                }
                if (result == DialogResult.Cancel)
                {
                    ckABearingPlate.Checked = false;
                    _Beam.EndA.BearingPlate.Checked = false;
                }
            }
            else
            {
                _BearingPlateA.Thickness = 0;
                _BearingPlateA.Width = 0;
                _BearingPlateA.Length = 0;
                _BearingPlateA.Studs = 0;
            }
        }

        private void ckBBearingPlate_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBBearingPlate.Checked)
            {
                DialogResult result = _BearingFormB.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _BearingPlateB = _BearingFormB.Values;
                }
                if (result == DialogResult.Cancel)
                {
                    ckBBearingPlate.Checked = false;
                    _Beam.EndB.BearingPlate.Checked = false;
                }
            }
            else
            {
                _BearingPlateB.Thickness = 0;
                _BearingPlateB.Width = 0;
                _BearingPlateB.Length = 0;
                _BearingPlateB.Studs = 0;
            }
        }

        private void ckAUserDefined_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAUserDefined.Checked)
            {
                DialogResult result = _UserFormA.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _UserDefA = _UserFormA.Values;
                }
                if (result == DialogResult.Cancel)
                {
                    ckAUserDefined.Checked = false;
                    _Beam.EndA.User.Checked = false;
                }
            }
            else
            {
                _UserDefA.Name = "";
                _UserDefA.ShopHours = 0;
                _UserDefA.TotalWeight = 0;
                _UserDefA.Bolts = 0;
            }
        }

        private void ckBUserDefined_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBUserDefined.Checked)
            {
                DialogResult result = _UserFormB.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _UserDefB = _UserFormB.Values;
                }
                if (result == DialogResult.Cancel)
                {
                    ckBUserDefined.Checked = false;
                    _Beam.EndB.User.Checked = false;
                }
            }
            else
            {
                _UserDefB.Name = "";
                _UserDefB.ShopHours = 0;
                _UserDefB.TotalWeight = 0;
                _UserDefB.Bolts = 0;
            }
        }

        private void ckAddExtras_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAddExtras.Checked)
            {
                DialogResult result = _ExtrasForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _Extras = _ExtrasForm.Values;
                }
                if (result == DialogResult.Cancel)
                {
                    ckAddExtras.Checked = false;
                }
            }
            else
            {
                _Extras.Total = true;
                _Extras.Holes = 0;
                _Extras.Bolts = 0;
                _Extras.Welds = 0;
            }
        }
        
    }
}
