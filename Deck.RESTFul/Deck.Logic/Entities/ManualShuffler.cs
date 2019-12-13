using Deck.Logic.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deck.Logic.Entities
{
    /// <summary>
    /// Алгоритм имитирующий ручную перетасовку.
    /// </summary>
    public class ManualShuffler : IShuffler<ICard>
    {
        /// <summary>
        /// Тасует коллекцию.
        /// </summary>
        public async Task<IList<ICard>> Shuffle(IList<ICard> items)
        {
            return await Task.Run(() =>
            {
                var rnd = new Random();
                var listItems = new LinkedList<ICard>(items);

                int rndIndex = rnd.Next(items.Count);

                for (int index = 0; index < rndIndex; index++)
                {
                    var item = listItems.First.Value;
                    listItems.RemoveFirst();
                    listItems.AddLast(item);
                }

                return listItems.ToList();
            });
        }
    }
}
