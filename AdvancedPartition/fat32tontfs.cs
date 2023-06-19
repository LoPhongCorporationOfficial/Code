using System;
using System.Management;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhập chữ cái ổ đĩa cần chuyển đổi: ");
        string driveLetter = Console.ReadLine(); 
        string fsLabel = "NTFS"; 


        ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Volume WHERE DriveLetter = '" + driveLetter + "'");
        ManagementObjectCollection volumes = searcher.Get();

        foreach (ManagementObject volume in volumes)
        {
            ManagementBaseObject result = volume.InvokeMethod("ConvertToFS", new object[] { fsLabel });
            if ((uint)result["ReturnValue"] == 0)
            {
                Console.WriteLine("Phân vùng được chuyển đổi sang file system '{0}' thành công.", fsLabel);
            }
            else
            {
                Console.WriteLine("Không thể chuyển đổi phân vùng sang file system '{0}'. Mã lỗi: {1}.", fsLabel, result["ReturnValue"]);
            }
        }
    }
}
//Create code by LoPhong Corporation