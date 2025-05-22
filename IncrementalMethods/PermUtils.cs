using System.Diagnostics.CodeAnalysis;

namespace IncrementalMethods
{
    public static class PermUtils
    {
        // Apply permutation perm to the given state (the given state can, itself, be a permutation to do permutation composition)
        public static int[] ApplyPerm(int[] state, int[] perm)
        {
            int[] result = new int[state.Length];
            for (int i = 0; i < state.Length; i++)
            {
                result[i] = state[perm[i]];
            }
            return result;
        }
        // Gets the Id permutation for a given length N
        public static int[] GetIdPerm(int N)
        {
            int[] result = new int[N];
            for (int i = 0; i < N; i++)
            {
                result[i] = i;
            }
            return result;
        }

        public static void PrintIntArray(int[] intArray)
        {
            Console.Write("(");
            for (int i = 0; i < intArray.Length; i++)
            {
                if (i < intArray.Length - 1)
                {
                    Console.Write("{0},", intArray[i]);
                }
                else
                {
                    Console.WriteLine("{0})", intArray[i]);
                }
            }
        }
    }

    public class PermEqualityComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[]? x, int[]? y)
        {
            if (x is null || y is null)
            {
                return x == y;
            }
            return Enumerable.SequenceEqual(x, y);
        }

        public int GetHashCode([DisallowNull] int[] obj)
        {
            int result = obj[0];
            int powerOf2 = 1;
            for (int i = 0; i < obj.Length; i++)
            {
                powerOf2 *= 2;
                result += obj[i] * powerOf2;
            }
            return result;
        }
    }
}