namespace Labb1_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var menus = new List<Menu>
            {
                new("Huvudmeny", new List<Menu>
                {
                    new("Visa produkter i elektronikkategorin", () => EStoreQueries.DisplayElectronicsByPrice()),
                    new("Visa leverantörer med lågt lagersaldo", () => EStoreQueries.DisplaySuppliersWithLowStock()),
                    new("Visa totalt ordervärde för senaste månaden", () => EStoreQueries.DisplayTotalOrderValueThisMonth()),
                    //new("Visa de mest sålda produkterna", () => EStoreQueries.DisplayMostSoldProducts()),
                    //new("Visa produktmängd för varje kategori", () => EStoreQueries.DisplayProductAmountsForEachCategory()),
                    //new("Visa de dyraste ordrarna", () => EStoreQueries.DisplayExpensiveOrders()),
                })
            };

            bool isRunning = true;
            while (isRunning)
            {
                menus[0].Execute();

                Console.WriteLine("\nTryck på valfri tangent för att återgå till huvudmenyn");
                var keyPress = Console.ReadKey(intercept: true);
                Console.WriteLine(keyPress.Key.ToString());

                if (keyPress.Key == ConsoleKey.Escape)
                {
                    isRunning = false;
                }
                else
                {
                    Console.Clear();
                }
            }

            Console.WriteLine("Programmet avslutas.");
        }
    }
}