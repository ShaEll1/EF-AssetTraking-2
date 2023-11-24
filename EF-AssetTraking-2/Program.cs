using EF_AssetTraking_2;
using Microsoft.EntityFrameworkCore;

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("---------------- Asset Tracking ----------------");

MyDbContext context = new MyDbContext();
List<Office> offices = context.Offices.ToList();
List<Asset> assets = context.Assets.ToList();

// Sort the list by AssetType and then by PurchaseDate
assets = assets.OrderBy(a => a.AssetType)
               .ThenBy(a => a.PurchaseDate)
               .ToList();

// Exchange rates
decimal usdToEuroRate = 0.85m; // Example: 1 USD = 0.85 EUR
decimal usdToSekRate = 8.83m;  // Example: 1 USD = 8.83 SEK


Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Asset Type".PadRight(15) + "Brand".PadRight(15) + "Date of Purchase".PadRight(20) + "Office".PadRight(15) + "Price in $".PadRight(15) + "Price in SEK".PadRight(15) + "Price in EURO".PadRight(15));

Console.ResetColor();



// Display the sorted list with formatting

foreach (var item in assets)
{
    string purchaseDateDisplay = item.PurchaseDate.Date.ToShortDateString();
    decimal priceInLocalCurrency = 0;
    string localCurrencySymbol = "";

    switch (item.Office.Name)
    {
        case "USA":
            priceInLocalCurrency = item.Price;
            localCurrencySymbol = "$";
            break;

        case "Spain":
            priceInLocalCurrency = item.Price * usdToEuroRate;
            localCurrencySymbol = "€";
            break;


        case "Sweden":
            priceInLocalCurrency = item.Price / usdToSekRate;
            localCurrencySymbol = "SEK";
            break;
    }

    decimal priceInSek = priceInLocalCurrency * usdToSekRate;
    decimal priceInEuro = priceInLocalCurrency / usdToEuroRate;


    if (IsSixMonthsAway(item.PurchaseDate))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
    }
    if (IsThreeYearsOld(item.PurchaseDate))
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }

    Console.WriteLine($"{item.AssetType.PadRight(15)} {item.Brand.PadRight(15)} {purchaseDateDisplay.PadRight(15)}  {item.Office.Name.PadRight(15)} " +
    $"{priceInLocalCurrency.ToString("F2").PadRight(15)}{priceInSek.ToString("F2").PadRight(15)} {priceInEuro.ToString("F2").PadRight(15)} ");

    Console.ResetColor();
}

  Console.WriteLine(" ");

static void DisplayAssetCounts(Office office)
{
    var assetCounts = office.Asset
        .GroupBy(a => a.AssetType)
        .Select(group => new { AssetType = group.Key, Count = group.Count() })
        .ToList();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"Assets in {office.Name} office : ");

    foreach (var count in assetCounts)
    {
        string pluralSuffix = count.Count > 1 ? "s" : "";
        Console.Write($" {count.Count} {count.AssetType}{pluralSuffix}.");
    }

    Console.ResetColor();
    Console.WriteLine();
}

MyDbContext Context = new MyDbContext();

DisplayAssetCounts(context.Offices.Include(x => x.Asset).FirstOrDefault(x => x.Id == 1));
DisplayAssetCounts(context.Offices.Include(y => y.Asset).FirstOrDefault(y => y.Id == 2));
DisplayAssetCounts(context.Offices.Include(z => z.Asset).FirstOrDefault(z => z.Id == 3));

Console.WriteLine(" ");
/*
// CREATE OR INSERT DATA

Asset asset15 = new Asset();
asset15.AssetType = "Mobile Phone";
asset15.Brand = "Samsung";
asset15.PurchaseDate = new DateTime(2023, 3, 17).Date;
asset15.Price = 3900;
asset15.OfficeId = 2;

context.Assets.Add(asset15);
context.SaveChanges();
Console.WriteLine("Asset Created - Run the programe again without this code to get the updated list ");
*/


//UPDATE OR EDIT DATA 
/*
Asset asset9 = context.Assets.FirstOrDefault(x => x.Id == 9);
asset9.PurchaseDate= new DateTime(2021, 4, 07).Date;

context.Assets.Update(asset9);
context.SaveChanges();
Console.WriteLine("Asset Updated - Run the programe again without this code to get the updated list ");
*/

//REMOVE- DELETE
/*
Asset asset15=context.Assets.FirstOrDefault(y => y.Id == 15);
context.Assets.Remove(asset15);
context.SaveChanges();
Console.WriteLine("Asset Deleted - Run the programe again without this code to get the updated list ");
*/

// check if the purchase date is 3months to 3 years, 
static bool IsThreeYearsOld(DateTime purchaseDate)
{
    return (DateTime.Now - purchaseDate).TotalDays > ((3 * 365) - 90);
}
// check if the purchase date is 6months to 3 years, 
static bool IsSixMonthsAway(DateTime purchaseDate)
{
    return (DateTime.Now - purchaseDate).TotalDays > ((3 * 365) - 180);
}