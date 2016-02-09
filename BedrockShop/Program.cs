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

            foreach (var product in Shop.GetAllProducts())
            {
                Console.WriteLine("{0}. {1} - {2} - {3:c}", product.ProductId,product.Name,product.Descripion,
                                                            product.Price);
            }
        }
    }
}
