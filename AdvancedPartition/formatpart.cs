using System.Management;
using System

public void FormatPartition(string diskName, string partitionLabel)
{
    ManagementScope scope = new ManagementScope(@"\\.\root\cimv2");
    scope.Connect();

    // Lấy thông tin về phân vùng
    ManagementObjectSearcher searcher = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + diskName.Replace("\\", "\\\\") + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition");
    ManagementObjectCollection partitions = searcher.Get();
    foreach (ManagementObject partition in partitions)
    {
        foreach (ManagementBaseObject logicalDisk in partition.GetRelated("Win32_LogicalDisk"))
        {
            string label = (string)logicalDisk.GetPropertyValue("VolumeName");
            if (label == partitionLabel)
            {
                ManagementBaseObject formatParams = logicalDisk.GetMethodParameters("Format");
                formatParams["FileSystem"] = "NTFS";
                formatParams["QuickFormat"] = true;
                logicalDisk.InvokeMethod("Format", formatParams, null);
            }
        }
    }
}
//Create code by LoPhong Corporation