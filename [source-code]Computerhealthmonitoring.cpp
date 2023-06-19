#include <windows.h>
#include <iostream>
#include <iomanip>
#include <string>

void GetCPUInfo()
{
    SYSTEM_INFO sysinfo;
    GetSystemInfo(&sysinfo);

    std::cout << "-- Processor Information -- " << std::endl;
    std::cout << "CPU Architecture: ";

    switch (sysinfo.wProcessorArchitecture)
    {
    case PROCESSOR_ARCHITECTURE_AMD64:
        std::cout << "x64 (AMD or Intel)" << std::endl;
        break;
    case PROCESSOR_ARCHITECTURE_ARM:
        std::cout << "ARM" << std::endl;
        break;
    case PROCESSOR_ARCHITECTURE_ARM64:
        std::cout << "ARM64" << std::endl;
        break;
    case PROCESSOR_ARCHITECTURE_INTEL:
        std::cout << "x86 (Intel)" << std::endl;
        break;
    default:
        std::cout << "Unknown" << std::endl;
    }

    std::cout << " of processors: " << sysinfo.dwNumberOfProcessors << std::endl;
    std::cout << "Page size: " << sysinfo.dwPageSize << " bytes" << std::endl;
}

void GetMemoryInfo()
{
    MEMORYSTATUSEX memStatus;
    memStatus.dwLength = sizeof(memStatus);
    GlobalMemoryStatusEx(&memStatus);

    std::cout << "-- Memory Information -- " << std::endl;
    std::cout << "Total physical memory: " << memStatus.ullTotalPhys / 1024 / 1024 << " MB" << std::endl;
    std::cout << "Available physical memory: " << memStatus.ullAvailPhys / 1024 / 1024 << " MB" << std::endl;
}

void GetDriveInfo()
{
    ULARGE_INTEGER freeBytesAvailableToCaller, totalNumberOfBytes, totalNumberOfFreeBytes;
    GetDiskFreeSpaceEx(NULL, &freeBytesAvailableToCaller, &totalNumberOfBytes, &totalNumberOfFreeBytes);

    std::cout << "-- Drive Information -- " << std::endl;
    std::cout << "Total size of drive: " << totalNumberOfBytes.QuadPart / 1024 / 1024 << " MB" << std::endl;
    std::cout << "Free space available on drive: " << freeBytesAvailableToCaller.QuadPart / 1024 / 1024 << " MB" << std::endl;
}

void GetOSInfo()
{
    OSVERSIONINFOEX osVersion;
    ZeroMemory(&osVersion, sizeof(OSVERSIONINFOEX));
    osVersion.dwOSVersionInfoSize = sizeof(OSVERSIONINFOEX);

    if (GetVersionEx((OSVERSIONINFO*)&osVersion) != 0)
    {
        std::cout << "-- Operating System Information -- " << std::endl;
        std::cout << "OS Name: " << osVersion.szCSDVersion << std::endl;
        std::cout << "Major Version: " << osVersion.dwMajorVersion << std::endl;
        std::cout << "Minor Version: " << osVersion.dwMinorVersion << std::endl;
    }
}

int main()
{
    GetCPUInfo();
    std::cout << std::endl;
    GetMemoryInfo();
    std::cout << std::endl;
    GetDriveInfo();
    std::cout << std::endl;
    GetOSInfo();

    return 0;
}


