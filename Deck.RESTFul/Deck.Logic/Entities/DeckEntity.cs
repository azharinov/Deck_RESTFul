using Deck.Logic.Interfaces.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Deck.Logic.Entities
{
    /// <summary>
    /// Бизнес-сущность колоды карт.
    /// </summary>
    public class DeckEntity : IDeck
    {
        private IList<ICard> _cards;

        private DeckEntity() { }

        public DeckEntity(string name, IEnumerable<ICard> cards)
        {
            Name = name;
            _cards = cards.ToList();
        }

        /// <summary>
        /// Имя колоды.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Возвращает набор карт только для чтения.
        /// </summary>
        public IReadOnlyList<ICard> Cards()
        {
            return new ReadOnlyCollection<ICard>(_cards);
        }

        /// <summary>
        /// Устанавливает новый набор карт.
        /// </summary>
        /// <param name="cards">Новый набор карт.</param>
        public void SetCards(IList<ICard> cards)
        {
            _cards = cards;
        }

        /// <summary>
        /// Заглушка для генерации случайной колоды с заданным именем.
        /// </summary>
        /// <param name="name">Имя колоды.</param>
        public static DeckEntity GenerateDeck(string name, int size)
        {
            var cards = new List<ICard>(size);

            for (int i = 0; i < size; i++)
            {
                cards.Add(CommonCard.GenerateCard());
            };

            return new DeckEntity(name, cards);
        }
    }
}
