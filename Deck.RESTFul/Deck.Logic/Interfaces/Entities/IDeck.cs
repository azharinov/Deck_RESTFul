using System.Collections.Generic;

namespace Deck.Logic.Interfaces.Entities
{
    /// <summary>
    /// Контракт для колоды.
    /// </summary>
    public interface IDeck
    {
        /// <summary>
        /// Имя колоды
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Возвращает набор карт колоды только для чтения.
        /// </summary>
        IReadOnlyList<ICard> Cards();

        /// <summary>
        /// Устанавливает новый набор карт в колоде.
        /// </summary>
        /// <param name="cards">Набор карт.</param>
        void SetCards(IList<ICard> cards);
    }
}
