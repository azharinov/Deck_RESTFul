using Deck.Logic.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deck.Logic.Entities
{
    /// <summary>
    /// Алгоритм быстрой перетасовки.
    /// Показывает лучше результат по времени чем оптимальный, но тратит больше памяти.
    /// </summary>
    /// <remarks>В итоге оказалось что этот алгоритм все же медленнее, но убирать уже не стал.</remarks>
    public class FastShuffler : IShuffler<ICard>
    {
        /// <summary>
        /// Тасует коллекцию.
        /// </summary>
        public async Task<IList<ICard>> Shuffle(IList<ICard> items)
        {
            return await Task.Run(() =>
            {
                var rnd = new Random();
                var newItems = new LinkedList<ICard>();

                int rndIndex = 0;
                int count = items.Count;

                for (int index = 0; index < count; index++)
                {
                    rndIndex = rnd.Next(items.Count);
                    newItems.AddLast(items[rndIndex]);
                    items.RemoveAt(rndIndex);
                }

                return newItems.ToList();
            });
        }
    }
}
