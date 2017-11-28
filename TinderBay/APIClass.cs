using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
namespace App1.Resources
{
    class APIClass
    {

        public static Products[] ProductArray { get; set; }
        //public static Users[] UserArray { get; set; }
        public static Sales[] SaleArray { get; set; }
        public static Byte[] ImageArray { get; set; }
        public static async Task<List<Products>> GetProductsAsync()
        {

            //Instantiating HTTPClient
            HttpClient client = new HttpClient();
            //String address (URL)
            var address = "http://profferapi20171114093444.azurewebsites.net/api/ProductsModels";
            //Awaiting Response
            var response = await client.GetAsync(address);
            string PurchaseJson = response.Content.ReadAsStringAsync().Result;
            List<Products> purchases = JsonConvert.DeserializeObject<List<Products>>(PurchaseJson);
            ProductArray = purchases.ToArray();
            return purchases;
        }
        public static async Task<List<Sales>> GetSalesAsync()
        {
            //Instantiating HTTPClient
            HttpClient client = new HttpClient();
            //String address (URL)
            var address = "http://profferapi20171114093444.azurewebsites.net/api/SalesModels";
            //Awaiting Response
            var response = await client.GetAsync(address);
            string PurchaseJson = response.Content.ReadAsStringAsync().Result;
            List<Sales> sales = JsonConvert.DeserializeObject<List<Sales>>(PurchaseJson);
            SaleArray = sales.ToArray();
            return sales;
        }
    }
    class Products
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
    class Sales
    {
        public decimal Sales_price { get; set; }
        public DateTime Date_sold { get; set; }
        public string User_id { get; set; }
        public string Product_id { get; set; }
    }
}