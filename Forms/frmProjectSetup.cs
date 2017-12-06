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
    public partial class frmProjectSetup : Form
    {
        Components.ProjectSetup _SetupDetails;
        public EventHandler UpdateDetails;
        internal frmProjectSetup(Components.ProjectSetup SetupDetails)//, Delegate UpdateDetails)
        {
            InitializeComponent();
            _SetupDetails = SetupDetails;
            txtCustomer.Text = _SetupDetails.Customer;
            txtEstimateNum.Text = _SetupDetails.EstimateNum;
            txtProject.Text = _SetupDetails.Project;
            txtDate.Text = _SetupDetails.ProjectDate.ToString("MM/dd/yyyy");
            txtSqFt.Text = _SetupDetails.SquareFt;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _SetupDetails.Customer = txtCustomer.Text;
            _SetupDetails.EstimateNum = txtEstimateNum.Text;
            _SetupDetails.Project = txtProject.Text;
            _SetupDetails.SquareFt = txtSqFt.Text;
            try 
            { 
                _SetupDetails.ProjectDate = DateTime.Parse(txtDate.Text);
                this.Dispose();
            }
            catch 
            { 
                txtDate.ForeColor = System.Drawing.Color.Maroon;
                lblDate.Font = new Font(lblDate.Font, FontStyle.Bold);
                lblDate.ForeColor = System.Drawing.Color.Maroon;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmProjectSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.UpdateDetails(this, new EventArgs());
        }
    }
}
