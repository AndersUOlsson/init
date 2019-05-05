using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopIntegration
{
    class FileHandler
    {
        //The destination where the file for the products is, this is in the App domain (In debug folder).
        private static readonly string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\" + "Lager.csv";

        /// <summary>  
        ///  This function reads from file and add to stock products.
        /// </summary> 
        public List<Item> ReadCSV(string filePath)
        {

            //string tillSimpleFile = AppDomain.CurrentDomain.BaseDirectory + @"\frShopFolder" + "//lager.csv";
            try
            {
                using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                using (CsvReader csv = new CsvReader(reader))
                {
                    var records = csv.GetRecords<Item>();
                    return records.ToList();
                }
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
          
        }

        public void WriteXML(List<Item> productList)
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Item>));
            string tillSimpleFile = AppDomain.CurrentDomain.BaseDirectory + @"\tillSimpleFolder" + "//tillSimple.xml";

            try
            {
                FileStream file = File.Create(tillSimpleFile);
                writer.Serialize(file, productList);
                file.Close();
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
