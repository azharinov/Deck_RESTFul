using Deck.Logic.Interfaces.Entities;
using Deck.Logic.Interfaces.Services;

namespace Deck.Logic.Services
{
    /// <summary>
    /// Доступные сервисы приложения.
    /// </summary>
    public class Services
    {
        /// <summary>
        /// Сервис тасования карт.
        /// </summary>
        public IShuffleService ShuffleService { get; private set; }

        /// <summary>
        /// Сервис управления колодами карт.
        /// </summary>
        public IDeckService<IDeck> DeckService { get; private set; }

        public Services(IShuffleService shuffleService, IDeckService<IDeck> deckService)
        {
            ShuffleService = shuffleService;
            DeckService = deckService;
        }
    }
}
