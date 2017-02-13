///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// ███████╗██████╗  █████╗ ██╗   ██╗███╗   ██╗██╗  ██╗ ██████╗ ███████╗███████╗██████╗       ██╗ ██████╗ ███████╗██████╗ 
// ██╔════╝██╔══██╗██╔══██╗██║   ██║████╗  ██║██║  ██║██╔═══██╗██╔════╝██╔════╝██╔══██╗      ██║██╔═══██╗██╔════╝██╔══██╗
// █████╗  ██████╔╝███████║██║   ██║██╔██╗ ██║███████║██║   ██║█████╗  █████╗  ██████╔╝█████╗██║██║   ██║███████╗██████╔╝
// ██╔══╝  ██╔══██╗██╔══██║██║   ██║██║╚██╗██║██╔══██║██║   ██║██╔══╝  ██╔══╝  ██╔══██╗╚════╝██║██║   ██║╚════██║██╔══██╗
// ██║     ██║  ██║██║  ██║╚██████╔╝██║ ╚████║██║  ██║╚██████╔╝██║     ███████╗██║  ██║      ██║╚██████╔╝███████║██████╔╝
// ╚═╝     ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚══════╝╚═╝  ╚═╝      ╚═╝ ╚═════╝ ╚══════╝╚═════╝ 
//  
//  Autor: Darius Korzeniewski     Date: 08.02.2017
//  Namespace:      HDF
// 	Class:          Hdf5Program
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
            // Menu
            while (true)
            {
                switch (Func.Menu())
                {
                    case 1:
                        Func.CreateHDF5();
                        break;
                    case 2:
                        Func.ReadHDF5();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ihre Eingaben konnnte nicht zugeordnet werden");
                        break;
                }
            }
        }
        //<<---Terminal-MENU-------------------------------------------->>
        private int Menu()
        {
            Console.WriteLine("\n ███████╗██████╗  █████╗ ██╗   ██╗███╗   ██╗██╗  ██╗ ██████╗ ███████╗███████╗██████╗       ██╗ ██████╗ ███████╗██████╗ ");
            Console.WriteLine(" ██╔════╝██╔══██╗██╔══██╗██║   ██║████╗  ██║██║  ██║██╔═══██╗██╔════╝██╔════╝██╔══██╗      ██║██╔═══██╗██╔════╝██╔══██╗");
            Console.WriteLine(" █████╗  ██████╔╝███████║██║   ██║██╔██╗ ██║███████║██║   ██║█████╗  █████╗  ██████╔╝█████╗██║██║   ██║███████╗██████╔╝");
            Console.WriteLine(" ██╔══╝  ██╔══██╗██╔══██║██║   ██║██║╚██╗██║██╔══██║██║   ██║██╔══╝  ██╔══╝  ██╔══██╗╚════╝██║██║   ██║╚════██║██╔══██╗");
            Console.WriteLine(" ██║     ██║  ██║██║  ██║╚██████╔╝██║ ╚████║██║  ██║╚██████╔╝██║     ███████╗██║  ██║      ██║╚██████╔╝███████║██████╔╝");
            Console.WriteLine(" ╚═╝     ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚══════╝╚═╝  ╚═╝      ╚═╝ ╚═════╝ ╚══════╝╚═════╝ ");
            Console.WriteLine("HDF5 Dateien erstellen und bearbeiten");
            Console.WriteLine("Author: Darius Korzeniewski\n");
            Console.WriteLine("1 HDF5 Datei erstellen");
            Console.WriteLine("2 HDF5 Datei auslesen");
            Console.WriteLine("0 Programm beenden");
            Console.WriteLine("\nTreffen Sie Ihre Wahl:");
            return int.Parse(Console.ReadLine());
        }
        //<<---CREATE--------------------------------------------------->>
        // Create an HDF5 file
        private void CreateHDF5()
        {
            try
            {
                // Filename request
                Console.WriteLine("Wie soll die HDF5 Datei heissen?");
                String fileName = Console.ReadLine() + ".h5";
                // Create File
                H5FileId fildId = H5F.create(fileName, H5F.CreateMode.ACC_TRUNC);
                // Create a HDF5 Groupe
                Console.WriteLine("Wie solle Ihre Gruppe heissen?");
                String groupName = Console.ReadLine();
                H5GroupId groupId = H5G.create(fildId, groupName);
                // <--- Create a Subgroupe --->
                // Console.WriteLine("Wie solle Ihre Gruppe heissen?");
                // groupName = Console.ReadLine();
                // H5GroupId subGroup = H5G.create(groupId, groupName);

                // Include data in Groupe

                Console.WriteLine("Wie solle Ihre Variabel Name heissen?");
                String dataName = Console.ReadLine();

                //H5A.write<int>(groupId, dataName,);
                
                                
                Console.WriteLine("Das erstellen der Datei war erfolgreich!");
                // Close all
                // H5G.close(subGroup);
                H5G.close(groupId);
                H5F.close(fildId);
                Thread.Sleep(2000);
            }
            catch (HDFException ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(2000);
            }
        }
        //<<---READ----------------------------------------------------->>
        // Read an HDF5 File
        private void ReadHDF5()
        { 
            try
            {
                H5FileId fileId = H5F.open("Meins.h5", H5F.OpenMode.ACC_RDONLY);
                                
                // H5DataSetId date = H5D.open(fildId, "/Meins");
                // Console.WriteLine(date);
                // H5D.close(date);

                H5F.close(fileId);
                Thread.Sleep(2000);
            }
            catch(HDFException ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(2000);
            }
        }
    }
}
