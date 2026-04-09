namespace Labb1_LINQ
{
    internal class Menu
    {
        // Menu class represents a menu item that can contain submenus
        public string Name { get; private set; }
        private Action? Action { get; set; }
        private List<Menu> SubMenus { get; set; }

        // Constructor for creating a menu with submenus
        public Menu(string name, List<Menu> menus)
        {
            Name = name;
            SubMenus = menus;
        }

        // Constructor for creating a menu with an action
        public Menu(string name, Action action)
        {
            Name = name;
            Action = action;
            SubMenus = [];
        }

        private bool IsLeafMenu() => SubMenus.Count == 0;

        public void Execute()
        {
            Console.Clear();

            if (IsLeafMenu())
            {
                Action?.Invoke();
                return;
            }

            DisplayMenu();
        }

        private void DisplayMenu()
        {
            Console.WriteLine($"--- {Name} ---");
            for (int i = 0; i < SubMenus.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {SubMenus[i].Name}");
            }

            HandleUserChoice();
        }

        private void HandleUserChoice()
        {
            Console.Write("\nVälj ett alternativ: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= SubMenus.Count)
            {
                SubMenus[choice - 1].Execute();
            }
            else
            {
                Console.Write("\nOgiltigt val, försök igen");
                Console.ReadKey();
                Execute();
            }
        }
    }
}
