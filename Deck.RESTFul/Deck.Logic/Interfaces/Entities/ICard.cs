namespace Deck.Logic.Interfaces.Entities
{
    /// <summary>
    /// Контракт для карты.
    /// </summary>
    public interface ICard
    {
        /// <summary>
        /// Ранг карты.
        /// </summary>
        string Rank { get; }

        /// <summary>
        /// Масть карты.
        /// </summary>
        string Suit { get; }

        /// <summary>
        /// Возвращает строковое представление карты.
        /// </summary>
        string Present();
    }
}
