﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;

namespace ListingSoftware
{
    class Programs
    {
        private static Registre reg;

        static void Main(string[] args)
        {

            Console.WriteLine(Comp.compTest());
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
                    
                    Console.Write(". ");
                    softList.addSoft(new Software(idN, name, vend, instLoc, prodID, version));
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
      
            softList.secondTurn();

            //Code pour lancer la fenetre graphique, le contenu de ce main devra se trouver dans celui de la fenetre
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm fen = new MainForm();
            Application.Run(fen);
            //Thread th = new Thread(new ThreadStart(Application.Run));
            //th.Start(fen);*/

            foreach (Software s in softList.getList())
            {
                //fen.AddToListBoxSoftwares(s.toStringKey());
                Console.WriteLine(s.toStringKey());
            }
            
            Console.ReadLine();
        }
    }
}
