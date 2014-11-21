namespace _02_OperationsPerformanceTests
{
    using System;

    class ComparingPerformanceTesting
    {
        public static void Main()
        {
            string[] types = { "int", "long", "float", "double", "decimal" };
            string[] actions = { "add", "subtract", "increment", "multiply", "divide" };

            foreach (var actionStr in actions)
            {
                foreach (var typeStr in types)
                {
                    ComparingPerformance.PrintMathComparingResult(typeStr, actionStr);
                }

                AwaitingToSeeResults();
            }

            string[] mathsFunctions = { "square root", "natural logarithm", "sinus" };
            var typesEndIndex = types.Length;
            var typesStartIndex = 2;

            foreach (var functionStr in mathsFunctions)
            {
                for (int i = typesStartIndex; i < typesEndIndex; i++)
                {
                    ComparingPerformance.PrintMathComparingResult(types[i], functionStr);
                }

                AwaitingToSeeResults();
            }

            string[] sortTypes = { "insertion sort", "selection sort", "quicksort" };
            string[] allTypesForSort = { "string", "int", "double" };

            foreach (var sortType in sortTypes)
            {
                foreach (var arrayType in allTypesForSort)
                {
                    ComparingPerformance.PrintSortComparingResults(arrayType, sortType);
                }

                AwaitingToSeeResults();
            }

            Console.WriteLine("That was all from me! Good bye!");
        }

        private static void AwaitingToSeeResults()
        {
            Console.WriteLine("Press [Enter] to print next command results...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
