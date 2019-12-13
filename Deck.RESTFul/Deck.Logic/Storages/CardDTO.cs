using System;

namespace Deck.Logic.Storages
{
    /// <summary>
    /// ДТО для хранения сущности карты.
    /// </summary>
    public class CardDTO
    {
        public Guid Id { get; private set; }

        public string Rank { get; private set; }

        public string Suit { get; private set; }

        public Guid DeckId { get; private set; }

        private CardDTO() { }

        public CardDTO(
            Guid id,
            string rank,
            string suit,
            Guid deckId)
        {
            Id = id;
            Rank = rank;
            Suit = suit;
            DeckId = deckId;
        }
    }
}
