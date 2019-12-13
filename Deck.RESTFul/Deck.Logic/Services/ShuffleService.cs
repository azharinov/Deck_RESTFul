using Deck.Logic.Interfaces.Entities;
using Deck.Logic.Interfaces.Services;
using Deck.Logic.Settings;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deck.Logic.Services
{
    /// <summary>
    /// Сервис для тасования колод.
    /// </summary>
    public class ShuffleService : IShuffleService
    {
        /// <summary>
        /// Алгоритм тасования.
        /// </summary>
        private readonly IShuffler<ICard> _shuffler;

        /// <summary>
        /// Настройки для сервиса тасования.
        /// </summary>
        private readonly IOptionsMonitor<ShuffleSettings> _settings;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public ShuffleService(IShuffler<ICard> shuffler, IOptionsMonitor<ShuffleSettings> settings)
        {
            _shuffler = shuffler;
            _settings = settings;
        }

        /// <summary>
        /// Таусем колоду карт.
        /// </summary>
        /// <param name="deck">Колода карт.</param>
        public async Task<IDeck> Shuffle(IDeck deck)
        {
            IList<ICard> cards = deck.Cards().ToList();

            for (int count = 0; count < _settings.CurrentValue.ShuffleCount; count++)
            {
                cards = await _shuffler.Shuffle(cards);
            }

            deck.SetCards(cards);

            return deck;
        }
    }
}
