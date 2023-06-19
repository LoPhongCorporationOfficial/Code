using System.Management;

public void CreatePartition(string diskName, uint partitionSize, string partitionLabel)
{
    ManagementScope scope = new ManagementScope(@"\\.\root\cimv2");
    scope.Connect();

    ManagementObject disk = new ManagementObject("Win32_DiskDrive.DeviceID=\"" + diskName + "\"");
    disk.Scope = scope;

    ManagementBaseObject partition = disk.GetMethodParameters("CreatePartition");
    partition["Size"] = partitionSize;
    partition["Name"] = partitionLabel;
    partition["Type"] = 0x7; 
    ManagementBaseObject result = disk.InvokeMethod("CreatePartition", partition, null);
}
//Create code by LoPhong Corporation