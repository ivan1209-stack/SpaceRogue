using System.Collections.Generic;
using System.Linq;
using Scriptables;
using Random = System.Random;

namespace Utilities.Mathematics
{
    public static class RandomPicker
    {
        public static T PickOneElementByWeights<T>(IEnumerable<WeightConfig<T>> weights, Random r)
        {
            var orderedWeights = weights
                .OrderBy(x => x.Weight)
                .ToArray();
            int weightSum = orderedWeights.Sum(x => x.Weight);
            double[] chances = orderedWeights.Select(x => x.Weight / (double)weightSum).ToArray();
            double randomDouble = r.NextDouble();
            
            if (randomDouble < chances[0]) return orderedWeights[0].Config;
            for (int i = 1; i < chances.Length; i++)
            {
                double sum = chances[..(i-1)].Sum();
                if (randomDouble > sum && randomDouble <= sum + chances[i]) return orderedWeights[i].Config;
            }

            return orderedWeights[^1].Config;
        }
    }
}