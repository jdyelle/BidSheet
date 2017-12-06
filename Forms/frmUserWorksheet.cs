using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace BidSheet.Forms
{
    public partial class frmUserWorksheet : Form
    {
        Components.ProjectSetup SetupDetails;
        Components.LaborTimes LaborTimings;
        Forms.frmProjectSetup SetupForm; 
        Forms.frmLaborTimes TimingsForm;
        Forms.frmNewBeam BeamForm;
        Forms.frmNewColumn ColumnForm;
        Forms.frmNewHandrail HandrailForm;
        Forms.frmNewStairs StairsForm;
        Forms.frmNewEdgeAngle EdgeAngleForm;
        Forms.frmSplashScreen SplashScreen;

        Common.WriteEntry LogTarget;
        Common.ExceptionHandler ExceptionTarget;
        Common.ChildFormClosed ChildClosed;

        Data.UIGridViewDataTable GridViewSource;

        Dictionary<Int32, Common.Part> Parts;

        FileInfo ExcelFile;
        DataGridViewCellStyle _HighlightStyle;
        List<Int32> _HighlightRows;



        public frmUserWorksheet(Forms.frmSplashScreen InitScreen)
        {
            InitializeComponent();           

            lblError.Text = "";
            SplashScreen = InitScreen;
            LogTarget = Common.WriteLog;
            ExceptionTarget = this.Exceptions;
            ChildClosed = this.RefreshGrid;

            SetupDetails = new Components.ProjectSetup();
            LaborTimings = new Components.LaborTimes(LogTarget, ExceptionTarget);
            LaborTimings.LoadFromFile();

            GridViewSource = new Data.UIGridViewDataTable();
            Parts = new Dictionary<int, Common.Part>();
            dataGridView1.ReadOnly = true;
            _HighlightStyle = new DataGridViewCellStyle();
            _HighlightStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            _HighlightRows = new List<Int32>();

        }

        public void Exceptions(Exception ex)
        {
            LogTarget(ex.ToString());
            lblError.Text = ex.Message;
        }

        public void RefreshGrid()
        {
            dataGridView1.Update();
        }

        private void frmProjectSetup_FormClosing(object sender, EventArgs e)
        {            
            ExcelFile = new FileInfo(GenerateFilename());
            Directory.CreateDirectory(ExcelFile.DirectoryName);
            lblProjectName.Text = ExcelFile.FullName;

            //Create the file from the database template if it isn't there already.
            if (!File.Exists(ExcelFile.FullName))
            {
                using (FileStream _stream = ExcelFile.OpenWrite())
                {
                    try
                    {
                        Byte[] _bytes = Common.GetTemplateBytes();
                        _stream.Write(_bytes, 0, _bytes.Length);
                        _stream.Flush();
                        _bytes = null;
                    }
                    catch (Exception ex)
                    {
                        LogTarget(ex.ToString());
                        lblError.Text = ex.Message;
                    }
                }
            }

            Common.SpreadSheetHeader(SetupDetails, ExcelFile);
        }

        private void frmUserWorksheet_Resize(object sender, EventArgs e)
        {
            dataGridView1.Height = (this.Height - 130);
            dataGridView1.Width = (this.Width - 45);
        }

        private void btnProjectDetails_Click(object sender, EventArgs e)
        {
            SetupForm = new Forms.frmProjectSetup(SetupDetails);
            SetupForm.UpdateDetails += frmProjectSetup_FormClosing;
            SetupForm.ShowDialog();
        }

        private void btnLaborTimes_Click(object sender, EventArgs e)
        {
            TimingsForm = new Forms.frmLaborTimes(LaborTimings, LogTarget, ExceptionTarget);
            TimingsForm.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Int32 _NextRowID = 1;
            if (GridViewSource.Count > 0)
            {
                DataRow[] _temprow = GridViewSource.Select("ItemNumber=MAX(ItemNumber)");
                _NextRowID = 1 + Int32.Parse(_temprow[0][0].ToString());
            }
            switch (cmbTypeSelect.Text)
            {
                case "Beam":
                    Components.BeamInfo _Beam = new Components.BeamInfo(_NextRowID, LaborTimings);
                    BeamForm = new Forms.frmNewBeam(ExceptionTarget, ChildClosed, _Beam);
                    DialogResult beamresult = BeamForm.ShowDialog();
                    if (beamresult == DialogResult.OK)
                    {
                        GridViewSource.ImportRow(_Beam.GetUIRow());
                        Parts.Add(_Beam.RowID, _Beam);                        
                        GridViewSource.AcceptChanges();
                        dataGridView1.DataSource = GridViewSource;
                        if (_Beam.Highlight) { _HighlightRows.Add(dataGridView1.Rows.Count - 2); }
                    }
                    BeamForm.Dispose();
                    break;
                case "Column":
                    Components.ColumnInfo _Column = new Components.ColumnInfo(_NextRowID, LaborTimings);
                    ColumnForm = new Forms.frmNewColumn(ExceptionTarget, ChildClosed, _Column);
                    DialogResult columnresult = ColumnForm.ShowDialog();
                    if (columnresult == DialogResult.OK)
                    {
                        GridViewSource.ImportRow(_Column.GetUIRow());
                        Parts.Add(_Column.RowID, _Column);
                        GridViewSource.AcceptChanges();
                        dataGridView1.DataSource = GridViewSource;
                        if (_Column.Highlight) { _HighlightRows.Add(dataGridView1.Rows.Count - 2); }
                    }
                    ColumnForm.Dispose();
                    break;
                case "Handrail":
                    Components.HandrailInfo _Handrail = new Components.HandrailInfo(_NextRowID, LaborTimings);
                    HandrailForm = new Forms.frmNewHandrail(ExceptionTarget, ChildClosed, _Handrail);
                    DialogResult Handrailresult = HandrailForm.ShowDialog();
                    if (Handrailresult == DialogResult.OK)
                    {
                        GridViewSource.ImportRow(_Handrail.GetUIRow());
                        Parts.Add(_Handrail.RowID, _Handrail);
                        GridViewSource.AcceptChanges();
                        dataGridView1.DataSource = GridViewSource;
                        if (_Handrail.Highlight) { _HighlightRows.Add(dataGridView1.Rows.Count - 2); }
                    }
                    HandrailForm.Dispose();
                    break;
                case "Stairs":
                    Components.StairsInfo _Stairs = new Components.StairsInfo(_NextRowID, LaborTimings);
                    StairsForm = new Forms.frmNewStairs(ExceptionTarget, ChildClosed, _Stairs);
                    DialogResult Stairsresult = StairsForm.ShowDialog();
                    if (Stairsresult == DialogResult.OK)
                    {
                        GridViewSource.ImportRow(_Stairs.GetUIRow());
                        Parts.Add(_Stairs.RowID, _Stairs);
                        GridViewSource.AcceptChanges();
                        dataGridView1.DataSource = GridViewSource;
                        if (_Stairs.Highlight) { _HighlightRows.Add(dataGridView1.Rows.Count - 2); }
                    }
                    StairsForm.Dispose();
                    break;
                case "Edge Angle":
                    Components.EdgeAngleInfo _EdgeAngle = new Components.EdgeAngleInfo(_NextRowID, LaborTimings);
                    EdgeAngleForm = new Forms.frmNewEdgeAngle(ExceptionTarget, ChildClosed, _EdgeAngle);
                    DialogResult EdgeAngleresult = EdgeAngleForm.ShowDialog();
                    if (EdgeAngleresult == DialogResult.OK)
                    {
                        GridViewSource.ImportRow(_EdgeAngle.GetUIRow());
                        Parts.Add(_EdgeAngle.RowID, _EdgeAngle);
                        GridViewSource.AcceptChanges();
                        dataGridView1.DataSource = GridViewSource;
                        if (_EdgeAngle.Highlight) { _HighlightRows.Add(dataGridView1.Rows.Count - 2); }
                    }
                    EdgeAngleForm.Dispose();
                    break;

                default:
                    break;
            }
            //Re-highlight the datagrid after adding a new row (because it resets formatting)
            foreach (int _RowNum in _HighlightRows)
            {
                dataGridView1.Rows[_RowNum].DefaultCellStyle = _HighlightStyle;
            }

        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                Int32 _rowid = Int32.Parse(row.Cells[0].Value.ToString());
                Parts.Remove(_rowid);
                DataRow _row = GridViewSource.Rows.Find(_rowid);
                GridViewSource.Rows.Remove(_row);                
            }
            GridViewSource.AcceptChanges();
            dataGridView1.DataSource = GridViewSource;
        }

        private void btnSpreadsheet_Click(object sender, EventArgs e)
        {
            if (lblProjectName.Text == "...") { MessageBox.Show("Please select a project file either by loading or by creating a new estimate."); }
            else
            {
                try
                {
                    //String _AuthDriveLetter = Common.USBDriveLetter();
                    FileStream _ReadStream = new FileStream(ExcelFile.FullName, FileMode.Open, FileAccess.Read);
                    XSSFWorkbook _ExcelBook = new XSSFWorkbook(_ReadStream);
                    ISheet _MatHandlingSheet = _ExcelBook.GetSheet("Material & Labor Takeoff");
                    String _CellValue = "temp";
                    Int32 _CellRow = 2;
                    Data.SpreadsheetRowsRow _CurrentRow;
                    XSSFCellStyle _Highlighted = (XSSFCellStyle)_MatHandlingSheet.GetRow(0).GetCell(2).CellStyle;

                    foreach (KeyValuePair<Int32, Common.Part> _entry in Parts)
                    {
                        //Loop through rows and find the next available where qty isn't set.
                        while (_CellValue != "")
                        {
                            _CellRow++;
                            _CellValue = _MatHandlingSheet.GetRow(_CellRow).GetCell(1).StringCellValue;
                        }

                        //Populate the values of the spreadsheet row with the datarow from the object
                        _CurrentRow = _entry.Value.GetRow();
                        _MatHandlingSheet.GetRow(_CellRow).GetCell(0).SetCellValue(_CurrentRow.Quantity);
                        _MatHandlingSheet.GetRow(_CellRow).GetCell(1).SetCellValue(_CurrentRow.Size);
                        _MatHandlingSheet.GetRow(_CellRow).GetCell(2).SetCellValue(_CurrentRow.Length);
                        _MatHandlingSheet.GetRow(_CellRow).GetCell(3).SetCellValue(_CurrentRow.TotalSqFt);
                        _MatHandlingSheet.GetRow(_CellRow).GetCell(4).SetCellValue(_CurrentRow.SteelWeight);
                        _MatHandlingSheet.GetRow(_CellRow).GetCell(5).SetCellValue(_CurrentRow.MatHandlingHours);
                        _MatHandlingSheet.GetRow(_CellRow).GetCell(6).SetCellValue(_CurrentRow.FittingWeight);
                        _MatHandlingSheet.GetRow(_CellRow).GetCell(7).SetCellValue(_CurrentRow.ShopHours);
                        if (!_CurrentRow["StdBolt"].Equals(DBNull.Value)) { _MatHandlingSheet.GetRow(_CellRow).GetCell(8).SetCellValue(_CurrentRow.StdBolt); }
                        if (!_CurrentRow["StudBolt"].Equals(DBNull.Value)) { _MatHandlingSheet.GetRow(_CellRow).GetCell(9).SetCellValue(_CurrentRow.StudBolt); }
                        if (!_CurrentRow["ChemBolt"].Equals(DBNull.Value)) { _MatHandlingSheet.GetRow(_CellRow).GetCell(10).SetCellValue(_CurrentRow.ChemBolt); }
                        if (!_CurrentRow["AnchorBolt"].Equals(DBNull.Value)) { _MatHandlingSheet.GetRow(_CellRow).GetCell(11).SetCellValue(_CurrentRow.AnchorBolt); }
                        if (!_CurrentRow["HandrailFeet"].Equals(DBNull.Value)) { _MatHandlingSheet.GetRow(_CellRow).GetCell(12).SetCellValue(_CurrentRow.HandrailFeet); }
                        if (!_CurrentRow["HandrailHours"].Equals(DBNull.Value)) { _MatHandlingSheet.GetRow(_CellRow).GetCell(13).SetCellValue(_CurrentRow.HandrailHours); }
                        if (!_CurrentRow["StairsFlights"].Equals(DBNull.Value)) { _MatHandlingSheet.GetRow(_CellRow).GetCell(14).SetCellValue(_CurrentRow.StairsFlights); }
                        if (!_CurrentRow["StairsHours"].Equals(DBNull.Value)) { _MatHandlingSheet.GetRow(_CellRow).GetCell(15).SetCellValue(_CurrentRow.StairsHours); }
                        if (!_CurrentRow["StairsTreads"].Equals(DBNull.Value)) { _MatHandlingSheet.GetRow(_CellRow).GetCell(16).SetCellValue(_CurrentRow.StairsTreads); }
                        if (!_CurrentRow["ErectionGirders"].Equals(DBNull.Value)) { _MatHandlingSheet.GetRow(_CellRow).GetCell(17).SetCellValue(_CurrentRow.ErectionGirders); }
                        if (!_CurrentRow["ErectionColumns"].Equals(DBNull.Value)) { _MatHandlingSheet.GetRow(_CellRow).GetCell(18).SetCellValue(_CurrentRow.ErectionColumns); }
                        if (!_CurrentRow["ErectionEdgeAngle"].Equals(DBNull.Value)) { _MatHandlingSheet.GetRow(_CellRow).GetCell(19).SetCellValue(_CurrentRow.ErectionEdgeAngle); }
                        if (!_CurrentRow["ErectionGirts"].Equals(DBNull.Value)) { _MatHandlingSheet.GetRow(_CellRow).GetCell(20).SetCellValue(_CurrentRow.ErectionGirts); }

                        //If highlighted is selected, loop through and apply the style
                        if (_CurrentRow.Highlight)
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                _MatHandlingSheet.GetRow(_CellRow).GetCell(i).CellStyle = _Highlighted;
                            }
                        }

                        //clean up the collections
                        DataRow _row = GridViewSource.Rows.Find(_entry.Key);
                        GridViewSource.Rows.Remove(_row);
                        _HighlightRows.Clear();
                        _CellRow++;
                        _CellValue = _MatHandlingSheet.GetRow(_CellRow).GetCell(1).StringCellValue;

                    }
                    XSSFFormulaEvaluator _Evaluator = new XSSFFormulaEvaluator(_ExcelBook);
                    _Evaluator.EvaluateAll();

                    FileStream _WriteStream = new FileStream(ExcelFile.FullName, FileMode.Create);
                    _ExcelBook.Write(_WriteStream);
                    //_WriteStream.Flush();
                    _WriteStream.Dispose();
                    Parts.Clear();

                    GridViewSource.AcceptChanges();
                    dataGridView1.DataSource = GridViewSource;

                    //lblError.Text = Common.USBDriveLetter();
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                    LogTarget(ex.ToString());
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnLoadProject_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.InitialDirectory = Common.USBDriveLetter() + @"\Projects\";
            openFileDialog1.Filter = "BidSheet Projects (*.xlsx)|*.xlsx";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelFile = new FileInfo(openFileDialog1.FileName);
                lblProjectName.Text = ExcelFile.FullName;

            }
        }

        private String GenerateFilename()
        {
            return /*Common.USBDriveLetter() +*/ @"\Projects\" + SetupDetails.Customer + @"\" + SetupDetails.Project + @"\" +
                SetupDetails.EstimateNum + @" " + SetupDetails.Customer + @" " + SetupDetails.Project + @" " + 
                SetupDetails.ProjectDate.ToString("yyyy-MM-dd") + @".xlsx";
        }

        private void frmUserWorksheet_FormClosing(object sender, FormClosingEventArgs e)
        {
            SplashScreen.Dispose();
        }
    }
}
