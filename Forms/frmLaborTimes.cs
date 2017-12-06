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
    public partial class frmLaborTimes : Form
    {
        Components.LaborTimes _LaborTimes;
        public EventHandler UpdateDetails;
        public delegate void WriteEntry(string LogEntry);
        Common.WriteEntry LogEntry;
        Common.ExceptionHandler ExHandler;
        internal frmLaborTimes(Components.LaborTimes Timings, Common.WriteEntry WriteLog, Common.ExceptionHandler Handler)
        {
            InitializeComponent();

            this.ExHandler = Handler;
            this.LogEntry = WriteLog;
            _LaborTimes = Timings;
            desc_Clips.Text = Components.LaborTimes.Descriptions.Clips;
            desc_Holes.Text = Components.LaborTimes.Descriptions.Holes;
            desc_Welds.Text = Components.LaborTimes.Descriptions.Welds;
            desc_Cuts.Text = Components.LaborTimes.Descriptions.Cuts;
            desc_Copes.Text = Components.LaborTimes.Descriptions.Copes;
            desc_ShearPlates.Text = Components.LaborTimes.Descriptions.ShearPlates;
            desc_CapPlates.Text = Components.LaborTimes.Descriptions.CapPlates;
            desc_BasePlates.Text = Components.LaborTimes.Descriptions.BasePlates;
            desc_Handrails.Text = Components.LaborTimes.Descriptions.Handrails;
            desc_Guardrails.Text = Components.LaborTimes.Descriptions.Guardrails;
            desc_Stiffners.Text = Components.LaborTimes.Descriptions.Stiffners;
            desc_Gusset.Text = Components.LaborTimes.Descriptions.Gusset;
            desc_HandWelds.Text = Components.LaborTimes.Descriptions.HWelds;
            desc_LessThan50.Text = Components.LaborTimes.Descriptions.MatHandleLess50lbs;
            desc_LessThan10.Text = Components.LaborTimes.Descriptions.MatHandleLess10ft;
            desc_Other.Text = Components.LaborTimes.Descriptions.MatHandleOther;

            txtClips.Text = _LaborTimes.Clips.ToString();
            txtHoles.Text = _LaborTimes.Holes.ToString();
            txtWelds.Text = _LaborTimes.Welds.ToString();
            txtCuts.Text = _LaborTimes.Cuts.ToString();
            txtCopes.Text = _LaborTimes.Copes.ToString();
            txtShearPlates.Text = _LaborTimes.ShearPlates.ToString();
            txtCapPlates.Text = _LaborTimes.CapPlates.ToString();
            txtBasePlates.Text = _LaborTimes.BasePlates.ToString();
            txtHandrails.Text = _LaborTimes.Handrails.ToString();
            txtGuardrails.Text = _LaborTimes.Guardrails.ToString();
            txtStiffners.Text = _LaborTimes.Stiffners.ToString();
            txtGusset.Text = _LaborTimes.Gusset.ToString();
            txtHandWelds.Text = _LaborTimes.HWelds.ToString();
            txtMatHandle50lbs.Text = _LaborTimes.MatHandleLess50lbs.ToString();
            txtMatHandle10ft.Text = _LaborTimes.MatHandleLess10ft.ToString();
            txtMatHandleOther.Text = _LaborTimes.MatHandleOther.ToString();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool _Continue = true;
            Font ErrorFont = new Font(lblClips.Font, FontStyle.Bold);
            Font ClearFont = new Font(lblClips.Font, FontStyle.Regular);
            try 
            {
                lblClips.Font = ClearFont;
                lblClips.ForeColor = System.Drawing.Color.Black;
                _LaborTimes.Clips = Double.Parse(txtClips.Text); 
            }
            catch
            {
                lblClips.Font = ErrorFont;
                lblClips.ForeColor = System.Drawing.Color.Maroon;
                _Continue = false;
            }

            try 
            { 
                _LaborTimes.Holes = Double.Parse(txtHoles.Text);
                lblHoles.Font = ClearFont;
                lblHoles.ForeColor = System.Drawing.Color.Black;
            }
            catch
            {
                lblHoles.Font = ErrorFont;
                lblHoles.ForeColor = System.Drawing.Color.Maroon;
                _Continue = false;
            }

            try 
            { 
                _LaborTimes.Welds = Double.Parse(txtWelds.Text);
                lblWelds.Font = ClearFont;
                lblWelds.ForeColor = System.Drawing.Color.Black;
            }
            catch
            {
                lblWelds.Font = ErrorFont;
                lblWelds.ForeColor = System.Drawing.Color.Maroon;
                _Continue = false;
            }

            try 
            { 
                _LaborTimes.Cuts = Double.Parse(txtCuts.Text);
                lblCuts.Font = ClearFont;
                lblCuts.ForeColor = System.Drawing.Color.Black;
            }
            catch
            {
                lblCuts.Font = ErrorFont;
                lblCuts.ForeColor = System.Drawing.Color.Maroon;
                _Continue = false;
            }

            try 
            { 
                _LaborTimes.Copes = Double.Parse(txtCopes.Text);
                lblCopes.Font = ClearFont;
                lblCopes.ForeColor = System.Drawing.Color.Black;
            }
            catch
            {
                lblCopes.Font = ErrorFont;
                lblCopes.ForeColor = System.Drawing.Color.Maroon;
                _Continue = false;
            }

            try 
            { 
                _LaborTimes.ShearPlates = Double.Parse(txtShearPlates.Text);
                lblShearPlates.Font = ClearFont;
                lblShearPlates.ForeColor = System.Drawing.Color.Black;
            }
            catch
            {
                lblShearPlates.Font = ErrorFont;
                lblShearPlates.ForeColor = System.Drawing.Color.Maroon;
                _Continue = false;
            }

            try 
            { 
                _LaborTimes.CapPlates = Double.Parse(txtCapPlates.Text);
                lblShearPlates.Font = ClearFont;
                lblShearPlates.ForeColor = System.Drawing.Color.Black;
            }
            catch
            {
                lblCapPlates.Font = ErrorFont;
                lblCapPlates.ForeColor = System.Drawing.Color.Maroon;
                _Continue = false;
            }

            try 
            { 
                _LaborTimes.BasePlates = Double.Parse(txtBasePlates.Text);
                lblBasePlates.Font = ClearFont;
                lblBasePlates.ForeColor = System.Drawing.Color.Black;
            }
            catch
            {
                lblBasePlates.Font = ErrorFont;
                lblBasePlates.ForeColor = System.Drawing.Color.Maroon;
                _Continue = false;
            }

            try 
            { 
                _LaborTimes.Handrails = Double.Parse(txtHandrails.Text);
                lblHandrails.Font = ClearFont;
                lblHandrails.ForeColor = System.Drawing.Color.Black;
            }
            catch
            {
                lblHandrails.Font = ErrorFont;
                lblHandrails.ForeColor = System.Drawing.Color.Maroon;
                _Continue = false;
            }

            try
            {
                _LaborTimes.Guardrails = Double.Parse(txtGuardrails.Text);
                lblGuardrails.Font = ClearFont;
                lblGuardrails.ForeColor = System.Drawing.Color.Black;
            }
            catch
            {
                lblGuardrails.Font = ErrorFont;
                lblGuardrails.ForeColor = System.Drawing.Color.Maroon;
                _Continue = false;
            }

            try 
            {
                _LaborTimes.Stiffners = Double.Parse(txtStiffners.Text);
                lblStiffners.Font = ClearFont;
                lblStiffners.ForeColor = System.Drawing.Color.Black;
            }
            catch
            {
                lblStiffners.Font = ErrorFont;
                lblStiffners.ForeColor = System.Drawing.Color.Maroon;
                _Continue = false;
            }

            try 
            { 
                _LaborTimes.Gusset = Double.Parse(txtGusset.Text);
                lblGusset.Font = ClearFont;
                lblGusset.ForeColor = System.Drawing.Color.Black;
            }
            catch
            {
                lblGusset.Font = ErrorFont;
                lblGusset.ForeColor = System.Drawing.Color.Maroon;
                _Continue = false;
            }

            try 
            {
                _LaborTimes.HWelds = Double.Parse(txtHandWelds.Text);
                lblHandWelds.Font = ClearFont;
                lblHandWelds.ForeColor = System.Drawing.Color.Black;
            }
            catch
            {
                lblHandWelds.Font = ErrorFont;
                lblHandWelds.ForeColor = System.Drawing.Color.Maroon;
                _Continue = false;
            }

            try
            {
                _LaborTimes.MatHandleLess50lbs = Double.Parse(txtMatHandle50lbs.Text);
                txtMatHandle50lbs.Font = ClearFont;
                txtMatHandle50lbs.ForeColor = System.Drawing.Color.Black;
            }
            catch
            {
                txtMatHandle50lbs.Font = ErrorFont;
                txtMatHandle50lbs.ForeColor = System.Drawing.Color.Maroon;
                _Continue = false;
            }

            try
            {
                _LaborTimes.MatHandleLess10ft = Double.Parse(txtMatHandle10ft.Text);
                txtMatHandle10ft.Font = ClearFont;
                txtMatHandle10ft.ForeColor = System.Drawing.Color.Black;
            }
            catch
            {
                txtMatHandle10ft.Font = ErrorFont;
                txtMatHandle10ft.ForeColor = System.Drawing.Color.Maroon;
                _Continue = false;
            }

            try
            {
                _LaborTimes.MatHandleOther = Double.Parse(txtMatHandleOther.Text);
                txtMatHandleOther.Font = ClearFont;
                txtMatHandleOther.ForeColor = System.Drawing.Color.Black;
            }
            catch
            {
                txtMatHandleOther.Font = ErrorFont;
                txtMatHandleOther.ForeColor = System.Drawing.Color.Maroon;
                _Continue = false;
            }

            //I get to be sloppy here because I know LaborTimes catches its exceptions.
            if (_Continue) 
            { 
                _LaborTimes.SaveToFile();
                this.Dispose();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmLaborTimes_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogEntry("Updating Saved Variables in the Text File");
        }
    }
}
