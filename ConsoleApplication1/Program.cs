using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections;

namespace ListingSoftware
{
    class Programs
    {
        private static Registre reg;

        static void Main(string[] args)
        {
            Ways wat = new Ways();
            SoftList softList = new SoftList();
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_Product");

                int i = 0;
                
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    i++;
                    /*Console.WriteLine(i + "-----------------------------------");
                    Console.WriteLine("Win32_Product instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("IdentifyingNumber: {0}", queryObj["IdentifyingNumber"]);
                    Console.WriteLine("InstallLocation: {0}", queryObj["InstallLocation"]);
                    Console.WriteLine("Name: {0}", queryObj["Name"]);
                    Console.WriteLine("ProductID: {0}", queryObj["ProductID"]);
                    Console.WriteLine("Vendor: {0}", queryObj["Vendor"]);
                    Console.WriteLine("Version: {0}", queryObj["Version"]);*/
                    String idN = "";
                    String name = "";
                    String vend = "";
                    String instLoc = "";
                    String prodID = "";
                    String version = "";

                    try{idN = queryObj["IdentifyingNumber"].ToString();}
                    catch (Exception){}
                    try{name = queryObj["Name"].ToString();}
                    catch (Exception){}
                    try{vend = queryObj["Vendor"].ToString();}
                    catch (Exception){}
                    try{instLoc = queryObj["InstallLocation"].ToString();}
                    catch (Exception){}
                    try{prodID = queryObj["ProductID"].ToString();}
                    catch (Exception){}
                    try{version = queryObj["Version"].ToString();}
                    catch (Exception){}
                    
                    Console.WriteLine(i + name);
                    softList.addSoft(new Software(idN, name, vend, instLoc, prodID, version));
                }
                
                foreach (Software soft in softList.getList())
                {
                
                    Console.WriteLine(soft.toString());
                }
                softList.firstTurn();
                foreach (Software soft in softList.getList())
                {

                    Console.WriteLine(soft.toStringKey());
                    Console.In.ReadLine();
                }
                Console.In.ReadLine();
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }

            reg = new Registre();
            List<RegGuess> GuessList = new List<RegGuess>();
            GuessList = reg.LectureReg(softList.getNames());
            Console.In.ReadLine();
            Console.WriteLine(GuessList.ElementAt(12));
        }
    }
}
