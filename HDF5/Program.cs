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
using System;
using System.Data;
using System.Threading;
// Install this pakage over NuGet
using HDF5DotNet;

namespace HDF5
{
    class Program
    {
        static void Main(string[] args)
        {
            //<<---MENU-------------------------------------------------->>


            //<<---CREATE------------------------------------------------>>
            // Create an HDF5 file
            try
            {
                // Filenmae request
                String fileName;
                Console.WriteLine("Wie soll die HDF5 Datei heissen?");
                fileName = Console.ReadLine() + ".h5";

                H5FileId fildId = H5F.create(fileName, H5F.CreateMode.ACC_TRUNC);

                // Create a HDF5 Groupe
                String groupName;
                Console.WriteLine("Wie solle Ihre Gruppe heissen?");
                groupName = Console.ReadLine();
                H5GroupId groupId = H5G.create(fildId, "/"+groupName);
                H5G.close(groupId);


                Console.WriteLine("Das erstellen der Datei war erfolgreich!");
                Thread.Sleep(2000);

            }
            catch (HDFException ex)
            {
               Console.WriteLine(ex.Message);
            }
            
            //<<---READ------------------------------------------------>>
            try
            {
                H5FileId fildId = H5F.open("Meins.h5", H5F.OpenMode.ACC_RDONLY);
                H5DataSetId daten = H5D.open(fildId,"/meins" );
                Console.WriteLine(daten);
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
