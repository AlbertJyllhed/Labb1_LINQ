using Labb1_LINQ.Models;

namespace Labb1_LINQ
{
    internal class EStoreQueries
    {
        internal static void DisplayElectronicsByPrice()
        {
            using (var context = new EStoreContext())
            {
                var electronics = context.Products
                    .Where(p => p.Category.Name == "Electronics")
                    .OrderByDescending(p => p.Price)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                    .ToList();

                foreach (var electronic in electronics)
                {
                    Console.WriteLine($"Produkt: {electronic.Name}\n" +
                        $"Pris: {electronic.Price}\n");
                }
            }
        }

        internal static void DisplaySuppliersWithLowStock()
        {
            using (var context = new EStoreContext())
            {
                var suppliers = context.Suppliers
                    .Select(s => new
                    {
                        s.Name,
                        Products = s.Products
                        .Where(p => p.StockQuantity < 10)
                        .Select(p => new
                        {
                            p.Name,
                            p.StockQuantity
                        })
                        .ToList()
                    })
                    .Where(s => s.Products.Count > 0)
                    .ToList();

                foreach (var supplier in suppliers)
                {
                    Console.WriteLine($"Leverantör: {supplier.Name}");

                    foreach (var product in supplier.Products)
                    {
                        Console.WriteLine($"Produkt: {product.Name}\n" +
                            $"Lagersaldo: {product.StockQuantity}\n");
                    }
                }
            }
        }

        internal static void DisplayTotalOrderValueThisMonth()
        {
            using (var context = new EStoreContext())
            {
                var total = context.Orders
                    .Where(o => o.OrderDate < DateTime.Now.AddDays(-30))
                    .Sum(o => o.TotalAmount);

                Console.WriteLine($"Totalt ordervärde senaste månaden: {total}");
            }
        }
    }
}
