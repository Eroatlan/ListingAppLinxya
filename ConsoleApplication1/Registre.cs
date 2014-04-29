﻿using System;
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
        private RegistryKey myRegKey = Registry.LocalMachine;
        List<String> toAvoid;
         
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

            this.toAvoid = new List<string>();
            toAvoid.Add("Classes"); 
            toAvoid.Add("CoreSecurity");
            toAvoid.Add("MaxxAudio");
            toAvoid.Add("ASP.NET");
            toAvoid.Add("Fax");
            toAvoid.Add("Microsoft");
            toAvoid.Add("secure");
            toAvoid.Add("SID");
        }

        //Fonction initiale pour la lecture de registre (sans paramètre) appelle la version surchargé pour la suite.
        public List<RegGuess> LectureReg (List<String> softList)
        {
            myRegKey = myRegKey.OpenSubKey(@"SOFTWARE");
            RegistryKey temp = myRegKey;

            Console.WriteLine(myRegKey.ToString());

            try
            {
                List<RegGuess> guessList = new List<RegGuess>();
                
                //Block d'affichage simple
                String[] subkeys = myRegKey.GetSubKeyNames();

                for (int i = 0; i < subkeys.Length; i++)
                {
                    if (toAvoid.Contains(subkeys[i]))
                    {
                    }
                    else
                    {
                        Console.WriteLine((i + 1) + " - " + subkeys[i]);
                        if (softList.Contains(subkeys[i]))
                        {
                            guessList.Add(FindValues(subkeys[i]));
                        }
                        else
                        {
                            guessList.AddRange(LectureReg(subkeys[i], softList));
                        }
                        myRegKey = temp;
                    }
                }

                Console.ReadLine();
                return (guessList);
            }
            catch (NullReferenceException err)
            {
                Console.WriteLine(err);
                Console.ReadLine();
                return (null);
            }
        }

        //Fonction surchargée de lecture de registre, lit jusqu'à trouver un noeud correspondant à un programme
        public List<RegGuess> LectureReg(String regPath, List<String> softList)
        {
            List<RegGuess> guessList = new List<RegGuess>(); 
            try
            {
                try
                {
                    RegistryPermission regPermission = new RegistryPermission(RegistryPermissionAccess.AllAccess, regPath);
                    regPermission.Demand();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                    return (null);
                }

                myRegKey = myRegKey.OpenSubKey(regPath);
                RegistryKey temp = myRegKey;

                String[] subkeys = myRegKey.GetSubKeyNames();
                String[] values = myRegKey.GetValueNames();

                for (int i = 0; i < subkeys.Length; i++)
                {
                    if (toAvoid.Contains(subkeys[i]))
                    {
                    }
                    else
                    {
                        if (softList.Contains(subkeys[i]))
                        {
                            Console.WriteLine((i + 1) + " - " + subkeys[i]);
                            guessList.Add(FindValues(subkeys[i]));
                        }
                        else
                        {
                            guessList.AddRange(LectureReg(subkeys[i], softList));
                        }
                        myRegKey = temp;
                    }
                }
                return (guessList);
            }
            catch (NullReferenceException err)
            {
                Console.WriteLine(err);
                return(guessList);
            }
        }

        public RegGuess FindValues(String regPath)
        {
            RegGuess current = new RegGuess(regPath);
            try
            {
                RegistryPermission regPermission = new RegistryPermission(RegistryPermissionAccess.AllAccess, regPath); //SOFTWAREMicrosoftWindows NTCurrentVersion
                regPermission.Demand();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return (null);
            }
            myRegKey = myRegKey.OpenSubKey(regPath);
            RegistryKey temp = myRegKey;

            String[] subkeys = myRegKey.GetSubKeyNames();
            String[] values = myRegKey.GetValueNames();

            //Selection criterias
            for (int i = 0; i < values.Length; i++)
            {
                current.addValue(values[i] + " -> \t" + myRegKey.GetValue(values[i]).ToString());
                //Console.Write("\t " + myRegKey.GetValue(values[i]));
            }

            for (int i = 0; i < subkeys.Length; i++)
            {
                current.addValueRange(FindUnderValues(subkeys[i]));
                myRegKey = temp;
            }
            return current;
        }

        public List<String> FindUnderValues(String path)
        {
            List<String> foundValues = new List<string>();
            try
            {
                RegistryPermission regPermission = new RegistryPermission(RegistryPermissionAccess.AllAccess, path);
                regPermission.Demand();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return (null);
            }  
            myRegKey = myRegKey.OpenSubKey(path);
            RegistryKey temp = myRegKey;

            String[] subkeys = myRegKey.GetSubKeyNames();
            String[] values = myRegKey.GetValueNames();

            //Selection criterias
            for (int i = 0; i < values.Length; i++)
            {
                foundValues.Add(values[i] + " -> \t" + myRegKey.GetValue(values[i]).ToString());
                //Console.Write("\t " + myRegKey.GetValue(values[i]));
            }
            for (int i = 0; i < subkeys.Length; i++)
            {
                foundValues.AddRange(FindUnderValues(subkeys[i]));
                myRegKey = temp;
            }

            return (foundValues);
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
