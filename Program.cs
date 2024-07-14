// See https://aka.ms/new-console-template for more information
using ReductioAndAbsurdum;
// Create ProductTypes for shop with the following categories:
//        apparel, potions, enchanted objects, and wands

List<ProductType> productType = new List<ProductType>()
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

// Create Main Menu with the following options: view all products, add product to inventory, 
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
    4. Update product in inventory
    5. View products by category");

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
    else if (choice == "5")
    {
        Console.Clear();
        FilterByType();
    }
    else
    {
        Console.WriteLine("Please choose a valid choice between 1 - 5!");
    }
}

string ProductDetails(Product product)
{
    string detailsString = $"{product.Name} is {(product.Available ? "available" : "sold")} for {product.Price}.";
    return detailsString;
}

// ViewProducts Method

void ViewProducts()
{
    Console.WriteLine("Here are all the products listed in your inventory:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {ProductDetails(products[i])}");
    }
}

// AddProduct Method
void AddProduct()
{
    string productName = null;
    while (string.IsNullOrEmpty(productName))
    {
        Console.WriteLine("What is the name of the product you would like to add?");
        productName = Console.ReadLine();
    }

    decimal productPrice;
    while (true)
    {
        Console.WriteLine("How much does the product cost?");

        if (decimal.TryParse(Console.ReadLine(), out productPrice))
        {
            break;
        }
        else
        {
            Console.WriteLine("Sorry, that input was invalid. Please enter a valid price as either a decimal or whole number.");
        }
    }

    bool productAvailable;
    while (true)
    {
        Console.Clear();
        Console.WriteLine($"Is {productName} currently available for purchase? Enter YES or NO");
        string choice = Console.ReadLine();
        if (choice.ToLower() == "yes" || choice == "y")
        {
            productAvailable = true;
            break;
        }
        else if (choice.ToLower() == "no" || choice == "n")
        {
            productAvailable = false;
            break;
        }
        else
        {
            Console.WriteLine($"I'm sorry, you're answer was not valid. Please enter YES if {productName} is available for purchase. If it is unavailble, responde with NO.");
        }
    }

    int productTypeInput;
    while (true)
    {
        Console.WriteLine($"What category should {productName} be sorted into?");
        ListProductTypes();

        if (Int32.TryParse(Console.ReadLine(), out productTypeInput)
            && productTypeInput > 0
            && productTypeInput <= productType.Count)
        {
            break;
        }
        else
        {
            Console.WriteLine($"I'm sorry, you're input was not valid. Please select the number of the category where you would like {productName} sorted.");
        }
    }

    Product newProduct = new(productName, productPrice, productAvailable, productTypeInput);
    products.Add(newProduct);
}

// DeleteProduct Method
void DeleteProduct()
{
    Console.Clear();
    Console.WriteLine("Enter the number of the product you would like to remove.");

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }

    // int productNumber;
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out int productNumber)
             && productNumber > 0
             && productNumber <= products.Count)
        {
            products.RemoveAt(productNumber - 1);
            Console.WriteLine($"As you wish! The {products[productNumber - 1].Name} has been removed from the shop!");
            break;
        }
        else
        {
            Console.WriteLine("I'm Sorry, your inout was invalid. Please select the number of the product you would like to remove.");
        }
    }
}


// UpdateProduct Method
void UpdateProduct()
{
    Console.Clear();
    Console.WriteLine("Which product would you like to update?");

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1} {products[i].Name}");
    }

//  int choice;
    int productIndex;
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out int choice)
             && choice > 0
             && choice <= products.Count)
             {
                productIndex = choice - 1;
                break;
             }
             else
             {
                Console.WriteLine("I'm sorry, your answer was not valid. Please select the number of the product you would like to update.");
             }
    }

    Console.Clear();

    string productName = products[productIndex].Name;
    while (true)
    {
        Console.WriteLine($"What is the new name of {products[productIndex].Name}?");

       if(!string.IsNullOrEmpty(productName))
       {
            productName = Console.ReadLine();
            break;
       }
       else 
       {
        Console.WriteLine("Please enter a name for this product.");
       }
    }

    Console.Clear();

    decimal productPrice = products[productIndex].Price;
    while (true)
    {
        Console.WriteLine($"{productName} currently costs {products[productIndex].Price}. What would you like the new price to be?");

        if (decimal.TryParse(Console.ReadLine(), out productPrice))
        {
            break;
        }
        else
        {
            Console.WriteLine("Sorry, that input was invalid. Please enter a valid price as either a decimal or whole number.");
        }
    }

    bool productAvailable = products[productIndex].Available;
    while (true)
    {
        Console.Clear();
        Console.WriteLine($"Is {productName} currently available for purchase? Enter YES or NO");
        string choice = Console.ReadLine();
        if (choice.ToLower() == "yes" || choice == "y")
        {
            productAvailable = true;
            break;
        }
        else if (choice.ToLower() == "no" || choice == "n")
        {
            productAvailable = false;
            break;
        }
        else
        {
            Console.WriteLine($"I'm sorry, you're answer was not valid. Please enter YES if {productName} is available for purchase. If it is unavailble, responde with NO.");
        }
    }

    Console.Clear();

    int productTypeInput;
    while (true)
    {
        Console.WriteLine($"What category should {productName} be sorted into?");
        ListProductTypes();

        if (Int32.TryParse(Console.ReadLine(), out productTypeInput)
            && productTypeInput > 0
            && productTypeInput <= productType.Count)
        {
            break;
        }
        else
        {
            Console.WriteLine($"I'm sorry, you're input was not valid. Please select the number of the category where you would like {productName} sorted.");
        }
    }

//  Update product at chosen index to reflect inputs from user. 
    products[productIndex].Name = productName;
    products[productIndex].Price = productPrice;
    products[productIndex].Available = productAvailable;
    products[productIndex].ProductTypeId = productTypeInput;

    Console.WriteLine($"Ichita copita melaka mystica..{productName} has been transformed!");
    Console.WriteLine("press ENTER to continue");
    Console.ReadLine();

}


// TODO: Filter by ProductTypeID
void FilterByType()
{
    int productTypeInput;
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Which category of products would you like to see?");

        for (int i = 0; i < productType.Count; i++)
        {
            Console.WriteLine($"{i + 1} {productType[i].Name}");
        }

        if (int.TryParse(Console.ReadLine(), out productTypeInput)
             && productTypeInput > 0
             && productTypeInput <= productType.Count)
             {
                break;
             }
             else
             {
                Console.WriteLine("I'm sorry, your answer was not valid. Please select the number of the category of products you would like to see.");
             }
    }
    Console.Clear();

    List<Product> filteredProducts = products.Where(p => p.ProductTypeId == productTypeInput).ToList();

    foreach (Product product in filteredProducts)
    {
        Console.WriteLine($"{product.Name} is {(product.Available ? "available" : "sold")} for {product.Price}. {product.ProductTypeId}");
    }

    Console.WriteLine("press ENTER to continue");
    Console.ReadLine();
    Console.Clear();
}



void ListProductTypes()
{
    for (int i = 0; i < productType.Count; i++)
    {
        Console.WriteLine($"{i + 1} {productType[i].Name}");
    }
}