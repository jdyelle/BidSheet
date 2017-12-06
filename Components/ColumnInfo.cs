using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace BidSheet.Components
{
    internal class ColumnInfo : Common.Part
    {

        public Int32 RowID;
        public String Size;
        public Double LengthFt;
        public Double LengthIn;
        public Int32 Qty;
        public Components.BearingPlate CapPlate;
        public Components.BearingPlate BasePlate;
        public Components.Enums.BoltTypes BoltType;
        public Components.Enums.HandlingModifier MatlHandling;
        public Boolean Highlight;

        Data.SpreadsheetRowsDataTable _RowsTable;
        Data.UIGridViewDataTable _UIRowsTable;
        Data.UIGridViewRow _UIRow;
        Data.SpreadsheetRowsRow _Row;
        Components.LaborTimes _LaborTimes;

        public ColumnInfo(int RowID, Components.LaborTimes LaborTimings)
        {
            this.RowID = RowID;
            this._LaborTimes = LaborTimings;
            _RowsTable = new Data.SpreadsheetRowsDataTable();
            _Row = _RowsTable.NewSpreadsheetRowsRow();
            _UIRowsTable = new Data.UIGridViewDataTable();
            _UIRow = _UIRowsTable.NewUIGridViewRow();
        }

        public Data.SpreadsheetRowsRow GetRow()
        {
            Data.dtSteelLookupDataTable _SteelLookup = new Data.dtSteelLookupDataTable();
            try
            {
                Common.dbConnection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Parameters.AddWithValue("@size", Size);
                command.Connection = Common.dbConnection;
                command.CommandText = Common.dtSteelLookupQuery;
                SQLiteDataAdapter _adapter = new SQLiteDataAdapter(command);
                _adapter.Fill(_SteelLookup);
                Common.dbConnection.Close();
            }
            catch
            {
                throw;
            }
            Data.dtSteelLookupRow _Lookup = _SteelLookup[0];

            _Row.Quantity = Qty;
            _Row.Size = _Lookup["size"].ToString();
            _Row.Length = Math.Round(LengthFt + (LengthIn / 12), 2);
            Double _SquareFtPer = Double.Parse(_Lookup["sff"].ToString()) * _Row.Length;
            _Row.TotalSqFt = Math.Round(_SquareFtPer * Qty, 2);
            Double _weightPer = Double.Parse(_Lookup["weight_ft"].ToString()) * _Row.Length;
            _Row.SteelWeight = Math.Round(_weightPer * Qty, 2);


            //The next 20 lines are all to deal with _Row.MatHandlingHours
            if (_Row.Length == 0) { _Row.MatHandlingHours = 0; }
            else if (_weightPer < 50) { _Row.MatHandlingHours = _LaborTimes.Adjusted.MatHandleLess50lbs * Qty; }
            else if (_Row.Length < 10) { _Row.MatHandlingHours = _LaborTimes.Adjusted.MatHandleLess10ft * Qty; }
            else { _Row.MatHandlingHours = _LaborTimes.MatHandleOther; }
            switch (MatlHandling)
            {
                case Enums.HandlingModifier.Half:
                    _Row.MatHandlingHours = _Row.MatHandlingHours * .5;
                    break;
                case Enums.HandlingModifier.Quarter:
                    _Row.MatHandlingHours = _Row.MatHandlingHours * .25;
                    break;
                case Enums.HandlingModifier.None:
                    _Row.MatHandlingHours = 0;
                    break;
                default:
                    break;
            }
            
            Double _FitWeight = 0;
            Double _FitHours = 0;
            Int32 _Bolts = 0;

            _FitHours += (_LaborTimes.Adjusted.Holes * CapPlate.Studs * Qty);
            if (CapPlate.Thickness != 0) { _FitHours += (_LaborTimes.Adjusted.CapPlates + (_SquareFtPer * 0.7 * _LaborTimes.Adjusted.HWelds * 12)) * Qty; }
            _FitWeight += (CapPlate.Thickness * CapPlate.Width * CapPlate.Length * 0.283) * Qty;
            _FitHours += ((2 * _LaborTimes.Adjusted.Holes * BasePlate.Studs) + (_LaborTimes.Adjusted.BasePlates) 
                + (_SquareFtPer * 0.7 * _LaborTimes.Adjusted.HWelds * 12)) * Qty;
            _FitWeight += (BasePlate.Length * BasePlate.Thickness * BasePlate.Width * 0.283) * Qty;
            _Bolts += BasePlate.Studs * Qty;

            if (BoltType == Enums.BoltTypes.Standard) { _Row.StdBolt = _Bolts + CapPlate.Studs * Qty; }
            else { _Row.StdBolt = CapPlate.Studs * Qty; }
            if (BoltType == Enums.BoltTypes.Stud) { _Row.StudBolt = _Bolts; }
            if (BoltType == Enums.BoltTypes.Chem) { _Row.ChemBolt = _Bolts; }
            if (BoltType == Enums.BoltTypes.Anchor) { _Row.AnchorBolt = _Bolts; }

            _Row.ErectionColumns = Qty;
            _Row.FittingWeight = _FitWeight;
            _Row.ShopHours = _FitHours;
            _Row.Highlight = Highlight;

            return _Row;
        }

        public Data.UIGridViewRow GetUIRow()
        {
            Data.dtSteelLookupDataTable _SteelLookup = new Data.dtSteelLookupDataTable();
            try
            {
                Common.dbConnection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Parameters.AddWithValue("@size", Size);
                command.Connection = Common.dbConnection;
                command.CommandText = Common.dtSteelLookupQuery;
                SQLiteDataAdapter _adapter = new SQLiteDataAdapter(command);
                _adapter.Fill(_SteelLookup);
                Common.dbConnection.Close();
            }
            catch
            {
                throw;
            }
            Data.dtSteelLookupRow _Lookup = _SteelLookup[0];

            _UIRow.ItemNumber = RowID;
            _UIRow.Quantity = Qty;
            _UIRow.Size = Size;
            _UIRow.Length = Math.Round(LengthFt + (LengthIn / 12), 2);
            _UIRow.SurfaceSquareFeet = Math.Round(Double.Parse(_Lookup["sff"].ToString()) * _UIRow.Length * Qty, 2);
            _UIRow.Weight = Math.Round(Double.Parse(_Lookup["weight_ft"].ToString()) * _UIRow.Length * Qty, 2);
            _UIRow.EndA = "Cap Plate";
            _UIRow.EndB = "Base Plate";
            _UIRowsTable.Rows.Add(_UIRow);
            _UIRowsTable.AcceptChanges();
            return _UIRowsTable[0];
        }
    }
}
