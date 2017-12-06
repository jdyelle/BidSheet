using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace BidSheet.Components
{
    internal class StairsInfo : Common.Part
    {

        public Int32 RowID;
        public Int32 Flights;
        public Int32 Treads;
        public Double StringerWeight;
        public Boolean Grating;
        public Boolean Pan;
        public Boolean Bolted;

        public Boolean Highlight;

        Data.SpreadsheetRowsDataTable _RowsTable;
        Data.UIGridViewDataTable _UIRowsTable;
        Data.UIGridViewRow _UIRow;
        Data.SpreadsheetRowsRow _Row;
        Components.LaborTimes _LaborTimes;

        public StairsInfo(int RowID, Components.LaborTimes LaborTimings)
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
            _Row.Size = "C12x20.7";
            _Row.MatHandlingHours = 0;
            _Row.ShopHours = 0;
            _Row.RowID = RowID;
            _Row.Quantity = 2 * Flights;
            _Row.Length = 0;
            _Row.TotalSqFt = (1.2 * 2 * Flights) * 5;
            _Row.SteelWeight = (1.2 * 2 * StringerWeight * Flights);
            _Row.FittingWeight = 0;
            _Row.StairsFlights = Flights;
            _Row.StairsTreads = Treads;

            if (Grating)
            {
                _Row.FittingWeight = 20;
                _Row.StdBolt = 2 * 2 * Treads;
                _Row.StairsHours = 2 * Flights + (30 / 60 * Treads);
            }
            if (Pan)
            {
                _Row.FittingWeight = (20 + 1.2 * 2 * 6.23 * Treads);
                _Row.StairsHours = 2 * Flights + (35 / 60 * Treads);
            }
            if (Bolted)
            {
                _Row.StdBolt = 4 * 2 * Treads;
                _Row.StairsHours = 2 * Flights + (30 / 60 * Treads);
            }
            
            _Row.Highlight = Highlight;
            return _Row;
        }

        public Data.UIGridViewRow GetUIRow()
        {


            _UIRow.ItemNumber = RowID;
            _UIRow.Quantity = Flights;            
            _UIRow.Length = Treads;
            _UIRow.SurfaceSquareFeet = (1.2 * 2 * Flights) * 5;
            _UIRow.Weight = (1.2 * 2 * StringerWeight * Flights);
            _UIRow.EndA = "";
            _UIRow.EndB = "";
            _UIRow.Size = "Stairs";
            
            _UIRowsTable.Rows.Add(_UIRow);
            _UIRowsTable.AcceptChanges();
            return _UIRowsTable[0];
        }
    }
}
