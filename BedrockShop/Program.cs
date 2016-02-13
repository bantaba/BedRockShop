using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //Customer c1 = new Customer();   //var x = new Customer();
            //var c1 = Shop.CreateCustomer("Matar", 123456789, "123 2nd Ave East", "mat@mail.net");
            //var c2 = Shop.CreateCustomer("Mahu", 123456789, "123 52nd Ave West", "Mahu@testMail.com");

            //Console.WriteLine("Id: {0}, Name: {1}, Address: {2}, SSN: {3}, Email Address: {4}",
            //        c1.CustomerId,c1.Name,c1.Address,c1.SSN,c1.EmailAddress);
            //Console.WriteLine("Id: {0}, Name: {1}, Address: {2}, SSN: {3}, Email Address: {4}",
            //        c2.CustomerId, c2.Name, c2.Address, c2.SSN, c2.EmailAddress);

            Console.WriteLine("*****Welcome to BedRock Shop******");
            Console.Write("Please provide your customer id: ");
            var customerID = Console.ReadLine();

            //convert customerID to int
            int convertedCustId;
            if (!int.TryParse(customerID, out convertedCustId))
            {
                Console.WriteLine("Sorry - invalid customer id");
                return;
            }

            Console.Write("Enter price value to search for: ");
            var searchValue = Console.ReadLine();
            decimal searchPrice;
            if(!decimal.TryParse(searchValue, out searchPrice))
            {
                throw new ArgumentOutOfRangeException("Invalid search price");
            }
            foreach (var product in Shop.SearchProducts(searchPrice))
            {
                Console.WriteLine("Product - {0}, Price - {1:c}", product.Name, product.Price);
            }

            foreach (var product in Shop.GetAllProducts())
            {
                Console.WriteLine("{0}. {1} - {2} - {3:c}", product.ProductId,product.Name,product.Descripion,
                                                            product.Price);
            }

            bool continueShopping = true;
            while (continueShopping)
            {            
                Console.WriteLine("Select a product number to add to shopping cart:");
                var pdtNumber = Console.ReadLine();
                int convertedPdtNumber;
                if (!int.TryParse(pdtNumber, out convertedPdtNumber))
                {
                    throw new ArgumentOutOfRangeException("Invalid product number");
                }

                Console.WriteLine("How many of the product do you want to buy? ");
                var quantity = Console.ReadLine();
                int convertedQuantity;
                if (!int.TryParse(quantity, out convertedQuantity))
                {
                    throw new ArgumentOutOfRangeException("Invalid quantity");
                }
                Shop.AddProductToCart(convertedPdtNumber, convertedCustId, convertedQuantity);
                Console.WriteLine("Product successfull added to the shopping cart");
                Console.WriteLine("1. Proceed to checkout");
                Console.WriteLine("2. Continue to shopping");
                Console.WriteLine("0. Exit");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        return;
                    case "1":
                        continueShopping = false;
                        break;
                    case "2":
                        continue; // continueShopping = true
                    default:
                        throw new ArgumentOutOfRangeException("Invalid choice");
                }
            }

            Console.WriteLine("Your shopping cart contains the following: ");
            foreach (var item in Shop.GetShoppingCartDetails(convertedCustId))
            {
                Console.WriteLine("Produc - {0}, Quantity - {1}, SubTotal - {2:c}", item.Product.Name, item.Quantity, item.SubTotal);
            }
        }
    }
}
