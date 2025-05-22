using System.Collections;
using IncrementalMethods;

namespace Trigger
{
    public class TriggerSet
    {
        public Dictionary<int[], string> interior;
        public Dictionary<int[], string> boundary;
        PermEqualityComparer comparer = new();
        public TriggerSet(List<int[]> permList, List<string> labelList)
        {
            int N = permList[0].Length;
            int[] Id = PermUtils.GetIdPerm(N);
            interior = new Dictionary<int[], string>(comparer)
            {
                {Id,""}
            };
            boundary = new Dictionary<int[], string>(comparer);
            for (int i = 0; i < permList.Count; i++)
            {
                if (!Enumerable.SequenceEqual(permList[i], Id))
                {
                    boundary[permList[i]] = labelList[i];
                }
            }
        }

        public void Expand(List<int[]> moveSet, List<string> labelSet)
        {
            Dictionary<int[], string> newBoundary = new Dictionary<int[],string>(comparer);
            // For each trigger in the boundary, we will apply each of the moves in moveSet to get a testPerm...
            foreach (var entry in boundary)
            {
                for (int i = 0; i < moveSet.Count; i++)
                {
                    int[] testPerm = PermUtils.ApplyPerm(entry.Key, moveSet[i]);
                    // If this testPerm is NOT already included in the old TriggerSet, add it to the new boundary.  Otherwise we skip it
                    if (!interior.ContainsKey(testPerm) && !boundary.ContainsKey(testPerm))
                    {
                        newBoundary[testPerm] = entry.Value + labelSet[i];
                    }
                }
                // Once we're done, go ahead and add this to the interior
                if (interior.ContainsKey(entry.Key))
                {
                    PermUtils.PrintIntArray(entry.Key);
                    Console.WriteLine(entry.Value);
                    Console.WriteLine(interior[entry.Key]);
                }
                interior.Add(entry.Key, entry.Value);
            }
            // All of entries in boundary are now in the interior, so it is safe to replace the old boundary with the new entries
            boundary = newBoundary;
        }

        public void Print()
        {
            Console.WriteLine("Interior: ");
            foreach (var entry in interior)
            {
                Console.Write("{0} : ", entry.Value);
                PermUtils.PrintIntArray(entry.Key);
            }
            Console.WriteLine("Boundary : ");
            foreach (var entry in boundary)
            {
                Console.Write("{0} : ", entry.Value);
                PermUtils.PrintIntArray(entry.Key);
            }
        }
    }
}