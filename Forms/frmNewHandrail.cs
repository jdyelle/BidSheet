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
    public partial class frmNewHandrail : Form
    {
        Common.ExceptionHandler ExHandler;
        Common.ChildFormClosed ChildClosed;

        internal Components.HandrailInfo _Handrail;

        internal frmNewHandrail(Common.ExceptionHandler ExceptionTarget, Common.ChildFormClosed FormClosed, Components.HandrailInfo Handrail)
        {
            InitializeComponent();
            this.ExHandler = ExceptionTarget;
            this.ChildClosed = FormClosed;
            this._Handrail = Handrail;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmbRailType.Text == "Guardrail") { _Handrail.Handrail = false; }
            _Handrail.Runs = Double.Parse(txtRuns.Text);
            _Handrail.Length = Double.Parse(txtLength.Text);
            _Handrail.Sloped = ckSloped.Checked;

            Double.TryParse(txtMemberASqFt.Text, out _Handrail.MemberASqFt);
            Double.TryParse(txtMemberAWtFt.Text, out _Handrail.MemberAWtFt);
            Double.TryParse(txtMemberBSqFt.Text, out _Handrail.MemberBSqFt);
            Double.TryParse(txtMemberBWtFt.Text, out _Handrail.MemberBWtFt);
            Double.TryParse(txtMemberCSqFt.Text, out _Handrail.MemberCSqFt);
            Double.TryParse(txtMemberCWtFt.Text, out _Handrail.MemberCWtFt);
            Double.TryParse(txtMemberDSqFt.Text, out _Handrail.MemberDSqFt);
            Double.TryParse(txtMemberDWtFt.Text, out _Handrail.MemberDWtFt);
            Double.TryParse(txtPicketSqFt.Text, out _Handrail.PicketSqFt);
            Double.TryParse(txtPicketLength.Text, out _Handrail.PicketLength);
            Double.TryParse(txtPicketWtFt.Text, out _Handrail.PicketWtFt);

            if (_Handrail.Handrail && _Handrail.Sloped) { _Handrail.Size = "Sloped Handrail"; }
            if (!_Handrail.Handrail && _Handrail.Sloped) { _Handrail.Size = "Sloped Guardrail"; }
            if (_Handrail.Handrail && !_Handrail.Sloped) { _Handrail.Size = "Straight Handrail"; }
            if (!_Handrail.Handrail && !_Handrail.Sloped) { _Handrail.Size = "Straight Guardrail"; }
            if (ckHighlight.Checked) { _Handrail.Highlight = true; }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

    }
}
