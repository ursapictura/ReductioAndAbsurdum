// See https://aka.ms/new-console-template for more information
using ReductioAndAbsurdum;
// Create ProductTypes for shop with the following categories:
//        apparel, potions, enchanted objects, and wands

List<ProductType> productType= new List<ProductType>()
{
    new ProductType(1, "apparel"),
    new ProductType(2, "potions"),
    new ProductType(3, "enchanted objects"),
    new ProductType(4, "wands"),
    new ProductType(5, "ingredients"),
};

// Create Products for shop
List<Product> products = new List<Product>()
{
    new Product("Hand of Glory", 500, true, 3),
    new Product("Vorpal Sword", 1200, true, 3),
    new Product("Gris Gris Bag", 100, true, 2),
    new Product("Willow and Tigers Eye", 300, true, 4),
    new Product("Oak and Lapiz Lazuli", 350, true, 4),
    new Product("grave dirt", 25, true, 5),
    new Product("Tarot Deck: Rider Waite", 50, true, 3),
    new Product("Tarot Deck: Aquarian", 65, true, 3),
    new Product("Channeling Oil", 120, true, 2),
    new Product("Elixir of Flight", 200, true, 2),
    new Product("Hag Stone", 70, true, 3),
    new Product("Banishing Oil", 80, true, 2),
    new Product("Four Thieves Vinegar", 45, true, 2),
    new Product("Summoning water", 55, true, 2),
    new Product("Altar Annointing Oil", 25, true, 2),
    new Product("Skyclad", 0, true, 1),
    new Product("Moonlit Robe", 250, false, 1),
    new Product("crossing dirt", 25, true, 5),
    new Product("mugwort", 5, true, 5),
    new Product("yarrow", 5, true, 5),
    new Product("rue", 5, false, 5),
    new Product("wormwood", 7, true, 5),
    new Product("belladonna", 10, false, 5),
    new Product("Radiant Veil", 175, false, 1),
    new Product("candles, assorted", 2, true, 5),
    new Product("Innovacation Candle", 75, false, 3)
};

// TODO: Create Main Menu with the following options: view all products, add product to inventory, 
// delete product, and update product

string greeting = "Welcome the the Inventory Management System for Reductio and Absurdum's Magick Shoppe!";
Console.WriteLine(greeting);

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@" What would you like to do today?
    0. Leave inventory
    1. View all products
    2. Add product to store's inventory
    3. Remove a product inventory
    4. Update product in inventory");

    choice = Console.ReadLine();

    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        Console.Clear();
        ViewProducts();
    }
    else if (choice == "2")
    {
        Console.Clear();
        AddProduct();
    }
    else if (choice == "3")
    {
        Console.Clear();
        DeleteProduct();
    }
    else if (choice == "4")
    {
        Console.Clear();
        UpdateProduct();
    }
    else {
        Console.WriteLine("Please choose a valid choice between 1 - 4!");
    }
}

string ProductDetails(Product product)
{
   string detailsString = $"{product.Name} is {(product.Available ? "sold" : "available")} for {product.Price}.";
   return detailsString;
}

// TODO: ViewAllProducts Method

void ViewProducts()
{
    Console.WriteLine("Here are all the products listed in your invenory:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. The {ProductDetails(products[i])}");
    }
} 

// TODO: AddProduct Method
void AddProduct()
{
    Console.WriteLine("Add a product");
}

// TODO: DeleteProduct Method
void DeleteProduct()
{
    Console.WriteLine("Delete a product");
}


// TODO: UpdateProduct Method
void UpdateProduct()
{
    Console.WriteLine("Update a Product");
}