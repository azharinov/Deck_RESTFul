using Deck.Logic.Interfaces.Entities;
using System.Threading.Tasks;

namespace Deck.Logic.Interfaces.Services
{
    /// <summary>
    /// Контракт сервиса для тасования колод.
    /// </summary>
    public interface IShuffleService
    {
        /// <summary>
        /// Тасуем колоду.
        /// </summary>
        /// <param name="deck">Колода.</param>
        Task<IDeck> Shuffle(IDeck deck);
    }
}
