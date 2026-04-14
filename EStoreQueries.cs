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
                    });

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
                    })
                    .Where(s => s.Products.Count() > 0);

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
                    .Where(o => o.OrderDate >= DateTime.Now.AddDays(-31))
                    .Sum(o => o.TotalAmount);

                Console.WriteLine($"Totalt ordervärde senaste månaden: {total} kr\n");
            }
        }

        internal static void DisplayMostSoldProducts()
        {
            using (var context = new EStoreContext())
            {
                var topProducts = context.OrderDetails
                    .GroupBy(od => od.Product.Name)
                    .Select(g => new
                    {
                        g.Key,
                        TotalQuantitySold = g.Sum(od => od.Quantity)
                    })
                    .OrderByDescending(p => p.TotalQuantitySold)
                    .Take(3);

                foreach (var product in topProducts)
                {
                    Console.WriteLine($"Produkt: {product}\n" +
                        $"Sålda enheter: {product.TotalQuantitySold}\n");
                }
            }
        }

        internal static void DisplayProductAmountsForEachCategory()
        {
            using (var context = new EStoreContext())
            {
                var categories = context.Categories
                    .Select(c => new
                    {
                        c.Name,
                        ProductAmount = c.Products.Count
                    });

                foreach (var category in categories)
                {
                    Console.WriteLine($"Kategori: {category.Name}\n" +
                        $"Produkter: {category.ProductAmount}\n");
                }
            }
        }

        internal static void DisplayExpensiveOrders()
        {
            using (var context = new EStoreContext())
            {
                var expensiveOrders = context.Orders
                    .Where(o => o.TotalAmount > 1000)
                    .Select(o => new
                    {
                        o.Customer.Name,
                        o.Customer.Email,
                        o.Customer.Phone,
                        o.Customer.Address,
                        o.OrderDate,
                        o.TotalAmount,
                        o.Status,
                        OrderDetails = o.OrderDetails
                        .Select(od => new
                        {
                            od.Product.Name,
                            od.Quantity,
                            od.UnitPrice,
                        })
                    });

                foreach (var order in expensiveOrders)
                {
                    Console.WriteLine($"Kund: {order.Name}\n" +
                        $"Email: {order.Email}\n" +
                        $"Tel: {order.Phone}\n" +
                        $"Adress: {order.Address}\n" +
                        $"Orderdatum: {order.OrderDate}\n" +
                        $"Status: {order.Status}\n" +
                        $"Totalt: {order.TotalAmount} kr\n");

                    foreach (var detail in order.OrderDetails)
                    {
                        Console.WriteLine($"Produkt: {detail.Name}\n" +
                            $"Antal: {detail.Quantity}\n" +
                            $"Pris per enhet: {detail.UnitPrice} kr\n");
                    }
                }
            }
        }
    }
}
