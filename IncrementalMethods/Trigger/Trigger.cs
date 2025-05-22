using IncrementalMethods;

namespace Trigger
{
    public class Trigger
    {
        int[] perm;
        string algString;
        public Trigger(int[] perm, string algString)
        {
            this.perm = perm;
            this.algString = algString;
        }

        public void WriteTrigger()
        {
            Console.Write("{0} : ", algString);
            PermUtils.PrintIntArray(perm);
        }
    }
}