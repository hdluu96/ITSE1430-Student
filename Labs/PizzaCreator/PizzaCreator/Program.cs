/*
 * ITSE 1430
 * Sample implementation
 */

using System;

namespace Section1
{
    class Program
    {
        static void Main( string[] args )
        {
            bool notQuit;
            do
            {
                notQuit = DisplayMenu();
            }
            while (notQuit);
        }

        private static bool DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("1) New Order");
                Console.WriteLine("2) Modify Order");
                Console.WriteLine("3) Display Order");
                Console.WriteLine("4) Quit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                    NewOrder();
                    break;

                    case "2":
                    ModifyOrder();
                    break;

                    case "3":
                    DisplayOrder();
                    break;

                    case "4":
                    break;

                    default:
                    Console.WriteLine("Please enter a valid value.\n");
                    break;
                };
                Console.WriteLine("\n-------------------\n");
            };

        }

        private static void NewOrder()
        {
            size = Size("What size did you want? 1)Small ($5.00), 2)Medium ($6.25), 3)Large ($8.75)", true);
            meats = Meats("What meats did you want? 1)Bacon ($0.75), 2)Ham ($0.75), 3)Pepperoni ($0.75), 4)Sausage ($0.75)", true);
            vegetables = Vegetables("What vegetables did you want? 1)Black Olives ($0.50), 2)Mushrooms ($0.50), 3)Onions ($0.50), 4)Peppers ($0.50)", true);
            sauce = Sauce("What sauce did you want? 1)Traditional ($0.00), 2)Garlic ($1.00), 3)Oregano ($1.00)", true);
            cheese = Cheese("What cheese did you want? 1)Regular ($0.00), 2)Extra ($1.25)", true);
            delivery = Delivery("Did you want it delivered or take out? 1)Take Out ($0.00), 2)Delivered ($2.50)", true);

            DisplayOrder();
        }

        private static void ModifyOrder()
        {
            DisplayOrder();

            var newSize = Size("Enter a size (or press ENTER for default): ", false);
            if (!String.IsNullOrEmpty(newSize))
                size = newSize;

            var newMeats = Meats("Enter type of meats (or press ENTER for default): ", false);
            if (!String.IsNullOrEmpty(newMeats))
                size = newMeats;

            var newVegetables = Vegetables("Enter type of vegetables (or press ENTER for default): ", false);
            if (!String.IsNullOrEmpty(newVegetables))
                size = newVegetables;

            var newSauce = Sauce("Enter a sauce (or press ENTER for default): ", false);
            if (!String.IsNullOrEmpty(newSauce))
                size = newSauce;

            var newCheese = Cheese("Enter type of cheese (or press ENTER for default): ", false);
            if (!String.IsNullOrEmpty(newCheese))
                size = newCheese;

            var newDelivery = Delivery("Enter a delivery option (or press ENTER for default): ", false);
            if (!String.IsNullOrEmpty(newDelivery))
                size = newDelivery;
        }

        private static void DisplayOrder()
        {
            if (String.IsNullOrEmpty(size))
            {
                Console.WriteLine("No order placed");
                return;
            }

            Console.WriteLine(size);

            if (!String.IsNullOrEmpty(meats))
                Console.WriteLine(meats);

            if (!String.IsNullOrEmpty(vegetables))
                Console.WriteLine(vegetables);

            if (!String.IsNullOrEmpty(sauce))
                Console.WriteLine(sauce);

            if (!String.IsNullOrEmpty(cheese))
                Console.WriteLine(cheese);

            if (!String.IsNullOrEmpty(delivery))
                Console.WriteLine(delivery);
        }

        private static string Size( string message, bool required )
        {
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input) || !required)
                    return input;

                Console.WriteLine("You must enter a value.");
            };
        }

        private static string Meats( string message, bool required )
        {
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input) || !required)
                    return input;

                Console.WriteLine("You must enter a value.");
            };
        }

        private static string Vegetables( string message, bool required )
        {
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input) || !required)
                    return input;

                Console.WriteLine("You must enter a value.");
            };
        }

        private static string Sauce( string message, bool required )
        {
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input) || !required)
                    return input;

                Console.WriteLine("You must enter a value.");
            };
        }

        private static string Cheese( string message, bool required )
        {
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input) || !required)
                    return input;

                Console.WriteLine("You must enter a value.");
            };
        }

        private static string Delivery( string message, bool required )
        {
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input) || !required)
                    return input;

                Console.WriteLine("You must enter a value.");
            };
        }

        static string size;
        static string meats;
        static string vegetables;
        static string sauce;
        static string cheese;
        static string delivery;
    }

}

