using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace BidSheet.Components
{
    internal class HandrailInfo : Common.Part
    {

        public Int32 RowID;
        public String Size;
        public Double Length;
        public Double Runs;
        public Double MemberASqFt;
        public Double MemberAWtFt;
        public Double MemberBSqFt;
        public Double MemberBWtFt;
        public Double MemberCSqFt;
        public Double MemberCWtFt;
        public Double MemberDSqFt;
        public Double MemberDWtFt;
        public Double PicketSqFt;
        public Double PicketLength;
        public Double PicketWtFt;
        public Boolean Handrail;
        public Boolean Sloped;


        public Boolean Highlight;

        Data.SpreadsheetRowsDataTable _RowsTable;
        Data.UIGridViewDataTable _UIRowsTable;
        Data.UIGridViewRow _UIRow;
        Data.SpreadsheetRowsRow _Row;
        Components.LaborTimes _LaborTimes;

        public HandrailInfo(int RowID, Components.LaborTimes LaborTimings)
        {
            this.RowID = RowID;
            this._LaborTimes = LaborTimings;
            _RowsTable = new Data.SpreadsheetRowsDataTable();
            _Row = _RowsTable.NewSpreadsheetRowsRow();
            _UIRowsTable = new Data.UIGridViewDataTable();
            _UIRow = _UIRowsTable.NewUIGridViewRow();

            this.Size = "";
            this.Length = 0;
            this.Runs = 0;
            this.MemberASqFt = 0;
            this.MemberAWtFt = 0;
            this.MemberBSqFt = 0;
            this.MemberBWtFt = 0;
            this.MemberCSqFt = 0;
            this.MemberCWtFt = 0;
            this.MemberDSqFt = 0;
            this.MemberDWtFt = 0;
            this.PicketSqFt = 0;
            this.PicketLength = 0;
            this.PicketWtFt = 0;
            this.Handrail = true;
            this.Sloped = false;
        }

        public Data.SpreadsheetRowsRow GetRow()
        {
            Double PipeSqFt = (Length * (Runs + 1) * 0.52);
            Double RunSqFt = (MemberASqFt + MemberBSqFt + MemberCSqFt + MemberDSqFt) * Length;
            Double PicketSqFtTotal = (PicketSqFt * PicketLength * 3 * Length);

            _Row.MatHandlingHours = 0;
            _Row.ShopHours = 0;
            _Row.RowID = RowID;
            _Row.Quantity = 1;
            _Row.Length = Length;
            _Row.TotalSqFt = PipeSqFt + RunSqFt + PicketSqFtTotal;
            _Row.SteelWeight = Length * (MemberAWtFt + MemberBWtFt + MemberCWtFt + MemberDWtFt);
            _Row.FittingWeight = Length * PicketLength * PicketWtFt * 3;
            _Row.HandrailFeet = Length * (Runs + 1);
            _Row.Size = Size;
            _Row.Highlight = Highlight;
            if (Handrail && Sloped)   { _Row.HandrailHours = (Length * ((Runs + 1) / 3)) * _LaborTimes.Adjusted.Handrails * 1.2; }
            if (!Handrail && Sloped)  { _Row.HandrailHours = (Length * ((Runs + 1) / 3)) * _LaborTimes.Adjusted.Guardrails * 1.2; }
            if (Handrail && !Sloped)  { _Row.HandrailHours = (Length * ((Runs + 1) / 3)) * _LaborTimes.Adjusted.Handrails; }
            if (!Handrail && !Sloped) { _Row.HandrailHours = (Length * ((Runs + 1) / 3)) * _LaborTimes.Adjusted.Guardrails; }
            return _Row;
        }

        public Data.UIGridViewRow GetUIRow()
        {
            Double PipeSqFt = (Length * (Runs + 1) * 0.52);
            Double RunSqFt = (MemberASqFt + MemberBSqFt + MemberCSqFt + MemberDSqFt) * Length;
            Double PicketSqFtTotal = (PicketSqFt * PicketLength * 3 * Length);

            _UIRow.ItemNumber = RowID;
            _UIRow.Quantity = 1;            
            _UIRow.Length = Length;
            _UIRow.SurfaceSquareFeet = PipeSqFt + RunSqFt + PicketSqFtTotal;
            _UIRow.Weight = Length * (MemberAWtFt + MemberBWtFt + MemberCWtFt + MemberDWtFt);
            _UIRow.EndA = "";
            _UIRow.EndB = "";
            _UIRow.Size = Size;
            
            _UIRowsTable.Rows.Add(_UIRow);
            _UIRowsTable.AcceptChanges();
            return _UIRowsTable[0];
        }
    }
}
