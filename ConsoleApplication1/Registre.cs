using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Security.Permissions;

namespace ListingSoftware
{
    class Registre
    {
        RegistryKey myRegKey = Registry.LocalMachine;

        public Registre()
        {
            try
            {
                RegistryPermission regPermission = new RegistryPermission(RegistryPermissionAccess.AllAccess, @"HKEY_LOCAL_MACHINE"); //SOFTWAREMicrosoftWindows NTCurrentVersion
                regPermission.Demand();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        //Fonction initiale pour la lecture de registre (sans paramètre) appelle la version surchargé pour la suite.
        public void LectureReg ()
        {
            try 
            {
                RegistryPermission regPermission = new RegistryPermission(RegistryPermissionAccess.AllAccess, @"HKEY_LOCAL_MACHINE"); //SOFTWAREMicrosoftWindows NTCurrentVersion
                regPermission.Demand(); 
            } 
            catch (Exception e) 
            { 
                Console.WriteLine(e.Message); 
                return; 
            }   

            myRegKey = myRegKey.OpenSubKey(@"SOFTWARE");
            RegistryKey temp = myRegKey;

            Console.WriteLine(myRegKey.ToString());

            try
            {
                
                //Block d'affichage simple
                String[] subkeys = myRegKey.GetSubKeyNames();

                for (int i = 0; i < subkeys.Length; i++)
                {
                    Console.WriteLine((i+1) + " - " + subkeys[i]);
                    LectureReg(subkeys[i]);
                    myRegKey = temp;
                }

                Console.ReadLine();
              
            }
            catch (NullReferenceException err)
            {
                Console.WriteLine(err);
            }
        }

        //Fonction surchargée de lecture de registre, lit jusqu'à trouver un noeud correspondant à un programme
        public void LectureReg(String regPath)
        {
            try
            {
                myRegKey = myRegKey.OpenSubKey(regPath);
                RegistryKey temp = myRegKey;

                String[] subkeys = myRegKey.GetSubKeyNames();
                String[] values = myRegKey.GetValueNames();

                for (int i = 0; i < values.Length; i++)
                {
                    Console.Write("\t " + myRegKey.GetValue(values[i]));
                }
                Console.WriteLine();

                for (int i = 0; i < subkeys.Length; i++)
                {
                   // Console.ReadLine();
                    Console.WriteLine((i + 1) + " - " + subkeys[i]);
                    if ("Classes-Shit".Contains(subkeys[i]))
                    {
                    }
                    else
                    {
                        LectureReg(subkeys[i]);
                        myRegKey = temp;
                    }
                }
            }
            catch (NullReferenceException err)
            {
                Console.WriteLine(err);
            }
        }

        /*
                //lire les valeurs d'un chemin particulier - Recover Keys
                regK = myRegKey.OpenSubKey("Recover Keys");
                Console.WriteLine(regK);
                subkeys = regK.GetValueNames();

                for (int i = 0; i < subkeys.Length; i++)
                {
                    Console.WriteLine((i + 1) + " - " + subkeys[i] + " - " + regK.GetValue(subkeys[i]));
                }*/
        public String readValue(PathValue p) 
        { 
            String[] subToOpen= p.path.Split('\\');
            RegistryKey regKey = myRegKey;
            foreach (String s in subToOpen) 
            { 
                regKey = regKey.OpenSubKey(s);
            }
            String result = (String)regKey.GetValue(p.value);
            return result;
        }
    }
}
