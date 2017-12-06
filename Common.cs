using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Management;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;


namespace BidSheet
{
    public class Common
    {
        public delegate void WriteEntry(string LogEntry);
        public delegate void ExceptionHandler(Exception ex);
        public delegate void ChildFormClosed();

        public interface Part
        {
            Data.SpreadsheetRowsRow GetRow();
        }

        public static SQLiteConnection dbConnection = new SQLiteConnection(@"Data Source=reference.bin;Version=3;");
        

        public struct USBInfo
        {
            public String Serial;
            public String Model;
            public String FirmwareRev;
            public Int64 PartitionSize;
            public Int64 PartitionOffset;
            public String VolumeID;
            public Int64 DiskIndex;
            public Int64 DiskSize;
            public String DriveLetter;
        }

        internal static void SpreadSheetHeader(Components.ProjectSetup ProjectDetails, FileInfo ExcelFile)
        {
            FileStream _ReadStream = new FileStream(ExcelFile.FullName, FileMode.Open, FileAccess.Read);
            XSSFWorkbook _ExcelBook = new XSSFWorkbook(_ReadStream);
            ISheet _MatHandlingSheet = _ExcelBook.GetSheet("Material & Labor Takeoff");
            ISheet _SummarySheet = _ExcelBook.GetSheet("Summary");

            _SummarySheet.GetRow(5).GetCell(6).SetCellValue(ProjectDetails.Customer);
            _SummarySheet.GetRow(6).GetCell(6).SetCellValue(ProjectDetails.Project);
            _SummarySheet.GetRow(7).GetCell(6).SetCellValue(ProjectDetails.ProjectDate);
            _SummarySheet.GetRow(8).GetCell(6).SetCellValue(ProjectDetails.SquareFt);
            _SummarySheet.GetRow(1).GetCell(8).SetCellValue(ProjectDetails.EstimateNum);
            _MatHandlingSheet.GetRow(0).GetCell(2).SetCellValue(ProjectDetails.EstimateNum);

            FileStream _WriteStream = new FileStream(ExcelFile.FullName, FileMode.Create);
            _ExcelBook.Write(_WriteStream);
            _WriteStream.Dispose();

        }

        public static String USBDriveLetter()
        {
            BidSheet.Common.USBInfo _USBInfo;// = new BidSheet.Common.USBInfo();
            _USBInfo.Model = "";
            _USBInfo.Serial = "";
            _USBInfo.FirmwareRev = "";
            _USBInfo.DiskIndex = 0;
            _USBInfo.DiskSize = 0;
            _USBInfo.PartitionSize = 0;
            _USBInfo.PartitionOffset = 0;
            _USBInfo.VolumeID = "";
            _USBInfo.DriveLetter = "";

            String _VolumeID = "";
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = BidSheet.Common.dbConnection;
            Common.dbConnection.Open();

            command.CommandText = @"SELECT count(*) from USBInfo WHERE USBSerial = @USBSerial AND Model = @Model 
                                    AND FirmwareRevision = @FirmwareRevision AND DiskSize = @DiskSize";
            command.Parameters.Add("@USBSerial", DbType.String);
            command.Parameters.Add("@Model", DbType.String);
            command.Parameters.Add("@FirmwareRevision", DbType.String);
            command.Parameters.Add("@DiskSize", DbType.Int64);

            var searcher1 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive WHERE InterfaceType = 'USB'");
            foreach (var queryObj in searcher1.Get())
            {
                _USBInfo.Model = (String)queryObj["Model"];
                _USBInfo.Serial = (String)queryObj["SerialNumber"];
                _USBInfo.FirmwareRev = (String)queryObj["FirmwareRevision"];
                _USBInfo.DiskIndex = (Int64)(UInt32)queryObj["Index"];
                _USBInfo.DiskSize = (Int64)(UInt64)queryObj["Size"];

                //Test to see if this USB drive is the one we're looking for (because someone might have more than one USB drive).                 
                command.Parameters["@USBSerial"].Value = _USBInfo.Serial;
                command.Parameters["@Model"].Value = _USBInfo.Model;
                command.Parameters["@FirmwareRevision"].Value = _USBInfo.FirmwareRev;
                command.Parameters["@DiskSize"].Value = _USBInfo.DiskSize;
                Int32 _rows = Int32.Parse(command.ExecuteScalar().ToString());
                if (_rows == 1) { break; } //If these are the droids we're looking for, break out of the loop.
            }

            //should only be one row here because we're specific about the disk index and partition number.
            var searcher2 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskPartition where DiskIndex = " + _USBInfo.DiskIndex + " and Index = 2");
            foreach (var queryObj in searcher2.Get())
            {
                _USBInfo.PartitionSize = (Int64)(UInt64)queryObj["Size"];
                _USBInfo.PartitionOffset = (Int64)(UInt64)queryObj["StartingOffset"];
            }
            
            command.CommandText = @"SELECT VolumeID from USBInfo WHERE USBSerial = @USBSerial AND Model = @Model AND FirmwareRevision = @FirmwareRevision
                                    AND DiskSize = @DiskSize AND PartitionSize = @PartitionSize AND @PartitionOffset = @PartitionOffset";
            command.Parameters.Add("@PartitionSize", DbType.Int64);
            command.Parameters.Add("@PartitionOffset", DbType.Int64);
            command.Parameters["@USBSerial"].Value = _USBInfo.Serial;
            command.Parameters["@Model"].Value = _USBInfo.Model;
            command.Parameters["@FirmwareRevision"].Value = _USBInfo.FirmwareRev;
            command.Parameters["@DiskSize"].Value = _USBInfo.DiskSize;
            command.Parameters["@PartitionSize"].Value = _USBInfo.PartitionSize;
            command.Parameters["@PartitionOffset"].Value = _USBInfo.PartitionOffset;

            try
            {
                _VolumeID = command.ExecuteScalar().ToString();
            }
            catch
            {
                throw new Exception("No authorized USB Drive found -- please insert a valid USB Device");
            }
            finally
            {
                Common.dbConnection.Close();
            }
            
            var searcher3 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_LogicalDisk where DriveType = 2 AND VolumeName = 'Bidsheet' AND VolumeSerialNumber = '" + _VolumeID + "'");
            foreach (var queryObj in searcher3.Get())
            {
                _USBInfo.VolumeID = (String)queryObj["VolumeSerialNumber"];
                _USBInfo.DriveLetter = (String)queryObj["Name"];
            }

                        
            return _USBInfo.DriveLetter;
        }

