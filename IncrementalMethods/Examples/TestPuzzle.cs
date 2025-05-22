using IncrementalMethods;

namespace Examples
{
    public class KCycleNPiecePuzzle : Puzzle
    {
        public KCycleNPiecePuzzle(int k, int n)
        {
            int numCases = n - k + 1;
            if (numCases < 1)
            {
                Console.WriteLine("cycle length cannot be greater than number of pieces.  returning empty puzzle");
            }
            else
            {
                int[] baseCycle = new int[k];
                for (int i = 0; i < k; i++)
                {
                    if (i == 0)
                    {
                        baseCycle[i] = k - 1;
                    }
                    else
                    {
                        baseCycle[i] = i - 1;
                    }
                }
                for (int j = 0; j < numCases; j++)
                {
                    int[] newPerm = PermUtils.GetIdPerm(n);
                    for (int i = 0; i < k; i++)
                    {
                        newPerm[j + i] = j + baseCycle[i];
                    }
                    permList.Add(newPerm);
                    labelList.Add(j.ToString());
                }
            }
        }
    }
    public abstract class Puzzle
    {
        public List<int[]> permList = new();
        public List<string> labelList = new();
    }
}