using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows;
using System.Windows.Forms;

namespace ListingLogiciels
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_Product");
                int i = 0;
                
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    i++;
                    Console.WriteLine(i + "-----------------------------------");
                    Console.WriteLine("Win32_Product instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("IdentifyingNumber: {0}", queryObj["IdentifyingNumber"]);
                    Console.WriteLine("InstallLocation: {0}", queryObj["InstallLocation"]);
                    Console.WriteLine("Name: {0}", queryObj["Name"]);
                    Console.WriteLine("ProductID: {0}", queryObj["ProductID"]);
                    Console.WriteLine("Vendor: {0}", queryObj["Vendor"]);
                    Console.WriteLine("Version: {0}", queryObj["Version"]);
                    Console.In.ReadLine();
                }
                
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
        }
        
    }
}