        public static void WriteLog(string LogEntry)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.DateTime.Now.ToString("yyyy-MM-dd") + ".log", true))
            {
                file.WriteLine(System.DateTime.Now.ToString() + " -- " + LogEntry);
            }
        }

        public static Byte[] GetTemplateBytes()
        {
            Byte[] _bytes = null;
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = BidSheet.Common.dbConnection;
            command.CommandText = @"SELECT SpreadSheetBlob from BidSheetTemplates WHERE SheetVersion = 3";
            try
            {                
                Common.dbConnection.Open();                
                _bytes = (Byte[])command.ExecuteScalar();
            }
            catch
            {
                throw;
            }
            finally
            {
                command.Dispose();
                Common.dbConnection.Close();  
            }
            return _bytes;
        }

        internal static Boolean VerifyKey(string DriveLetter)
        {
            //Yes I realize this isn't a substitute for real software protection, but it's good enough for guys with laptops to not copy to competitors.
            //  the .key file is a red herring to make them think that was the special thing about the authorization, when really it was the USB stick
            //  partition table that mattered (and was hardcoded into the SQLLite DB that I distributed with the USB stick).
            const String Key = @"-----BEGIN KEY-----
MIICIjANBgkqhkiG9w0BAQEFAAOCAg8AMIICCgKCAgEA7qDAQAcJ+B7NbXqmWxdC
91TN7EzxooNjd+mI/4ViE7fn4xiMmCGWo/ppo8+ol9GLCMVrdU7mutQq10T0II0B
xzai411YVU90Gbi1TgHV/oLue5Ji5l65R1gWOHIbp80XamG1Ns/NvksdUx+e6ZZp
h7L5C2dW2Wg3blGPbUnjg17Uc52IS1aLVc1trNVUB5aqr0iz3Q5NmrLOakZucxkT
j3RYmNVO96Cu4fEWbFmZlqKf4JvSe6WwfgKpahMA180QeBqzFBnKEclco6YMpsVk
kLERqx2nVLhHtCUlQ+sMaezddDOHNKOzca/DpzOQ2ziW8vcfZBXN10luMoztPYY3
HCNhyqvtyvixxQVo2ckzqO7SG/r2HSLURMG4xtBzsoQRHbAIUfoz0vM+trOSYuom
8T+tsDFFzic6WsLGZPpLkk8h5BRdQ5OSLw8pilEDeBEGRMXZNns0M6CeLqzHarQ2
R+tB7qMFeYICy2/xicVf+1QFyhG3wzCzIhuy03x6odNVIWL+vtDtr9LT7/6o0qSK
fI8WWzCVEfoMs7hHMApTqST0UWpH9V8PVvHDJR1Cq46GcQ1FKcU8J36bBGhMimNn
tsLnt6I45qHRw8Z7c4HEAC8b5kyk4wNy0G6RF1Nc3P3mGkTA9ETjVSShrDrnJ9lY
IN6wAj5kL63AIPTjhVgXIHUCAwEAAQ==
-----END KEY-----";

            try
            {
                using (StreamReader _FileStream = new StreamReader(DriveLetter + @"\bidsheet.key"))
                {
                    String _FileContents = _FileStream.ReadToEnd();
                    if (_FileContents == Key) { return true; }
                }
                return false;
            }
            catch
            {
                throw new Exception("No authorized USB Drive found -- please insert a valid USB Device");
            }
        }

        internal static String dtSteelLookupQuery = @"select lookup, size, weight_ft, sff, area, depth, tf, bf, tw, clip_holes from SteelLookup where lookup = @size";

    }
}
