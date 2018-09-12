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

            //PlayWithStrings();

        }

        private static void PlayWithStrings()
        {
            string hoursString = "10";
            //int hours = Int32.Parse(hoursString);
            //int hours;
            //bool result = Int32.TryParse(hoursString, out hours);
            //bool result = Int32.TryParse(hoursString, out int hours);

            //Examples of ToString()
            //hoursString = hours.ToString();
            //3.14.ToString();
            //456.ToString();
            //Console.ReadLine().ToString();

            string message = "Hello\tworld";
            string filePath = "C:\\Temp\\Test";

            //Verbatim strings
            filePath = @"C:\Temp\Test";

            //Concat
            string firstName = "Bob";
            string lastName = "Smith";
            string name = firstName + " " + lastName;

            //Strings are immutable - this produces a new string
            //name = "Hello " + name;
            Console.WriteLine("Hello " + name); //Method 1
            Console.WriteLine("Hello {0} {1}", firstName, lastName);//Method 2
            string str = String.Format("Hello {0} {1},", firstName, lastName); //Method 3
            Console.WriteLine(str);

            Console.WriteLine($"Hello {firstName} {lastName}"); //Method 4

            //Null vs. Empty
            string missing = null; //Nothing exist
            string empty = ""; //Empty value
            string empty2 = String.Empty; //Same as above, rare use case

            //Checking for empty strings
            //if (firstName.Length == 0)
            //if (firstName != null && firstName != "")
            if (!String.IsNullOrEmpty(firstName))
                Console.WriteLine(firstName);

            //Other stuff
            string upperName = firstName.ToUpper(); //Upper case the string
            string lowerName = firstName.ToLower(); //Lower case the string

            //Comparison
            bool areEqual = firstName == lastName;
            areEqual = firstName.ToLower() == lastName.ToLower();
            areEqual = String.Compare(firstName, lastName, true) == 0; //Compares two strings that ignores case sensitivity

            bool startsWithA = firstName.StartsWith("A");
            bool endsWithA = firstName.EndsWith("A");
            bool hasA = firstName.IndexOf("A") >= 0;
            string subset = firstName.Substring(4);

            //Clean up
            string cleanMe = firstName.Trim(); //TrimStart, TrimEnd
            string makeLonger = firstName.PadLeft(20); //PadRight

        }

        private static void PlayWithArrays()
        {
            int count = ReadInt32("How many names? ", 1);

            string[] names = new string[count];
            for (int index = 0; index < count; ++index)
            {
                Console.WriteLine("Name? ");
                names[index] = Console.ReadLine();
            };

            foreach (string name in names)
            //for(int index = 0; index < names.Length; ++index)
            {
                //Console.WriteLine(names[index]);
                Console.WriteLine(name);
            }
        }

        private static void PlayWithObjects()
        {
            int hours = 10;
            Int32 hoursFull = 10;
            var areEqual = hours = hoursFull;

            var obj1 = "Hello";
            DisplayObject(obj1);
        }

        private static void DisplayObject( object value )
        {
            //Approach 1
            if (value == null)
                return;

            if(value is string)
            {
                var str = (string)value;
                Console.WriteLine(str);
            } else
            {
                var str = value.ToString();
                Console.WriteLine(str);
            };

            //Approach 2
            var str2 = value as string;
            if (value != null)
                Console.WriteLine(str2);
            else
                Console.WriteLine(value.ToString());

            //Approach 3
            var str3 = value as string;
            Console.WriteLine((str3 != null) ? str3.ToString() : value.ToString());

            //Approach 4
            var str4 = value as string;
            Console.WriteLine((str4 ?? value).ToString());

            //Approach 5
            if (value is string str5)
                Console.WriteLine(str5.ToString());
            else
                Console.WriteLine(value.ToString());

            //Approach 6
            var str6 = value as string;
            Console.WriteLine(str6?.ToString());
        }

        private static bool DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("A)dd Movie");
                Console.WriteLine("E)dit Movie");
                Console.WriteLine("D)elet Movie");
                Console.WriteLine("V)iew Movie");
                Console.WriteLine("Q)uit");

                string input = Console.ReadLine();
                switch (input[0])
                {
                    case 'a':
                    case 'A':
                    AddMovie();
                    return true;

                    case 'e':
                    case 'E':
                    EditMovie();
                    return true;

                    case 'd':
                    case 'D':
                    DeleteMovie();
                    return true;

                    case 'v':
                    case 'V':
                    ViewMovie();
                    return true;

                    case 'q':
                    case 'Q':
                    return false;

                    default:
                    Console.WriteLine("Please enter a valid value.\n");
                    break;
                };
            };
        }

        private static void AddMovie()
        {
            name = ReadString("Enter a name: ", true);
            description = ReadString("Enter the description: ");
            runLength = ReadInt32("Enter the length (in minutes): ", 0);
        }

        private static void EditMovie()
        {
            ViewMovie();

            //"var" can be used as type inferencing instead of actual data type

            var newName = ReadString("Enter a name (or press ENTER for default): ", false);
            if (!String.IsNullOrEmpty(newName))
                name = newName;

            var newDescription = ReadString("Enter the description (or press ENTER for default): ");
            if (!String.IsNullOrEmpty(newDescription))
                description = newDescription;

            var newLength = ReadInt32("Enter the length (in minutes): \n", 0);
            if (newLength > 0)
                runLength = newLength;
        }

        private static void DeleteMovie()
        {
            if (Confirm("Are you sure you want to delete this movie?"))
            {
                name = null;
                description = null;
                runLength = 0;
            };
        }

        private static bool Confirm( string message )
        {
            Console.WriteLine($"{message} (Y/N)");

            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'Y':
                    case 'y':
                    return true;

                    case 'N':
                    case 'n':
                    return false;
                };
            } while (true);
        }

        private static void ViewMovie()
        {
            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("No movies available");
                return;
            }

            Console.WriteLine(name);

            if (!String.IsNullOrEmpty(description))
                Console.WriteLine(description);

            Console.WriteLine($"Run length = {runLength} mins");
        }

        private static int ReadInt32( string message, int minValue )
        {
            while (true)
            {
                Console.WriteLine(message);
                var input = Console.ReadLine();

                //int.TryParse();
                if (Int32.TryParse(input, out var result))
                {
                    if (result >= minValue)
                        return result;
                };
                Console.WriteLine($"You must enter an integer value >= {minValue}");
            };
        }

        private static string ReadString( string message )
        {
            return ReadString(message, false);
        }

        private static string ReadString( string message, bool required )
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

        //A movie
        static string name;
        static string description;
        static int runLength;
    }
}
