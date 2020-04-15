using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;

class Test
{
    static void Main(string[] args)
    {
        ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts()};      
        decimal price = cart.TotalPrice();
        Console.WriteLine($"Total: {price:C2}");
        Console.ReadKey();
    }

}


public  class Product
{
    public string Name { get; set; }
    public decimal? Price { get; set; }

    public static Product[] GetProducts()
    {
        Product onion = new Product { Name = "Onion", Price = 245.39M };
        Product cabbige = new Product { Name = "Cabbidge", Price = 239.88M };
        return new Product[] { onion, cabbige };
    }
}

public class ShoppingCart
{
    public IEnumerable<Product> Products { get; set; }
}

public static class MyExtensionMethods
{
    public static Decimal TotalPrice(this ShoppingCart cartProp)
    {
        decimal total = 0;

        foreach(Product prod in cartProp.Products)
        {
            total += prod?.Price ?? 0;
        }


        return total;
    }
}
/*
/main.html
/about.html
/portfolio.html
/portfolio/work-{workId}.html
/blog.html
/blog/post/{postID}.html
/{filePath}.txt
/user/avatar/{userID}.jpg
/promo-{promoID}.html
/blog/year-{year}.html
/blog/year-{year}/month-{month}/list.html
/blog/tag-{tagName}.html
/orders.html
/orders/{date}.html?sort={sort}&view={view}
/chat/{chatID}/user-1-{user1ID}/user-2-{user2ID}.html
/app/{scriptPath}.js
/app/style/{scriptPath}.css
/app/style/images/{ imageFileName } . {  extension  }
{литерал}{заполнитель} { } {заполнитель} 
*/

