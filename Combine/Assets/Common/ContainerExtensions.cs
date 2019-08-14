using System.Linq;
using System.Collections.Generic;

namespace Common
{
    public static class ContainerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool ScrambledEquals<T>(IReadOnlyList<T> self, IReadOnlyList<T> other)
        {
            if(self.Count != other.Count)
            {
                return false;
            }

            Dictionary<T, int> counts = new Dictionary<T, int>();
            foreach(T element in self)
            {
                if(!counts.ContainsKey(element))
                {
                    counts.Add(element, 1);
                }
                else
                {
                    counts[element]++;
                }
            }

            foreach(T element in other)
            {
                if(counts.TryGetValue(element, out int value))
                {
                    counts[element] = value - 1;
                }
                else
                {
                    // Element doesn't exist, so the lists can't be equal.
                    return false;
                }
            }

            return counts.Values.All(c => c == 0);
        }
    }
}
