///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//███████╗██████╗  █████╗ ██╗   ██╗███╗   ██╗██╗  ██╗ ██████╗ ███████╗███████╗██████╗       ██╗ ██████╗ ███████╗██████╗ 
//██╔════╝██╔══██╗██╔══██╗██║   ██║████╗  ██║██║  ██║██╔═══██╗██╔════╝██╔════╝██╔══██╗      ██║██╔═══██╗██╔════╝██╔══██╗
//█████╗  ██████╔╝███████║██║   ██║██╔██╗ ██║███████║██║   ██║█████╗  █████╗  ██████╔╝█████╗██║██║   ██║███████╗██████╔╝
//██╔══╝  ██╔══██╗██╔══██║██║   ██║██║╚██╗██║██╔══██║██║   ██║██╔══╝  ██╔══╝  ██╔══██╗╚════╝██║██║   ██║╚════██║██╔══██╗
//██║     ██║  ██║██║  ██║╚██████╔╝██║ ╚████║██║  ██║╚██████╔╝██║     ███████╗██║  ██║      ██║╚██████╔╝███████║██████╔╝
//╚═╝     ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚══════╝╚═╝  ╚═╝      ╚═╝ ╚═════╝ ╚══════╝╚═════╝ 
//  
//  Autor: Darius Korzeniewski     Date: 08.02.2017
//
//  
//  Description:
//
//
// 
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Naming Guidelines =)
// https://msdn.microsoft.com/de-de/library/xzf533w0(v=vs.71).aspx

using System;
using System.Threading;
// Install this package over NuGet
using HDF5DotNet;

namespace HDF5
{
    class Hdf5Program
    {
        static void Main(string[] args)
        {
            Hdf5Program Func = new Hdf5Program();

            //<<---MENU-------------------------------------------------->>
            while (true)
            {
                switch (Func.Menu())
                {
                    case 1:
                        Func.CreateHDF5();
                        break;
                    case 2:
                    break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ihre Eingaben konnnte nicht zugeordnet werden");
                        break;
                }
            }
                                    
            //<<---READ------------------------------------------------>>
            try
            {
                H5FileId fildId = H5F.open("Meins.h5", H5F.OpenMode.ACC_RDONLY);
                H5DataSetId date = H5D.open(fildId,"/meins" );
                Console.WriteLine(date);
                Thread.Sleep(2000);
            }
            catch(HDFException ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(2000);
            }
        }
        
        // Menu
        private int Menu()
        {
            int choice;
            
            Console.WriteLine("\n███████╗██████╗  █████╗ ██╗   ██╗███╗   ██╗██╗  ██╗ ██████╗ ███████╗███████╗██████╗       ██╗ ██████╗ ███████╗██████╗ ");
            Console.WriteLine("██╔════╝██╔══██╗██╔══██╗██║   ██║████╗  ██║██║  ██║██╔═══██╗██╔════╝██╔════╝██╔══██╗      ██║██╔═══██╗██╔════╝██╔══██╗");
            Console.WriteLine("█████╗  ██████╔╝███████║██║   ██║██╔██╗ ██║███████║██║   ██║█████╗  █████╗  ██████╔╝█████╗██║██║   ██║███████╗██████╔╝");
            Console.WriteLine("██╔══╝  ██╔══██╗██╔══██║██║   ██║██║╚██╗██║██╔══██║██║   ██║██╔══╝  ██╔══╝  ██╔══██╗╚════╝██║██║   ██║╚════██║██╔══██╗");
            Console.WriteLine("██║     ██║  ██║██║  ██║╚██████╔╝██║ ╚████║██║  ██║╚██████╔╝██║     ███████╗██║  ██║      ██║╚██████╔╝███████║██████╔╝");
            Console.WriteLine("╚═╝     ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚══════╝╚═╝  ╚═╝      ╚═╝ ╚═════╝ ╚══════╝╚═════╝ ");
            Console.WriteLine("HDF5 Dateien erstellen und bearbeiten\n");
            Console.WriteLine("1 HDF5 Datei erstellen");
            Console.WriteLine("0 Programm beenden");
            Console.WriteLine("\nTreffen Sie Ihre Wahl:");
            choice = int.Parse( Console.ReadLine());
            
            return choice;
        }

        //<<---CREATE------------------------------------------------>>
        // Create an HDF5 file
        private void CreateHDF5()
        {
            try
            {
                // Filename request
                String fileName;
                Console.
                WriteLine("Wie soll die HDF5 Datei heissen?");
                fileName = Console.ReadLine() + ".h5";

                H5FileId fildId = H5F.create(fileName, H5F.CreateMode.ACC_TRUNC);

                // Create a HDF5 Groupe
                String groupName;
                Console.WriteLine("Wie solle Ihre Gruppe heissen?");
                groupName = Console.ReadLine();
                H5GroupId groupId = H5G.create(fildId, "/" + groupName);
                H5G.close(groupId);


                Console.WriteLine("Das erstellen der Datei war erfolgreich!");
                Thread.Sleep(2000);

            }
            catch (HDFException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
