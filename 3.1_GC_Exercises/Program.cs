using System;

namespace _3._1_GC_Exercises
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] exercises = { 31, 32 };
            string exerciseString = " ";
            foreach (int exercise in exercises)
            {
                exerciseString += exercise + " / ";
            }
            exerciseString = exerciseString.Remove(exerciseString.Length - 2);

            bool tryAgain = true;
            while (tryAgain)
            {
                tryAgain = false;
                switch (GetInt($"Which exercise would you like to run ({exerciseString})? "))
                {
                    case 31:
                        ElementReturn();
                        tryAgain = Continue();
                        break;
                    case 32:
                        IndexReturn();
                        tryAgain = Continue();
                        break;
                    default:
                        Console.Write("That's not a valid input. Try again. ");
                        tryAgain = true;
                        break;
                }
            }
        }

        public static void ElementReturn()
        {
            int[] baseArray = { 2, 8, 0, 24, 51 };
            Console.WriteLine($"Your element is {baseArray[GetInt("Please enter an index: ", "That is not a valid index. ", 0, baseArray.Length)]}!");
        }

        public static void IndexReturn()
        {
            int[] baseArray = { 2, 8, 0, 24, 51 };
            int value = GetInt("Please enter a number: ");
            int index = Array.IndexOf(baseArray, value);
                if (index > -1)
                {
                Console.WriteLine($"The value {value} can be found at index {index}");
                return;
                }
            Console.WriteLine($"The value {value} cannot be found in the array");
        }

        //IO methods required for Main switch to function
        public static bool Continue()
        {
            return (GetYN("Would you like to continue? (y/n) ")=="y");
        }

        public static string GetYN(string message)
        {
            while (true)
            {
                string input = PromptUser(message).ToLower();
                if(input == "y" || input== "yes" || input == "n" || input == "no")
                {
                    return input.Substring(0,1);
                }
            }
        }
        public static string PromptUser(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public static int GetInt(string message)
        {
            return GetInt(message, "Not a valid input. ", int.MinValue, int.MaxValue);
        }

        public static int GetInt(string message, string errorMessage, int lowerBound, int upperBound)
        {
            int returnVal;
            while (!int.TryParse(PromptUser(message), out returnVal) || returnVal >= upperBound || returnVal < lowerBound)
            {
                Console.Write(errorMessage);
            }
                return returnVal;
        }
    }
}
