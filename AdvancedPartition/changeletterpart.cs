using System;
using System.IO;
using System.Management;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhập chữ cái ổ đĩa hiện tại: ");
        string oldDriveLetter = Console.ReadLine();

        Console.Write("Nhập chữ cái mới: ");
        string newDriveLetter = Console.ReadLine();

        DriveInfo drive = DriveInfo.GetDrives().FirstOrDefault(d => d.Name.StartsWith(oldDriveLetter, StringComparison.InvariantCultureIgnoreCase));
        
        if (drive != null)
        {
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid='" + oldDriveLetter.ToUpper() + ":\'");
            disk.Get();
            ManagementBaseObject inParams = disk.GetMethodParameters("ChangeDriveLetter");
            inParams["DriveLetter"] = newDriveLetter.ToUpper() + ":";
            ManagementBaseObject outParams = disk.InvokeMethod("ChangeDriveLetter", inParams, null);

            uint resultCode = (uint)outParams["ReturnValue"];
            if (resultCode == 0)
            {
                Console.WriteLine("Chữ cái ổ đĩa đã được thay đổi thành '{0}'.", newDriveLetter.ToUpper());
            }
            else
            {
                Console.WriteLine("Không thể thay đổi chữ cái của ổ đĩa. Mã lỗi: {0}.", resultCode);
            }
        }
        else
        {
            Console.WriteLine("Không tìm thấy ổ đĩa với chữ cái '{0}'.", oldDriveLetter.ToUpper());
        }
    }
}
//Create code by LoPhong Corporation