using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidSheet.Components
{
    internal struct BearingPlate
    {
        public Boolean Checked;
        public Double Thickness;
        public Double Width;
        public Double Length;
        public Int32 Studs;
    }

    internal struct Stiffner
    {
        public Double StiffnerQty;
        public Double StiffnerThickness;
        public Double StiffnerPercentWeld;
        public Double GussetQty;
        public Double GussetThickness;
        public Double GussetWidth;
        public Double GussetLength;
        public Double GussetWeld;
    }

    internal struct UserDefined
    {
        public Boolean Checked;
        public String Name;
        public Double TotalWeight;
        public Double ShopHours;
        public Int32 Bolts;
    }

    internal struct Extras
    {
        internal Double Holes;
        internal Int32 Bolts;
        internal Double Welds;
        internal Boolean Total;
    }

}
