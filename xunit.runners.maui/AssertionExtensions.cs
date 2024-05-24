using Xunit.Sdk;

namespace Xunit.Runners.Maui
{
    public static partial class AssertionExtensions
    {
        static readonly Random rnd = new Random();

        public static async Task<bool> Wait(Func<bool> exitCondition, int timeout = 1000)
        {
            while ((timeout -= 100) > 0)
            {
                if (!exitCondition.Invoke())
                    await Task.Delay(rnd.Next(100, 200));
                else
                    break;
            }

            return exitCondition.Invoke();
        }

        public static void AssertHasFlag(this Enum self, Enum flag)
        {
            var hasFlag = self.HasFlag(flag);

            if (!hasFlag)
                throw ContainsException.ForCollectionItemNotFound($"flag {flag}", $"Enum {self.GetType().Name}");
        }
    }
}