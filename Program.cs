using System;
using System.IO;

namespace ShopIntegration
{
    class Program
    {
        private static FileHandler fileHandler = new FileHandler();
        static void Main(string[] args)
        {

            //Sökvägar.
            string fromShopFolder = AppDomain.CurrentDomain.BaseDirectory + "frShopFolder";
            string tillSimpleFolder = AppDomain.CurrentDomain.BaseDirectory + "tillSimpleFolder";

            //Skapar mapparna
            Directory.CreateDirectory(fromShopFolder);
            Directory.CreateDirectory(tillSimpleFolder);


            //Event handler.
            FileSystemWatcher fw = new FileSystemWatcher();
            fw.Path = fromShopFolder;
            
            // Händelser som vi är intresserade av
            fw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName;
            fw.Filter = "*.csv";
            // Registrera händelsehanterare 
            //fw.Changed += new FileSystemEventHandler(FilAndrad);
            fw.Created += new FileSystemEventHandler(FilAndrad);
            // Starta övervakning
            fw.EnableRaisingEvents = true;

            //Låter programmet stå och tugga. 
            Console.WriteLine("Välj \'q\' för att avsluta.");
            while (Console.Read() != 'q') ;
      
        }

        //This function is called when there is a new file in the watched folder. 
        private static void FilAndrad(object s, FileSystemEventArgs e)
        {
            fileHandler.WriteXML(fileHandler.ReadCSV(e.FullPath));
            File.Delete(e.FullPath);
        }
    }
}
