using System.Management;
using System

public void ListDisks()
{
    ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive"); // Lấy tất cả các ổ đĩa
    ManagementObjectCollection disks = searcher.Get();

    foreach (ManagementObject disk in disks)
    {
        Console.WriteLine("Disk: " + disk["Name"]);
        // Console.WriteLine("   Model: " + disk["Model"]);
        // Console.WriteLine("   Size: " + disk["Size"]);
        // Console.WriteLine("   Serial Number: " + disk["SerialNumber"]);
    }
}
//Create code by LoPhong Corporation