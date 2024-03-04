using System.Collections.Generic;
using System.Linq;

namespace InterviewProblems.Trilogy._2022.Treasure;

public class Gem
{
    public int Time { get; set; }
    public int BadLuck { get; set; }
}

public static class Solution
{
    public static (int, int) BadLuck(List<Gem> gems)
    {
        var badLuckAvoided = 0;
        var badLuckConsumed = 0;
        
        gems.Sort(Comparer<Gem>.Create((a, b) => a.BadLuck != b.BadLuck ? a.BadLuck.CompareTo(b.BadLuck) : a.Time.CompareTo(b.Time)));
        
        var consumptionCounter = 0;
        while (gems.Count != 0)
        {
            if (consumptionCounter > 0)
            {
                var lastGem = gems.Last();
                badLuckAvoided += lastGem.BadLuck;
                gems.Remove(lastGem);
                consumptionCounter--;
                continue;
            }

            var firstNonInstantGem = gems.FirstOrDefault(x => x.Time > 0);
            if (firstNonInstantGem != null)
            {
                gems.Remove(firstNonInstantGem);
                consumptionCounter = firstNonInstantGem.Time;
                badLuckConsumed += firstNonInstantGem.BadLuck;
            }
            else
            {
                badLuckConsumed += gems.Sum(gem => gem.BadLuck);
                break;
            }
        }
        
        return (badLuckAvoided, badLuckConsumed);
    }
}
