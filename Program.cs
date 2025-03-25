using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask6_Q1_
{

    public class product
    {
        public int ProductId;
        public string Name;
        public decimal Price;
        public int QuantityinStock;

        //Chaining Method 1
        public void CheckQuantityinStock(int quantityinStock)
        {
            if (quantityinStock >= 0 && quantityinStock <= 100)
            {
                QuantityinStock = quantityinStock;
            }
            else
            {

                Console.WriteLine("Make sure Quantity in Stock should be in the range 0 - 100");
                QuantityinStock = 0;
            }


        }


        //public product(int productId, string Name, decimal price, int quantityinStock)
        //{
        //    ProductId = productId;
        //    this.Name = Name;
        //    Price = price;
        //   CheckQuantityinStock(quantityinStock);

        //}
        // 3 Appraoch Contructor Chaining

        //public product(int productId, string Name, decimal price) : this(productId, Name, price, 0)
        //{
        //    // No need to add anything
        //}
        //public product(int productId, int quantityinStock) : this(productId, "", 0, quantityinStock)
        //{
        //    // No need to add anything
        //}
        //public product() : this(0, "", 0, 0)
        //{
        //    // No need to add anything
        //}
        //public product(int productId, string Name) : this(productId, Name, 0, 0)
        //{
        //    // No need to add anything
        //}
        //**********************Done Method 03

        //4 Approach Default values
        public product(int productId = 0, string Name = "", decimal price = 0, int quantityinStock = 0)
        {
            ProductId = productId;
            this.Name = Name;
            Price = price;
            CheckQuantityinStock(quantityinStock);

        }
        public void DisplayProductInfo()
        {
            Console.WriteLine($"Product ID = {ProductId},Name = {Name} Price = {Price}, Quantity = {QuantityinStock} ");
        }
        // Destructor
        ~product()
        {
            Console.WriteLine($"Product Having ID {ProductId} is killed");
        }
        public class Store
        {
            public string StoreName;
            public string Storelocation;
            private product[] Products;
            private int productCount;

            //Constructor

            public Store(string S_Name, string S_location)
            {
                StoreName = S_Name;
                Storelocation = S_location;
                Products = new product[10];
                productCount = 0;
            }

            //Method

            public void AddProductinStore(product Product)
            {
                if (productCount < Products.Length)
                {
                    Products[productCount++] = Product;
                }
                else
                {
                    Console.WriteLine("Not add products");
                }
            }
            public void DisplayAllProducts()
            {
                Console.WriteLine($"All Inventory of the store {StoreName} at location {Storelocation} is here");
                foreach (var Dummy_Product in Products)
                {
                    if(Dummy_Product!=null)
                    Dummy_Product.DisplayProductInfo();
                }
            }
            ~Store()
            {
                Console.WriteLine("stored Application Closed");
            }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                product p1= new product();  //Default
                product p2= new product(1,"camera",25.5m,10);//All Values
                product p3 = new product(2, "Mouse", 10.23m); //No Quantity in Stock 4 Apprach Default Values
                product p4 = new product(3,"",0, 23);//No name and No price 3 Approach
                product p5 = new product(4, "Keyboard"); //Only iD and name

                Store store = new Store("Zeenat","FSD");
                store.AddProductinStore(p1);    
                store.AddProductinStore(p2);
                store.AddProductinStore(p3);
                store.AddProductinStore(p4);
                store.AddProductinStore(p5);

                store.DisplayAllProducts();
                Console.ReadLine();

                Console.WriteLine("Here we are killing objects");

                //How to Handle Destructor
                p1 = null;
                p2 = null;
                p3 = null;
                p4 = null;
                p5 = null;
                store = null;

                //Run Garbage Value
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }
    }
}
