using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deck.Logic.Interfaces.Entities
{
    /// <summary>
    /// Алгоритм тасования коллекции.
    /// </summary>
    /// <typeparam name="T">Тип элементов коллекции.</typeparam>
    public interface IShuffler<T>
    {
        /// <summary>
        /// Тасует коллекцию.
        /// </summary>
        Task<IList<T>> Shuffle(IList<T> items);
    }
}
