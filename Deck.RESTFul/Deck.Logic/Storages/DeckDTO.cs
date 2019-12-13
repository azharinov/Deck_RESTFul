using System;
using System.Collections.Generic;

namespace Deck.Logic.Storages
{
    /// <summary>
    /// ДТО для хранения сущности колоды.
    /// </summary>
    public class DeckDTO
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public IEnumerable<CardDTO> Cards { get; private set; }

        private DeckDTO() { }

        public DeckDTO(
            Guid id,
            string name,
            IEnumerable<CardDTO> cards)
        {
            Id = id;
            Name = name;
            Cards = cards;
        }
    }
}
