using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShopIntegration
{
    [XmlRoot("Product")]
    public class Item
    {
        public string Name { get; set; } = "NAN";

        public int Count { get; set; } = 0;

        public double Price { get; set; } = 0;

        public string Comments { get; set; } = "NAN";

        public string Artist { get; set;  } = "NAN";

        public string Publisher { get; set; } = "NAN";

        public string Genre { get; set; } = "NAN";

        public int Year { get; set; } = 0;

        public int ProductID { get; set; } = 0;

       
        public Item()
        {

        }

        /// <summary>  
        ///  Constructor for a product.
        /// </summary> 
        public Item(string Name, string Count, string Price, string Comments, string Artist, string Publisher,
            string Genre, string Year, string ProductID)
        {
            this.Name = Name;
            this.Count = int.Parse(Count);
            this.Price = double.Parse(Price);
            this.Comments = Comments;
            this.Artist = Artist;
            this.Publisher = Publisher;
            this.Genre = Genre;
            this.Year = int.Parse(Year);
            this.ProductID = int.Parse(ProductID);
        }
    }
}

