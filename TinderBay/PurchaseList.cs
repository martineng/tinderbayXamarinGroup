using System;
namespace TinderBay
{
    public class PurchaseList
    {
        public string Product_id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public DateTime Upload_date { get; set; }
        public int Image_int { get; set; }
        public string User_id { get; set; }
    }
}
