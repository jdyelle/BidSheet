using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace BidSheet.Components
{
    internal class BeamInfo : Common.Part
    {
        
        public Int32 RowID;
        public String Size;
        public Double LengthFt;
        public Double LengthIn;
        public Int32 Qty;
        public EndType EndA;
        public EndType EndB;
        public ErectionType Erection;
        public Components.Enums.BoltTypes BoltType;
        public Components.Enums.LintelTypes LintelType;
        public Components.Enums.HandlingModifier MatlHandling;
        public Components.Extras Extras;
        public Boolean Highlight;

        Components.LaborTimes _LaborTimes;

        Data.SpreadsheetRowsDataTable _RowsTable;
        Data.UIGridViewDataTable _UIRowsTable;
        Data.UIGridViewRow _UIRow;
        Data.SpreadsheetRowsRow _Row;
        
        public BeamInfo(int RowID, Components.LaborTimes LaborTimings)
        {
            this.RowID = RowID;
            this._LaborTimes = LaborTimings;
            _RowsTable = new Data.SpreadsheetRowsDataTable();
            _Row = _RowsTable.NewSpreadsheetRowsRow();
            _UIRowsTable = new Data.UIGridViewDataTable();
            _UIRow = _UIRowsTable.NewUIGridViewRow();



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
            _UIRow.EndA = DetermineEndType(EndA);
            _UIRow.EndB = DetermineEndType(EndB);
            _UIRowsTable.Rows.Add(_UIRow);
            _UIRowsTable.AcceptChanges();            
            return _UIRowsTable[0];
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
            else if (LintelType != Enums.LintelTypes.None) { _Row.MatHandlingHours = 0; }
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

            //Calculate fitting weight, hours, bolts.
            Double _FitWeight = 0;
            Double _FitHours = 0;
            Int32 _Bolts = 0;
            Int32 _Studs = 0;
            Int32 bcHoles = Int32.Parse(_Lookup["clip_holes"].ToString());
            Double bcDepth = Double.Parse(_Lookup["depth"].ToString());
            Double bcBF = Double.Parse(_Lookup["depth"].ToString());
            Double bcWPF = Double.Parse(_Lookup["weight_ft"].ToString());
            Double bcSFF = Double.Parse(_Lookup["sff"].ToString());

            //Deal with the Checkboxes for End A
            if (EndA.StdDblAngle) 
            { 
                _FitHours += (2 * _LaborTimes.Adjusted.Clips + 4 * (_LaborTimes.Adjusted.Holes * bcHoles)) * Qty;
                _FitWeight += (2 * (bcDepth - 3) * 7.2 / 12) * Qty;
                _Bolts += bcHoles * 3 * Qty;
            }            
            if (EndA.StdSngAngle) 
            { 
                _FitHours += (_LaborTimes.Adjusted.Clips + 2.5 * (_LaborTimes.Adjusted.Holes * bcHoles)) * Qty; 
                _FitWeight += (1 * (bcDepth - 3) * 10 / 12) * Qty;
                _Bolts += bcHoles * 2 * Qty;
            }
            if (EndA.ShearPlate) 
            { 
                _FitHours += _FitHours + (1 * (_LaborTimes.Adjusted.ShearPlates + (bcDepth * _LaborTimes.Adjusted.Welds) + (_LaborTimes.Adjusted.Holes * bcHoles))) * Qty;
                _FitWeight += (1 * (bcDepth - 3) * 6 / 12) * Qty;
                _Bolts += bcHoles * Qty;
            }

            //Stiffner Subform
            if (EndA.Stiffner.StiffnerQty > 0)
            {
                _FitHours += EndA.Stiffner.StiffnerQty * (_LaborTimes.Adjusted.Stiffners + EndA.Stiffner.StiffnerPercentWeld / 100 * 2 * (bcBF + bcDepth) * _LaborTimes.Adjusted.HWelds) * Qty;
                _FitWeight += EndA.Stiffner.StiffnerQty * (EndA.Stiffner.StiffnerThickness * bcBF / 2 * bcDepth * 0.283) * Qty;
            }
            if (EndA.Stiffner.GussetQty > 0)
            {
                _FitHours += EndA.Stiffner.GussetQty * (_LaborTimes.Adjusted.Gusset + EndA.Stiffner.GussetWeld * _LaborTimes.Adjusted.Welds) * Qty;
                _FitWeight += EndA.Stiffner.GussetQty * (EndA.Stiffner.GussetThickness * EndA.Stiffner.GussetWidth * EndA.Stiffner.GussetLength * 0.283) * Qty;
            }
            if (EndA.BearingPlate.Checked)
            {
                _FitHours += 0.25 * Qty;
                _FitWeight += (EndA.BearingPlate.Thickness * EndA.BearingPlate.Width * EndA.BearingPlate.Length * 0.283) * Qty;
                _Studs += EndA.BearingPlate.Studs * Qty;
            }
            if (EndA.Cut) { _FitHours += _LaborTimes.Adjusted.Cuts * Qty; }
            if (EndA.DoubleCope) { _FitHours += (_LaborTimes.Adjusted.Copes * 2) * Qty; }
            if (EndA.SingleCope) { _FitHours += _LaborTimes.Adjusted.Copes * Qty; }
            if (EndA.User.Checked) 
            {
                _FitHours += EndA.User.ShopHours * Qty;
                _FitWeight += EndA.User.TotalWeight * Qty;
                _Bolts += EndA.User.Bolts * Qty;
                _Row.UserDefNameA = EndA.User.Name;
            }

            //Deal with the Checkboxes for End B
            if (EndB.StdDblAngle)
            {
                _FitHours += (2 * _LaborTimes.Adjusted.Clips + 4 * (_LaborTimes.Adjusted.Holes * bcHoles)) * Qty;
                _FitWeight += (2 * (bcDepth - 3) * 7.2 / 12) * Qty;
                _Bolts += bcHoles * 3 * Qty;
            }
            if (EndB.StdSngAngle)
            {
                _FitHours += (_LaborTimes.Adjusted.Clips + 2.5 * (_LaborTimes.Adjusted.Holes * bcHoles)) * Qty;
                _FitWeight += (1 * (bcDepth - 3) * 10 / 12) * Qty;
                _Bolts += bcHoles * 2 * Qty;
            }
            if (EndB.ShearPlate)
            {
                _FitHours += _FitHours + (1 * (_LaborTimes.Adjusted.ShearPlates + (bcDepth * _LaborTimes.Adjusted.Welds) + (_LaborTimes.Adjusted.Holes * bcHoles))) * Qty;
                _FitWeight += (1 * (bcDepth - 3) * 6 / 12) * Qty;
                _Bolts += bcHoles * Qty;
            }

            //Stiffner Subform
            if (EndB.Stiffner.StiffnerQty > 0)
            {
                _FitHours += EndB.Stiffner.StiffnerQty * (_LaborTimes.Adjusted.Stiffners + EndB.Stiffner.StiffnerPercentWeld / 100 * 2 * (bcBF + bcDepth) * _LaborTimes.Adjusted.HWelds) * Qty;
                _FitWeight += EndB.Stiffner.StiffnerQty * (EndB.Stiffner.StiffnerThickness * bcBF / 2 * bcDepth * 0.283) * Qty;
            }
            if (EndB.Stiffner.GussetQty > 0)
            {
                _FitHours += EndB.Stiffner.GussetQty * (_LaborTimes.Adjusted.Gusset + EndB.Stiffner.GussetWeld * _LaborTimes.Adjusted.Welds) * Qty;
                _FitWeight += EndB.Stiffner.GussetQty * (EndB.Stiffner.GussetThickness * EndB.Stiffner.GussetWidth * EndB.Stiffner.GussetLength * 0.283) * Qty;
            }
            if (EndB.BearingPlate.Checked)
            {
                _FitHours += 0.25 * Qty;
                _FitWeight += (EndB.BearingPlate.Thickness * EndB.BearingPlate.Width * EndB.BearingPlate.Length * 0.283) * Qty;
                _Studs += EndB.BearingPlate.Studs * Qty;
            }
            if (EndB.Cut) { _FitHours += _LaborTimes.Adjusted.Cuts * Qty; }
            if (EndB.DoubleCope) { _FitHours += (_LaborTimes.Adjusted.Copes * 2) * Qty; }
            if (EndB.SingleCope) { _FitHours += _LaborTimes.Adjusted.Copes * Qty; }
            if (EndB.User.Checked)
            {
                _FitHours += EndB.User.ShopHours * Qty;
                _FitWeight += EndB.User.TotalWeight * Qty;
                _Bolts += EndB.User.Bolts * Qty;
                _Row.UserDefNameB = EndB.User.Name;
            }

            if (Extras.Holes > 0 && !Extras.Total) { _FitHours += ((_Row.Length * 12) / Extras.Holes * _LaborTimes.Adjusted.Holes) * Qty; }
            if (Extras.Bolts > 0 && !Extras.Total) { _Bolts += (Int32)Math.Ceiling((_Row.Length * 12) / Extras.Bolts * Qty); }
            if (Extras.Welds > 0 && !Extras.Total) { _FitHours += (_Row.Length * Extras.Welds * _LaborTimes.Adjusted.Welds) * Qty; }
            if (Extras.Holes > 0 && Extras.Total) { _FitHours += (Extras.Holes * _LaborTimes.Adjusted.Holes) * Qty; }
            if (Extras.Bolts > 0 && Extras.Total) { _Bolts += Extras.Bolts * Qty;}
            if (Extras.Welds > 0 && Extras.Total) { _FitHours += (Extras.Welds * _LaborTimes.Adjusted.Welds) * Qty; }

            if (Erection.Girder) { _Row.ErectionGirders = Qty; }
            if (Erection.Column) { _Row.ErectionColumns = Qty; }
            if (Erection.EdgeAngle) { _Row.ErectionEdgeAngle = _Row.Length * Qty; }
            if (Erection.Girt) { _Row.ErectionGirts = Qty; }


            switch (LintelType)
            {
                case Enums.LintelTypes.BackBack:
                    _FitHours = Qty / 2 * 0.5;
                    _Row.MatHandlingHours = 0;
                    break;
                case Enums.LintelTypes.Single:
                    _FitHours = Qty * 0.17;
                    _Row.MatHandlingHours = 0;
                    break;
                case Enums.LintelTypes.BeamPlate:
                    _FitHours = Qty * 1;
                    _Row.MatHandlingHours = 0;
                    break;
                case Enums.LintelTypes.Bollard:
                    _FitHours = Qty * 0.25;
                    _Row.MatHandlingHours = 0;
                    break;
                case Enums.LintelTypes.PlateBollard:
                    _FitHours = Qty * 0.58;
                    _Bolts = Qty * 4;
                    _Row.MatHandlingHours = 0;
                    break;
                default:
                    break;
            }

            switch (BoltType)
            {
                case Enums.BoltTypes.Standard:
                    _Row.StdBolt = _Bolts;
                    _Row.StudBolt = _Studs;
                    break;
                case Enums.BoltTypes.Stud:
                    _Row.StudBolt = _Bolts + _Studs;
                    break;
                case Enums.BoltTypes.Chem:
                    _Row.ChemBolt = _Bolts;
                    _Row.StudBolt = _Studs;
                    break;
                case Enums.BoltTypes.Anchor:
                    _Row.AnchorBolt = _Bolts;
                    _Row.StudBolt = _Studs;
                    break;
                default:
                    break;
            }

            _Row.FittingWeight = _FitWeight;
            _Row.ShopHours = _FitHours;
            _Row.Highlight = Highlight;

            return _Row;
        }

        private String DetermineEndType(EndType _End)
        {
            String _EndTypeLabel = "";

            //If the end type label is already set, it's multiple.  Otherwise, set it.
            if (_End.StdDblAngle == true) 
            {
                if (_EndTypeLabel == "") { _EndTypeLabel = "Double Angle"; }
                else { _EndTypeLabel = "Multiple"; }
            }
            if (_End.StdSngAngle == true)
            {
                if (_EndTypeLabel == "") { _EndTypeLabel = "Single Angle"; }
                else { _EndTypeLabel = "Multiple"; }
            }
            if (_End.ShearPlate == true)
            {
                if (_EndTypeLabel == "") { _EndTypeLabel = "Shear Plate"; }
                else { _EndTypeLabel = "Multiple"; }
            }
            if (_End.Cut == true)
            {
                if (_EndTypeLabel == "") { _EndTypeLabel = "Cut"; }
                else { _EndTypeLabel = "Multiple"; }
            }
            if (_End.DoubleCope == true)
            {
                if (_EndTypeLabel == "") { _EndTypeLabel = "Double Cope"; }
                else { _EndTypeLabel = "Multiple"; }
            }
            if (_End.SingleCope == true)
            {
                if (_EndTypeLabel == "") { _EndTypeLabel = "Single Cope"; }
                else { _EndTypeLabel = "Multiple"; }
            }
            if (_End.Stiffner.StiffnerQty > 0)
            {
                if (_EndTypeLabel == "") { _EndTypeLabel = "Stiffner"; }
                else { _EndTypeLabel = "Multiple"; }
            }
            if (_End.Stiffner.GussetQty > 0)
            {
                if (_EndTypeLabel == "") { _EndTypeLabel = "Gusset"; }
                else { _EndTypeLabel = "Multiple"; }
            }
            if (_End.BearingPlate.Length > 0)
            {
                if (_EndTypeLabel == "") { _EndTypeLabel = "Bearing Plate"; }
                else { _EndTypeLabel = "Multiple"; }
            }
            if (_End.User.Bolts > 0 || _End.User.ShopHours > 0 || _End.User.TotalWeight > 0)
            {
                if (_EndTypeLabel == "") { _EndTypeLabel = "User Defined"; }
                else { _EndTypeLabel = "Multiple"; }
            }
            return _EndTypeLabel;
        }


        internal struct EndType
        {
            internal Boolean StdDblAngle;
            internal Boolean StdSngAngle;
            internal Boolean ShearPlate;
            internal Components.Stiffner Stiffner;
            internal Components.BearingPlate BearingPlate;
            internal Boolean Cut;
            internal Boolean DoubleCope;
            internal Boolean SingleCope;
            internal Components.UserDefined User;
        }

        internal struct ErectionType
        {
            internal Boolean Girder;
            internal Boolean Column;
            internal Boolean EdgeAngle;
            internal Boolean Girt;
        }
        
    }
}
