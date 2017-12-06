using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BidSheet.Components
{
    internal class LaborTimes
    {
        public Double Clips;
        public Double Holes;
        public Double Welds;
        public Double Cuts;
        public Double Copes;
        public Double ShearPlates;
        public Double CapPlates;
        public Double BasePlates;
        public Double Handrails;
        public Double Guardrails;
        public Double Stiffners;
        public Double Gusset;
        public Double HWelds;
        public Double MatHandleLess50lbs;
        public Double MatHandleLess10ft;
        public Double MatHandleOther;
        public Normalize Adjusted;

        Common.WriteEntry LogEntry;
        Common.ExceptionHandler ExHandler;
        
        public LaborTimes(Common.WriteEntry WriteLog, Common.ExceptionHandler Handler)
        {
            this.ExHandler = Handler;
            this.LogEntry = WriteLog;
        }

        private void FixAdjusted()
        {
            Adjusted = new Normalize();
            Adjusted.Clips = Clips / 60;
            Adjusted.Holes = Holes / 60;
            Adjusted.Welds = 1 / Welds / 12;
            Adjusted.Cuts = Cuts / 60;
            Adjusted.Copes = Copes / 60;
            Adjusted.ShearPlates = ShearPlates / 60;
            Adjusted.CapPlates = CapPlates / 60;
            Adjusted.BasePlates = BasePlates / 60;
            Adjusted.Handrails = 1 / Handrails;
            Adjusted.Guardrails = 1 / Handrails;
            Adjusted.Stiffners = Stiffners / 60;
            Adjusted.Gusset = Gusset / 60;
            Adjusted.HWelds = 1 / HWelds / 12;
            Adjusted.MatHandleLess50lbs = MatHandleLess50lbs / 60;
            Adjusted.MatHandleLess10ft = MatHandleLess10ft / 60;
            Adjusted.MatHandleOther = MatHandleOther / 60;
        }

        public void LoadFromFile()
        {
            try
            {
                String line;
                using (System.IO.StreamReader file = new System.IO.StreamReader("LaborVariables.txt"))
                {

                    while ((line = file.ReadLine()) != null)
                    {
                        char[] delimiterChars = { ' ', '#', ':' };
                        string[] Parameter = line.Split(delimiterChars);
                        switch (Parameter[0])
                        {
                            case "Clips":
                                Clips = Double.Parse(Parameter[1]);
                                break;
                            case "Holes":
                                Holes = Double.Parse(Parameter[1]);
                                break;
                            case "Welds":
                                Welds = Double.Parse(Parameter[1]);
                                break;
                            case "Cuts":
                                Cuts = Double.Parse(Parameter[1]);
                                break;
                            case "Copes":
                                Copes = Double.Parse(Parameter[1]);
                                break;
                            case "ShearPlates":
                                ShearPlates = Double.Parse(Parameter[1]);
                                break;
                            case "CapPlates":
                                CapPlates = Double.Parse(Parameter[1]);
                                break;
                            case "BasePlates":
                                BasePlates = Double.Parse(Parameter[1]);
                                break;
                            case "Handrails":
                                Handrails = Double.Parse(Parameter[1]);
                                break;
                            case "Guardrails":
                                Handrails = Double.Parse(Parameter[1]);
                                break;
                            case "Stiffners":
                                Stiffners = Double.Parse(Parameter[1]);
                                break;
                            case "Gusset":
                                Gusset = Double.Parse(Parameter[1]);
                                break;
                            case "HWelds":
                                HWelds = Double.Parse(Parameter[1]);
                                break;
                            case "MatHandleLess50lbs":
                                MatHandleLess50lbs = Double.Parse(Parameter[1]);
                                break;
                            case "MatHandleLess10ft":
                                MatHandleLess10ft = Double.Parse(Parameter[1]);
                                break;
                            case "MatHandleOther":
                                MatHandleOther = Double.Parse(Parameter[1]);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler(ex);
            }
            FixAdjusted();
        }

        public void SaveToFile()
        {
            FixAdjusted();
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("LaborVariables.txt", false))
                {
                    file.WriteLine("Clips" + ":" + Clips.ToString() + "   #" + Descriptions.Clips);
                    file.WriteLine("Holes" + ":" + Holes.ToString() + "   #" + Descriptions.Holes);
                    file.WriteLine("Welds" + ":" + Welds.ToString() + "   #" + Descriptions.Welds);
                    file.WriteLine("Cuts" + ":" + Cuts.ToString() + "   #" + Descriptions.Cuts);
                    file.WriteLine("Copes" + ":" + Copes.ToString() + "   #" + Descriptions.Copes);
                    file.WriteLine("ShearPlates" + ":" + ShearPlates.ToString() + "   #" + Descriptions.ShearPlates);
                    file.WriteLine("CapPlates" + ":" + CapPlates.ToString() + "   #" + Descriptions.CapPlates);
                    file.WriteLine("BasePlates" + ":" + BasePlates.ToString() + "   #" + Descriptions.BasePlates);
                    file.WriteLine("Handrails" + ":" + Handrails.ToString() + "   #" + Descriptions.Handrails);
                    file.WriteLine("Guardrails" + ":" + Handrails.ToString() + "   #" + Descriptions.Handrails);
                    file.WriteLine("Stiffners" + ":" + Stiffners.ToString() + "   #" + Descriptions.Stiffners);
                    file.WriteLine("Gusset" + ":" + Gusset.ToString() + "   #" + Descriptions.Gusset);
                    file.WriteLine("HWelds" + ":" + HWelds.ToString() + "   #" + Descriptions.HWelds);
                    file.WriteLine("MatHandleLess50lbs" + ":" + MatHandleLess50lbs.ToString() + "   #" + Descriptions.MatHandleLess50lbs);
                    file.WriteLine("MatHandleLess10ft" + ":" + MatHandleLess10ft.ToString() + "   #" + Descriptions.MatHandleLess10ft);
                    file.WriteLine("MatHandleOther" + ":" + MatHandleOther.ToString() + "   #" + Descriptions.MatHandleOther);
                }
            }
            catch (Exception ex)
            {
                ExHandler(ex);
            }
        }
        public struct Descriptions
        {
            public const String Clips = "Minutes per Clip";
            public const String Holes = "Minutes per Hole";
            public const String Welds = "Feet Per Hour";
            public const String Cuts = "Minutes Each";
            public const String Copes = "Minutes Each";
            public const String ShearPlates = "Minutes Each (2 x (d - 3) Weld)";
            public const String CapPlates = "Minutes Each + ('sff' Weld + Hole Time x Holes)";
            public const String BasePlates = "Minutes Each + ('sff' Weld + Hole Time x 2 x Holes)";
            public const String Handrails = "Feet Per Hour";
            public const String Guardrails = "Feet Per Hour";
            public const String Stiffners = "Minutes Each + (2(d + bf) Weld)";
            public const String Gusset = "Minutes Each";
            public const String HWelds = "Feet Per Hour (For Stiffners and Columns)";
            public const String MatHandleLess50lbs = "Minutes For Material Handling Less Than 50lbs";
            public const String MatHandleLess10ft = "Minutes For Material Handling Less Than 10ft";
            public const String MatHandleOther = "Minutes For Material Handling (Other Sizes)";
        }

        public struct Normalize
        {
            public Double Clips;
            public Double Holes;
            public Double Welds;
            public Double Cuts;
            public Double Copes;
            public Double ShearPlates;
            public Double CapPlates;
            public Double BasePlates;
            public Double Handrails;
            public Double Guardrails;
            public Double Stiffners;
            public Double Gusset;
            public Double HWelds;
            public Double MatHandleLess50lbs;
            public Double MatHandleLess10ft;
            public Double MatHandleOther;
        }

    }
}
