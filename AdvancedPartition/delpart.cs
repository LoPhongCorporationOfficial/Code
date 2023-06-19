using System.Management;
using System

public void DeletePartition(string diskName, uint partitionIndex)
{
    ManagementScope scope = new ManagementScope(@"\\.\root\cimv2");
    scope.Connect();

    ManagementObject disk = new ManagementObject("Win32_DiskDrive.DeviceID=\"" + diskName + "\"");
    disk.Scope = scope;

    ManagementObject partition = disk.GetRelated("Win32_DiskPartition") as ManagementObject;
    if (partition != null && partition.Count > partitionIndex)
    {
        ManagementBaseObject inParams = partition[partitionIndex].GetMethodParameters("Delete");
        inParams["Force"] = true; 
        ManagementBaseObject outParams = partition[partitionIndex].InvokeMethod("Delete", inParams, null);
    }
}
//Create code by LoPhong Corporation