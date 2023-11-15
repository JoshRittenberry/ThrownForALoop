﻿// See https://aka.ms/new-console-template for more information
List<Product> products = new List<Product>()
{
new Product()
{
Name = "Football",
Price = 15.00M,
Sold = false,
StockDate = new DateTime(2022, 10 ,20),
ManufacturerYear = 2010,
Condition = 4.2
},
new Product()
{
Name = "Hockey Stick",
Price = 12.99M,
Sold = false,
StockDate = new DateTime(2023, 1, 14),
ManufacturerYear = 2020,
Condition = 2.5
},
new Product()
{
Name = "Boomerang",
Price = 7.50M,
Sold = false,
StockDate = new DateTime(2021, 3, 29),
ManufacturerYear = 2012,
Condition = 3
},
new Product()
{
Name = "Frisbee",
Price = 10.99M,
Sold = false,
StockDate = new DateTime(2023, 11, 12),
ManufacturerYear = 2023,
Condition = 5
},
new Product()
{
Name = "Golf Putter",
Price = 23.75M,
Sold = true,
StockDate = new DateTime(2003, 1, 10),
ManufacturerYear = 1999,
Condition = 4.9
},
new Product()
{
Name = "Tennis Balls",
Price = 5.60M,
Sold = false,
StockDate = new DateTime(2020, 7, 16),
ManufacturerYear = 2014,
Condition = 3.6
},
new Product()
{
Name = "Basketball",
Price = 20.00M,
Sold = false,
StockDate = new DateTime(2023, 9, 10),
ManufacturerYear = 2021,
Condition = 4.5
},
new Product()
{
Name = "Badminton Racket",
Price = 18.50M,
Sold = false,
StockDate = new DateTime(2023, 9, 25),
ManufacturerYear = 2022,
Condition = 4.8
},
new Product()
{
Name = "Volleyball",
Price = 16.00M,
Sold = false,
StockDate = new DateTime(2023, 10, 1),
ManufacturerYear = 2023,
Condition = 4.7
}
};

DateTime now = DateTime.Now;

string greeting = @"Welcme to Thrown For a Loop
Your one-stop shop for used sporting equipment";

Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
0. Exit
1. View All Products
2. View Product Details
3. View Latest Products");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2")
    {
        ViewProductDetails();
    }
    else if (choice == "3")
    {
        ViewLatestProducts();
    }
}

void ViewProductDetails()
{
    ListProducts();

    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }
    }

    TimeSpan timeInStock = now - chosenProduct.StockDate;

    Console.WriteLine(@$"You chose: 
{chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufacturerYear} years old.
It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}");
}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewLatestProducts()
{
    // create a new empty List to store the latest products
    List<Product> latestProducts = new List<Product>();
    // Calculate a DateTime 90 days in the past
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    // loop through the products
    foreach (Product product in products)
    {
        // Add a product to latestProducts if it fits the criteria
        if (product.StockDate > threeMonthsAgo && !product.Sold)
        {
            latestProducts.Add(product);
        }
    }
    Console.WriteLine("The Latest Products Are:");
    // print out the latest products to the console
    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
    }
}