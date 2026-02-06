using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Order> orders = new List<Order>();

        Address usaAddress = new Address("1250 Harbor Lane", "Seattle", "WA", "USA");
        Customer usaCustomer = new Customer("Maya Thompson", usaAddress);
        Order orderOne = new Order(usaCustomer);
        orderOne.AddProduct(new Product("Wireless Mouse", "WM-204", 24.99m, 2));
        orderOne.AddProduct(new Product("Mechanical Keyboard", "KB-873", 129.50m, 1));
        orderOne.AddProduct(new Product("USB-C Cable", "UC-115", 9.75m, 3));
        orders.Add(orderOne);

        Address internationalAddress = new Address("88 Pine Street", "Vancouver", "BC", "Canada");
        Customer internationalCustomer = new Customer("Oliver Chen", internationalAddress);
        Order orderTwo = new Order(internationalCustomer);
        orderTwo.AddProduct(new Product("Stainless Steel Bottle", "BT-442", 18.25m, 2));
        orderTwo.AddProduct(new Product("Insulated Lunch Bag", "LB-902", 21.40m, 1));
        orders.Add(orderTwo);

        int orderNumber = 1;

        foreach (Order order in orders)
        {
            Console.WriteLine($"Order {orderNumber}");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();

            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();

            Console.WriteLine($"Total Cost: ${order.GetTotalCost():0.00}");
            Console.WriteLine(new string('-', 40));

            orderNumber++;
        }
    }
}