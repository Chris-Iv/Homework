namespace _02_OperationsPerformanceTests
{
    using System;
    using System.Diagnostics;

    public class ComparingPerformance
    {
        private const int TestValue = 1000000; 

        public static void PrintMathComparingResult(string type, string action)
        {
            dynamic holdingValue = 0;
            dynamic testingValue = 0;
            dynamic valueThatAllTypesHas = 1;
            
            ParseType(type, valueThatAllTypesHas, ref holdingValue, ref testingValue);
            
            var stopWach = new Stopwatch();

            CalculateTimeForAction(action, stopWach, holdingValue, testingValue);
            
            PrintrResults(type, action, stopWach);
        }

        public static void PrintSortComparingResults(string arrayType, string sortType)
        {
            IComparable[] values = { };

            MakeArrayFromType(arrayType, ref values);

            var stopWach = new Stopwatch();

            CalculateTimeForSorting(sortType, stopWach, values);

            PrintrResults(arrayType, sortType, stopWach);
        }
       
        private static void ParseType(string type, dynamic valueThatAllTypesHas, ref dynamic holdingValue, ref dynamic testingValue)
        {
            switch (type.ToLower().Trim())
            {
                case "int":
                    {
                        holdingValue = (int)valueThatAllTypesHas;
                        testingValue = (int)valueThatAllTypesHas;
                    }
                    break;

                case "long":
                    {
                        holdingValue = (long)valueThatAllTypesHas;
                        testingValue = (long)valueThatAllTypesHas;
                    }
                    break;

                case "double":
                    {
                        holdingValue = (double)valueThatAllTypesHas;
                        testingValue = (double)valueThatAllTypesHas;
                    }
                    break;

                case "float":
                    {
                        holdingValue = (float)valueThatAllTypesHas;
                        testingValue = (float)valueThatAllTypesHas;
                    }
                    break;

                case "decimal":
                    {
                        holdingValue = (decimal)valueThatAllTypesHas;
                        testingValue = (decimal)valueThatAllTypesHas;
                    }
                    break;

                default:
                {
                    throw new ArgumentException(string.Format("Can not resolve this kind of type {0}!", type));
                }
            }
        }

        private static void CalculateTimeForAction(string action, Stopwatch stopWach, dynamic holdingValue, dynamic testingValue)
        {
            switch (action.ToLower().Trim())
            {
                case "add":
                {
                    stopWach.Start();

                    for (int i = 0; i < TestValue; i++)
                    {
                        holdingValue = testingValue + testingValue;
                    }

                    stopWach.Stop();
                }
                    break;

                case "subtract":
                {
                    stopWach.Start();

                    for (int i = 0; i < TestValue; i++)
                    {
                        holdingValue = testingValue - testingValue;
                    }

                    stopWach.Stop();
                }
                    break;

                case "increment":
                {
                    stopWach.Start();

                    for (int i = 0; i < TestValue; i++)
                    {
                        holdingValue++;
                    }

                    stopWach.Stop();
                }
                    break;

                case "multiply":
                {
                    stopWach.Start();

                    for (int i = 0; i < TestValue; i++)
                    {
                        holdingValue = testingValue * testingValue;
                    }

                    stopWach.Stop();
                }
                    break;

                case "divide":
                {
                    stopWach.Start();
                    for (int i = 0; i < TestValue; i++)
                    {

                        holdingValue = testingValue / testingValue;
                    }

                    stopWach.Stop();
                }
                    break;

                case "square root":
                {
                    stopWach.Start();
                    for (int i = 0; i < TestValue; i++)
                    {
                        holdingValue = Math.Sqrt((double)testingValue);
                    }

                    stopWach.Stop();
                }
                break;

                case "natural logarithm":
                {
                    stopWach.Start();
                    for (int i = 0; i < TestValue; i++)
                    {
                        holdingValue = Math.Log((double)testingValue);
                    }

                    stopWach.Stop();
                }
                break;

                case "sinus":
                {
                    stopWach.Start();
                    for (int i = 0; i < TestValue; i++)
                    {
                        holdingValue = Math.Sin((double)testingValue);
                    }

                    stopWach.Stop();
                }
                break;

                default:
                {
                    throw new ArgumentException(string.Format("Can not resolve this kind of action {0}!", action));
                }
            }
        }

        private static void PrintrResults(string type, string action, Stopwatch stopWach)
        {
            Console.WriteLine(
                string.Format(
                    "Results from {0} for {1} times, values type {2}, elapsed {3}ms.",
                    action,
                    TestValue,
                    type,
                    stopWach.ElapsedMilliseconds));
        }

        private static void MakeArrayFromType(string arrayType, ref IComparable[] values)
        {
            switch (arrayType)
            {
                case "int":
                {
                    values = new IComparable[] { 2, 1, 3, 5, 4 };
                }

                break;

                case "double":
                {
                    values = new IComparable[] { 2.0, 1.0, 3.0, 5.0, 4.0 };
                }

                break;

                case "string":
                {
                    values = new IComparable[] { "2", "1", "3", "5", "4" };
                }

                break;

                default:
                {
                    throw new ArgumentException(string.Format("Can not make array of type {0}!", arrayType));
                }
            }
        }

        private static void CalculateTimeForSorting(string sortType, Stopwatch stopWach, IComparable[] values)
        {
            switch (sortType.ToLower().Trim().Trim())
            {
                case "insertion sort":
                    {
                        stopWach.Start();
                        for (int i = 0; i < TestValue; i++)
                        {
                            InsertionSort(values);
                        }

                        stopWach.Stop();
                    }
                    break;

                case "selection sort":
                    {
                        stopWach.Start();
                        for (int i = 0; i < TestValue; i++)
                        {
                            SelectionSort(values);
                        }

                        stopWach.Stop();
                    }
                    break;

                case "quicksort":
                    {
                        stopWach.Start();
                        for (int i = 0; i < TestValue; i++)
                        {
                            Quicksort(values, 0, (values.Length - 1));
                        }

                        stopWach.Stop();
                    }
                    break;

                default:
                    {
                        throw new ArgumentException(string.Format("Can not implement sort type {0}!", sortType));
                    }
            }
        }

        static void InsertionSort(IComparable[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                var value = values[i];
                int index = i;

                while (index > 0 && (values[index - 1]).CompareTo(value) >= 0) // CompareTo is used becouse a string has no operators >, = and <
                {
                    values[index] = values[index - 1];
                    index--;
                }
                values[index] = value;
            }
        }

        static void SelectionSort(IComparable[] values)
        {
            for (int i = 0; i < values.Length - 1; i++)
            {
                for (int j = i + 1; j < values.Length; j++)
                {
                    if (values[i].CompareTo(values[j]) > 0) // swap items
                    {
                        var tmp = values[i];
                        values[i] = values[j];
                        values[j] = tmp;
                    }
                }
            }
        }

        public static void Quicksort(IComparable[] values, int left, int right)
        {
            int i = left, j = right;
            IComparable pivot = values[(left + right) / 2];

            while (i <= j)
            {
                while (values[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (values[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    IComparable tmp = values[i];
                    values[i] = values[j];
                    values[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(values, left, j);
            }

            if (i < right)
            {
                Quicksort(values, i, right);
            }
        }
    }
}
