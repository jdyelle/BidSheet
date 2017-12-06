using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidSheet.Components
{
    internal class Enums
    {
        internal enum EndTypes { DoubleAngle, SingleAngle, ShearPlate, Stiffner, BearingPlate, Cut, DoubleCope, SingleCope, User, Multiple }
        internal enum BoltTypes { Standard, Stud, Chem, Anchor }
        internal enum LintelTypes { None, BackBack, Single, BeamPlate, Bollard, PlateBollard }
        internal enum HandlingModifier { Full, Half, Quarter, None }
    }
}
