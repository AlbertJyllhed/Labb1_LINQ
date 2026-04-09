namespace Labb1_LINQ
{
    internal class Program
    {
        static bool _isRunning = true;

        static void Main(string[] args)
        {
            var menus = new List<Menu>
            {
                new("Huvudmeny",
                [
                    new("Visa produkter i elektronikkategorin", EStoreQueries.DisplayElectronicsByPrice),
                    new("Visa leverantörer med lågt lagersaldo", EStoreQueries.DisplaySuppliersWithLowStock),
                    new("Visa totalt ordervärde för senaste månaden", EStoreQueries.DisplayTotalOrderValueThisMonth),
                    new("Visa de mest sålda produkterna", EStoreQueries.DisplayMostSoldProducts),
                    new("Visa produktmängd för varje kategori", EStoreQueries.DisplayProductAmountsForEachCategory),
                    new("Visa de dyraste ordrarna", EStoreQueries.DisplayExpensiveOrders),
                    new("Avsluta programmet", () => _isRunning = false),
                ])
            };

            while (_isRunning)
            {
                menus[0].Execute();

                if (_isRunning)
                {
                    Console.Write("Tryck på valfri tangent för att återgå till huvudmenyn");
                    var keyPress = Console.ReadKey();
                }
            }

            Console.WriteLine("Programmet avslutas.");
        }
    }
}