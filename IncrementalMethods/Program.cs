using Trigger;
using Examples;

namespace IncrementalMethods
{
    class Program
    {
        public static void Main(string[] args)
        {
            Puzzle puzzle = new KCycleNPiecePuzzle(3, 5);
            TriggerSet test = new TriggerSet(puzzle.permList, puzzle.labelList);
            while (test.boundary.Count() != 0)
            {
                test.Expand(puzzle.permList, puzzle.labelList);
            }
            test.Print();
        }
    }

    class TestMethods
    {
        public static bool TestPermMethod(Func<object, int[]> method, object input, int[] expectedOutput)
        {
            int[] methodOutput = method(input);
            Console.WriteLine("Provided Input: {0}", input);
            if (Enumerable.SequenceEqual(methodOutput, expectedOutput))
            {
                Console.WriteLine("PASS");
                return true;
            }
            else
            {
                Console.WriteLine("-------FAIL---------");
                Console.Write("Expected Output: ");
                PermUtils.PrintIntArray(expectedOutput);
                Console.Write("Method's Output: ");
                PermUtils.PrintIntArray(methodOutput);
                return false;
            }
        }
    }
}