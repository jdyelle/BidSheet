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
    public partial class frmSplashScreen : Form
    {
        private Timer _BarTimer = new Timer();
        Forms.frmUserWorksheet _MainAppWindow;
        String _DriveLetter = "";

        public frmSplashScreen()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.TopMost = true;
            _MainAppWindow = new frmUserWorksheet(this);
            panel1.Width = 0;
            label4.Text = "";
            InitBarTimer();
        }


        private void InitBarTimer()
        {
            _BarTimer.Interval = 10;
            _BarTimer.Tick += new EventHandler(ProgressBarTimer);
            _BarTimer.Start();
        }

        private void ProgressBarTimer(object sender, EventArgs e)
        {
            panel1.Width = panel1.Width + 5;            
            if (panel1.Width == 50)
            {
                try
                {
                    Common.dbConnection.Open();
                    Common.dbConnection.Close();
                }
                catch (Exception ex)
                {
                    Common.WriteLog(ex.ToString());
                    _BarTimer.Stop();
                    MessageBox.Show("Could not connect to the internal database.  Please reinstall.");
                    this.Dispose();
                }

                label4.Text = "Database Loading";
            }

            if (panel1.Width == 150)
            {
                label4.Text = "Verifying USB";
            }

            if (panel1.Width == 200) 
            {                
                try
                {
                    //_DriveLetter = Common.USBDriveLetter();
                }
                catch (Exception ex)
                {
                    Common.WriteLog(ex.ToString());
                    _BarTimer.Stop();
                    MessageBox.Show(new Form { TopMost = true }, ex.Message);
                    this.Dispose();
                }                
                //label4.Text = "USB Found [" + _DriveLetter + "]";
            }

            if (panel1.Width == 300) 
            { 
                _MainAppWindow.ShowDialog();                
            }

            if (panel1.Width == 400)
            {
                try
                {
                    //Common.VerifyKey(_DriveLetter);
                    //if ((DateTime.Now > DateTime.Parse(@"06/30/2015"))) { throw new Exception("This beta software has expired, please get a new copy"); }
                }
                catch (Exception ex)
                {
                    Common.WriteLog(ex.ToString());
                    _BarTimer.Stop();
                    MessageBox.Show(new Form { TopMost = true }, ex.Message);
                    this.Dispose();
                }
                label4.Text = "Launching Main Window";

            }

            if (panel1.Width == 500)
            {
                label4.Text = "";
                _BarTimer.Dispose();
                this.Hide(); 
            }

        }

    }
}
