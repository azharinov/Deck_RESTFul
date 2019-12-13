using Deck.Logic.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deck.Logic.Entities
{
    /// <summary>
    /// Алгоритм перетасовки Фишера-Йетса.
    /// Наиболее оптимальный по соотношению время/память.
    /// </summary>
    public class OptimalShuffler : IShuffler<ICard>
    {
        /// <summary>
        /// Тасует коллекцию.
        /// </summary>
        public async Task<IList<ICard>> Shuffle(IList<ICard> items)
        {
            return await Task.Run(() =>
            {
                var rnd = new Random();

                for(int index = items.Count - 1; index > 0; --index)
                {
                    var newIndex = rnd.Next(index + 1);

                    var item = items[index];
                    items[index] = items[newIndex];
                    items[newIndex] = item;
                }

                return items;
            });
        }
    }
}
