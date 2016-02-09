using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockShop
{
    public static class Shop
    {


        #region Methods

        public static IEnumerable<Product> GetAllProducts()
        {
            var db = new ShopModel();
            return db.Products;
        }

        public static Customer CreateCustomer(string name, int ssn, string address, string emailAdd)
        {
            using (var db = new ShopModel())
            {
                var cust = new Customer();      //same        //Customer customer = new Customer()
                cust.Name = name;
                cust.SSN = ssn;
                cust.Address = address;
                cust.EmailAddress = emailAdd;

                db.Customers.Add(cust);
                db.SaveChanges();
                return cust;
            }
        }

        public static Product CreateProduct(string name,  string description, decimal price, decimal weight,
                                            string image)
        {
            using (var db = new ShopModel())
            {
                var prod = new Product
                {
                    Name = name,
                    Descripion = description,
                    Price = price,
                    Weight = weight,
                    Image = image
                };
                db.Products.Add(prod);
                db.SaveChanges();

                return prod;
            }
        }
       // public static OrderHeader CreateOrder
       public static void AddProductToCart(int productId, int customerId, int quantity)
        {
            using (var db = new ShopModel())
            {
                //LING (language integrated Query) & LAMBDA
                var cart = db.ShoppingCarts.Where(s => s.CustomerId == customerId).FirstOrDefault();
                if (cart == null)
                {
                    //did not find a cart - create one
                    cart = new ShoppingCart
                    {
                        CustomerId = customerId
                    };
                    db.ShoppingCarts.Add(cart);
                }
                var product = db.Products.Where(p => p.ProductId == productId).FirstOrDefault();
                if (product != null)
                {
                    var detailEntry = new ShoppingCartDetail
                    {
                        ShoppingCartId = cart.ShoppingCartId,
                        ProductId = product.ProductId,
                        Quantity = quantity,
                        SubTotal = quantity * product.Price
                    };
                    db.ShoppingCartDetails.Add(detailEntry);                 
                }
                db.SaveChanges();
            }
        }
        #endregion
    }
}
